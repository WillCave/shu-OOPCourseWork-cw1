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
        /// Gets the person the user has voted for
        /// </summary>
        /// <param name="voteEventId"></param>
        /// <param name="userId"></param>
        /// <returns>Vote if found or null</returns>
        Vote GetVote(long voteEventId, long userId);

        /// <summary>
        /// Getting Candidate votes for vote event
        /// </summary>
        /// <param name="voteEventId"></param>
        /// <returns>Numbers of votes for each candidate</returns>
        List<CandidateVotes> GetCandidateVotes(long voteEventId);
        
        /// <summary>
        /// Allows user to Cancel current vote and change it
        /// </summary>
        /// <param name="voteEventId"></param>
        /// <param name="userId"></param>
        /// <param name="candidateId"></param>
        /// <returns>Returns true if revoked otherewise false</returns>
        bool RevokeVote(long voteEventId, long userId);

        /// <summary>
        /// Creates a new event for users to vote on
        /// </summary>
        /// <param name="eventName"></param>
        /// <returns>VoteEvent</returns>
        VoteEvent CreateVoteEvent(string eventName);

        /// <summary>
        /// Allows admin to add candidates
        /// </summary>
        /// <param name="voteEventId"></param>
        /// <param name="candidateName"></param>
        /// <returns>Newly added candidate</returns>
        Candidate AddCandidate(long voteEventId, string candidateName);

        /// <summary>
        /// Allows admin to delete a candidate with no votes
        /// </summary>
        /// <param name="voteEventId"></param>
        /// <param name="candidateId"></param>
        /// <returns>True if deleted otherwise false</returns>
        bool DeleteCandidate(long voteEventId, long candidateId);

        /// <summary>
        /// Allows admin to check to see if candidate can be deleted
        /// </summary>
        /// <param name="voteEventId"></param>
        /// <param name="candidateId"></param>
        /// <returns>True if can delete otherwise false</returns>
        bool CanDeleteCandidate(long voteEventId, long candidateId);
    }
}
