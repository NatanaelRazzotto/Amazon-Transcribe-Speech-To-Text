using Amazon.TranscribeService;
using Amazon_Transcribe_Speech_To_Text.Helpers.Interface;
using Amazon_Transcribe_Speech_To_Text.Helpers.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Amazon_Transcribe_Speech_To_Text
{
    public partial class Form1 : Form, IViewTranscribe
    {
        Controller controller; 
        public Form1()
        {
            InitializeComponent();
            controller = new Controller(this);
            List<string> buckets = controller.getLoadS3ListBuckets();
            if (buckets != null)
            {
                foreach (string buckte in buckets)
                {
                    cbBucketsInputS3.Items.Add(buckte);
                    cbBucketsOutputS3.Items.Add(buckte);
                }
            }
        }

        private void btnSearchFiles_Click(object sender, EventArgs e)
        {
            ofdSearchFiles.InitialDirectory = "c:\\";
            ofdSearchFiles.Filter = "Media File (*.mp3, *.MP3) | *.mp3; *.MP3";
            ofdSearchFiles.Title = "Selecione uma Imagem a Ser Analizada";
            if (ofdSearchFiles.ShowDialog() == DialogResult.OK)
            {
                controller.setFileFromBucket(ofdSearchFiles.FileName);
            }
        }



        private void btnSelectBucktes_Click(object sender, EventArgs e)
        {
            string bucketInput = cbBucketsInputS3.SelectedItem.ToString();
            string bucketOutput = cbBucketsOutputS3.SelectedItem.ToString();
            if (!String.IsNullOrEmpty(bucketInput))
            {
                if (!controller.setFromNameBuckets(bucketInput, bucketOutput))
                {
                    MessageBox.Show("Não foi possivel Buscar os Arquivos constidos no Bucket");
                }
                
            }
            else
            {
                MessageBox.Show("Você deve informar os Buckets");
            }
           
        }


        #region Methods
        // Metodos responsaveis pelo populamento dos dados

        public bool updateComboNameAudios(string nameBucket,List<string> nameAudios)
        {
            if (!String.IsNullOrEmpty(nameBucket)) 
            {
                lblNameBucketInput.Text = nameBucket;
                if (nameAudios != null)
                {
                    foreach (string item in nameAudios)
                    {
                        cbFilesBucket.Items.Add(item);
                    }
                    return true;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        public async Task displayStatusProgressFile(bool state, string fileName = null)
        {
            if (state)
            {
                pgbUploadFlie.Style = ProgressBarStyle.Marquee;
                pgbUploadFlie.MarqueeAnimationSpeed = 10;
                pgbUploadFlie.Visible = true;
            }
            else
            {
                pgbUploadFlie.Style = ProgressBarStyle.Continuous;
                pgbUploadFlie.MarqueeAnimationSpeed = 0;
                tbFileAudio.Text = fileName;
            }
        }
        public void releaseTranscript(string file)
        {
            lblFileSelecionado.Text = file;
            btnAnalizer.Enabled = true;
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbFileAudio.Text))
            {
                controller.setFileFromAnalize(Path.GetFileName(tbFileAudio.Text));
            }
        }

        private void cbFilesBucket_SelectedValueChanged(object sender, EventArgs e)
        {
            if ((cbFilesBucket.SelectedItem != null))//&& (cbFilesBucket.ValueMember != "")
            {
                controller.setFileFromAnalize(cbFilesBucket.SelectedItem.ToString());
            }
        }

        private void btnAnalizer_Click(object sender, EventArgs e)
        {
            pgbAnalizer.Minimum = 0;
            pgbAnalizer.Maximum = 100;
            controller.executeTranscribeToS3();
        }

        private void btnLoadTranscription_Click(object sender, EventArgs e)
        {
            controller.TranscribeObject();
            tabControlBody.SelectedIndex = 1;
        }

        public void setJobProperties(string nameJob, TranscriptionJobStatus status, string formatMidia, int incrementProgrees)
        {
            lblNameJob.Text = nameJob;
            lblStatusJob.Text = status.ToString();
            //lblFormatMidia.Text = formatMidia.ToString();
            pgbAnalizer.Increment(incrementProgrees);

        }
    }
}
