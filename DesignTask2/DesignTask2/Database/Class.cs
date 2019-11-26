using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignTask2.Database
{
    public class Class
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Hour { get; set; }
    }
}
