namespace SDD_Project
{
    partial class TeamMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.name = new System.Windows.Forms.Label();
            this.teamID = new System.Windows.Forms.Label();
            this.task = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tasks_noSQL = new System.Windows.Forms.Label();
            this.comboBoxTasks = new System.Windows.Forms.ComboBox();
            this.commentTitle = new System.Windows.Forms.TextBox();
            this.commentDescription = new System.Windows.Forms.RichTextBox();
            this.communication_noSQL = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.taskDescription = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.PJName = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Team Member Menu";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(366, 416);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(137, 39);
            this.button2.TabIndex = 2;
            this.button2.Text = "Make Comment";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.Location = new System.Drawing.Point(413, 16);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(66, 24);
            this.name.TabIndex = 4;
            this.name.Text = "Name:";
            this.name.Click += new System.EventHandler(this.name_Click);
            // 
            // teamID
            // 
            this.teamID.AutoSize = true;
            this.teamID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teamID.Location = new System.Drawing.Point(447, 53);
            this.teamID.Name = "teamID";
            this.teamID.Size = new System.Drawing.Size(32, 24);
            this.teamID.TabIndex = 5;
            this.teamID.Text = "ID:";
            // 
            // task
            // 
            this.task.AutoSize = true;
            this.task.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.task.Location = new System.Drawing.Point(5, 246);
            this.task.Name = "task";
            this.task.Size = new System.Drawing.Size(58, 26);
            this.task.TabIndex = 6;
            this.task.Text = "Task";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(11, 424);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(134, 24);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Complete Task";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // tasks_noSQL
            // 
            this.tasks_noSQL.AutoSize = true;
            this.tasks_noSQL.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tasks_noSQL.Location = new System.Drawing.Point(4, 148);
            this.tasks_noSQL.Name = "tasks_noSQL";
            this.tasks_noSQL.Size = new System.Drawing.Size(207, 31);
            this.tasks_noSQL.TabIndex = 9;
            this.tasks_noSQL.Text = "Assigned Tasks";
            // 
            // comboBoxTasks
            // 
            this.comboBoxTasks.FormattingEnabled = true;
            this.comboBoxTasks.Location = new System.Drawing.Point(10, 218);
            this.comboBoxTasks.Name = "comboBoxTasks";
            this.comboBoxTasks.Size = new System.Drawing.Size(219, 21);
            this.comboBoxTasks.TabIndex = 10;
            this.comboBoxTasks.SelectedIndexChanged += new System.EventHandler(this.comboBoxTasks_SelectedIndexChanged);
            // 
            // commentTitle
            // 
            this.commentTitle.Location = new System.Drawing.Point(315, 219);
            this.commentTitle.Name = "commentTitle";
            this.commentTitle.Size = new System.Drawing.Size(241, 20);
            this.commentTitle.TabIndex = 11;
            this.commentTitle.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // commentDescription
            // 
            this.commentDescription.Location = new System.Drawing.Point(315, 278);
            this.commentDescription.Name = "commentDescription";
            this.commentDescription.Size = new System.Drawing.Size(241, 124);
            this.commentDescription.TabIndex = 12;
            this.commentDescription.Text = "";
            // 
            // communication_noSQL
            // 
            this.communication_noSQL.AutoSize = true;
            this.communication_noSQL.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.communication_noSQL.Location = new System.Drawing.Point(309, 148);
            this.communication_noSQL.Name = "communication_noSQL";
            this.communication_noSQL.Size = new System.Drawing.Size(247, 31);
            this.communication_noSQL.TabIndex = 13;
            this.communication_noSQL.Text = "Progress Comment";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(311, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Title:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(311, 252);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Description:";
            // 
            // taskDescription
            // 
            this.taskDescription.BackColor = System.Drawing.Color.White;
            this.taskDescription.Location = new System.Drawing.Point(10, 278);
            this.taskDescription.Name = "taskDescription";
            this.taskDescription.ReadOnly = true;
            this.taskDescription.Size = new System.Drawing.Size(219, 124);
            this.taskDescription.TabIndex = 16;
            this.taskDescription.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 20);
            this.label4.TabIndex = 17;
            this.label4.Text = "Select Task:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(179, 24);
            this.label6.TabIndex = 43;
            this.label6.Text = "Project Completion: ";
            // 
            // PJName
            // 
            this.PJName.AutoSize = true;
            this.PJName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PJName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.PJName.Location = new System.Drawing.Point(152, 54);
            this.PJName.Name = "PJName";
            this.PJName.Size = new System.Drawing.Size(204, 24);
            this.PJName.TabIndex = 42;
            this.PJName.Text = "Example Project Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(5, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 24);
            this.label7.TabIndex = 41;
            this.label7.Text = "Current Project:";
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.status.ForeColor = System.Drawing.SystemColors.ControlText;
            this.status.Location = new System.Drawing.Point(181, 91);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(45, 24);
            this.status.TabIndex = 44;
            this.status.Text = "50%\n";
            this.status.Click += new System.EventHandler(this.status_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(271, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 39);
            this.button1.TabIndex = 45;
            this.button1.Text = "Log Out";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TeamMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 482);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.PJName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.status);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.taskDescription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.communication_noSQL);
            this.Controls.Add(this.commentDescription);
            this.Controls.Add(this.commentTitle);
            this.Controls.Add(this.comboBoxTasks);
            this.Controls.Add(this.tasks_noSQL);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.task);
            this.Controls.Add(this.teamID);
            this.Controls.Add(this.name);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Name = "TeamMenu";
            this.Text = "TeamMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label teamID;
        private System.Windows.Forms.Label task;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label tasks_noSQL;
        private System.Windows.Forms.ComboBox comboBoxTasks;
        private System.Windows.Forms.TextBox commentTitle;
        private System.Windows.Forms.RichTextBox commentDescription;
        private System.Windows.Forms.Label communication_noSQL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox taskDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label PJName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Button button1;
    }
}