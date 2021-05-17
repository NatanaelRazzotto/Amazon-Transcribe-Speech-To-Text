using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_Transcribe_Speech_To_Text.Helpers.Models.Entity
{
    public class Items
    {
        public string start_time { get; set; }
        public string end_time { get; set; }
        public List<Alternatives> alternatives { get; set; }
        public string type { get; set; }

    }
}
