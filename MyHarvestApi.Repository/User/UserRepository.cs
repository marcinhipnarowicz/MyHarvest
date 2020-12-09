using MyHarvestApi.Entity.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHarvestApi.Entity.Model;

namespace MyHarvestApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public User GetUserByEmail(string email)
        {
            var user = _db.Users.FirstOrDefault(u => u.Email.Equals(email));//napisz w pracy różnicę pomiędzy == a Equals()
            return user;
        }

        public List<User> GetUsers()
        {
            var usersDb = _db.Users.ToList();
            return usersDb;
        }
    }
}