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
    public partial class TasksManager : Form
    {
        private int nListId;

        public TasksManager(Todo td)
        {
            InitializeComponent();
            nListId = td.ListId;
            textBoxName.Text = td.Name;
            numericUpDownPriority.Value = Convert.ToInt32(td.Priority);
            textBoxDueDate.Text = td.Duedate;

            RefreshTaskManager();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAddTask_Click(object sender, EventArgs e)
        {
            TaskEditor te = new TaskEditor(nListId);
            te.ShowDialog();

            RefreshTaskManager();
        }

        private void buttonAddSubTask_Click(object sender, EventArgs e)
        {
            var tn = (TaskNode)treeViewTasks.SelectedNode;
            Task task;
            using (var db = new SteveTDMDbEntities())
            {
                task = db.Tasks.SingleOrDefault(t => t.TaskId == tn.TaskId);

                db.Dispose();
            }

            if (task.ParentId == null)
            {
                TaskEditor te = new TaskEditor(nListId, (int)task.TaskId);
                te.ShowDialog();
            }
            else
            {
                MessageBox.Show("SubTasks can't have Subtasks");
            }

            RefreshTaskManager();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var tn = (TaskNode)treeViewTasks.SelectedNode;
            Task task;
            using (var db = new SteveTDMDbEntities())
            {
                task = db.Tasks.SingleOrDefault(t => t.TaskId == tn.TaskId);
                db.Tasks.Remove(task);
                db.SaveChanges();

                List<Task> listToReOrder = (from t in db.Tasks where t.ParentId == task.ParentId && t.ListId == task.ListId orderby t.Position ascending select t).ToList();
                if (listToReOrder.Count > 0)
                {
                    for(int i = 0; i < listToReOrder.Count; i++)
                    {
                        listToReOrder[i].Position = i;
                        db.SaveChanges();
                    }
                }

                db.Dispose();
            }
            

            RefreshTaskManager();
        }

        private void treeViewTasks_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void buttonMoveUp_Click(object sender, EventArgs e)
        {
            var tn = (TaskNode) treeViewTasks.SelectedNode;
            if (tn != null)
            {
                int nbottom = tn.TaskId;
                int ntop;
                using (var db = new SteveTDMDbEntities())
                {
                    Task bottom = db.Tasks.SingleOrDefault(t => t.TaskId == nbottom);

                    if(bottom.Position == 0)
                    {
                        db.Dispose();
                        return;
                    }
                    Task top = db.Tasks.SingleOrDefault(t => t.ListId == bottom.ListId && t.ParentId == bottom.ParentId && t.Position == bottom.Position - 1);
                    ntop = top.TaskId;

                    db.Dispose();
                }
                SwapItems(ntop, nbottom);
            }
        }

        private void buttonMoveDown_Click(object sender, EventArgs e)
        {
            var tn = (TaskNode)treeViewTasks.SelectedNode;
            if (tn != null)
            {
                int ntop = tn.TaskId;
                int nbottom;
                using (var db = new SteveTDMDbEntities())
                {
                    Task top = db.Tasks.SingleOrDefault(t => t.TaskId == ntop);

                    if(top.Position == db.Tasks.Where(t => t.ListId == top.ListId && t.ParentId == top.ParentId).Select(t => t.Position).DefaultIfEmpty(0).Max())
                    {
                        db.Dispose();
                        return;
                    }

                    Task bottom = db.Tasks.SingleOrDefault(t => t.ListId == top.ListId && t.ParentId == top.ParentId && t.Position == top.Position + 1);
                    nbottom = bottom.TaskId;

                    db.Dispose();
                }
                SwapItems(ntop, nbottom);
            }
        }

        //Generic swap function for task nodes
        //I'm having trouble getting the swap to happen in the list so this will just update the SQLite DB
        //and then refresh the list from scratch which for now I'll assume the dataset is small enough to
        //impactful to performance but should be corrected in the future
        private void SwapItems(int idTop, int idBottom)
        {
            using (var db = new SteveTDMDbEntities())
            {
                Task top = db.Tasks.SingleOrDefault(t => t.TaskId == idTop);
                Task bottom = db.Tasks.SingleOrDefault(t => t.TaskId == idBottom);

                top.Position++;
                bottom.Position--;
                db.SaveChanges();
                db.Dispose();
            }

            RefreshTaskManager();
        }

        //Refresh function for the treelist
        private void RefreshTaskManager()
        {
            //clear list
            treeViewTasks.Nodes.Clear();

            //setup iteration variables
            List<Task> listTasks;
            TaskNode tnTask;
            List<Task> listSubTasks;
            TaskNode tnSubTask;
            using (var db = new SteveTDMDbEntities())
            {
                //Uncompleted Tasks

                //select all parent tasks for this list
                listTasks = (from tasks in db.Tasks
                           where tasks.ListId == nListId && tasks.ParentId == null && tasks.Complete == 0
                           orderby tasks.Position ascending
                           select tasks).ToList();

                //add all the parent tasks to the Active treeview
                int nTaskId;
                for (int p = 0; p < listTasks.Count; p++)
                {
                    tnTask = new TaskNode(listTasks[p]);

                    treeViewTasks.Nodes.Add(tnTask);

                    nTaskId = listTasks[p].TaskId;

                    //select all subtasks for this parent
                    listSubTasks = (from tasks in db.Tasks
                                  where tasks.ListId == nListId && tasks.ParentId == nTaskId && tasks.Complete == 0
                                  orderby tasks.Position ascending
                                  select tasks).ToList();

                    //add all subtasks to the parent task in the treeview
                    for (int s = 0; s < listSubTasks.Count; s++)
                    {
                        tnSubTask = new TaskNode(listSubTasks[s]);

                        treeViewTasks.Nodes[p].Nodes.Add(tnSubTask);
                    }

                }

                treeViewTasks.ExpandAll();

                //Completed Tasks
                //select all parent tasks for this list
                listTasks = (from tasks in db.Tasks
                             where tasks.ListId == nListId && tasks.ParentId == null && tasks.Complete == 1
                             orderby tasks.Position ascending
                             select tasks).ToList();

                //add all the parent tasks to the Completed treeview
                for (int p = 0; p < listTasks.Count; p++)
                {
                    tnTask = new TaskNode(listTasks[p]);

                    treeViewCompleted.Nodes.Add(tnTask);

                    nTaskId = listTasks[p].TaskId;

                    //select all subtasks for this parent
                    listSubTasks = (from tasks in db.Tasks
                                    where tasks.ListId == nListId && tasks.ParentId == nTaskId && tasks.Complete == 1
                                    orderby tasks.Position ascending
                                    select tasks).ToList();

                    //add all subtasks to the parent task in the treeview
                    for (int s = 0; s < listSubTasks.Count; s++)
                    {
                        tnSubTask = new TaskNode(listSubTasks[s]);

                        treeViewCompleted.Nodes[p].Nodes.Add(tnSubTask);
                    }

                }

                treeViewCompleted.ExpandAll();

                //Update the progressbar
                int nTotalTasks = db.Tasks.Where(t => t.ListId == nListId).Count();
                int nCompletedTasks = db.Tasks.Where(t => t.ListId == nListId && t.Complete == 1).Count();

                progressBarTodo.Minimum = 0;
                progressBarTodo.Maximum = nTotalTasks;
                progressBarTodo.Value = nCompletedTasks;

                db.Dispose();
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            RefreshTaskManager();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            var tn = (TaskNode)treeViewTasks.SelectedNode;
            Task task;
            using (var db = new SteveTDMDbEntities())
            {
                task = db.Tasks.SingleOrDefault(t => t.TaskId == tn.TaskId);

                db.Dispose();
            }

            TaskEditor te = new TaskEditor(task);
            te.ShowDialog();

            RefreshTaskManager();
        }
    }
}
