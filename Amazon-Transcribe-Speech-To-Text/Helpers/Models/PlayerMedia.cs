using Amazon_Transcribe_Speech_To_Text.Helpers.Interface;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_Transcribe_Speech_To_Text.Helpers.Models
{
    public class PlayerMedia
    {
        private Mp3FileReader mp3Reader;
        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;
        private IController controller;
        private bool executeMedia = false;

        public PlayerMedia(IController controller) {
            this.controller = controller;
        }

        public bool checkExecute() {
            return executeMedia;
        }

        public void clickPaused() {
            outputDevice.Pause();
            executeMedia = (executeMedia == false) ? true : false;
        }

        public async Task clickPlay()
        {
            if (outputDevice == null)
            {
                outputDevice = new WaveOutEvent();
                outputDevice.PlaybackStopped += OnPlaybackStopped;
            }
            if (mp3Reader == null)
            {
                mp3Reader = new Mp3FileReader(@"D:\UserFiles\Musicas\Audios\rosalina_batista_entrevista.mp3");
                //audioFile = new AudioFileReader(@"D:\UserFiles\Musicas\Audios\rosalina_batista_entrevista.mp3");
                //outputDevice.Init(audioFile);
                outputDevice.Init(mp3Reader);
            }
            outputDevice.Play();
            executeMedia = (executeMedia == false) ? true : false;
            //await trackAudio();

        }

        private void OnPlaybackStopped(object sender, StoppedEventArgs args)
        {
            outputDevice.Dispose();
            outputDevice = null;
            audioFile.Dispose();
            audioFile = null;
        }
        public async Task trackAudioA() {
            while (outputDevice.PlaybackState == PlaybackState.Playing)
            {
                await Task.Delay(3000);
                long currentPosition = outputDevice.GetPosition();
                decimal position = ((decimal)currentPosition / (decimal)audioFile.Length)*100;
            }          
        
        }

        public void defineNewCurrentTimeMilisseconds(double time)
        {
            TimeSpan newTime = TimeSpan.FromMilliseconds(time);
            trackAudioPlay(newTime);
        }

        public void trackAudioPlay(TimeSpan time) {
            mp3Reader.CurrentTime = time;//TimeSpan.FromSeconds(5.0);
        }

        public PlaybackState getPlaybackState()
        {
            return outputDevice.PlaybackState;
        }

        public TimeSpan getCurrentTime()
        {
           return mp3Reader.CurrentTime;
        }
        public TimeSpan getTotalTimeAudio() {
            return mp3Reader.TotalTime;
        }
    }
}
