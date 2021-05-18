using Amazon.TranscribeService;
using Amazon_Transcribe_Speech_To_Text.Helpers.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_Transcribe_Speech_To_Text.Helpers.Interface
{
    public interface IViewTranscribe
    {
       public bool updateComboNameAudios(string nameBucket, List<string> nameAudios);
       public bool updateComboNameTranscribes(string nameBucket, List<string> nameTranscribe);
       public Task displayStatusProgressFile(bool state, string fileName = null);
       public void releaseTranscript(string file);
       public void setJobProperties(string nameJob, TranscriptionJobStatus status, string formatMidia, int incrementProgrees);
        // public void displayStatusCurrentProgress(TimeSpan TotalTime, TimeSpan currentAudio);
        public void displayTotalTime(TimeSpan totalTime);
        public void bindTextContent(List<Transcript> contentText);
        public void displayTrancribe(Item item);
        public void displayStatusCurrentProgress(TimeSpan currentAudio);
    }
}
