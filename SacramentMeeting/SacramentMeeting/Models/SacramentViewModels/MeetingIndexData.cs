using System;
using System.Collections.Generic;

namespace SacramentMeeting.Models.SacramentViewModels
{
    public class MeetingIndexData
    {
        public IEnumerable<Meeting> Meetings { get; set; }
        public IEnumerable<Speaker> Speakers { get; set; }
    }
}
