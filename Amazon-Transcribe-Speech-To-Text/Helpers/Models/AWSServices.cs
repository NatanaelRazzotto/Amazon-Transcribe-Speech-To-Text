using Amazon;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Amazon.TranscribeService;
using Amazon.TranscribeService.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AWS_Rekognition_Objects.Helpers.Model
{
    public class AWSServices
    {
        AWSCredentials awsCredentials;
        AmazonS3Client s3Client;
        private static readonly RegionEndpoint region = RegionEndpoint.USEast1;

        private string bucketNameInput, bucketNameOutput;

        private string fileNameActual;

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

        public AWSServices() {
            bucketNameInput = "unibrasil-transcriberazz-input";
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
        public async Task ExecuteTranscribe(string fileName, string selectedBucketName)
        {
            AmazonTranscribeServiceClient TranscribeServiceClient = new AmazonTranscribeServiceClient(awsCredentials, region);
            StartTranscriptionJobRequest JobRequest = new StartTranscriptionJobRequest
            {
                Media = new Media { MediaFileUri = $"s3://{bucketNameInput}/{fileName}" },
                OutputBucketName = selectedBucketName,
                LanguageCode = LanguageCode.PtBR,
                MediaFormat = MediaFormat.Mp3,
                TranscriptionJobName = $"Trascribe-Reuniao-{DateTime.Now.ToString("yyyymmddhhmmss")}"
            };

            StartTranscriptionJobResponse jobResponse = await TranscribeServiceClient.StartTranscriptionJobAsync(JobRequest);

            GetTranscriptionJobRequest jobStatus = new GetTranscriptionJobRequest()
            {
                TranscriptionJobName = JobRequest.TranscriptionJobName
            };
            GetTranscriptionJobResponse jobData = await TranscribeServiceClient.GetTranscriptionJobAsync(jobStatus);
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
