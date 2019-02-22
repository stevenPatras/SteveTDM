using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Data.SQLite;
using System.Configuration;

namespace SteveTDM
{
    public partial class wndTodoLists : Form
    {
        private static List<Todo> listTodo = new List<Todo>();

        public wndTodoLists()
        {
            InitializeComponent();
            PopulateList();
        }

        private void listTodoLists_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //EditTodo();
            ManageTasks();
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            if(listviewTodoLists.SelectedItems.Count > 0)
            {
                using (var db = new SteveTDMDbEntities())
                {
                    var item = listviewTodoLists.SelectedItems[0];
                    db.Todos.Remove(db.Todos.Find(listTodo[item.Index].ListId));
                    db.SaveChanges();

                    db.Dispose();
                }
            }

            //Refresh list after removing item
            PopulateList();
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            ListEditor listEditor = new ListEditor();
            listEditor.ShowDialog();

            PopulateList();
        }

        private void butMoveDown_Click(object sender, EventArgs e)
        {
            //make sure something is selected before attempting
            if (listviewTodoLists.SelectedItems.Count > 0)
            {
                var item = listviewTodoLists.SelectedItems[0];
                //check to make sure its not the bottom item in the list (count doesn't start at 0)
                if (item.Index != listviewTodoLists.Items.Count - 1)
                {
                    //we move the item below up and this item down
                    SwapPosition(item.Index + 1, item.Index);
                }
            }

            PopulateList();
        }

        private void butMoveUp_Click(object sender, EventArgs e)
        {
            //make sure something is selected before attempting
            if (listviewTodoLists.SelectedItems.Count > 0)
            {
                var item = listviewTodoLists.SelectedItems[0];
                //check to make sure its not the top item in the list
                if (item.Index != 0)
                {
                    //we move the item above down and this item down
                    SwapPosition(item.Index, item.Index - 1);
                }
            }

            PopulateList();
        }

        //Refreshes both local list of stored objects and the listview
        private void PopulateList()
        {
            //Since function is used for both initial population and refresh we'll clear the list items first
            listviewTodoLists.Items.Clear();
            listTodo.Clear();

            using (var db = new SteveTDMDbEntities())
            {
                listTodo = (from t in db.Todos where t.Hidden == 0 orderby t.Position ascending select t).ToList();

                db.Dispose();
            }

            for (int nCount = 0; nCount < listTodo.Count; nCount++)
            {
                listviewTodoLists.Items.Add(new ListViewItem(new string[] {
                      listTodo[nCount].Name
                    , listTodo[nCount].Priority.ToString()
                    , "0"
                    , listTodo[nCount].Description
                    , "0"
                    , listTodo[nCount].Duedate
                }));
            }
        }

        //function to swap the position of any two items in the list 
        //Works for both ups and downs
        private void SwapPosition(int intexTop, int indexBottom)
        {

            Todo up = listTodo[intexTop];
            Todo down = listTodo[indexBottom];

            using (var db = new SteveTDMDbEntities())
            {
                Todo resultUp = db.Todos.SingleOrDefault(t => t.ListId == up.ListId);
                Todo resultDown = db.Todos.SingleOrDefault(t => t.ListId == down.ListId);

                if (resultUp != null)
                {
                    resultUp.Position--;
                    db.SaveChanges();
                }


                if (resultDown != null)
                {
                    resultDown.Position++;
                    db.SaveChanges();
                }

                db.Dispose();
            }

        }

        private void butEdit_Click(object sender, EventArgs e)
        {
            EditTodo();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            PopulateList();
        }

        private void buttonTasks_Click(object sender, EventArgs e)
        {
            ManageTasks();
        }

        //Opens a List Editor Dialog based on current selected item
        private void EditTodo()
        {
            if (listviewTodoLists.SelectedItems.Count > 0)
            {
                var item = listviewTodoLists.SelectedItems[0];
                ListEditor todoEditor = new ListEditor(listTodo[item.Index]);
                todoEditor.ShowDialog();
            }
            PopulateList();
        }

        //Opens a Task Manager Dialog based on current selected item
        private void ManageTasks()
        {
            if (listviewTodoLists.SelectedItems.Count > 0)
            {
                var item = listviewTodoLists.SelectedItems[0];
                TasksManager taskManager = new TasksManager(listTodo[item.Index]);
                taskManager.ShowDialog();
            }
            PopulateList();
        }
    }
}
