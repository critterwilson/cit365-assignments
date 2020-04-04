using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace SacramentMeeting.Models
{
    public class Speaker
    {
        public int ID { get; set; }
        public int MemberID { get; set; }
        public string Topic { get; set; }
        public int MeetingID { get; set; }

        public Member Member { get; set; }
        public Meeting Meeting { get; set; }
    }
}
