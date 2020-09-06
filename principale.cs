using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextToSpeech
{
    public partial class principale : Form
    {
        private const int nbMaxCaractères = 4950;

        Dictionary<string, string[]> lstLangues = new Dictionary<string, string[]>();

        public principale()
        {
            lstLangues = new Dictionary<string, string[]>();
            lstLangues.Add("da-DK", new string[] { "da-DK-Wavenet-A", "da-DK-Wavenet-C", "da-DK-Wavenet-D", "da-DK-Wavenet-E" });
            lstLangues.Add("de-DE", new string[] { "de-DE-Wavenet-A", "de-DE-Wavenet-B", "de-DE-Wavenet-C", "de-DE-Wavenet-D", "de-DE-Wavenet-E", "de-DE-Wavenet-F" });
            lstLangues.Add("en-AU", new string[] { "en-AU-Wavenet-A", "en-AU-Wavenet-B", "en-AU-Wavenet-C", "en-AU-Wavenet-D" });
            lstLangues.Add("en-GB", new string[] { "en-GB-Wavenet-A", "en-GB-Wavenet-B", "en-GB-Wavenet-C", "en-GB-Wavenet-D", "en-GB-Wavenet-F" });
            lstLangues.Add("en-US", new string[] { "en-US-Wavenet-A", "en-US-Wavenet-B", "en-US-Wavenet-C", "en-US-Wavenet-D", "en-US-Wavenet-E", "en-US-Wavenet-F", "en-US-Wavenet-G", "en-US-Wavenet-H", "en-US-Wavenet-I", "en-US-Wavenet-J" });
            lstLangues.Add("fr-CA", new string[] { "fr-CA-Wavenet-A", "fr-CA-Wavenet-B", "fr-CA-Wavenet-C", "fr-CA-Wavenet-D" });
            lstLangues.Add("fr-FR", new string[] { "fr-FR-Wavenet-A", "fr-FR-Wavenet-B", "fr-FR-Wavenet-C", "fr-FR-Wavenet-D", "fr-FR-Wavenet-E" });
            lstLangues.Add("nb-NO", new string[] { "nb-NO-Wavenet-A", "nb-NO-Wavenet-B", "nb-NO-Wavenet-C", "nb-NO-Wavenet-D", "nb-NO-Wavenet-E" });
            //lstLangues.Add("", new string[] {  });
            //lstLangues.Add("", new string[] { });
            //lstLangues.Add("", new string[] { });
            InitializeComponent();

            cbLangue.Items.Clear();
            foreach (KeyValuePair<string, string[]> kv in lstLangues)
                cbLangue.Items.Add(kv.Key);
            cbLangue.SelectedIndex = 6;
        }

        private void btDesignerChemin_Click(object sender, EventArgs e)
        {
            SaveFileDialog openFile = new SaveFileDialog();
            openFile.InitialDirectory = Application.ExecutablePath;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                txtChemin.Text = openFile.FileName;
            }
        }

        private string getAuthorisation()
        {
            ProcessStartInfo sinfo = new ProcessStartInfo(
                txtGCloud.Text,//"C:/Users/Tigroux/AppData/Local/Google/Cloud SDK/google-cloud-sdk/bin/gcloud.cmd",
                "auth application-default print-access-token");
            sinfo.CreateNoWindow = true;
            sinfo.UseShellExecute = false;
            sinfo.RedirectStandardOutput = true;
            Process p = System.Diagnostics.Process.Start(sinfo);
            p.WaitForExit();
            //return "@{ \"Authorization\" = \"Bearer " + p.StandardOutput.ReadLine() + "\" }";
            return p.StandardOutput.ReadLine();
        }

        private byte[] processTTS(string texte, string authorisation, string languageCode = "fr-FR", string voix = "fr-FR-Wavenet-A", string pitch = "1", string speakingRate = "0.80")
        {
            //File.WriteAllText("request.json", "{\"input\":{\"text\":\" " + texte + " \"},\"voice\":{\"languageCode\":\"" + languageCode + "\",\"name\":\"" + voix + "\"},\"audioConfig\":{\"audioEncoding\":\"MP3\",\"pitch\":" + pitch  + ",\"speakingRate\":" + speakingRate + "}}");

            /*HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Post, "https://texttospeech.googleapis.com/v1/text:synthesize");
            httpRequest.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authorisation);
            //httpRequest.Content = new Http;
            var values = new Dictionary<string, string>
            {
                { "texte", texte }
            };

            var content = new FormUrlEncodedContent(values);
            httpRequest.Content = content;
            httpRequest.*/

            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://texttospeech.googleapis.com/v1/text:synthesize");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(txtURI.Text);

            string postData = "{\"input\":{\"text\":\" " + texte + " \"},\"voice\":{\"languageCode\":\"" + languageCode + "\",\"name\":\"" + voix + "\"},\"audioConfig\":{\"audioEncoding\":\"MP3\",\"pitch\":" + pitch + ",\"speakingRate\":" + speakingRate + "}}";
            byte[] data = Encoding.UTF8.GetBytes(postData);

            //request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authorisation);
            request.Headers.Add("Authorization", "Bearer " + authorisation);
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            int idxBegin = responseString.IndexOf("\"", responseString.IndexOf("\"audioContent\"") + voix.Length)+1;
            int idxEnd = responseString.LastIndexOf("\"");

            responseString = responseString.Substring(idxBegin, idxEnd - idxBegin);


            /*ProcessStartInfo sinfo = new ProcessStartInfo(
                "C:/Windows/System32/WindowsPowerShell/v1.0/powershell.exe",
                "Invoke-WebRequest -Method POST -Headers ${" + headers + "} -ContentType: \"application/json; charset=utf-8\" -InFile request.json -Uri \"https://texttospeech.googleapis.com/v1/text:synthesize\" -UseBasicParsing | Select-Object -Expand Content");
            sinfo.CreateNoWindow = true;
            sinfo.UseShellExecute = false;
            sinfo.RedirectStandardOutput = true;
            sinfo.RedirectStandardError = true;
            Process p = System.Diagnostics.Process.Start(sinfo);
            p.WaitForExit();
            string mp3b64 = p.StandardOutput.ReadToEnd();
            string tt = p.StandardError.ReadToEnd();*/

            //File.Delete("request.json");

            return Convert.FromBase64String(responseString);
        }
        
        private string ReplaceAll(string str, string from, string to)
        {
            for (string old = null; old != str;)
            {
                old = str;
                str = str.Replace(from, to);
            }
            return str;
        }

        private string ManyToOne(string str, string tg)
        {
            str = ReplaceAll(str, " " + tg, tg);
            str = ReplaceAll(str, tg + " ", tg);
            str = ReplaceAll(str, tg+ tg, tg);
            return str;
        }

        private string ManySplit(string str, string tg)
        {
            return str.Replace(tg + "\".", tg + "\"").Replace(tg + "«.", tg + "«").Replace(tg + "».", tg + "»").Replace(tg + ".", tg).Replace(tg, tg + " ");
        }

        private void btProcessTTS_Click(object sender, EventArgs e)
        {
            btProcessTTS.Enabled = false;
            string root = txtChemin.Text.Trim();
            if (root.ToUpper().EndsWith(".MP3"))
                root = root.Substring(0, root.Length - ".MP3".Length);

            string fnom = txtNomFichier.Text.Trim();
            if (fnom.ToUpper().EndsWith(".MP3"))
                fnom = fnom.Substring(0, fnom.Length - ".MP3".Length);

            string authorisation = getAuthorisation();
            string tts = txtTexte.Text
                .Replace("\r\n", "\n")
                .Replace("\n\n", ".")
                .Replace("\n", " ");

            tts = ManyToOne(tts, ".");
            tts = ManyToOne(tts, "?");
            tts = ManyToOne(tts, "!");
            tts = ManyToOne(tts, ";");
            tts = ManyToOne(tts, ":");
            tts = ManyToOne(tts, ",");

            tts = ManySplit(tts, ".");
            tts = ManySplit(tts, "?");
            tts = ManySplit(tts, "!");
            tts = ManySplit(tts, ";");
            tts = ManySplit(tts, ":");
            tts = ManySplit(tts, ",");
            tts = tts.Trim();

            List<string> ttsList = new List<string>();
            while(tts != "")
            {
                int dotIdx;
                if (tts.Length > nbMaxCaractères)
                {
                    dotIdx  =  tts.LastIndexOf('.', nbMaxCaractères);
                    if (dotIdx < 0) dotIdx = tts.Length;
                    else dotIdx += 1;
                }
                else dotIdx = tts.Length;
                ttsList.Add(tts.Substring(0, dotIdx));
                tts = tts.Substring(dotIdx);
            }

            pbProcess.Value = 0;
            pbProcess.Maximum = ttsList.Count;
            pbProcess.Visible = true;
            pbProcess.Refresh();

            int nbChiffre;
            int delta;
            txtNumbStart.Text = txtNumbStart.Text.Trim();
            if (txtNumbStart.Text == "")
            {
                nbChiffre = 1 + (int)Math.Log10(ttsList.Count());
                delta = 0;
            }
            else
            {
                nbChiffre = txtNumbStart.Text.Length;
                delta = int.Parse(txtNumbStart.Text);
            }

            for (int i = 0; i < ttsList.Count; ++i)
            {
                string numb = (delta+i).ToString();
                byte[] audio = processTTS(ttsList[i], authorisation, cbLangue.Text, cbVoix.Text, txtPitch.Text, txtSpeed.Text);
                string zero = (nbChiffre > numb.Length ? new String('0', nbChiffre - numb.Length) : "");
                File.WriteAllBytes(root + zero + numb + fnom + ".mp3", audio);
                pbProcess.Value++;
                pbProcess.Refresh();
            }

            btProcessTTS.Enabled = true;
            pbProcess.Visible = false;
        }

        private void cbLangue_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbVoix.Items.Clear();
            foreach (string v in lstLangues[cbLangue.Text])
                cbVoix.Items.Add(v);
            cbVoix.SelectedIndex = 0;
        }

        private void txtTexte_TextChanged(object sender, EventArgs e)
        {
            if(txtTexte.Text != "")
            {
                int idx = txtTexte.Text.IndexOf(".");
                int idx2 = txtTexte.Text.IndexOf("\n");
                if (idx < 0 || idx > idx2) idx = idx2;
                idx2 = 20;
                if (idx < 0 || idx > idx2) idx = idx2;
                txtNomFichier.Text = txtTexte.Text.Substring(0, idx).Trim();
            }
        }
    }
}
