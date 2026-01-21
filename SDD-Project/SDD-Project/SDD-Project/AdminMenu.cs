using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SDD_Project
{
    public partial class AdminMenu : Form
    {
        private Querys.Tasks selectedTask;
        private Querys.Project selectedProject;
        private int i;

        public AdminMenu(string correctUser)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            pDesc.MaxLength = 300;
            tDesc.MaxLength = 300;

            var table = Querys.commsLog();

            var managerTable = Querys.availableManagers();

            this.dataGridView2.DataSource = managerTable;
            DataGridViewColumn manager = dataGridView2.Columns[0];
            manager.Width = 405;

            this.dataGridView1.DataSource = table;
            DataGridViewColumn column = dataGridView1.Columns[0];
            column.Width = 70;
            DataGridViewColumn column2 = dataGridView1.Columns[1];
            column2.Width = 80;
            DataGridViewColumn column3 = dataGridView1.Columns[2];
            column3.Width = 180;
            DataGridViewColumn column4 = dataGridView1.Columns[3];
            column4.Width = 80;

            var projects = Querys.ProjectQuery();
            comboBox2.DataSource = projects;

        }

        private void communication_noSQL_Click(object sender, EventArgs e)
        {

        }

        private void commentDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedProject = (Querys.Project)comboBox2.SelectedItem;

            int projectID = selectedProject.ID;
            var tasks = Querys.taskQuery(projectID);
            comboBox1.DataSource = tasks;

            int managerID = Convert.ToInt32(selectedProject.projectManager);
            string manager = Querys.ManagerName(managerID);

            var projectManagers = Querys.projectManagersQuery();
            comboBox4.DataSource = projectManagers;

            if (selectedProject != null)
            {
                pTitle.Text = selectedProject.title;
                pDesc.Text = selectedProject.description;
                pProg.Text = selectedProject.progress.ToString();
                comboBox4.Text = manager;
                if (pProg.Text == "100")
                {
                    label14.Visible = true;
                }
                else
                {
                    label14.Visible = false;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry; // "logs user out"
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTask = (Querys.Tasks)comboBox1.SelectedItem;

            string employee = Querys.employeeName(Convert.ToInt32(selectedTask.employeeID));

            if (selectedTask != null)
            {
                tDesc.Text = selectedTask.description;
                textBox1.Text = employee;

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

        private void button2_Click(object sender, EventArgs e)
        {
            var conn = database.Connection;
            conn.Open();

            string Query = "DELETE FROM project WHERE ID ='"+selectedProject.ID+"';";
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete?",
                "Confirm Choice",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
);

            if (result == DialogResult.Yes)
            {
                MySqlCommand CMD = new MySqlCommand(Query, conn);
                CMD.ExecuteNonQuery();
                conn.Close();
                this.dataGridView2.DataSource = Querys.availableManagers();
                var newProjects = Querys.ProjectQuery();
                comboBox2.DataSource = newProjects;
                MessageBox.Show("Successfully Deleted Project!");

            }
            else
            {
                conn.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var conn = database.Connection;
            conn.Open();

            string Query = "DELETE FROM projecttask WHERE title ='" + selectedTask.title + "';";

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete?",
                "Confirm Choice",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
);

            if (result == DialogResult.Yes)
            {
                MySqlCommand CMD = new MySqlCommand(Query, conn);
                CMD.ExecuteNonQuery();
                conn.Close();
                var newTasks = Querys.taskQuery(selectedProject.ID);
                comboBox1.DataSource = newTasks;
                MessageBox.Show("Successfully Deleted Task!");

            }
            else
            {
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int oldP = selectedProject.progress;
            string q1 = pTitle.Text;
            string q2 = pDesc.Text;
            int q3 = 0;
            int q4 = 0;
            if (!int.TryParse(pProg.Text, out q4))
            {
                MessageBox.Show("Invalid input. Enter a Progress Number between 100 - 0");
                return;
            }
            
            q3 = Querys.ManagerID(comboBox4.Text);

            q4 = Convert.ToInt32(pProg.Text);
            if (q4 <= 100 && q4 >= 0)
            {
                var conn = database.Connection;
                conn.Open();
                string Query = "UPDATE project SET title = '" + q1 + "', description = '" + q2 + "', ProjectManagerID = '" + q3 + "', progress = '" + q4 + "' WHERE ID = '" + selectedProject.ID + "'";

                try
                {
                    MySqlCommand CMD = new MySqlCommand(Query, conn);
                    CMD.ExecuteNonQuery();
                    MessageBox.Show("Successfully Updated Project!");
                }
                catch
                {
                    MessageBox.Show("You must select an available or the same Project Manager!");
                }
                conn.Close();
                this.dataGridView2.DataSource = Querys.availableManagers();
                var newProjects = Querys.ProjectQuery();
                comboBox2.DataSource = newProjects;
            }
            else
            {
                MessageBox.Show("Enter a Progress Number between 100 - 0");
                pProg.Text = oldP.ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string q1 = comboBox1.Text;
            string q2 = tDesc.Text;
            var conn = database.Connection;
            conn.Open();
            string Query = "UPDATE projecttask SET title = '" + q1 + "', description = '" + q2 + "', taskCompleted = '" + i + "' WHERE ID = '" + selectedTask.ID + "' ";
            MySqlCommand CMD = new MySqlCommand(Query, conn);
            CMD.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Successfully Updated Task!");
            var newTasks = Querys.taskQuery(selectedProject.ID);
            comboBox1.DataSource = newTasks;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                i = 1;
            }
            else
            {
                i = 0;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int oldP = selectedProject.progress;
            string q1 = pTitle.Text;
            string q2 = pDesc.Text;
            int q3 = 0;
            int q4 = 0;
            if (!int.TryParse(pProg.Text, out q4))
            {
                MessageBox.Show("Invalid input. Enter a Progress Number between 100 - 0");
                return;
            }

            q3 = Querys.ManagerID(comboBox4.Text);

            q4 = Convert.ToInt32(pProg.Text);
            if (q4 <= 100 && q4 >= 0)
            {
                var conn = database.Connection;
                conn.Open();
                string Query = "INSERT INTO project(title, description, ProjectManagerID, Progress) VALUES ('" + q1 + "','" + q2 + "','" + q3 + "','" + q4 + "'); ";

                try
                {
                    MySqlCommand CMD = new MySqlCommand(Query, conn);
                    CMD.ExecuteNonQuery();
                    MessageBox.Show("Successfully Created Project!");
                }
                catch
                {
                    MessageBox.Show("You must select an available Project Manager!");
                }
                conn.Close();
                this.dataGridView2.DataSource = Querys.availableManagers();
                var newProjects = Querys.ProjectQuery();
                comboBox2.DataSource = newProjects;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string q1 = comboBox1.Text;
            string q2 = tDesc.Text;
            var conn = database.Connection;
            conn.Open();
            string Query = "INSERT INTO projecttask(projectID, title, description, taskCompleted) VALUES ('" + selectedProject.ID +"','" + q1 + "','" + q2 + "','" + i + "');";
            MySqlCommand CMD = new MySqlCommand(Query, conn);
            CMD.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Successfully Updated Task!");
            var newTasks = Querys.taskQuery(selectedProject.ID);
            comboBox1.DataSource = newTasks;
        }
    }
}
