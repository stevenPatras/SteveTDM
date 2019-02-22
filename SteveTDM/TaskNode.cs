using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteveTDM
{
    class TaskNode : TreeNode
    {
        public int TaskId { get; set; }
        //public long Position { get; set; }

        public TaskNode(int id, int pos, string name)
        {
            this.TaskId = id;
            //this.Position = pos;
            this.Text = name;
        }

        public TaskNode(Task task)
        {
            this.TaskId = task.TaskId;
            //this.Position = task.Position;
            this.Text = task.Name;
        }
    }
}
