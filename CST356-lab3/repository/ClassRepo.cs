using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CST356_lab3.Data.Entities;
using CST356_lab3.Data;
using CST356_lab3.ViewModel;

namespace CST356_lab3.repository
{
    public class ClassRepo : IClasses
    {
        private readonly AppDb _db;

         public ClassRepo(AppDb DB)
        {
            _db = new AppDb();
            _db = DB;
        }

        public void DeleteClass(int id)
        {
            var cls = _db.Classes.Find(id);

            if (cls == null) return;

            _db.Classes.Remove(cls);
            _db.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = _db.Users.Find(id);

            if (user == null) return;

            _db.Users.Remove(user);
            _db.SaveChanges();
        }

        public IEnumerable<Classes> GetAllClasses()
        {
            return _db.Classes.ToList();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _db.Users;
        }

        public Classes GetClass(int id)
        {
            return _db.Classes.Find(id);
        }

        public IEnumerable<Classes> GetClassesForUser(int userId)
        {
            return _db.Classes.Where(cls => cls.UserId == userId).ToList();
        }

        public User GetUser(int id)
        {
            return _db.Users.Find(id);
        }

        public void SaveClass(Classes cls)
        {
            _db.Classes.Add(cls);

            _db.SaveChanges();
        }

        public void SaveUser(User user)
        {
            _db.Users.Add(user);

            _db.SaveChanges();
        }

        public void UpdateClass(Classes user)
        {
            _db.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _db.SaveChanges();
        }
    }
}