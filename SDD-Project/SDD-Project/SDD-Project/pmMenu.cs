using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SDD_Project.Querys;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace SDD_Project
{
    public partial class pmMenu : Form
    {
        private Querys.Tasks selectedTask;
        private Querys.User currentUser;
        private Querys.User selectedEmployee;
        private string progName;
        private string pProgress;
        private int projectID;
        public pmMenu(string correctUser)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            taskDescription.MaxLength = 500;

            currentUser = Querys.userQuery(correctUser);
            int PMID = Convert.ToInt32(currentUser.projectManagerID);
            string person = correctUser;
            name.Text = "Name: "+person;
            teamID.Text = "ID: "+ PMID.ToString();
            var (pID, pName, pDesc, pProg) = Querys.ProgQuery(PMID);
            label5.Text = pName;
            descProg.Text = pDesc;
            prog.Text = pProg;
            progName = pName;
            pProgress = pProg;
            projectID = pID;

            
            var taskRecievers = Querys.taskEmployeeQuery();
            var tasks = Querys.taskQuery(projectID);
            comboBoxTasks.DataSource = tasks;
            comboBox1.DataSource = taskRecievers;

            var table = Querys.commsLog();

            this.dataGridView1.DataSource = table;
            DataGridViewColumn column = dataGridView1.Columns[0];
            column.Width = 70;
            DataGridViewColumn column2 = dataGridView1.Columns[1];
            column2.Width = 80;
            DataGridViewColumn column3 = dataGridView1.Columns[2];
            column3.Width = 180;
            DataGridViewColumn column4 = dataGridView1.Columns[3];
            column4.Width = 80;

        }

        private void name_Click(object sender, EventArgs e)
        {

        }

        private void teamID_Click(object sender, EventArgs e)
        {

        }

        private void pmMenu_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry; // "logs user out"
            this.Close();
        }

        private void updateProg_Click(object sender, EventArgs e)
        {
            int NewProg;

            if (!int.TryParse(prog.Text, out NewProg))
            {
                MessageBox.Show("Invalid input. Please enter a number.");
                return;
            }

            var conn = database.Connection;
            conn.Open();

            string progUpdateQuery = "UPDATE project SET Progress = '" + NewProg + "' WHERE title = '" + progName + "'";
            if (NewProg <= 100 && NewProg >= 0)
            {
                MySqlCommand progUpdateCMD = new MySqlCommand(progUpdateQuery, conn);
                progUpdateCMD.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Successfully Updated Project Progress!");
            }
            else
            {
                MessageBox.Show("Enter a Progress Number between 100 - 0");
                prog.Text = pProgress.ToString();
            }

        }

        private void comboBoxTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTask = (Querys.Tasks)comboBoxTasks.SelectedItem;
            string userName;

            if (selectedTask != null)
            {
                userName = employeeName(Convert.ToInt32(selectedTask.employeeID));

                task.Text = selectedTask.title;
                taskDescription.Text = selectedTask.description;
                label9.Text = "Assigned to: "+userName;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedEmployee = (Querys.User)comboBox1.SelectedItem;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                string taskTitle = selectedTask.title;
                int employeeID = Convert.ToInt32(selectedEmployee.employeeID);
                Querys.assignEmployeeQuery(employeeID, taskTitle);

                var newTasks = taskQuery(projectID);
                comboBoxTasks.DataSource = newTasks;
                comboBoxTasks.DisplayMember = "title";

                MessageBox.Show("Successfully Assigned Employee!");
            }
            catch
            {
                MessageBox.Show("Invalid Input!");
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
