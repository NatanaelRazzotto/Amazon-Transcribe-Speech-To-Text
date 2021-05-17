using Amazon.TranscribeService;
using Amazon.TranscribeService.Model;
using Amazon_Transcribe_Speech_To_Text.Helpers.Interface;
using Amazon_Transcribe_Speech_To_Text.Helpers.Models.Entity;
using AWS_Rekognition_Objects.Helpers.Model;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Amazon_Transcribe_Speech_To_Text.Helpers.Models
{
    public class Controller : IController
    {
        private IViewTranscribe formTranscribe;
        private AWSServices awsServices;
        private PlayerMedia playerMedia;
        public Controller(IViewTranscribe formTranscribe)
        {
            this.formTranscribe = formTranscribe;
            this.awsServices = new AWSServices(this);
            this.playerMedia = new PlayerMedia(this);
        }
        public List<string> getLoadS3ListBuckets() {
           return awsServices.S3ListBuckets();        
        }

        public async void setFileFromBucket(string fileName)
        {
            bool insertInBucket= true;
            if (awsServices.checkFileOnBucket(Path.GetFileName(fileName)))
            {
                string messageAlert = $"Arquivo ja consta no bucket: {awsServices.getNameBucketInput()}, deseja substituilo ?";
                if (MessageBox.Show(messageAlert, "Atenção", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    insertInBucket = false;
                }
            }
            if (insertInBucket)
            {
                await formTranscribe.displayStatusProgressFile(true);
                bool checkTerminateUpload = await awsServices.UploadAudioFromS3(fileName);
                if (checkTerminateUpload)
                {
                    await formTranscribe.displayStatusProgressFile(false, fileName);
                }
            }
        }
        public bool setFromNameBuckets(string bucketInput, string bucketOutput)
        {
            awsServices.setBucktes(bucketInput, bucketOutput);
            return updateComboFileOnBucket(bucketInput);

        }
        public bool updateComboFileOnBucket(string bucket)
        {
            //string bucket = awsServices.getBucketInput();
            List<string> nameAudios = awsServices.audioInputBucketNames();
            if (nameAudios.Count != 0)
            {
                bool validation = formTranscribe.updateComboNameAudios(bucket, nameAudios);
                return validation;
            }
            else
            {
                return false;
            }
        }

        public void setFileFromAnalize(string file)
        {
            awsServices.FileNameActual = file;
            formTranscribe.releaseTranscript(file);
        }

        public async void executeTranscribeToS3()
        {
           await awsServices.requestExecuteTranscribe(awsServices.FileNameActual, awsServices.BucketNameOutput);
        }

        public void ViewStatusofTranscriptJob(TranscriptionJob transcriptionJob, int incrementProgrees)
        {
            string nameJob = transcriptionJob.TranscriptionJobName;
            TranscriptionJobStatus status = transcriptionJob.TranscriptionJobStatus;
            string formatMidia = transcriptionJob.MediaFormat;
            formTranscribe.setJobProperties(nameJob, status, formatMidia, incrementProgrees);
        }

        public async void TranscribeObject()
        {
            string jsonString = await awsServices.getObjectTranscribeS3();
            Transcribed transcribed = Newtonsoft.Json.JsonConvert.DeserializeObject<Transcribed>(jsonString);
        }

        #region controlesAudio
        public async void setPlayMedia()
        {
            if (!playerMedia.checkExecute())
            {
                await playerMedia.clickPlay();
            }
            else
            {
                playerMedia.clickPaused();
            }
            
            await trackAudio();
        }
        public void definedPositionAudioMilisseconds(double timeSelect)
        {
            //double newTimeSelect = Convert.ToDouble(timeSelect);
            playerMedia.defineNewCurrentTimeMilisseconds(timeSelect);
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
                    TimeSpan TotalTime = playerMedia.getTotalTimeAudio();                    
                    //int currentMilliseconds = (int)currentAudio.TotalMilliseconds;
                    
                    formTranscribe.displayStatusCurrentProgress(TotalTime, currentAudio);
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
        #endregion
    }
}
