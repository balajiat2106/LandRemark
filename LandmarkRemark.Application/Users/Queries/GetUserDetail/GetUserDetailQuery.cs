using LandmarkRemark.Context;
using System.Threading.Tasks;

namespace LandmarkRemark.Application.Users.Queries.GetUserDetail
{
    public class GetUserDetailQuery:IGetUserDetailQuery
    {
        private readonly LandmarkRemarkContext _landmarkRemarkContext;

        public GetUserDetailQuery(LandmarkRemarkContext landmarkRemarkContext)
        {
            _landmarkRemarkContext = landmarkRemarkContext;
        }

        /// <summary>
        /// Gets user details for a specific user 
        /// </summary>
        /// <param name="id">Valid user id</param>
        /// <returns>User details</returns>
        public async Task<UserDetailModel> Execute(int id)
        {
            var entity = await _landmarkRemarkContext.Users.FindAsync(id);

            if (entity == null)
                return null;

            return new UserDetailModel
            {
                FirstName=entity.FirstName,
                LastName = entity.LastName,
                UserName = entity.UserName,
                Email=entity.Email,
                IsActive=entity.IsActive,
                CreationDate=entity.CreationDate
            };
        }
    }
}
