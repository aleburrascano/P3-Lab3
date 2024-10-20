using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P3_Lab3.Models;

namespace P3_Lab3
{
    public class TaskScheduler
    {
        // Private members
        private Dictionary<int, Models.Task> _tasks;
        private int _nextTaskId;

        // Constructor
        public TaskScheduler()
        {
            _tasks = new Dictionary<int, Models.Task>();
            _nextTaskId = 1;
        }


    }
}
