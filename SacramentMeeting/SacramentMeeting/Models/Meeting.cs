using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace SacramentMeeting.Models
{
    public class Meeting
    {
        public int ID { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime MeetingDate { get; set; }

        [Required]
        [Display(Name = "Conducting")]
        public int ConductingID { get; set; }

        [Required]
        [Display(Name = "Opening Hymn")]
        public int OpeningHymnID { get; set; }

        [Display(Name = "Opening Prayer")]
        public int OpeningPrayerID { get; set; }

        [Required]
        [Display(Name = "Sacrament Hymn")]
        public int SacramentHymnID { get; set; }

        [Display(Name = "Intermediate Hymn")]
        public int? IntermediateHymnID { get; set; }

        [Required]
        [Display(Name = "Closing Hymn")]
        public int ClosingHymnID { get; set; }

        [Required]
        [Display(Name = "Closing Prayer")]
        public int ClosingPrayerID { get; set; }

        [Display(Name = "Meeting Date")]
        public string MeetingIdentifier
        {
            get
            {
                return MeetingDate.ToString("dddd, MMMM d , yyyy",
                  CultureInfo.CreateSpecificCulture("en-US"));
            }
        }

        public ICollection<Speaker> Speakers { get; set; }

        public Member Presiding { get; set; }
        public Member Conducting { get; set; }
        public Hymn OpeningHymn { get; set; }
        public Member OpeningPrayer { get; set; }
        public Hymn SacramentHymn { get; set; }
        public Hymn IntermediateHymn { get; set; }
        public Hymn ClosingHymn { get; set; }
        public Member ClosingPrayer { get; set; }

    }
}
