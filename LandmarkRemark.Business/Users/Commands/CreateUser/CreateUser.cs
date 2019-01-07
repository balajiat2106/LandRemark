using System.Threading.Tasks;
using LandmarkRemark.Application.Users.Commands.CreateUser;

namespace LandmarkRemark.Business.Users.Commands.CreateUser
{
    public class CreateUser : ICreateUser
    {
        private readonly ICreateUserCommand _createUserCommand;

        public CreateUser(ICreateUserCommand createUserCommand)
        {
            _createUserCommand = createUserCommand;
        }
        public async Task<int> Execute(CreateUserModel model)
        {
            if (string.IsNullOrEmpty(model.FirstName) ||
                    string.IsNullOrEmpty(model.LastName) ||
                        string.IsNullOrEmpty(model.UserName) ||
                            string.IsNullOrEmpty(model.Password) ||
                                string.IsNullOrEmpty(model.Email))
            {
                return -1;
            }
            else
            {
                return await _createUserCommand.Execute(model);
            }
        }
    }
}
