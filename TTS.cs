using Microsoft.CognitiveServices.Speech;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TextToSpeech
{
    public class TTS
    {
        public enum ECloud
        {
            Aucun = 0,
            Azure,
            Google
        }

        private ECloud eCloud;
        private string authKey;
        private string URI;
        private string languageCode = "fr-FR";
        private string voix = "fr-FR-Wavenet-A";
        private string pitch = "1";
        private string speakingRate = "0.80";
        private SpeechSynthesizer speechSynthesizer;
        private string région;

        public TTS(ECloud _eCloud = ECloud.Google, string _languageCode = "fr-FR", string _voix = "fr-FR-Wavenet-A", string _pitch = "1", string _speakingRate = "0.80", string _authKey = null, string _URI = null, string _région = "francecentral")
        {
            eCloud = _eCloud;
            authKey = _authKey;
            languageCode = _languageCode;
            voix = _voix;
            pitch = _pitch;
            speakingRate = _speakingRate;
            région = null;
            URI = _URI;
            région = _région;

            if(eCloud == ECloud.Azure)
            {
                SpeechConfig speechConfig = SpeechConfig.FromSubscription(authKey, "francecentral");
                speechConfig.SpeechSynthesisLanguage = _languageCode;
                speechConfig.SetSpeechSynthesisOutputFormat(SpeechSynthesisOutputFormat.Audio48Khz96KBitRateMonoMp3);
                //AudioConfig audioConfig = AudioConfig.;
                //AudioProcessingOptions audioProcessingOptions = null;
                speechSynthesizer = new SpeechSynthesizer(speechConfig);
            }
        }

        public byte[] TextToSpeech(string texte)
        {
            if(eCloud == ECloud.Google)
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
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URI);

                string postData = "{\"input\":{\"text\":\" " + texte + " \"},\"voice\":{\"languageCode\":\"" + languageCode + "\",\"name\":\"" + voix + "\"},\"audioConfig\":{\"audioEncoding\":\"MP3\",\"pitch\":" + pitch + ",\"speakingRate\":" + speakingRate + "}}";
                byte[] data = Encoding.UTF8.GetBytes(postData);

                //request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authorisation);
                request.Headers.Add("Authorization", "Bearer " + authKey);
                request.Method = "POST";
                request.ContentType = "application/json; charset=utf-8";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                int idxBegin = responseString.IndexOf("\"", responseString.IndexOf("\"audioContent\"") + voix.Length) + 1;
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
            else
            {
                Task<SpeechSynthesisResult> tache = speechSynthesizer.SpeakTextAsync(texte);
                tache.Wait();
                return tache.Result.AudioData;
            }
        }
    }
}
