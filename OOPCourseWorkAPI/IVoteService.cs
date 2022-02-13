using System;
using System.Collections.Generic;
using System.Text;

namespace OOPCourseWorkAPI
{
    public interface IVoteService
    {
        /// <summary>
        /// Get Vote Events
        /// </summary>
        /// <returns>Returns all the vote events in the Database</returns>
        List<VoteEvent> GetVoteEvents();

        /// <summary>
        ///Gets candidates for vote event ID 
        /// </summary>
        /// <param name="voteEventId"></param>
        /// <returns>A list of candidates for this vote event</returns>
        List<Candidate> GetCandidates( long voteEventId);

        /// <summary>
        /// Checks if user has already voted
        /// </summary>
        /// <param name="voteEventId"></param>
        /// <param name="userId"></param>
        /// <returns>True if can vote otherwise false</returns>        
        bool CanVote(long voteEventId, long userId);

        /// <summary>
        /// Logs the Vote with specified Parameters
        /// </summary>
        /// <param name="VoteEventId"></param>
        /// <param name="UserId"></param>
        /// <param name="CandidateId"></param>
        /// <returns>Returns newly logged Votes</returns>
        Vote LogVote(long voteEventId, long userId, long candidateId);

        /// <summary>
        /// Getting Candidate votes for vote event
        /// </summary>
        /// <param name="voteEventId"></param>
        /// <returns>Numbers of votes for each candidate</returns>
        List<CandidateVotes> GetCandidateVotes(long voteEventId);        
    }
}
