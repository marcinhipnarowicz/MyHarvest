using MyHarvestApi.Entity.Context;
using MyHarvestApi.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Repository
{
    public class UserInformationRepository : IUserInformationRepository
    {
        private ApplicationDbContext _db;

        public UserInformationRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void AddUserInformation(UserInformation userInformation)
        {
            _db.UsersInformation.Add(userInformation);
            _db.SaveChanges();
        }

        public List<UserInformation> GetInformationAboutTaskList(int id)
        {
            var infoAboutTaskList = _db.UsersInformation.Where(x => x.IdUser.Equals(id)).ToList();
            return infoAboutTaskList;
        }
    }
}