using Amazon.TranscribeService;
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
       public Task displayStatusProgressFile(bool state, string fileName = null);
       public void releaseTranscript(string file);
       public void setJobProperties(string nameJob, TranscriptionJobStatus status, string formatMidia, int incrementProgrees);
    }
}
