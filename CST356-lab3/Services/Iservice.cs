using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CST356_lab3.Data.Entities;
using CST356_lab3.ViewModel;

namespace CST356_lab3.Services
{
    public interface Iservice
    {
        ViewClassesModel GetClass(int id);

        IEnumerable<ViewClassesModel> GetClassesForUser(int userId);
        IEnumerable<Classes> GetAllClasses();

        void SaveClass(ViewClassesModel cls);

        void UpdateClass(ViewClassesModel user);

        void DeleteClass(int id);

        ViewUserModel GetUser(int id);

        IEnumerable<ViewUserModel> GetAllUsers();

        void SaveUser(ViewUserModel user);

        void UpdateUser(ViewUserModel user);

        void DeleteUser(int id);

    }
}
