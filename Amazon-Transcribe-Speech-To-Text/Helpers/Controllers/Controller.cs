﻿using Amazon_Transcribe_Speech_To_Text.Helpers.Interface;
using AWS_Rekognition_Objects.Helpers.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Amazon_Transcribe_Speech_To_Text.Helpers.Models
{
    public class Controller
    {
        private IViewTranscribe formTranscribe;
        private AWSServices awsServices;
        public Controller(IViewTranscribe formTranscribe)
        {
            this.formTranscribe = formTranscribe;
            this.awsServices = new AWSServices();
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
           await awsServices.ExecuteTranscribe(awsServices.FileNameActual, awsServices.BucketNameOutput);
        }
    }
}