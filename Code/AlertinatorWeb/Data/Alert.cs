using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlertinatorWeb.Data
{
    public class Alert
    {
        public int ID { get; set; }
        public string Keyword { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DatePublished { get; set; }
    }
}
