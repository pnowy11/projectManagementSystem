using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509.SigI;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SDD_Project
{
    internal class Program
    {
        static void Main(string[] args)

        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string connString = "server=localhost;user=root;database=sdd_db;port=3306;password=;"; //database connection string
            database.Connection = new MySqlConnection(connString);
            var conn = database.Connection; //creates connection
            int permission = 0;
            string correctUser = "";

            Login(permission, correctUser);


        }
        static void Menu(int permission, string correctUser)
        {
            bool showLoginAgain = false;
            switch (permission)
            {
                case 1:
                    TeamMenu teamMenu = new TeamMenu(correctUser);
                    if (teamMenu.ShowDialog() == DialogResult.Retry)
                    {
                        showLoginAgain = true;
                    }
                    break;
                case 2:
                    pmMenu pmm = new pmMenu(correctUser);
                    if (pmm.ShowDialog() == DialogResult.Retry)
                    {
                        showLoginAgain = true;
                    }
                    break;
                case 3:
                    AdminMenu aMenu = new AdminMenu(correctUser);
                    if (aMenu.ShowDialog() == DialogResult.Retry)
                    {
                        showLoginAgain = true;
                    }
                    break;

            }
            if (showLoginAgain)
            {
                Login(0, ""); // Reset and restart login
            }
        }
        static void Login(int permission, string correctUser)
        {
            var conn = database.Connection; //creates connection
            Login loginForm = new Login(); // initializes the Login form

            while (permission == 0) //keeps the form open until a correct login is made
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    correctUser = loginForm.person;
                    try
                    {
                        conn.Open(); //opens connection
                        string userQuery = "SELECT role FROM user WHERE userName = '" + loginForm.person + "'"; //SQL query
                        MySqlCommand cmd2 = new MySqlCommand(userQuery, conn); //SQL command utilizing the query
                        MySqlDataReader reader = cmd2.ExecuteReader();//executing query
                        if (reader.Read())
                        {
                            string role = reader[0].ToString();
                            if (role == "Admin")
                            {
                                permission = 3;
                            }
                            else if (role == "projectManager")
                            {
                                permission = 2;
                            }
                            else if (role == "teamMember")
                            {
                                permission = 1; //sets permission for the rest of the application
                            }
                            //Console.WriteLine("\nWelcome: " + reader[0] + " Role: " + reader[1] + "\n");
                        }
                        else
                        {
                            loginForm.ShowError("Incorrect User or Role"); //displays error for when a user enters the wrong login
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    return; // Exit if user closes or cancels
                }
            }
            conn.Close();
            Menu(permission, correctUser);
        }
    }
}

