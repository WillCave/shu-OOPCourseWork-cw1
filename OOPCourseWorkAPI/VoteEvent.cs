using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOPCourseWorkAPI
{
    public class VoteEvent
    {       
        [Key]
        public long VoteEventId { get; set; }

        public string EventName { get; set; }

        public override string ToString()
        {
            return EventName;
        }
    }
}
