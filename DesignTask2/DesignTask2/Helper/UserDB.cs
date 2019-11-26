using DesignTask2.Database;
using DesignTask2.Interfaces;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace DesignTask2.Helper
{
    public class UserDB
    {
        private SQLiteConnection _SQLiteConnection;

        public UserDB()
        {
            _SQLiteConnection = DependencyService.Get<ISQLiteInterface>().GetSQLiteConnection();
            _SQLiteConnection.CreateTable<User>();
            _SQLiteConnection.CreateTable<Class>();
        }

        public IEnumerable<User> GetUsers()
        {
            return (from u in _SQLiteConnection.Table<User>()
                    select u).ToList();
        }
        public User GetSpecificUser(int id)
        {
            return _SQLiteConnection.Table<User>().FirstOrDefault(t => t.Id == id);
        }
        public User GetSpecificUserFromUserName(string userName1, string pwd1)
        {
            var data = _SQLiteConnection.Table<User>();
            var d1 = data.Where(x => x.name == userName1 && x.password == pwd1).FirstOrDefault();
            return d1;
        }
        public Class GetSpecificClass(int id)
        {
            return _SQLiteConnection.Table<Class>().FirstOrDefault(t => t.Id == id);
        }
        public List<Class> GetAllClassesFromUser(User user)
        {
            return _SQLiteConnection.Table<User>().FirstOrDefault(u => u.Id == user.Id).Classes.ToList();
        }
        public void DeleteUser(int id)
        {
            _SQLiteConnection.Delete<User>(id);
        }
        public string AddUser(User user)
        {
            var data = _SQLiteConnection.Table<User>();
            var d1 = data.Where(x => x.name == user.name && x.userName == user.userName).FirstOrDefault();
            if (d1 == null)
            {
                _SQLiteConnection.Insert(user);
                return "Adicionado com Sucesso";
            }
            else
                return "Email já existente";


        }
        public bool AddClass(User user, Class c)
        {
            var data = _SQLiteConnection.Table<User>();
            var classes = GetAllClassesFromUser(user);
            classes.Add(c);
            user.Classes = classes;

            _SQLiteConnection.Update(user);

            return true;
        }
        public bool updateUserValidation(string userid)
        {
            var data = _SQLiteConnection.Table<User>();
            var d1 = (from values in data
                      where values.name == userid
                      select values).Single();
            if (d1 != null)
            {
                return true;
            }
            else
                return false;
        }
        public bool updateUser(string username, string pwd)
        {
            var data = _SQLiteConnection.Table<User>();
            var d1 = (from values in data
                      where values.name == username
                      select values).Single();
            if (true)
            {
                d1.password = pwd;
                _SQLiteConnection.Update(d1);
                return true;
            }
            else
                return false;

        }

        public bool LoginValidate(string userName1, string pwd1)
        {
            var data = _SQLiteConnection.Table<User>();
            var d1 = data.Where(x => x.name == userName1 && x.password == pwd1).FirstOrDefault();

            if (d1 != null)
            {
                return true;
            }
            else
                return false;
        }

    }
}
