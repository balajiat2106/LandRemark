using System;

namespace LandmarkRemark.Application.Users.Queries.GetUserList
{
    public class UserListModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
    }
}