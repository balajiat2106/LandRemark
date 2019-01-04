using LandmarkRemark.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LandmarkRemark.Context
{
    public class LandmarkRemarkInitializer
    {
        public static void Initialize(LandmarkRemarkContext landmarkRemarkContext)
        {
            if(landmarkRemarkContext.Users.Any())
            {
                return;
            }
            SeedUsers(landmarkRemarkContext);
            SeedLocations(landmarkRemarkContext);
        }

        private static void SeedLocations(LandmarkRemarkContext landmarkRemarkContext)
        {
            var locations = new[]
            {
                new Location{Label="India",Latitude=20.66,Longitude=6.47,Remark="Variant cultures",UserId=1},
                new Location{Label="London",Latitude=20.66,Longitude=6.47,Remark="Cool and breezy",UserId=1},
                new Location{Label="Dubai",Latitude=20.66,Longitude=6.47,Remark="Humid, but rich",UserId=2},
                new Location{Label="Zimbabwe",Latitude=20.66,Longitude=6.47,Remark="Green and chill",UserId=2},
                new Location{Label="Singapore",Latitude=20.66,Longitude=6.47,Remark="Rich and great",UserId=2}
            };
            landmarkRemarkContext.Locations.AddRange(locations);

            landmarkRemarkContext.SaveChanges();
        }

        private static void SeedUsers(LandmarkRemarkContext landmarkRemarkContext)
        {
            var users = new[]
            {
                new User{FirstName="User1",LastName="_1",UserName="user11",Password="Abcd1234",Email="user11@gmail.com",CreationDate=DateTime.Now.Date,IsActive=true},
                new User{FirstName="User1",LastName="_2",UserName="user12",Password="Bcde2345",Email="user12@gmail.com",CreationDate=DateTime.Now.AddDays(2),IsActive=true},
            };
            landmarkRemarkContext.Users.AddRange(users);

            landmarkRemarkContext.SaveChanges();
        }
    }
}
