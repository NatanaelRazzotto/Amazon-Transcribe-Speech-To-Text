﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_Transcribe_Speech_To_Text.Helpers.Models.Entity
{
    public class ResultsTranscribed
    {
        public List<Transcript> transcripts { get; set; }
        public List<Items> items { get; set; }
    }
}
