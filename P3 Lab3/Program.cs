using System.Collections.Generic;
using System;

namespace P3_Lab3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            TaskScheduler taskScheduler = new TaskScheduler();

            // Seed test data
            List<Task> tasks = Seed();

            foreach (Task task in tasks)
                taskScheduler.AddTask(task);

            // Print completed tasks
            Console.WriteLine("Completed Tasks:");
            PrintTasksInfo(taskScheduler.CompletedTasks);

            // Print Incompleted tasks
            Console.WriteLine("\nIncompleted Tasks:");
            PrintTasksInfo(taskScheduler.IncompletedTasks);

            // Print overdue tasks
            Console.WriteLine("\nOverdue Tasks:");
            PrintTasksInfo(taskScheduler.OverdueTasks);

            // Add a new task
            taskScheduler.AddTask(new Task("New Task", DateTime.Today.AddDays(7)));

            // Print Incompleted tasks again
            Console.WriteLine("\nIncompleted Tasks After Adding:");
            PrintTasksInfo(taskScheduler.IncompletedTasks);

            // Search for a task
            var foundTask = taskScheduler.FindTask(1); // Assume task ID 1
            Console.WriteLine("\nFound Task:");
            Console.WriteLine(foundTask);

            // Close a task
            taskScheduler.CloseTask(1);
            Console.WriteLine("\nCompleted Tasks After Closing:");
            PrintTasksInfo(taskScheduler.CompletedTasks);

            // Remove a task
            taskScheduler.RemoveTask(1);
            Console.WriteLine("\nCompleted Tasks After Removal:");
            PrintTasksInfo(taskScheduler.CompletedTasks);

            // Print the count of tasks
            Console.WriteLine($"\nTask Count: {taskScheduler.Count}");

            // Clear the scheduler
            taskScheduler.ClearScheduler();
            Console.WriteLine($"\nTask Count After Clearing: {taskScheduler.Count}");
        }

        // Generate test data
        public static List<Task> Seed()
        {
            return new List<Task>
            {
                new Task("Finish OOP Lab", DateTime.Today.AddDays(15)),
                new Task("Finish Assignment", DateTime.Now.AddMonths(1)) { IsCompleted = true },
                new Task("Finish English Essay", DateTime.Today.AddDays(-4)),
                new Task("Submit Report", DateTime.Today.AddDays(10)),
                new Task("Prepare Presentation", DateTime.Today.AddDays(-2)),
                new Task("Study for Exam", DateTime.Today.AddDays(5)),
                new Task("Plan Project", DateTime.Today.AddDays(7)) { IsCompleted = true }
            };
        }

        // Print a list of tasks
        public static void PrintTasksInfo(List<Task> tasks)
        {
            foreach (Task task in tasks)
                Console.WriteLine(task);
        }
    }
}