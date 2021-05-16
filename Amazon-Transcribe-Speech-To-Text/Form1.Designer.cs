
namespace Amazon_Transcribe_Speech_To_Text
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblTempoTotal = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.trackBarStateAudio = new System.Windows.Forms.TrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSelectBucktes = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbBucketsInputS3 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbBucketsOutputS3 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAnalizer = new System.Windows.Forms.Button();
            this.btnSearchFiles = new System.Windows.Forms.Button();
            this.panelExibicao = new System.Windows.Forms.Panel();
            this.tabControlBody = new System.Windows.Forms.TabControl();
            this.tabPageFile = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pgbAnalizer = new System.Windows.Forms.ProgressBar();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnLoadTranscription = new System.Windows.Forms.Button();
            this.lblFormat = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblStatusJob = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblNameJob = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblFileSelecionado = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pgbUploadFlie = new System.Windows.Forms.ProgressBar();
            this.cbFilesBucket = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tbFileAudio = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblNameBucketInput = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPageAudio = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.ofdSearchFiles = new System.Windows.Forms.OpenFileDialog();
            this.panelMenu.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarStateAudio)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelExibicao.SuspendLayout();
            this.tabControlBody.SuspendLayout();
            this.tabPageFile.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.Tan;
            this.panelMenu.Controls.Add(this.panel2);
            this.panelMenu.Controls.Add(this.panel1);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(858, 168);
            this.panelMenu.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.BurlyWood;
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.lblTempoTotal);
            this.panel2.Controls.Add(this.button8);
            this.panel2.Controls.Add(this.button7);
            this.panel2.Controls.Add(this.button6);
            this.panel2.Controls.Add(this.trackBarStateAudio);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 99);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(858, 69);
            this.panel2.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.BurlyWood;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(190, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(48, 19);
            this.textBox1.TabIndex = 11;
            this.textBox1.Text = "00:00";
            // 
            // lblTempoTotal
            // 
            this.lblTempoTotal.AutoSize = true;
            this.lblTempoTotal.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTempoTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTempoTotal.Location = new System.Drawing.Point(730, 23);
            this.lblTempoTotal.Name = "lblTempoTotal";
            this.lblTempoTotal.Size = new System.Drawing.Size(47, 16);
            this.lblTempoTotal.TabIndex = 10;
            this.lblTempoTotal.Text = "00:00";
            // 
            // button8
            // 
            this.button8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button8.BackgroundImage")));
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button8.Location = new System.Drawing.Point(45, 20);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(26, 26);
            this.button8.TabIndex = 9;
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button7.BackgroundImage")));
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button7.Location = new System.Drawing.Point(136, 20);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(26, 26);
            this.button7.TabIndex = 8;
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button6.BackgroundImage")));
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button6.Location = new System.Drawing.Point(77, 10);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(53, 45);
            this.button6.TabIndex = 7;
            this.button6.UseVisualStyleBackColor = true;
            // 
            // trackBarStateAudio
            // 
            this.trackBarStateAudio.Location = new System.Drawing.Point(261, 22);
            this.trackBarStateAudio.Name = "trackBarStateAudio";
            this.trackBarStateAudio.Size = new System.Drawing.Size(463, 45);
            this.trackBarStateAudio.TabIndex = 6;
            this.trackBarStateAudio.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.BurlyWood;
            this.panel1.Controls.Add(this.btnSelectBucktes);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbBucketsInputS3);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cbBucketsOutputS3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(858, 93);
            this.panel1.TabIndex = 0;
            // 
            // btnSelectBucktes
            // 
            this.btnSelectBucktes.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSelectBucktes.BackgroundImage")));
            this.btnSelectBucktes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSelectBucktes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelectBucktes.Location = new System.Drawing.Point(774, 23);
            this.btnSelectBucktes.Name = "btnSelectBucktes";
            this.btnSelectBucktes.Size = new System.Drawing.Size(57, 50);
            this.btnSelectBucktes.TabIndex = 15;
            this.btnSelectBucktes.UseVisualStyleBackColor = true;
            this.btnSelectBucktes.Click += new System.EventHandler(this.btnSelectBucktes_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(261, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "Bucket de Entrada:";
            // 
            // cbBucketsInputS3
            // 
            this.cbBucketsInputS3.BackColor = System.Drawing.Color.NavajoWhite;
            this.cbBucketsInputS3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbBucketsInputS3.FormattingEnabled = true;
            this.cbBucketsInputS3.Location = new System.Drawing.Point(374, 15);
            this.cbBucketsInputS3.Name = "cbBucketsInputS3";
            this.cbBucketsInputS3.Size = new System.Drawing.Size(359, 23);
            this.cbBucketsInputS3.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(261, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Bucket de Destino:";
            // 
            // cbBucketsOutputS3
            // 
            this.cbBucketsOutputS3.BackColor = System.Drawing.Color.NavajoWhite;
            this.cbBucketsOutputS3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbBucketsOutputS3.FormattingEnabled = true;
            this.cbBucketsOutputS3.Location = new System.Drawing.Point(374, 55);
            this.cbBucketsOutputS3.Name = "cbBucketsOutputS3";
            this.cbBucketsOutputS3.Size = new System.Drawing.Size(359, 23);
            this.cbBucketsOutputS3.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Square721 BT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(33, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "AWS TRANSCRIBE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(335, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "Análisar";
            // 
            // btnAnalizer
            // 
            this.btnAnalizer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAnalizer.BackgroundImage")));
            this.btnAnalizer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAnalizer.Enabled = false;
            this.btnAnalizer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAnalizer.Location = new System.Drawing.Point(331, 13);
            this.btnAnalizer.Name = "btnAnalizer";
            this.btnAnalizer.Size = new System.Drawing.Size(59, 50);
            this.btnAnalizer.TabIndex = 13;
            this.btnAnalizer.UseVisualStyleBackColor = true;
            this.btnAnalizer.Click += new System.EventHandler(this.btnAnalizer_Click);
            // 
            // btnSearchFiles
            // 
            this.btnSearchFiles.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearchFiles.BackgroundImage")));
            this.btnSearchFiles.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSearchFiles.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearchFiles.Location = new System.Drawing.Point(340, 113);
            this.btnSearchFiles.Name = "btnSearchFiles";
            this.btnSearchFiles.Size = new System.Drawing.Size(37, 32);
            this.btnSearchFiles.TabIndex = 12;
            this.btnSearchFiles.UseVisualStyleBackColor = true;
            this.btnSearchFiles.Click += new System.EventHandler(this.btnSearchFiles_Click);
            // 
            // panelExibicao
            // 
            this.panelExibicao.BackColor = System.Drawing.Color.Tan;
            this.panelExibicao.Controls.Add(this.tabControlBody);
            this.panelExibicao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelExibicao.Location = new System.Drawing.Point(0, 168);
            this.panelExibicao.Name = "panelExibicao";
            this.panelExibicao.Size = new System.Drawing.Size(858, 283);
            this.panelExibicao.TabIndex = 1;
            // 
            // tabControlBody
            // 
            this.tabControlBody.Controls.Add(this.tabPageFile);
            this.tabControlBody.Controls.Add(this.tabPageAudio);
            this.tabControlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlBody.Location = new System.Drawing.Point(0, 0);
            this.tabControlBody.Name = "tabControlBody";
            this.tabControlBody.SelectedIndex = 0;
            this.tabControlBody.Size = new System.Drawing.Size(858, 283);
            this.tabControlBody.TabIndex = 0;
            // 
            // tabPageFile
            // 
            this.tabPageFile.BackColor = System.Drawing.Color.BurlyWood;
            this.tabPageFile.Controls.Add(this.panel4);
            this.tabPageFile.Controls.Add(this.panel3);
            this.tabPageFile.Location = new System.Drawing.Point(4, 24);
            this.tabPageFile.Name = "tabPageFile";
            this.tabPageFile.Size = new System.Drawing.Size(850, 255);
            this.tabPageFile.TabIndex = 0;
            this.tabPageFile.Text = "Gerenciar Files In Bucket";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.Tan;
            this.panel4.Controls.Add(this.pgbAnalizer);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.lblFileSelecionado);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.btnAnalizer);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(439, 9);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(403, 238);
            this.panel4.TabIndex = 1;
            // 
            // pgbAnalizer
            // 
            this.pgbAnalizer.Location = new System.Drawing.Point(225, 56);
            this.pgbAnalizer.Name = "pgbAnalizer";
            this.pgbAnalizer.Size = new System.Drawing.Size(100, 15);
            this.pgbAnalizer.TabIndex = 18;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnLoadTranscription);
            this.panel5.Controls.Add(this.lblFormat);
            this.panel5.Controls.Add(this.label14);
            this.panel5.Controls.Add(this.lblStatusJob);
            this.panel5.Controls.Add(this.label13);
            this.panel5.Controls.Add(this.lblNameJob);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Location = new System.Drawing.Point(10, 84);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(384, 145);
            this.panel5.TabIndex = 17;
            // 
            // btnLoadTranscription
            // 
            this.btnLoadTranscription.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLoadTranscription.BackgroundImage")));
            this.btnLoadTranscription.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLoadTranscription.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLoadTranscription.Location = new System.Drawing.Point(341, 106);
            this.btnLoadTranscription.Name = "btnLoadTranscription";
            this.btnLoadTranscription.Size = new System.Drawing.Size(37, 32);
            this.btnLoadTranscription.TabIndex = 17;
            this.btnLoadTranscription.UseVisualStyleBackColor = true;
            this.btnLoadTranscription.Click += new System.EventHandler(this.btnLoadTranscription_Click);
            // 
            // lblFormat
            // 
            this.lblFormat.AutoSize = true;
            this.lblFormat.Location = new System.Drawing.Point(123, 62);
            this.lblFormat.Name = "lblFormat";
            this.lblFormat.Size = new System.Drawing.Size(106, 15);
            this.lblFormat.TabIndex = 22;
            this.lblFormat.Text = "Audio Selecionado";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Bahnschrift Condensed", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label14.Location = new System.Drawing.Point(8, 62);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(109, 16);
            this.label14.TabIndex = 21;
            this.label14.Text = "Formato da Midia:";
            // 
            // lblStatusJob
            // 
            this.lblStatusJob.AutoSize = true;
            this.lblStatusJob.Location = new System.Drawing.Point(101, 38);
            this.lblStatusJob.Name = "lblStatusJob";
            this.lblStatusJob.Size = new System.Drawing.Size(106, 15);
            this.lblStatusJob.TabIndex = 20;
            this.lblStatusJob.Text = "Audio Selecionado";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Bahnschrift Condensed", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(8, 37);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 16);
            this.label13.TabIndex = 19;
            this.label13.Text = "Status do JOB:";
            // 
            // lblNameJob
            // 
            this.lblNameJob.AutoSize = true;
            this.lblNameJob.Location = new System.Drawing.Point(101, 13);
            this.lblNameJob.Name = "lblNameJob";
            this.lblNameJob.Size = new System.Drawing.Size(106, 15);
            this.lblNameJob.TabIndex = 18;
            this.lblNameJob.Text = "Audio Selecionado";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Bahnschrift Condensed", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(8, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 16);
            this.label9.TabIndex = 16;
            this.label9.Text = "Nome do JOB:";
            // 
            // lblFileSelecionado
            // 
            this.lblFileSelecionado.AutoSize = true;
            this.lblFileSelecionado.Location = new System.Drawing.Point(43, 40);
            this.lblFileSelecionado.Name = "lblFileSelecionado";
            this.lblFileSelecionado.Size = new System.Drawing.Size(106, 15);
            this.lblFileSelecionado.TabIndex = 16;
            this.lblFileSelecionado.Text = "Audio Selecionado";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(18, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(159, 19);
            this.label10.TabIndex = 15;
            this.label10.Text = "Arquivo Selecionado\r\n";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel3.BackColor = System.Drawing.Color.Tan;
            this.panel3.Controls.Add(this.pgbUploadFlie);
            this.panel3.Controls.Add(this.cbFilesBucket);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.tbFileAudio);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.btnSearchFiles);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.lblNameBucketInput);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Location = new System.Drawing.Point(3, 9);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(430, 238);
            this.panel3.TabIndex = 0;
            // 
            // pgbUploadFlie
            // 
            this.pgbUploadFlie.Location = new System.Drawing.Point(222, 94);
            this.pgbUploadFlie.Name = "pgbUploadFlie";
            this.pgbUploadFlie.Size = new System.Drawing.Size(112, 18);
            this.pgbUploadFlie.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pgbUploadFlie.TabIndex = 16;
            this.pgbUploadFlie.Visible = false;
            // 
            // cbFilesBucket
            // 
            this.cbFilesBucket.BackColor = System.Drawing.Color.NavajoWhite;
            this.cbFilesBucket.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbFilesBucket.FormattingEnabled = true;
            this.cbFilesBucket.Location = new System.Drawing.Point(26, 196);
            this.cbFilesBucket.Name = "cbFilesBucket";
            this.cbFilesBucket.Size = new System.Drawing.Size(308, 23);
            this.cbFilesBucket.TabIndex = 15;
            this.cbFilesBucket.SelectedValueChanged += new System.EventHandler(this.cbFilesBucket_SelectedValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Bahnschrift Condensed", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(13, 163);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(211, 18);
            this.label8.TabIndex = 14;
            this.label8.Text = "Selecionar Arquivo: Já Incluso:";
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(383, 113);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(37, 32);
            this.button1.TabIndex = 13;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbFileAudio
            // 
            this.tbFileAudio.BackColor = System.Drawing.Color.NavajoWhite;
            this.tbFileAudio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbFileAudio.Location = new System.Drawing.Point(26, 120);
            this.tbFileAudio.Name = "tbFileAudio";
            this.tbFileAudio.Size = new System.Drawing.Size(308, 23);
            this.tbFileAudio.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Bahnschrift Condensed", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(11, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(147, 18);
            this.label7.TabIndex = 4;
            this.label7.Text = "Incluir Novo Arquivo:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 15);
            this.label6.TabIndex = 3;
            this.label6.Text = "Name File (audio) :";
            // 
            // lblNameBucketInput
            // 
            this.lblNameBucketInput.AutoSize = true;
            this.lblNameBucketInput.Location = new System.Drawing.Point(38, 40);
            this.lblNameBucketInput.Name = "lblNameBucketInput";
            this.lblNameBucketInput.Size = new System.Drawing.Size(102, 15);
            this.lblNameBucketInput.TabIndex = 1;
            this.lblNameBucketInput.Text = "Bucket de Entrada";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(13, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(224, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "Gerenciar Arquivos no Bucket";
            // 
            // tabPageAudio
            // 
            this.tabPageAudio.BackColor = System.Drawing.Color.BurlyWood;
            this.tabPageAudio.Location = new System.Drawing.Point(4, 24);
            this.tabPageAudio.Name = "tabPageAudio";
            this.tabPageAudio.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAudio.Size = new System.Drawing.Size(850, 255);
            this.tabPageAudio.TabIndex = 1;
            this.tabPageAudio.Text = "View Transcription";
            // 
            // button3
            // 
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Location = new System.Drawing.Point(82, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(69, 56);
            this.button3.TabIndex = 1;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Location = new System.Drawing.Point(157, 24);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(32, 33);
            this.button4.TabIndex = 2;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button5.BackgroundImage")));
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.Location = new System.Drawing.Point(44, 24);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(32, 33);
            this.button5.TabIndex = 3;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // ofdSearchFiles
            // 
            this.ofdSearchFiles.FileName = "ofdSearchFiles";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 451);
            this.Controls.Add(this.panelExibicao);
            this.Controls.Add(this.panelMenu);
            this.Name = "Form1";
            this.Text = "Transcribe Speech To Text";
            this.panelMenu.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarStateAudio)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelExibicao.ResumeLayout(false);
            this.tabControlBody.ResumeLayout(false);
            this.tabPageFile.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelExibicao;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblTempoTotal;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TrackBar trackBarStateAudio;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbBucketsOutputS3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAnalizer;
        private System.Windows.Forms.Button btnSearchFiles;
        private System.Windows.Forms.OpenFileDialog ofdSearchFiles;
        private System.Windows.Forms.TabControl tabControlBody;
        private System.Windows.Forms.TabPage tabPageFile;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblNameBucketInput;
        private System.Windows.Forms.ComboBox cbFilesBucket;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbFileAudio;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbBucketsInputS3;
        private System.Windows.Forms.Button btnSelectBucktes;
        private System.Windows.Forms.ProgressBar pgbUploadFlie;
        private System.Windows.Forms.Label lblFileSelecionado;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblFormat;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblStatusJob;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblNameJob;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tabPageAudio;
        private System.Windows.Forms.Button btnLoadTranscription;
        private System.Windows.Forms.Label s;
        private System.Windows.Forms.Label lblFormatMidia;
        private System.Windows.Forms.Label b;
        private System.Windows.Forms.ProgressBar pgbAnalizer;
    }
}

