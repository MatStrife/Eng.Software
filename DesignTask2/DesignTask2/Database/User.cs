using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace DesignTask2.Database
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string userName { get; set; }
        public string name { get; set; }
        [MaxLength(12)]
        public string password { get; set; }
        [ManyToOne]
        public List<Class> Classes { get; set; } = new List<Class>();

        public User()
        {

        }

    }
}
