using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOPCourseWorkAPI
{
    public class Vote
    {       
        [Key]
        public long VoteId { get; set; }

        public long VoteEventId { get; set; }

        public long UserId { get; set; }

        public long CandidateId { get; set; }

    }
}
