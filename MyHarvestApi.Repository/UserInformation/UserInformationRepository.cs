using Microsoft.EntityFrameworkCore;
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

        public void EditUserInformation(UserInformation userInformation)
        {
            _db.Entry(userInformation).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public List<UserInformation> GetInformationAboutTaskListForBoss(int id)
        {
            var infoAboutTaskList = _db.UsersInformation.Where(x => x.User.IdBoss == id)
                                                        .Include(x => x.User)
                                                        .Include(x => x.Task)
                                                        .Include(x => x.StatusOfTask).ToList();

            return infoAboutTaskList;
        }

        public List<UserInformation> GetInformationAboutTaskListForEmployee(int id)
        {
            var infoAboutTaskList = _db.UsersInformation.Where(x => x.IdUser == id)
                                                        .Include(x => x.User)
                                                        .Include(x => x.Task)
                                                        .Include(x => x.StatusOfTask).ToList();

            return infoAboutTaskList;
        }
    }
}