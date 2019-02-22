using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteveTDM
{
    public partial class TaskEditor : Form
    {
        private static Task task;
        private static int? ParentId;
        private static int? ListId;

        //constructor for editing
        public TaskEditor(Task t)
        {
            InitializeComponent();
            task = t;
            textBoxDueDate.Text = task.DueDate;
            textBoxName.Text = task.Name;
            richTextBoxDescription.Text = task.Description;
            checkBoxComplete.Checked = (task.Complete == 1);
            numericUpDownPriority.Value = task.Priority;
        }

        //constructor for new task
        public TaskEditor(int nListId)
        {
            InitializeComponent();
            ListId = nListId;
        }

        //constructor for new subtask
        public TaskEditor(int nListId, int nParentId)
        {
            InitializeComponent();
            ListId = nListId;
            ParentId = nParentId;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if(task != null)
            {
                SaveExisting();
            }
            else
            {
                SaveNew();
            }

            //after save we'll close the dialog
            this.Close();
        }

        private void SaveExisting()
        {
            using (var db = new SteveTDMDbEntities())
            {
                Task result = db.Tasks.SingleOrDefault(t => t.TaskId == task.TaskId);

                if (result != null)
                {
                    result.Name = textBoxName.Text;
                    result.Priority = Convert.ToInt32(numericUpDownPriority.Value);
                    result.DueDate = textBoxDueDate.Text;
                    result.Description = richTextBoxDescription.Text;
                    if (checkBoxComplete.Checked)
                    {
                        result.Complete = 1;
                    }
                    else
                    {
                        result.Complete = 0;
                    }
                    db.SaveChanges();
                }

                db.Dispose();
            }
        }

        private void SaveNew()
        {
            //put data into new Task object
            Task taskNew = new Task();
            taskNew.Name = textBoxName.Text;
            taskNew.Priority = Convert.ToInt32(numericUpDownPriority.Value);
            taskNew.DueDate = textBoxDueDate.Text;
            taskNew.Description = richTextBoxDescription.Text;
            switch (checkBoxComplete.Checked)
            {
                case true:
                    taskNew.Complete = 1;
                    break;
                case false:
                    taskNew.Complete = 0;
                    break;
            }

            if (task == null && ListId != null && ParentId == null)
            {
                using (var db = new SteveTDMDbEntities())
                {
                    taskNew.ListId = (long)ListId;
                    taskNew.Position = db.Tasks.Where(t => t.ListId == ListId).Select(t => t.Position).DefaultIfEmpty(-1).Max() + 1;
                    taskNew.ParentId = null;

                    db.Tasks.Add(taskNew);
                    db.SaveChanges();

                    db.Dispose();
                }
            }
            else if(ParentId != null && ListId != null)
            {
                using (var db = new SteveTDMDbEntities())
                {
                    taskNew.ListId = (long)ListId;
                    taskNew.ParentId = (long)ParentId;
                    taskNew.Position = db.Tasks.Where(t => t.ListId == ListId && t.ParentId == ParentId).Select(t => t.Position).DefaultIfEmpty(-1).Max() + 1;

                    db.Tasks.Add(taskNew);
                    db.SaveChanges();

                    db.Dispose();
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
