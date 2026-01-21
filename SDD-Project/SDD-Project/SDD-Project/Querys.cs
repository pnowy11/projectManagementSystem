using Google.Protobuf.Compiler;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static SDD_Project.Querys;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SDD_Project
{
    internal class Querys
    {
        public static Querys.User userQuery(string correctUser)
        {
            string query = "SELECT * FROM user WHERE userName = '" + correctUser + "'";
            User currentUser = new User();
            var conn = database.Connection;
            conn.Open();

            MySqlCommand CMD = new MySqlCommand(query, conn);
            MySqlDataReader Reader = CMD.ExecuteReader();
            if (Reader.Read())
            {
                currentUser.username = Reader[1].ToString();
                currentUser.role = Reader[2].ToString();
                if (!Reader.IsDBNull(3)){currentUser.employeeID = Convert.ToInt32(Reader[3]);}
                else{currentUser.employeeID = null;}
                if (!Reader.IsDBNull(4)){currentUser.projectManagerID = Convert.ToInt32(Reader[4]);}
                else{currentUser.projectManagerID = null;}
            }
            Reader.Close();
            conn.Close();
            return currentUser;
        }
        public static List<Project> ProjectQuery()
        {
            var conn = database.Connection;
            conn.Open();

            string pjQuery = "SELECT * FROM project";

            MySqlCommand pjCMD = new MySqlCommand(pjQuery, conn);
            MySqlDataReader pReader = pjCMD.ExecuteReader();

            List<Querys.Project> projects = new List<Querys.Project>();

            while (pReader.Read())
            {
                projects.Add(new Querys.Project
                {
                    ID = Convert.ToInt32(pReader[0]),
                    title = pReader[1].ToString(),
                    description = pReader[2].ToString(),
                    projectManager = Convert.ToInt32(pReader[3]),
                    progress = Convert.ToInt32(pReader[4].ToString())

                });
            }
            pReader.Close();
            conn.Close();
            return projects;

        }
        public static (int, string, string, string) ProgQuery(int PMID)
        {
            var conn = database.Connection;
            conn.Open();

            string pjQuery = "SELECT ID, title, description, progress FROM project WHERE ProjectManagerID = '" + PMID + "'";

            MySqlCommand pjCMD = new MySqlCommand(pjQuery, conn);
            MySqlDataReader pReader = pjCMD.ExecuteReader();
            int ID = 0;
            string projectName = "";
            string description = "";
            string progress = "";

            if (pReader.Read())
            {
                ID = Convert.ToInt32(pReader[0]);
                projectName = pReader[1].ToString();
                description = pReader[2].ToString();
                progress = pReader[3].ToString();
            }

            pReader.Close();
            conn.Close();
            return (ID,projectName,description, progress);
        }
        public static List<User> taskEmployeeQuery()
        {
            string Query = "SELECT userName, employeeID FROM user WHERE role = 'teamMember'";

            var conn = database.Connection;
            conn.Open();

            MySqlCommand CMD = new MySqlCommand(Query, conn);
            MySqlDataReader tReader = CMD.ExecuteReader();

            List<Querys.User> taskRecievers = new List<Querys.User>();

            while (tReader.Read())
            {
                taskRecievers.Add(new Querys.User
                {
                    username = tReader[0].ToString(),
                    employeeID = Convert.ToInt32(tReader[1]),

                });
            }
            tReader.Close();
            conn.Close();
            return taskRecievers;
        }
        public static List<User> projectManagersQuery()
        {
            string Query = "SELECT userName, projectManagerID FROM user WHERE role = 'projectManager'";

            var conn = database.Connection;
            conn.Open();

            MySqlCommand CMD = new MySqlCommand(Query, conn);
            MySqlDataReader tReader = CMD.ExecuteReader();

            List<Querys.User> projectManagers = new List<Querys.User>();

            while (tReader.Read())
            {
                projectManagers.Add(new Querys.User
                {
                    username = tReader[0].ToString(),
                    projectManagerID = Convert.ToInt32(tReader[1]),

                });
            }
            tReader.Close();
            conn.Close();
            return projectManagers;
        }
        public static List<Tasks> taskQuery(int ProjID)
        {
            string taskQuery = "SELECT ID, title, description, taskCompleted, employeeID FROM projecttask WHERE projectID = '" + ProjID + "'";

            var conn = database.Connection;
            conn.Open();

            MySqlCommand taskCMD = new MySqlCommand(taskQuery, conn);
            MySqlDataReader tReader = taskCMD.ExecuteReader();

            List<Querys.Tasks> tasks = new List<Querys.Tasks>();

            while (tReader.Read())
            {
                int? employeeID = null;
                if (!tReader.IsDBNull(4)) { employeeID = Convert.ToInt32(tReader[4]); } else { employeeID = null; }

                tasks.Add(new Querys.Tasks
                {
                    ID = Convert.ToInt32(tReader[0]),
                    title = tReader[1].ToString(),
                    description = tReader[2].ToString(),
                    completedInt = Convert.ToInt32(tReader[3]),
                    employeeID = employeeID

                });
            }
            tReader.Close();
            conn.Close();
            return tasks;
        }
        public static DataTable commsLog()
        {
            var conn = database.Connection;
            conn.Open();
            string Query = "SELECT creator, title, description, date FROM communication ORDER BY date DESC";

            MySqlCommand CMD = new MySqlCommand(Query, conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(CMD);

            var table = new DataTable();
            adapter.Fill(table);
            conn.Close();

            return table;
        }
        public static DataTable availableManagers()
        {
            var conn = database.Connection;
            conn.Open();

            string Query = "SELECT userName FROM user WHERE role = 'projectManager'AND projectManagerID NOT IN(SELECT projectManagerID FROM project); ";

            MySqlCommand CMD = new MySqlCommand(Query, conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(CMD);

            var table = new DataTable();
            adapter.Fill(table);
            conn.Close();

            return table;
        }
        public static string employeeName(int employeeID)
        {
            var conn = database.Connection;
            conn.Open();

            string Query = "SELECT userName FROM user WHERE employeeID = '" + employeeID + "'";

            MySqlCommand pjCMD = new MySqlCommand(Query, conn);
            MySqlDataReader pReader = pjCMD.ExecuteReader();
            string userName = "";

            if (pReader.Read())
            {
                userName = pReader[0].ToString();
            }

            pReader.Close();
            conn.Close();
            return userName;
        }
        public static string ManagerName(int managerID)
        {
            var conn = database.Connection;
            conn.Open();

            string Query = "SELECT userName FROM user WHERE projectManagerID = '" + managerID + "'";

            MySqlCommand pjCMD = new MySqlCommand(Query, conn);
            MySqlDataReader pReader = pjCMD.ExecuteReader();
            string userName = "";

            if (pReader.Read())
            {
                userName = pReader[0].ToString();
            }

            pReader.Close();
            conn.Close();
            return userName;
        }
        public static int ManagerID(string name)
        {
            var conn = database.Connection;
            conn.Open();

            string Query = "SELECT projectManagerID FROM user WHERE userName = '" + name + "'";

            MySqlCommand pjCMD = new MySqlCommand(Query, conn);
            MySqlDataReader pReader = pjCMD.ExecuteReader();
            int ID = 0;

            if (pReader.Read())
            {
                ID = Convert.ToInt32(pReader[0]);
            }

            pReader.Close();
            conn.Close();
            return ID;
        }
        public static int EmployeeID(string name)
        {
            var conn = database.Connection;
            conn.Open();

            string Query = "SELECT employeeID FROM user WHERE userName = '" + name + "'";

            MySqlCommand pjCMD = new MySqlCommand(Query, conn);
            MySqlDataReader pReader = pjCMD.ExecuteReader();
            int ID = 0;

            if (pReader.Read())
            {
                ID = Convert.ToInt32(pReader[0]);
            }

            pReader.Close();
            conn.Close();
            return ID;
        }

        public static void assignEmployeeQuery(int employeeID, string taskTitle)
        {
            var conn = database.Connection;
            conn.Open();

            string Query = "UPDATE projecttask SET employeeID = '" + employeeID + "' WHERE title = '" + taskTitle + "'";

            MySqlCommand CMD = new MySqlCommand(Query, conn);
            CMD.ExecuteNonQuery();

            conn.Close();
        }

        public class User
        {
            public string username;
            public string role;
            public int? employeeID;
            public int? projectManagerID;//int? serves as a nullable int meaning employeeID and etc can be null
            public override string ToString()
            {
                return username;
            }

        }
        public class Project
        {
            public int ID;
            public string title;
            public string description;
            public int projectManager;
            public int progress;
            public override string ToString()
            {
                return ID.ToString();
            }

        }
        public class Tasks
        {
            public int ID;
            public int projectID;
            public string title;
            public string description;
            public int completedInt;
            public int? employeeID;
            public override string ToString()
            {
                return (title);
            }
        }
    }
}
