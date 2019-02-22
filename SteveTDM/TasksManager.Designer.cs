namespace SteveTDM
{
    partial class TasksManager
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
            this.groupBoxTasks = new System.Windows.Forms.GroupBox();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonMoveDown = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonMoveUp = new System.Windows.Forms.Button();
            this.treeViewTasks = new System.Windows.Forms.TreeView();
            this.buttonAddSubTask = new System.Windows.Forms.Button();
            this.buttonAddTask = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            this.labelDuedate = new System.Windows.Forms.Label();
            this.textBoxDueDate = new System.Windows.Forms.TextBox();
            this.numericUpDownPriority = new System.Windows.Forms.NumericUpDown();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.progressBarTodo = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelPriority = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.treeViewCompleted = new System.Windows.Forms.TreeView();
            this.groupBoxTasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPriority)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxTasks
            // 
            this.groupBoxTasks.Controls.Add(this.treeViewCompleted);
            this.groupBoxTasks.Controls.Add(this.label3);
            this.groupBoxTasks.Controls.Add(this.label2);
            this.groupBoxTasks.Controls.Add(this.buttonEdit);
            this.groupBoxTasks.Controls.Add(this.buttonRefresh);
            this.groupBoxTasks.Controls.Add(this.buttonMoveDown);
            this.groupBoxTasks.Controls.Add(this.buttonDelete);
            this.groupBoxTasks.Controls.Add(this.buttonMoveUp);
            this.groupBoxTasks.Controls.Add(this.treeViewTasks);
            this.groupBoxTasks.Controls.Add(this.buttonAddSubTask);
            this.groupBoxTasks.Controls.Add(this.buttonAddTask);
            this.groupBoxTasks.Location = new System.Drawing.Point(12, 66);
            this.groupBoxTasks.Name = "groupBoxTasks";
            this.groupBoxTasks.Size = new System.Drawing.Size(727, 383);
            this.groupBoxTasks.TabIndex = 7;
            this.groupBoxTasks.TabStop = false;
            this.groupBoxTasks.Text = "Tasks";
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(646, 93);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(75, 23);
            this.buttonEdit.TabIndex = 13;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(646, 209);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
            this.buttonRefresh.TabIndex = 12;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonMoveDown
            // 
            this.buttonMoveDown.Location = new System.Drawing.Point(646, 180);
            this.buttonMoveDown.Name = "buttonMoveDown";
            this.buttonMoveDown.Size = new System.Drawing.Size(75, 23);
            this.buttonMoveDown.TabIndex = 11;
            this.buttonMoveDown.Text = "Move Down";
            this.buttonMoveDown.UseVisualStyleBackColor = true;
            this.buttonMoveDown.Click += new System.EventHandler(this.buttonMoveDown_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(646, 122);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonMoveUp
            // 
            this.buttonMoveUp.Location = new System.Drawing.Point(646, 151);
            this.buttonMoveUp.Name = "buttonMoveUp";
            this.buttonMoveUp.Size = new System.Drawing.Size(75, 23);
            this.buttonMoveUp.TabIndex = 10;
            this.buttonMoveUp.Text = "Move Up";
            this.buttonMoveUp.UseVisualStyleBackColor = true;
            this.buttonMoveUp.Click += new System.EventHandler(this.buttonMoveUp_Click);
            // 
            // treeViewTasks
            // 
            this.treeViewTasks.Location = new System.Drawing.Point(232, 35);
            this.treeViewTasks.Name = "treeViewTasks";
            this.treeViewTasks.Size = new System.Drawing.Size(403, 342);
            this.treeViewTasks.TabIndex = 1;
            this.treeViewTasks.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewTasks_AfterSelect);
            // 
            // buttonAddSubTask
            // 
            this.buttonAddSubTask.Location = new System.Drawing.Point(641, 64);
            this.buttonAddSubTask.Name = "buttonAddSubTask";
            this.buttonAddSubTask.Size = new System.Drawing.Size(80, 23);
            this.buttonAddSubTask.TabIndex = 9;
            this.buttonAddSubTask.Text = "Add SubTask";
            this.buttonAddSubTask.UseVisualStyleBackColor = true;
            this.buttonAddSubTask.Click += new System.EventHandler(this.buttonAddSubTask_Click);
            // 
            // buttonAddTask
            // 
            this.buttonAddTask.Location = new System.Drawing.Point(646, 35);
            this.buttonAddTask.Name = "buttonAddTask";
            this.buttonAddTask.Size = new System.Drawing.Size(75, 23);
            this.buttonAddTask.TabIndex = 8;
            this.buttonAddTask.Text = "Add Task";
            this.buttonAddTask.UseVisualStyleBackColor = true;
            this.buttonAddTask.Click += new System.EventHandler(this.buttonAddTask_Click);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(4, 20);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(35, 13);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Name";
            // 
            // labelDuedate
            // 
            this.labelDuedate.AutoSize = true;
            this.labelDuedate.Location = new System.Drawing.Point(546, 20);
            this.labelDuedate.Name = "labelDuedate";
            this.labelDuedate.Size = new System.Drawing.Size(53, 13);
            this.labelDuedate.TabIndex = 2;
            this.labelDuedate.Text = "Due Date";
            // 
            // textBoxDueDate
            // 
            this.textBoxDueDate.Enabled = false;
            this.textBoxDueDate.Location = new System.Drawing.Point(605, 17);
            this.textBoxDueDate.Name = "textBoxDueDate";
            this.textBoxDueDate.Size = new System.Drawing.Size(116, 20);
            this.textBoxDueDate.TabIndex = 3;
            // 
            // numericUpDownPriority
            // 
            this.numericUpDownPriority.Enabled = false;
            this.numericUpDownPriority.Location = new System.Drawing.Point(487, 18);
            this.numericUpDownPriority.Name = "numericUpDownPriority";
            this.numericUpDownPriority.Size = new System.Drawing.Size(46, 20);
            this.numericUpDownPriority.TabIndex = 2;
            // 
            // textBoxName
            // 
            this.textBoxName.Enabled = false;
            this.textBoxName.Location = new System.Drawing.Point(45, 17);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(216, 20);
            this.textBoxName.TabIndex = 0;
            // 
            // progressBarTodo
            // 
            this.progressBarTodo.Enabled = false;
            this.progressBarTodo.Location = new System.Drawing.Point(317, 14);
            this.progressBarTodo.Name = "progressBarTodo";
            this.progressBarTodo.Size = new System.Drawing.Size(120, 23);
            this.progressBarTodo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(267, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Progress";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.progressBarTodo);
            this.groupBox1.Controls.Add(this.textBoxName);
            this.groupBox1.Controls.Add(this.numericUpDownPriority);
            this.groupBox1.Controls.Add(this.textBoxDueDate);
            this.groupBox1.Controls.Add(this.labelDuedate);
            this.groupBox1.Controls.Add(this.labelPriority);
            this.groupBox1.Controls.Add(this.labelName);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(727, 47);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "List Details";
            // 
            // labelPriority
            // 
            this.labelPriority.AutoSize = true;
            this.labelPriority.Location = new System.Drawing.Point(443, 20);
            this.labelPriority.Name = "labelPriority";
            this.labelPriority.Size = new System.Drawing.Size(38, 13);
            this.labelPriority.TabIndex = 1;
            this.labelPriority.Text = "Priority";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(229, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "UnCompleted";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Completed";
            // 
            // treeViewCompleted
            // 
            this.treeViewCompleted.Location = new System.Drawing.Point(9, 35);
            this.treeViewCompleted.Name = "treeViewCompleted";
            this.treeViewCompleted.Size = new System.Drawing.Size(160, 342);
            this.treeViewCompleted.TabIndex = 16;
            // 
            // TasksManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 457);
            this.Controls.Add(this.groupBoxTasks);
            this.Controls.Add(this.groupBox1);
            this.Name = "TasksManager";
            this.Text = "TasksManager";
            this.groupBoxTasks.ResumeLayout(false);
            this.groupBoxTasks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPriority)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBoxTasks;
        private System.Windows.Forms.TreeView treeViewTasks;
        private System.Windows.Forms.Button buttonAddTask;
        private System.Windows.Forms.Button buttonAddSubTask;
        private System.Windows.Forms.Button buttonMoveUp;
        private System.Windows.Forms.Button buttonMoveDown;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelDuedate;
        private System.Windows.Forms.TextBox textBoxDueDate;
        private System.Windows.Forms.NumericUpDown numericUpDownPriority;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.ProgressBar progressBarTodo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelPriority;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.TreeView treeViewCompleted;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}