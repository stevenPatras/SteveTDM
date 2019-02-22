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
    public partial class ListEditor : Form
    {
        private static Todo todo;

        //Constructor for modifying existing Todo
        public ListEditor(Todo td)
        {
            InitializeComponent();
            textBoxName.Text = td.Name;
            numericUpDownPriority.Value = td.Priority;
            textBoxDueDate.Text = td.Duedate;
            richTextBoxDescription.Text = td.Description;
            checkBoxComplete.Checked = Convert.ToBoolean(td.Hidden);

            using (var db = new SteveTDMDbEntities())
            {
                int nTotalTasks = db.Tasks.Where(t => t.ListId == td.ListId).Count();
                int nCompletedTasks = db.Tasks.Where(t => t.ListId == td.ListId && t.Complete == 1).Count();

                progressBarTodo.Minimum = 0;
                progressBarTodo.Maximum = nTotalTasks;
                progressBarTodo.Value = nCompletedTasks;
            }

            todo = td;
        }

        //Constructor for creating a new Todo
        public ListEditor()
        {
            InitializeComponent();
            checkBoxComplete.Enabled = false;
            todo = null;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            //Save Todo we were passed or create a new entry
            if(todo != null)
            {
                SaveExisting();
            }
            else
            {
                SaveNew();
            }

            this.Close();
        }

        //function to save existing items
        private void SaveExisting()
        {
            using (var db = new SteveTDMDbEntities())
            {
                Todo result = db.Todos.SingleOrDefault(t => t.ListId == todo.ListId);

                if (result != null)
                {
                    result.Name = textBoxName.Text;
                    result.Priority = Convert.ToInt32(numericUpDownPriority.Value);
                    result.Duedate = textBoxDueDate.Text;
                    result.Description = richTextBoxDescription.Text;
                    if (checkBoxComplete.Checked)
                    {
                        result.Hidden = 1;
                    }
                    else
                    {
                        result.Hidden = 0;
                    }
                    db.SaveChanges();
                }

                db.Dispose();
            }
        }

        //Function to save new items
        private void SaveNew()
        {
            using (var db = new SteveTDMDbEntities())
            {
                Todo todoNew = new Todo();
                todoNew.Name = textBoxName.Text;
                todoNew.Priority = Convert.ToInt32(numericUpDownPriority.Value);
                todoNew.Duedate = textBoxDueDate.Text;
                todoNew.Description = richTextBoxDescription.Text;
                todoNew.Position = db.Todos.Max(p => p.Position + 1);
                switch (checkBoxComplete.Checked)
                {
                    case true:
                        todoNew.Hidden = 1;
                        break;
                    case false:
                        todoNew.Hidden = 0;
                        break;
                }
                db.Todos.Add(todoNew);
                db.SaveChanges();

                db.Dispose();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
