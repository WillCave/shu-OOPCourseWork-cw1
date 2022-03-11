using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPCourseWorkAPI
{
    public class VoteService : IVoteService
    {
        private string _connectionString;

        public VoteService(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <inheritdoc/>
        public List<VoteEvent> GetVoteEvents()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<VoteEvent>($"SELECT * FROM VoteEvents").ToList();
            }
        }

        /// <inheritdoc/>
        public List<Candidate> GetCandidates(long voteEventId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Candidate>($"SELECT * FROM Candidates WHERE VoteEventId = {voteEventId}").ToList();
            }
        }

        /// <inheritdoc/>
        public bool CanVote(long voteEventId, long userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query($"SELECT * FROM Votes WHERE VoteEventId = {voteEventId} AND UserId = {userId}").ToList().Count == 0;
            }
        }

        /// <inheritdoc/>
        public Vote LogVote(long voteEventId, long userId, long candidateId)
        {
            if (CanVote(voteEventId, userId) == false)
                throw new Exception("Already voted");

            // Insert New Vote
            using (var connection = new SqlConnection(_connectionString))
            {
                var newVote = new Vote() { VoteEventId = voteEventId, UserId = userId, CandidateId = candidateId };
                connection.Insert(newVote);

                return newVote;
            }
        }

        /// <inheritdoc/>
        public List<CandidateVotes> GetCandidateVotes(long voteEventId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<CandidateVotes>($"SELECT c.CandidateName," +
                                                        $" (SELECT COUNT(*) FROM Votes WHERE VoteEventId = {voteEventId} AND CandidateId = c.CandidateId) AS NumberOfVotes " +
                                                        $"FROM Candidates c WHERE VoteEventId = {voteEventId}").ToList();
            }
        }

        /// <inheritdoc/>
        public bool RevokeVote(long voteEventId, long userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Execute($"DELETE FROM Votes WHERE VoteEventId = {voteEventId} AND UserId = {userId} ") >= 1;
            }
        }


        /// <inheritdoc/>
        public VoteEvent CreateVoteEvent(string eventName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var newVoteEvent = new VoteEvent() { EventName = eventName };
                connection.Insert(newVoteEvent);

                return newVoteEvent;
            }
        }

        /// <inheritdoc/>
        public Candidate AddCandidate(long voteEventId, string candidateName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var newCandidate = new Candidate() { VoteEventId = voteEventId, CandidateName = candidateName };
                connection.Insert(newCandidate);

                return newCandidate;
            }
        }

        /// <inheritdoc/>
        public bool DeleteCandidate(long voteEventId, long candidateId)
        {
            if(CanDeleteCandidate(voteEventId, candidateId) == false)    
                return false;

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Execute($"DELETE FROM Candidates WHERE VoteEventId = {voteEventId} AND CandidateId = {candidateId} ") >= 1;
            }
        }

        /// <inheritdoc/>
        public bool CanDeleteCandidate(long voteEventId, long candidateId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query($"SELECT * FROM Votes WHERE VoteEventId = {voteEventId} AND CandidateId = {candidateId}").ToList().Count == 0;
            }
        }
    }
}
