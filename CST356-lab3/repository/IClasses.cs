using CST356_lab3.Data.Entities;
using CST356_lab3.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CST356_lab3.repository
{
    public interface IClasses
    {
       
            Classes GetClass(int id);

            IEnumerable<Classes> GetClassesForUser(int userId);
            IEnumerable<Classes> GetAllClasses();

            void SaveClass(Classes cls);

            void UpdateClass(Classes user);

            void DeleteClass(int id);

            User GetUser(int id);

            IEnumerable<User> GetAllUsers();

            void SaveUser(User user);

            void UpdateUser(User user);

            void DeleteUser(int id);

    }
}
