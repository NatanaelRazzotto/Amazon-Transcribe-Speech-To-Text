using Amazon.TranscribeService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_Transcribe_Speech_To_Text.Helpers.Interface
{
    public interface IController
    {
        public void ViewStatusofTranscriptJob(TranscriptionJob transcriptionJob, int incrementProgrees);

    }
}
