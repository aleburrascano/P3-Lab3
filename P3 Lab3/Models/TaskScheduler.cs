using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_Lab3
{
    public class TaskScheduler
    {
        // Private members
        private readonly Dictionary<int, Task> _tasks;
        private int _nextTaskId;

        // Constructor
        public TaskScheduler()
        {
            _tasks = new Dictionary<int, Task>();
            NextTaskId = 1;
        }

        public TaskScheduler(List<Task> tasks) : this()  // Calls the default constructor
        {
            if (tasks == null)
                throw new ArgumentNullException(nameof(tasks), "Task list cannot be null.");

            foreach (Task task in tasks)
                this.AddTask(task);
        }

        // Property to return the number of tasks
        public int Count
        {
            get { return this._tasks.Count; }
        }

        // Property to return a list of completed tasks
        public List<Task> CompletedTasks
        {
            get
            {
                List<Task> completedTasks = new List<Task>();

                foreach (Task task in _tasks.Values)
                    if (task.IsCompleted)
                        completedTasks.Add(task);

                return completedTasks;
            }
        }

        // Property to return a list of uncompleted tasks
        public List<Task> IncompletedTasks
        {
            get
            {
                List<Task> incompletedTasks = new List<Task>();

                foreach (Task task in _tasks.Values)
                    if (!task.IsCompleted)
                        incompletedTasks.Add(task);

                return incompletedTasks;
            }
        }

        // Property to return a list of overdue tasks
        public List<Task> OverdueTasks
        {
            get
            {
                List<Task> overdueTasks = new List<Task>();

                foreach (Task task in _tasks.Values)
                    if (task.IsOverDue)
                        overdueTasks.Add(task);

                return overdueTasks;
            }
        }

        // Property to get and set the next task ID
        private int NextTaskId
        {
            get { return this._nextTaskId; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Task ID must be greater than zero.", nameof(value));

                this._nextTaskId = value;
            }
        }

        // Add a new task to the scheduler
        public TaskScheduler AddTask(Task newTask)
        {
            if (newTask == null)
                return this;

            _tasks.Add(NextTaskId++, newTask);
            return this;
        }

        // Remove a task from the scheduler by ID
        public bool RemoveTask(int taskId)
        {
            return _tasks.Remove(taskId);
        }

        // Mark a task as completed
        public bool CloseTask(int taskId)
        {
            if (_tasks.TryGetValue(taskId, out Task? task))
            {
                task.IsCompleted = true;
                return true;
            }
            return false;
        }

        // Find a task by ID
        public Task? FindTask(int taskId)
        {
            return _tasks.TryGetValue(taskId, out Task? task) ? task : null;
        }

        // Clear all tasks in the scheduler
        public void ClearScheduler()
        {
            _tasks.Clear();
        }
    }
}
