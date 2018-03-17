using System;
using System.Collections.Generic;
using CST356_lab3.Data;
using CST356_lab3.Data.Entities;
using CST356_lab3.repository;
using CST356_lab3.ViewModel;

namespace CST356_lab3.Services
{
    public class Service : Iservice
    {
        private readonly IClasses _Iclasses;
        
        public Service(IClasses Iclasses)
        {
            // var _db = new AppDb();
            //_Iclasses = new ClassRepo(_db);
            _Iclasses = Iclasses;
        }
        public void DeleteClass(int id)
        {
            _Iclasses.DeleteClass(id);
        }

        public void DeleteUser(int id)
        {
            _Iclasses.DeleteUser(id);
        }

        public IEnumerable<ViewUserModel> GetAllUsers()
        {
            var userViewModels = new List<ViewUserModel>();

            var _us = _Iclasses.GetAllUsers();
            foreach (var us in _us)
            {
                userViewModels.Add(MapToUserViewModel(us));
            }

            return userViewModels;
        }

        public ViewClassesModel GetClass(int id)
        {
            var pet = _Iclasses.GetClass(id);
            return MapToClassViewModel(pet);
        }

        public IEnumerable<ViewClassesModel> GetClassesForUser(int userId)
        {
            var ClassesViewModel = new List<ViewClassesModel>();

            var classes = _Iclasses.GetClassesForUser(userId);

            foreach (var cls in classes)
            {
                ClassesViewModel.Add(MapToClassViewModel(cls));
            }

            return ClassesViewModel;
        }

        public ViewUserModel GetUser(int id)
        {
            var user = _Iclasses.GetUser(id);

            return (MapToUserViewModel(user));
        }

        public void SaveClass(ViewClassesModel cls)
        {
            var Class = MapToClass(cls);

            _Iclasses.SaveClass(Class);
        }

        public void SaveUser(ViewUserModel user)
        {
            _Iclasses.SaveUser(MapToUser(user));
        }

        public void UpdateClass(ViewClassesModel viewclass)
        {
            var upclass = _Iclasses.GetClass(viewclass.Id);

            CopyToClass(viewclass, upclass);

            _Iclasses.UpdateClass(upclass);
        }
        public double CheckClassDelta(ViewClassesModel viewclass)
        {
            double delta = (viewclass.EndDate - viewclass.StartDate).TotalDays;

            return delta;
        }

        public void UpdateUser(ViewUserModel uvm)
        {
            var user = _Iclasses.GetUser(uvm.Id);
            CopyToUser(uvm, user);

            _Iclasses.UpdateUser(user);
        }
        private Classes MapToClass(ViewClassesModel ViewModel)
        {
            return new Classes
            {
                Id = ViewModel.Id,
                ClassName = ViewModel.ClassName,
                StartDate = ViewModel.StartDate,
                EndDate = ViewModel.EndDate,
                CRN = ViewModel.CRN,
                UserId = ViewModel.UserId
            };
        }

        private ViewClassesModel MapToClassViewModel(Classes Class)
        {
            return new ViewClassesModel
            {
                Id = Class.Id,
                ClassName = Class.ClassName,
                StartDate = Class.StartDate,
                EndDate = Class.EndDate,
                CRN = Class.CRN,
                UserId = Class.UserId
            };
        }
        private User MapToUser(ViewUserModel userViewModel)
        {
            return new User
            {
                Id = userViewModel.Id,
                FirstName = userViewModel.FirstName,
                MiddleName = userViewModel.MiddleName,
                LastName = userViewModel.LastName,
                EmailAddress = userViewModel.EmailAddress,
                GraduationDate = userViewModel.GraduationDate,
                YearsInSchool = userViewModel.YearsInSchool,
                Age = userViewModel.Age
            };
        }

        private ViewUserModel MapToUserViewModel(User user)
        {
            return new ViewUserModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                EmailAddress = user.EmailAddress,
                GraduationDate = user.GraduationDate,
                YearsInSchool = user.YearsInSchool,
                Age = user.Age
            };
        }

        private void CopyToUser(ViewUserModel userViewModel, User user)
        {
            user.FirstName = userViewModel.FirstName;
            user.MiddleName = userViewModel.MiddleName;
            user.LastName = userViewModel.LastName;
            user.EmailAddress = userViewModel.EmailAddress;
            user.GraduationDate = userViewModel.GraduationDate;
            user.YearsInSchool = userViewModel.YearsInSchool;
            user.Age = userViewModel.Age;
        }
        private void CopyToClass(ViewClassesModel vcm, Classes cls)
        {
            cls.ClassName = vcm.ClassName;
            cls.CRN = vcm.CRN;
            cls.EndDate = vcm.EndDate;
            cls.StartDate = vcm.StartDate;
            cls.Id = vcm.Id;
            cls.UserId = vcm.UserId;
        }

        public IEnumerable<Classes> GetAllClasses()
        {
            return _Iclasses.GetAllClasses();
        }
    }
}