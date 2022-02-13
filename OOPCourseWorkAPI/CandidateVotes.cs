using System;
using System.Collections.Generic;
using System.Text;

namespace OOPCourseWorkAPI
{
    public class CandidateVotes
    {
        public string CandidateName { get; set; }

        public long NumberOfVotes { get; set; }

        public override string ToString()
        {
            return $"{CandidateName} has {NumberOfVotes} Votes";
        }
    }
}
