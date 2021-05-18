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
                this.transcribed = JsonConvert.DeserializeObject<Transcribed>(jsonString);
                await playerMedia.newFileAudio();
                TimeSpan TotalTime = playerMedia.getTotalTimeAudio();
                List<Transcript> contentText = transcribed.results.transcripts;
                Controller.displayParametersInitials(TotalTime, contentText);
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
                else if (statePlayback == PlaybackState.Stopped)
                {

                }
            }

        }
        public Item getTextFromSpeach(TimeSpan timeCurrent) {
            List<Item> items = transcribed.results.items;
            Item itemSelect = items.Find(x => (x.start_time <= timeCurrent.TotalSeconds) && (x.end_time >= timeCurrent.TotalSeconds));

            return itemSelect;

            //foreach (Item item in items)
            //{
            //    double star_Time = item.start_time;
            //    double end_Time = item.end_time;
            //    double time_Current = timeCurrent.TotalSeconds;//timeCurrent.TotalMinutes;
            //    if ((time_Current >= star_Time) && (time_Current <= end_Time))
            //    {
            //        int a = 10;
            //    }
            //}

            //var lis = items.Select(x =>x.start_time >= timeCurrent.TotalMinutes)
        }





    }
}
