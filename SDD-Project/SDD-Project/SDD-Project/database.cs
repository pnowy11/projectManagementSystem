using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDD_Project
{
    public static class database
    {
        public static MySqlConnection Connection { get; set; } 
    } //allows the database connection set in Program.cs to be used everywhere in the project
}
