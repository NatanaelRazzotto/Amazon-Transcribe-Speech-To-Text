﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_Transcribe_Speech_To_Text.Helpers.Models.Entity
{
    public class Item
    {
        public double start_time { get; set; }
        public double end_time { get; set; }
        public List<Alternatives> alternatives { get; set; }
        public float averageConfidence { get; set; }
        public string type { get; set; }

    }
}
