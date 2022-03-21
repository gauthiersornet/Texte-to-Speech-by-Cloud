namespace TextToSpeech
{
    partial class principale
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(principale));
            this.txtChemin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btDesignerChemin = new System.Windows.Forms.Button();
            this.txtTexte = new System.Windows.Forms.TextBox();
            this.btProcessTTS = new System.Windows.Forms.Button();
            this.pbProcess = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPitch = new System.Windows.Forms.TextBox();
            this.txtSpeed = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbLangue = new System.Windows.Forms.ComboBox();
            this.cbVoix = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtURI = new System.Windows.Forms.TextBox();
            this.txtGCloud = new System.Windows.Forms.TextBox();
            this.txtNomFichier = new System.Windows.Forms.TextBox();
            this.txtNumbStart = new System.Windows.Forms.TextBox();
            this.RadBtAzure = new System.Windows.Forms.RadioButton();
            this.RadBtGoogle = new System.Windows.Forms.RadioButton();
            this.lblNbCar = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtChemin
            // 
            this.txtChemin.Location = new System.Drawing.Point(189, 9);
            this.txtChemin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtChemin.Name = "txtChemin";
            this.txtChemin.Size = new System.Drawing.Size(573, 22);
            this.txtChemin.TabIndex = 0;
            this.txtChemin.Text = "TextToSpeech";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chemin et nom du fichier :";
            // 
            // btDesignerChemin
            // 
            this.btDesignerChemin.Location = new System.Drawing.Point(768, 7);
            this.btDesignerChemin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btDesignerChemin.Name = "btDesignerChemin";
            this.btDesignerChemin.Size = new System.Drawing.Size(51, 27);
            this.btDesignerChemin.TabIndex = 2;
            this.btDesignerChemin.Text = "...";
            this.btDesignerChemin.UseVisualStyleBackColor = true;
            this.btDesignerChemin.Click += new System.EventHandler(this.btDesignerChemin_Click);
            // 
            // txtTexte
            // 
            this.txtTexte.Location = new System.Drawing.Point(15, 37);
            this.txtTexte.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTexte.MaxLength = 1000000;
            this.txtTexte.Multiline = true;
            this.txtTexte.Name = "txtTexte";
            this.txtTexte.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtTexte.Size = new System.Drawing.Size(1089, 543);
            this.txtTexte.TabIndex = 3;
            this.txtTexte.Text = resources.GetString("txtTexte.Text");
            this.txtTexte.TextChanged += new System.EventHandler(this.txtTexte_TextChanged);
            // 
            // btProcessTTS
            // 
            this.btProcessTTS.Location = new System.Drawing.Point(16, 586);
            this.btProcessTTS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btProcessTTS.Name = "btProcessTTS";
            this.btProcessTTS.Size = new System.Drawing.Size(169, 26);
            this.btProcessTTS.TabIndex = 4;
            this.btProcessTTS.Text = "Procéder au traitement";
            this.btProcessTTS.UseVisualStyleBackColor = true;
            this.btProcessTTS.Click += new System.EventHandler(this.btProcessTTS_Click);
            // 
            // pbProcess
            // 
            this.pbProcess.Location = new System.Drawing.Point(192, 586);
            this.pbProcess.Margin = new System.Windows.Forms.Padding(4);
            this.pbProcess.Name = "pbProcess";
            this.pbProcess.Size = new System.Drawing.Size(913, 26);
            this.pbProcess.TabIndex = 5;
            this.pbProcess.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1133, 57);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Pitch   :";
            // 
            // txtPitch
            // 
            this.txtPitch.Location = new System.Drawing.Point(1203, 53);
            this.txtPitch.Margin = new System.Windows.Forms.Padding(4);
            this.txtPitch.Name = "txtPitch";
            this.txtPitch.Size = new System.Drawing.Size(203, 22);
            this.txtPitch.TabIndex = 7;
            this.txtPitch.Text = "1.0";
            // 
            // txtSpeed
            // 
            this.txtSpeed.Location = new System.Drawing.Point(1203, 85);
            this.txtSpeed.Margin = new System.Windows.Forms.Padding(4);
            this.txtSpeed.Name = "txtSpeed";
            this.txtSpeed.Size = new System.Drawing.Size(203, 22);
            this.txtSpeed.TabIndex = 9;
            this.txtSpeed.Text = "0.8";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1133, 89);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Speed :";
            // 
            // cbLangue
            // 
            this.cbLangue.FormattingEnabled = true;
            this.cbLangue.Items.AddRange(new object[] {
            "fr-FR"});
            this.cbLangue.Location = new System.Drawing.Point(1203, 117);
            this.cbLangue.Margin = new System.Windows.Forms.Padding(4);
            this.cbLangue.Name = "cbLangue";
            this.cbLangue.Size = new System.Drawing.Size(203, 24);
            this.cbLangue.TabIndex = 10;
            this.cbLangue.Text = "fr-FR";
            this.cbLangue.SelectedIndexChanged += new System.EventHandler(this.cbLangue_SelectedIndexChanged);
            // 
            // cbVoix
            // 
            this.cbVoix.FormattingEnabled = true;
            this.cbVoix.Items.AddRange(new object[] {
            "fr-FR-Wavenet-A"});
            this.cbVoix.Location = new System.Drawing.Point(1203, 150);
            this.cbVoix.Margin = new System.Windows.Forms.Padding(4);
            this.cbVoix.Name = "cbVoix";
            this.cbVoix.Size = new System.Drawing.Size(203, 24);
            this.cbVoix.TabIndex = 11;
            this.cbVoix.Text = "fr-FR-Wavenet-A";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1133, 121);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Langue :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1136, 154);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Voix :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1136, 244);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "TTS URI Google :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1139, 382);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(280, 34);
            this.label7.TabIndex = 15;
            this.label7.Text = "Chemin absolus vers command gcloud.cmd\r\nde google sdk ou clé de Azure :";
            // 
            // txtURI
            // 
            this.txtURI.Location = new System.Drawing.Point(1140, 263);
            this.txtURI.Margin = new System.Windows.Forms.Padding(4);
            this.txtURI.Multiline = true;
            this.txtURI.Name = "txtURI";
            this.txtURI.Size = new System.Drawing.Size(265, 99);
            this.txtURI.TabIndex = 16;
            this.txtURI.Text = "https://texttospeech.googleapis.com/v1/text:synthesize";
            // 
            // txtGCloud
            // 
            this.txtGCloud.Location = new System.Drawing.Point(1140, 420);
            this.txtGCloud.Margin = new System.Windows.Forms.Padding(4);
            this.txtGCloud.Multiline = true;
            this.txtGCloud.Name = "txtGCloud";
            this.txtGCloud.Size = new System.Drawing.Size(265, 96);
            this.txtGCloud.TabIndex = 17;
            this.txtGCloud.Text = "fd214e837cb44d0280135600ebceaa07";
            // 
            // txtNomFichier
            // 
            this.txtNomFichier.Location = new System.Drawing.Point(825, 9);
            this.txtNomFichier.Margin = new System.Windows.Forms.Padding(4);
            this.txtNomFichier.Name = "txtNomFichier";
            this.txtNomFichier.Size = new System.Drawing.Size(184, 22);
            this.txtNomFichier.TabIndex = 18;
            this.txtNomFichier.Text = "Chap1";
            // 
            // txtNumbStart
            // 
            this.txtNumbStart.Location = new System.Drawing.Point(1019, 9);
            this.txtNumbStart.Margin = new System.Windows.Forms.Padding(4);
            this.txtNumbStart.Name = "txtNumbStart";
            this.txtNumbStart.Size = new System.Drawing.Size(85, 22);
            this.txtNumbStart.TabIndex = 19;
            // 
            // RadBtAzure
            // 
            this.RadBtAzure.AutoSize = true;
            this.RadBtAzure.Checked = true;
            this.RadBtAzure.Location = new System.Drawing.Point(1136, 13);
            this.RadBtAzure.Name = "RadBtAzure";
            this.RadBtAzure.Size = new System.Drawing.Size(66, 21);
            this.RadBtAzure.TabIndex = 20;
            this.RadBtAzure.TabStop = true;
            this.RadBtAzure.Text = "Azure";
            this.RadBtAzure.UseVisualStyleBackColor = true;
            // 
            // RadBtGoogle
            // 
            this.RadBtGoogle.AutoSize = true;
            this.RadBtGoogle.Location = new System.Drawing.Point(1203, 13);
            this.RadBtGoogle.Name = "RadBtGoogle";
            this.RadBtGoogle.Size = new System.Drawing.Size(75, 21);
            this.RadBtGoogle.TabIndex = 21;
            this.RadBtGoogle.Text = "Google";
            this.RadBtGoogle.UseVisualStyleBackColor = true;
            // 
            // lblNbCar
            // 
            this.lblNbCar.AutoSize = true;
            this.lblNbCar.Location = new System.Drawing.Point(1110, 542);
            this.lblNbCar.Name = "lblNbCar";
            this.lblNbCar.Size = new System.Drawing.Size(169, 17);
            this.lblNbCar.TabIndex = 22;
            this.lblNbCar.Text = "Nombre de caractères : 0";
            // 
            // principale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1432, 624);
            this.Controls.Add(this.lblNbCar);
            this.Controls.Add(this.RadBtGoogle);
            this.Controls.Add(this.RadBtAzure);
            this.Controls.Add(this.txtNumbStart);
            this.Controls.Add(this.txtNomFichier);
            this.Controls.Add(this.txtGCloud);
            this.Controls.Add(this.txtURI);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbVoix);
            this.Controls.Add(this.cbLangue);
            this.Controls.Add(this.txtSpeed);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPitch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pbProcess);
            this.Controls.Add(this.btProcessTTS);
            this.Controls.Add(this.txtTexte);
            this.Controls.Add(this.btDesignerChemin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtChemin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "principale";
            this.Text = "TextToSpeech";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtChemin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btDesignerChemin;
        private System.Windows.Forms.TextBox txtTexte;
        private System.Windows.Forms.Button btProcessTTS;
        private System.Windows.Forms.ProgressBar pbProcess;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPitch;
        private System.Windows.Forms.TextBox txtSpeed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbLangue;
        private System.Windows.Forms.ComboBox cbVoix;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtURI;
        private System.Windows.Forms.TextBox txtGCloud;
        private System.Windows.Forms.TextBox txtNomFichier;
        private System.Windows.Forms.TextBox txtNumbStart;
        private System.Windows.Forms.RadioButton RadBtAzure;
        private System.Windows.Forms.RadioButton RadBtGoogle;
        private System.Windows.Forms.Label lblNbCar;
    }
}

