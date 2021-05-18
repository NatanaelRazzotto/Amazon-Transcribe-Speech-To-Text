using Amazon;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Amazon.TranscribeService;
using Amazon.TranscribeService.Model;
using Amazon_Transcribe_Speech_To_Text.Helpers.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AWS_Rekognition_Objects.Helpers.Model
{
    public class AWSServices
    {
        AWSCredentials awsCredentials;
        AmazonS3Client s3Client;
        IController controller;
        private static readonly RegionEndpoint region = RegionEndpoint.USEast1;

        private string bucketNameInput, bucketNameOutput;

        private string fileNameActual;

        private string JobName;

        private List<string> ExistingImagesBucket;

        public string FileNameActual
        {
            get => fileNameActual;
            set => fileNameActual = value;
        }
        public string BucketNameInput
        {
            get => bucketNameInput;
            set => bucketNameInput = value;
        }
        public string BucketNameOutput
        {
            get => bucketNameOutput;
            set => bucketNameOutput = value;
        }

        public AWSServices(IController controller) {
            bucketNameInput = "unibrasil-transcriberazz-input";
            JobName = "Transcribe-Reuniao-20210917100919.json";
            this.controller = controller;
        }

        public void setBucktes(string bucketInput, string bucketOutput) {
            this.bucketNameInput = bucketInput;
            this.bucketNameOutput = bucketOutput;
        }
           
        private bool GetCredentialsAWS()
        {
            CredentialProfileStoreChain credentialProfileChain = new CredentialProfileStoreChain();
            if (credentialProfileChain.TryGetAWSCredentials("AWS-Educate-profileD", out awsCredentials))
            {
               return true;
            }
            else
            {
                throw new ApplicationException("Erro obtendo credenciais");
               // return false;
            }

        }

        public string getNameBucketInput()
        {
            return bucketNameInput;
        }

        private bool S3Client() {
            if (GetCredentialsAWS()) {
                s3Client = new AmazonS3Client(awsCredentials, region);
                return true;
            }
            return false;
        }

        public List<string> S3ListBuckets() {
            List<String> bucktes = new List<string>();
            if (S3Client())
            {
                ListBucketsResponse bucketsResponse = (s3Client.ListBucketsAsync()).Result;
                foreach (S3Bucket bucket in bucketsResponse.Buckets)
                {
                    bucktes.Add(bucket.BucketName);
                }
                return bucktes;
            }
            return null;            
        }

        public bool checkFileOnBucket(string fileName)
        {
            List<string> audiosInBucket = audioInputBucketNames();
            if (audiosInBucket.Count!=0)
            {
                return audiosInBucket.Contains(fileName);
            }
            else
            {
                return false;
            }
      
        }


        public async Task<bool> UploadAudioFromS3(string fileName)
        {
            //GetCredentialsAWS();
            try
            {
                if (S3Client())
                {
                    TransferUtility fileTransferUtility = new TransferUtility(s3Client);
                    await fileTransferUtility.UploadAsync(fileName, bucketNameInput);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (AmazonS3Exception ex)
            {
                MessageBox.Show($"Erro encontrado no servidor, ao escrever objeto { ex.Message} ");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro encontrado no servidor, ao escrever objeto { ex.Message} ");
                return false;
            }        
         
        }
        public async Task<bool> DownloadFileS3(String fileName) {
            try
            {
                if (S3Client())
                {
                    TransferUtility fileTransferUtility = new TransferUtility(s3Client);
                    TransferUtilityDownloadRequest transferUtilityDownloadRequest = new TransferUtilityDownloadRequest()
                    {
                        BucketName = this.bucketNameOutput,
                        Key = fileName,
                        FilePath = ""
                    };
                    //https://docs.aws.amazon.com/sdkfornet/latest/apidocs/items/TS3TransferTransferUtilityDownloadRequestNET45.html
                    //https://csharp.hotexamples.com/pt/examples/Amazon.S3.Transfer/TransferUtility/Download/php-transferutility-download-method-examples.html
                    return true;
                }
                else
                {
                    return false;  
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<string> getObjectTranscribeS3()
        {
            try
            {
                if (S3Client())
                {
                    GetObjectRequest getObjectRequest = new GetObjectRequest()
                    {
                        BucketName = bucketNameOutput,
                        Key = JobName
                    };
                    using (GetObjectResponse getObjectResponse = await s3Client.GetObjectAsync(getObjectRequest))
                    {
                        using (StreamReader reader = new StreamReader(getObjectResponse.ResponseStream))
                        {
                            string contents = reader.ReadToEnd();
                            return contents;
                        }
                    }                    
                }
                return String.Empty;
            }
            catch (WebException)
            {
                throw;
            }
            catch (ArgumentNullException)
            {
                throw;
            }
            catch (AmazonS3Exception)
            {
                throw;
            }
        }
        public async Task<StartTranscriptionJobResponse> ExecuteTranscribe(AmazonTranscribeServiceClient TranscribeClient, string fileName, string selectedBucketName)
        {

            StartTranscriptionJobRequest JobRequest = new StartTranscriptionJobRequest
            {
                Media = new Media { MediaFileUri = $"s3://{bucketNameInput}/{fileName}" },
                OutputBucketName = selectedBucketName,
                LanguageCode = LanguageCode.PtBR,
                MediaFormat = MediaFormat.Mp3,
                Settings = new Settings { MaxAlternatives = 5, ShowAlternatives = true,
                                          MaxSpeakerLabels = 3, ShowSpeakerLabels = true},
                TranscriptionJobName = $"Transcribe-MediaFile-{DateTime.Now.ToString("yyyymmddhhmmss")}"
            };

            StartTranscriptionJobResponse jobResponse = await TranscribeClient.StartTranscriptionJobAsync(JobRequest);

            return jobResponse;

        }

        public async Task getListJobsTranscribe() {
            CancellationTokenSource cancellation = new CancellationTokenSource();
            CancellationToken token = cancellation.Token;
            AmazonTranscribeServiceClient TranscribeClient = new AmazonTranscribeServiceClient(awsCredentials, region);

            ListTranscriptionJobsRequest request = new ListTranscriptionJobsRequest
            {
                Status = TranscriptionJobStatus.COMPLETED
            };
            ListTranscriptionJobsResponse response = await TranscribeClient.ListTranscriptionJobsAsync(request); // token
        }

        public async Task requestExecuteTranscribe(string fileName, string selectedBucketName) 
        {
            AmazonTranscribeServiceClient TranscribeServiceClient = new AmazonTranscribeServiceClient(awsCredentials, region);

            StartTranscriptionJobResponse jobTranscribe = await ExecuteTranscribe(TranscribeServiceClient, fileName, selectedBucketName);

            if (jobTranscribe.HttpStatusCode == HttpStatusCode.OK)
            {
                GetTranscriptionJobRequest jobStatus = new GetTranscriptionJobRequest()
                {
                    TranscriptionJobName = jobTranscribe.TranscriptionJob.TranscriptionJobName
                };

                GetTranscriptionJobResponse jobDataTranscribe;
                bool runningJobStatus = true;
                int incrementProgree = 0;
                while (runningJobStatus)
                {
                    jobDataTranscribe = await TranscribeServiceClient.GetTranscriptionJobAsync(jobStatus);
                    TranscriptionJob transcriptionJob = jobDataTranscribe.TranscriptionJob;
                    if (transcriptionJob.TranscriptionJobStatus == TranscriptionJobStatus.COMPLETED)
                    {
                        JobName = extractFileKey(transcriptionJob.Transcript.TranscriptFileUri);
                        incrementProgree = 100;
                        controller.ViewStatusofTranscriptJob(transcriptionJob, incrementProgree);
                        //  definedFileKey(transcriptionJob.Media.MediaFileUri);
                        runningJobStatus = false;
                    }
                    else
                    {
                        controller.ViewStatusofTranscriptJob(transcriptionJob, incrementProgree);
                        if (incrementProgree > 80)
                        {
                            incrementProgree = 0;
                        }
                        else
                        {
                            incrementProgree += 5;
                        }
                       
                        await Task.Delay(5000);
                    }
                }
            }
            else
            {

            }  
        }

        private string extractFileKey(string mediaFileUri)
        {
            string[] nameFileSplit = mediaFileUri.Split('/');
            string nomeFile = nameFileSplit[nameFileSplit.Length - 1];
            return nomeFile;
        }

        public List<string> audioInputBucketNames()
        {
            ExistingImagesBucket = new List<string>();
            AmazonS3Client amazonS3Client = new AmazonS3Client(awsCredentials, region);
            ListObjectsRequest request = new ListObjectsRequest
            {
                BucketName = bucketNameInput
            };

            ListObjectsResponse listResponse = new ListObjectsResponse();
            do
            {
                listResponse = amazonS3Client.ListObjectsAsync(request).Result;
                foreach (S3Object s3Object in listResponse.S3Objects)
                {
                    ExistingImagesBucket.Add(s3Object.Key);
                }
                request.Marker = listResponse.NextMarker;

            } while (listResponse.IsTruncated);

            return ExistingImagesBucket;
        }
    }
}
