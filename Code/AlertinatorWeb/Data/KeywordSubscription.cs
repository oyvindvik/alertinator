using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlertinatorWeb.Data
{
    public class KeywordSubscription
    {
        public int ID { get; set; }
        public string Keyword { get; set; }
        public string UserID { get; set; }

        [Display(Name = "Receive E-Mail Notifications")]
        public bool SendEMail { get; set; }
    }
}
