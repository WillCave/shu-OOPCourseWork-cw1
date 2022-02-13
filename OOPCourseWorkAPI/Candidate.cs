using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOPCourseWorkAPI
{
    public class Candidate
    {       
        [Key]
        public long CandidateId { get; set; }

        public long VoteEventId { get; set; }

        public string CandidateName { get; set; }
        public override string ToString()
        {
            return CandidateName;
        }
    }
}
