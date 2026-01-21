using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Tsp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SDD_Project
{
    public partial class TeamMenu : Form
    {
        private Querys.Tasks selectedTask;
        private string correctUser;
        public TeamMenu(string user)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += TeamMenu_Load;
            correctUser = user;

        }
        private void TeamMenu_Load(object sender, EventArgs e)
        {
            tQuerry();
            PJQuery();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var conn = database.Connection;
            string finalDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            conn.Open();
            try
            {
                if (commentTitle.Text.Length > 0 && commentDescription.Text.Length > 0)
                {
                    string commentQuery = "INSERT INTO communication (title, description, date, creator) VALUES ('" + commentTitle.Text + "', '" + commentDescription.Text + "','" + finalDate + "','" + correctUser + "' );";
                    MySqlCommand commentCMD = new MySqlCommand(commentQuery, conn);
                    commentCMD.ExecuteNonQuery();
                    MessageBox.Show("Successfully Commented!");
                    commentTitle.Clear();
                    commentDescription.Clear();
                }
                else
                {
                    MessageBox.Show("You must enter a Title and Description first!");
                }
            }
            catch {
                MessageBox.Show("SQL/Logic Error");
            }
            conn.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void name_Click(object sender, EventArgs e)
        {
        }

        private void comboBoxTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTask = (Querys.Tasks)comboBoxTasks.SelectedItem;

            if (selectedTask != null)
            {
                task.Text = selectedTask.title;
                taskDescription.Text = selectedTask.description;
                PJQuery();
                if (selectedTask.completedInt == 0)
                {
                    checkBox1.CheckState = CheckState.Unchecked;
                }
                else
                {
                    checkBox1.CheckState = CheckState.Checked;
                }
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            int i;
            if (checkBox1.Checked)
            {
                i = 1;
            }
            else
            {
                i = 0;
            }
            var conn = database.Connection;
            conn.Open();
            string taskUpdateQuery = "UPDATE projecttask SET taskCompleted = '"+i+"' WHERE title = '" +selectedTask.title+"'";
            MySqlCommand taskUpdateCMD = new MySqlCommand(taskUpdateQuery, conn);
            taskUpdateCMD.ExecuteNonQuery();
            conn.Close();
        }
        private void PJQuery()
        {
            var conn = database.Connection;
            conn.Open();
            string pjQuery = "SELECT title, progress FROM project WHERE ID = '" + selectedTask.projectID + "'";
            MySqlCommand pjCMD = new MySqlCommand(pjQuery, conn);
            MySqlDataReader pReader = pjCMD.ExecuteReader();
            string projectName;
            string progress;

            if (pReader.Read())
            {
                projectName = pReader[0].ToString();
                progress = pReader[1].ToString();
            }
            else
            {
                return;
            }
            PJName.Text = projectName;
            status.Text = progress + "%";
            pReader.Close();
            conn.Close();
        }
        private object tQuerry()
        {
            int ID = uQuerry();
            string taskQuery = "SELECT projectID, title, description, taskCompleted FROM projecttask WHERE employeeID = '" + ID + "'";

            var conn = database.Connection;
            conn.Open();

            MySqlCommand taskCMD = new MySqlCommand(taskQuery, conn);
            MySqlDataReader tReader = taskCMD.ExecuteReader();

            List<Querys.Tasks> tasks = new List<Querys.Tasks>();

            while (tReader.Read())
            {
                tasks.Add(new Querys.Tasks
                {
                    projectID = Convert.ToInt32(tReader[0]),
                    title = tReader[1].ToString(),
                    description = tReader[2].ToString(),
                    completedInt = Convert.ToInt32(tReader[3]),

                });
            }
            tReader.Close();
            conn.Close();
            comboBoxTasks.DataSource = tasks;
            return tasks;
        }
        private int uQuerry()
        {
            string userQuery = "SELECT employeeID FROM user WHERE userName = '" + correctUser + "'";
            int ID = 0;

            var conn = database.Connection;
            conn.Open();

            MySqlCommand userCMD = new MySqlCommand(userQuery, conn);
            MySqlDataReader uReader = userCMD.ExecuteReader();
            if (uReader.Read())
            {
                ID = Convert.ToInt32(uReader[0]);
            }
            name.Text = "Name: " + correctUser;
            teamID.Text = "ID: " + ID.ToString();
            uReader.Close();
            conn.Close();
            return ID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry; // "logs user out"
            this.Close();
        }

        private void status_Click(object sender, EventArgs e)
        {

        }
    }
}
