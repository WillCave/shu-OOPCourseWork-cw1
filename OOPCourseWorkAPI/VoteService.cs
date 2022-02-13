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

            // Insert New User
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
    }
}
