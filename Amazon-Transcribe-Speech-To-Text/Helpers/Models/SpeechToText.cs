using Amazon_Transcribe_Speech_To_Text.Helpers.Interface;
using AWS_Rekognition_Objects.Helpers.Model;
using NAudio.Wave;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_Transcribe_Speech_To_Text.Helpers.Models.Entity
{
    public class SpeechToText
    {
        IController Controller;
        AWSServices awsServices;
        PlayerMedia playerMedia;
        Transcribed transcribed;
        public SpeechToText(Controller Controller, AWSServices awsServices) {
            this.Controller = Controller;
            this.awsServices = awsServices;
            this.playerMedia = new PlayerMedia(this.Controller);
            setNewFileFromExecuteTrasncribe();
        }
        public async void setNewFileFromExecuteTrasncribe() {
            //this.transcribed = new Transcribed();
            string jsonString = await awsServices.getObjectTranscribeS3();
            if (!String.IsNullOrEmpty(jsonString))
            {
                transcribed = JsonConvert.DeserializeObject<Transcribed>(jsonString);
                await playerMedia.newFileAudio();
                TimeSpan TotalTime = playerMedia.getTotalTimeAudio();
                ResultsTranscribed results = transcribed.results;
                setAverageConfidenceItem(results.items);
                Controller.displayParametersInitials(TotalTime, results.transcripts);
            }
        }
        public void setAverageConfidenceItem(List<Item> items) {
            foreach (Item itemElement in items)
            {
                float confidences = 0;
                foreach (Alternatives itemAlternative in itemElement.alternatives)
                {
                    confidences += itemAlternative.confidence;
                }
                itemElement.averageConfidence = (confidences / itemElement.alternatives.Count);
            }
        }

        public async void controlExecutePlayer()
        {
            if (!playerMedia.checkExecute())
            {
                playerMedia.clickPlay();
            }
            else
            {
                playerMedia.clickPaused();
            }

            await trackAudio();
        }
        public void defineNewCurrentTimeMilisseconds(double time)
        {
            TimeSpan newTime = TimeSpan.FromMilliseconds(time);
            playerMedia.trackAudioPlay(newTime);
        }

        public async Task trackAudio()
        {
            bool playMedia = true;
            PlaybackState statePlayback = playerMedia.getPlaybackState();

            while (playMedia)
            {
                if (statePlayback == PlaybackState.Playing)
                {
                    await Task.Delay(1000);
                    TimeSpan currentAudio = playerMedia.getCurrentTime();
                    Item item = getTextFromSpeach(currentAudio);
                    await Controller.displayParametersCurrents(currentAudio, item);                    
                }
                else if (statePlayback == PlaybackState.Paused)
                {
                    await Task.Delay(2000);
                }
            }

        }
        public Item getTextFromSpeach(TimeSpan timeCurrent) {
            List<Item> items = transcribed.results.items;
            Item itemSelect = items.Find(x => (x.start_time <= timeCurrent.TotalSeconds) && (x.end_time >= timeCurrent.TotalSeconds));
            return itemSelect;

        }
        public void regenerate()
        {
            List<Item> items = transcribed.results.items;
            string content = "";
            foreach (Item item in items)
            {               
                if (item.alternatives.Count > 0)
                {
                    Alternatives alternative;
                    alternative = item.alternatives.Find(x => x.changed.Equals(true));
                    if (alternative == null)
                    {
                        alternative = searchMaxConfidence(item);
                    }
                    content = $"{content} {alternative.content}";
                }
                else
                {
                    content = content + item.alternatives.ElementAt(0).content;
                }
            }
            Transcript transcript = new Transcript();
            transcript.transcript = content;
            transcribed.results.transcripts.Clear();
            transcribed.results.transcripts.Add(transcript);
        }
        public Alternatives searchMaxConfidence(Item item) {
            float confidences = 0;
            //int index = -1;
            Alternatives alternative = null;
            for (int a = 0; a < item.alternatives.Count; a++)
            {
                if (item.alternatives.ElementAt(a).confidence > confidences)
                {
                    alternative = item.alternatives.ElementAt(a);
                    confidences = alternative.confidence;
                }
            }
            if (alternative == null)
            {
                alternative = item.alternatives.ElementAt(0);
            }
            return alternative;
        }

        public Item addContentItem(double valueStart, double valueEnd, string content)
        {
            List<Item> items = transcribed.results.items;
            Item itemSelect = items.Find(x => (x.start_time == valueStart) && (x.end_time == valueEnd));
            if (!itemSelect.Equals(null))
            {
                // bool checkAlternative = itemSelect.alternatives.Any(x => x.content.Equals(content));
                Alternatives checkAlternative = itemSelect.alternatives.Find(x => x.changed.Equals(true));
                if (checkAlternative == null)
                {
                    Alternatives alternative = new Alternatives
                    {
                        confidence = 1,
                        content = content,
                        changed = true
                    };
                    itemSelect.alternatives.Insert(0, alternative);
                }
                else
                {
                    checkAlternative.content = content;
                }             

            }
            
            return itemSelect;
        }

        public Item removeContentItem(double valueStart, double valueEnd, int indexSelect)
        {
            List<Item> items = transcribed.results.items;
            Item itemSelect = items.Find(x => (x.start_time == valueStart) && (x.end_time == valueEnd));
            if ((indexSelect > 0) && (indexSelect < itemSelect.alternatives.Count))
            {
                itemSelect.alternatives.RemoveAt(indexSelect);
                return itemSelect;
            }
            else
            {
                return null;
            }
            
        }
    }
}
