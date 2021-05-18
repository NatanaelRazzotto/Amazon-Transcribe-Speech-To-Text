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
        private SpeechToText speechToText;
        ///private Transcribed transcribed;
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

        public void displayParametersInitials(TimeSpan totalTime, List<Entity.Transcript> contentText)
        {
            formTranscribe.displayTotalTime(totalTime);
            formTranscribe.bindTextContent(contentText);//
        }

        public async Task displayParametersCurrents(TimeSpan currentAudio, Item item) {
            formTranscribe.displayStatusCurrentProgress(currentAudio);
            formTranscribe.displayTrancribe(item);
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
            formTranscribe.setJobProperties(transcriptionJob, incrementProgrees);
        }

        public void TranscribeObject()
        {
            speechToText = new SpeechToText(this, awsServices);

        }

        #region controlesAudio
        public async void setPlayMedia()
        {
            //speechToText = new SpeechToText(this, awsServices);//
            speechToText.controlExecutePlayer();
        }
        public void definedPositionAudioMilisseconds(double timeSelect)
        {
            //double newTimeSelect = Convert.ToDouble(timeSelect);
            speechToText.defineNewCurrentTimeMilisseconds(timeSelect);
        }

        internal void setModifyContent(double valueStart, double valueEnd, string content)
        {
            Item itemNew = speechToText.addContentItem(valueStart, valueEnd, content);
            if (itemNew != null)
            {
                if (itemNew.alternatives.Count != 0)
                {
                    formTranscribe.displayTrancribe(itemNew);
                }
            }
        }

        public void setRemoveContentSelect(double valueStart, double valueEnd, int indexSelect)
        {
            Item item = speechToText.removeContentItem(valueStart, valueEnd, indexSelect);
            if (item != null)
            {
                if (item.alternatives.Count != 0)
                {
                    formTranscribe.displayTrancribe(item);
                }
            }

        }

        public void genarateNewContent() {
            speechToText.regenerate();
            //formTranscribe.bindTextContent(contentText);//
        }


        #endregion
    }
}
