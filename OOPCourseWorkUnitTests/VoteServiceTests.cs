using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOPCourseWorkAPI;
using System;
using System.Linq;

namespace OOPCourseWorkUnitTests
{
    [TestClass]
    public class VoteServiceTests
    {

        protected IUserService _userService;
        protected User _defaultUser;
        protected IVoteService _voteService;
        protected VoteEvent _defaultVoteEvent;
        protected Candidate _defaultCandidate;
            
        [TestInitialize]
        public void TestInit()
        {
            // Need to clean up Test Database delete tables in order to not break forign key links           
            DatabaseTestHelpers.DeleteTableContent("Votes");            
            DatabaseTestHelpers.DeleteTableContent("Candidates");
            DatabaseTestHelpers.DeleteTableContent("VoteEvents");
            DatabaseTestHelpers.DeleteTableContent("Users");

            _userService = new UserService(DatabaseTestHelpers.TestConnectionString);
            _defaultUser = _userService.RegisterUser("wcave", "Password123", UserRoleType.Voter, "Will", "Cave");
            _voteService = new VoteService(DatabaseTestHelpers.TestConnectionString);
            _defaultVoteEvent = _voteService.CreateVoteEvent("General Election 2022");
            _defaultCandidate = _voteService.AddCandidate(_defaultVoteEvent.VoteEventId, "Borris");
        }

        [TestMethod]
        public void CreateVoteEventTest()
        {
            //Test                  
            var result = _voteService.CreateVoteEvent("New vote event");

            //check
            Assert.IsNotNull(result);
            Assert.IsTrue(result.VoteEventId > 0);
            Assert.AreEqual("New vote event", result.EventName);            
        }

        [TestMethod]
        public void VoteEventTest()
        {
            //Set Up                 
            _voteService.CreateVoteEvent("New vote event 1");
            _voteService.CreateVoteEvent("New vote event 2");
            _voteService.CreateVoteEvent("New vote event 3");

            //Test
            var voteEvents = _voteService.GetVoteEvents();

            //check
            Assert.IsNotNull(voteEvents);
            Assert.AreEqual(4, voteEvents.Count);
            Assert.IsTrue(voteEvents.Any(ve => ve.EventName == "General Election 2022"), "General Election Vote Event Missing");
            Assert.IsTrue(voteEvents.Any(ve => ve.EventName == "New vote event 1"), "Vote Event 1 Missing");
            Assert.IsTrue(voteEvents.Any(ve => ve.EventName == "New vote event 2"), "Vote Event 2 Missing");
            Assert.IsTrue(voteEvents.Any(ve => ve.EventName == "New vote event 3"), "Vote Event 3 Missing");
        }

        [TestMethod]
        public void AddCandidateTest()
        {
            //Test                  
            var result = _voteService.AddCandidate(_defaultVoteEvent.VoteEventId, "New candidate");

            //check
            Assert.IsNotNull(result);
            Assert.IsTrue(result.CandidateId > 0);
            Assert.AreEqual(_defaultVoteEvent.VoteEventId, result.VoteEventId);
            Assert.AreEqual("New candidate", result.CandidateName);
        }

        [TestMethod]
        public void GetCandidatesTest()
        {
            //Set Up
            var voteEvent = _voteService.CreateVoteEvent("New vote event");
            _voteService.AddCandidate(voteEvent.VoteEventId, "New candidate 1");
            _voteService.AddCandidate(voteEvent.VoteEventId, "New candidate 2");
            _voteService.AddCandidate(voteEvent.VoteEventId, "New candidate 3");

            //Test
            var candidates = _voteService.GetCandidates(voteEvent.VoteEventId);

            //check
            Assert.IsNotNull(candidates);
            Assert.AreEqual(3, candidates.Count);
            Assert.IsTrue(candidates.Any(c => c.CandidateName == "New candidate 1"), "Candidate 1 missing");
            Assert.IsTrue(candidates.Any(c => c.CandidateName == "New candidate 2"), "Candidate 2 missing");
            Assert.IsTrue(candidates.Any(c => c.CandidateName == "New candidate 3"), "Candidate 3 missing");
        }

        [TestMethod]
        public void DeleteCandidateTest()
        {
            //Set Up
            var voteEvent = _voteService.CreateVoteEvent("New vote event");
            var candidate1 = _voteService.AddCandidate(voteEvent.VoteEventId, "New candidate 1");
            var candidate2 = _voteService.AddCandidate(voteEvent.VoteEventId, "New candidate 2");
            var candidate3 = _voteService.AddCandidate(voteEvent.VoteEventId, "New candidate 3");

            //Test
            var result = _voteService.DeleteCandidate(voteEvent.VoteEventId, candidate2.CandidateId);

            //check
            Assert.IsTrue(result);
            var candidates = _voteService.GetCandidates(voteEvent.VoteEventId);
            Assert.IsNotNull(candidates);
            Assert.AreEqual(2, candidates.Count);
            Assert.IsTrue(candidates.Any(c => c.CandidateName == "New candidate 1"), "Candidate 1 missing");
            Assert.IsTrue(candidates.Any(c => c.CandidateName == "New candidate 3"), "Candidate 3 missing");
        }

        [TestMethod]
        public void CanDeleteCandidateTest()
        {
            //Set Up
            var voteEvent = _voteService.CreateVoteEvent("New vote event");
            var candidate1 = _voteService.AddCandidate(voteEvent.VoteEventId, "New candidate 1");
            var candidate2 = _voteService.AddCandidate(voteEvent.VoteEventId, "New candidate 2");
            var candidate3 = _voteService.AddCandidate(voteEvent.VoteEventId, "New candidate 3");
            var user1 = _userService.RegisterUser("User 1", "xxx", UserRoleType.Voter, "User", "1");
            var user2 = _userService.RegisterUser("User 2", "xxx", UserRoleType.Voter, "User", "2");
            _voteService.LogVote(voteEvent.VoteEventId, user1.UserId, candidate1.CandidateId);
            _voteService.LogVote(voteEvent.VoteEventId, user2.UserId, candidate3.CandidateId);

            //Test
            var candidate1Result = _voteService.CanDeleteCandidate(voteEvent.VoteEventId, candidate1.CandidateId);
            var candidate2Result = _voteService.CanDeleteCandidate(voteEvent.VoteEventId, candidate2.CandidateId);
            var candidate3Result = _voteService.CanDeleteCandidate(voteEvent.VoteEventId, candidate3.CandidateId);

            //check
            Assert.IsFalse(candidate1Result, "Candidate 1 is not deletable");
            Assert.IsTrue(candidate2Result, "Candidate 2 is deletable");
            Assert.IsFalse(candidate3Result, "Candidate 3 is not deletable");           
        }

        [TestMethod]
        public void GetCandidateVotesTest()
        {
            //Set Up
            var voteEvent = _voteService.CreateVoteEvent("New vote event");
            var user1 = _userService.RegisterUser("User 1", "xxx", UserRoleType.Voter, "User", "1");
            var user2 = _userService.RegisterUser("User 2", "xxx", UserRoleType.Voter, "User", "2");
            var user3 = _userService.RegisterUser("User 3", "xxx", UserRoleType.Voter, "User", "3");
            var user4 = _userService.RegisterUser("User 4", "xxx", UserRoleType.Voter, "User", "4");
            var candidate1 = _voteService.AddCandidate(voteEvent.VoteEventId, "New candidate 1");
            var candidate2 = _voteService.AddCandidate(voteEvent.VoteEventId, "New candidate 2");
            var candidate3 = _voteService.AddCandidate(voteEvent.VoteEventId, "New candidate 3");
            var candidate4 = _voteService.AddCandidate(voteEvent.VoteEventId, "New candidate 4");
            _voteService.LogVote(voteEvent.VoteEventId, user1.UserId, candidate3.CandidateId);
            _voteService.LogVote(voteEvent.VoteEventId, user2.UserId, candidate2.CandidateId);
            _voteService.LogVote(voteEvent.VoteEventId, user3.UserId, candidate2.CandidateId);
            _voteService.LogVote(voteEvent.VoteEventId, user4.UserId, candidate1.CandidateId);

            //Test
            var candidateVotes = _voteService.GetCandidateVotes(voteEvent.VoteEventId);

            //check
            Assert.IsNotNull(candidateVotes);
            Assert.AreEqual(4, candidateVotes.Count);
            Assert.IsTrue(candidateVotes.Any(cv => cv.CandidateName == "New candidate 1" && cv.NumberOfVotes == 1), "Candidate 1 votes incorrect");
            Assert.IsTrue(candidateVotes.Any(cv => cv.CandidateName == "New candidate 2" && cv.NumberOfVotes == 2), "Candidate 2 votes incorrect");
            Assert.IsTrue(candidateVotes.Any(cv => cv.CandidateName == "New candidate 3" && cv.NumberOfVotes == 1), "Candidate 3 votes incorrect");
            Assert.IsTrue(candidateVotes.Any(cv => cv.CandidateName == "New candidate 4" && cv.NumberOfVotes == 0), "Candidate 4 votes incorrect");
        }

        [TestMethod]
        public void VoteTest()
        {
            //Test                  
            var result = _voteService.LogVote(_defaultVoteEvent.VoteEventId, _defaultUser.UserId, _defaultCandidate.CandidateId);     

            //check
            Assert.IsNotNull(result);
            Assert.IsTrue(result.VoteId > 0);
            Assert.AreEqual(_defaultVoteEvent.VoteEventId, result.VoteEventId);
            Assert.AreEqual(_defaultUser.UserId, result.UserId);
            Assert.AreEqual(_defaultCandidate.CandidateId, result.CandidateId);
        } 

        [TestMethod]
        public void CanVoteShouldBeFalseTest()
        {
            //Set Up
             _voteService.LogVote(_defaultVoteEvent.VoteEventId, _defaultUser.UserId, _defaultCandidate.CandidateId);

            //Test                  
            var result = _voteService.CanVote(_defaultVoteEvent.VoteEventId, _defaultUser.UserId);

            //check
            Assert.AreEqual(false, result);      
        }

        [TestMethod]
        public void CanVoteShouldBeTrueTest()
        {
            //Test                  
            var result = _voteService.CanVote(_defaultVoteEvent.VoteEventId, _defaultUser.UserId);

            //check
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void RevokeVoteTest()
        {
            //Set Up                   
            var addVote = _voteService.LogVote(_defaultVoteEvent.VoteEventId, _defaultUser.UserId, _defaultCandidate.CandidateId);

            //Test
            var result = _voteService.RevokeVote(_defaultVoteEvent.VoteEventId, _defaultUser.UserId);

            //check
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void RevokeVoteWhenNoVoteTest()
        {
            //Set Up                   
            //Not adding a vote

            //Test
            var result = _voteService.RevokeVote(_defaultVoteEvent.VoteEventId, _defaultUser.UserId);

            //check
            Assert.AreEqual(false, result);
        }
    }
}
