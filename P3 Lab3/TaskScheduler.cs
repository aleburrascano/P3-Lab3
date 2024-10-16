using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_Lab3
{
    public class TaskScheduler
    {
        private Dictionary<int, Task> _tasks;
        private int _nextTaskId;

        public TaskScheduler()
        {
            _tasks = new Dictionary<int, Task>();

        }
    }
}
