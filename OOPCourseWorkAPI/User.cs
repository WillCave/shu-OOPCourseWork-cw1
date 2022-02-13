using Dapper.Contrib.Extensions;
using System;

namespace OOPCourseWorkAPI
{

    public enum UserRoleType
    {
        Admin = 1,
        Audit = 2,
        Voter = 3
    }
    public class User
    {
        [Key]
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public UserRoleType UserRole { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime EntryDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }
    }
}
