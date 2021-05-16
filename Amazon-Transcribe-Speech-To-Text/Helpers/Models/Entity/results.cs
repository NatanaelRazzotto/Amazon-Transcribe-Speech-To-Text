using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_Transcribe_Speech_To_Text.Helpers.Models.Entity
{
    public class Results
    {
        public List<string> transcripts { get; set; }
        public List<string> items { get; set; }
    }
}
