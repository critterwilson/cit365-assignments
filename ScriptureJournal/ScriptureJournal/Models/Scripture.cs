using System;
using System.ComponentModel.DataAnnotations;

namespace ScriptureJournal.Models
{
    public class Scripture
    {
        public int        ID { get; set; }
        public string   Book { get; set; }
        public int   Chapter { get; set; }
        public int     Verse { get; set; }
        public string   Note { get; set; }
        [Display(Name = "Date Added")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
