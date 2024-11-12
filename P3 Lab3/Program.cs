using System.Collections.Generic;
using System;
using P3_Lab3.Models;

namespace P3_Lab3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            TestBudgetClass();
            //TaskScheduler taskScheduler = new TaskScheduler();

            //// Seed test data
            //List<Task> tasks = Seed();

            //foreach (Task task in tasks)
            //    taskScheduler.AddTask(task);

            //// Print completed tasks
            //Console.WriteLine("Completed Tasks:");
            //PrintTasksInfo(taskScheduler.CompletedTasks);

            //// Print Incompleted tasks
            //Console.WriteLine("\nIncompleted Tasks:");
            //PrintTasksInfo(taskScheduler.IncompletedTasks);

            //// Print overdue tasks
            //Console.WriteLine("\nOverdue Tasks:");
            //PrintTasksInfo(taskScheduler.OverdueTasks);

            //// Add a new task
            //taskScheduler.AddTask(new Task("New Task", DateTime.Today.AddDays(7)));

            //// Print Incompleted tasks again
            //Console.WriteLine("\nIncompleted Tasks After Adding:");
            //PrintTasksInfo(taskScheduler.IncompletedTasks);

            //// Search for a task
            //Task? foundTask = taskScheduler.FindTask(new Random().Next(1, taskScheduler.Count));
            //Console.WriteLine("\nFound Task:");
            //Console.WriteLine(foundTask);

            //// Close a task
            //taskScheduler.CloseTask(1); // Assume task ID 1
            //Console.WriteLine("\nCompleted Tasks After Closing:");
            //PrintTasksInfo(taskScheduler.CompletedTasks);

            //// Remove a task
            //taskScheduler.RemoveTask(1); // Assume task ID 1
            //Console.WriteLine("\nCompleted Tasks After Removal:");
            //PrintTasksInfo(taskScheduler.CompletedTasks);

            //// Print the count of tasks
            //Console.WriteLine($"\nTask Count: {taskScheduler.Count}");

            //// Clear the scheduler
            //taskScheduler.ClearScheduler();
            //Console.WriteLine($"\nTask Count After Clearing: {taskScheduler.Count}");
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

        static void TestBudgetClass()
        {
            const int ALLOWANCES = 6;
            const int EXPENESES = 12;
            int[] ITAllowances = new int[] { 1000, 5234, 9654, 256, 102400, 5555 }; //6 values
            int[] managementAllowances = new int[] { 250000, 45000, 22100, 4500, 0, 0 }; //6 values
            int[] HRAllowances = new int[] { 50000, 32000, 4000, 0, 0, 0 }; //6 values

            int[] ITExpenses = new int[] { 456, 8877, 6321, 1001, 788, 112, 66, 55, 88, 55, 789, 452 }; //12 values
            int[] managementExpenses = new int[] { 400, 100, 200, 300, 1000, 50000, 0, 0, 0, 0, 0, 0 }; //12 values
            int[] HRExpenses = new int[] { 1000, 2000, 3000, 4500, 200, 45800, 0, 0, 0, 0, 0, 0 }; //12 values

            //Create an array of Budget objects using object initialization syntax
            Budget[] companyDivisions = new Budget[]
            {
        new Budget("IT"),
        new Budget("Management"),
        new Budget("HR"),
            };

            //Add allowances: 6 values
            Console.WriteLine(">>> Adding Allowances to the divisions <<<");
            for (int i = 0; i < ALLOWANCES; i++)
            {
                companyDivisions[0].AddAllowance(ITAllowances[i]);
                companyDivisions[1].AddAllowance(managementAllowances[i]);
                companyDivisions[2].AddAllowance(HRAllowances[i]);
            }

            //Add expenses: 12 values
            Console.WriteLine("\n>>> Paying IT Expenses by the divisions <<<");
            for (int i = 0; i < EXPENESES; i++)
            {
                try
                {
                    companyDivisions[0].PayExpense(ITExpenses[i]);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine("\n>>> Paying Management Expenses by the divisions <<<");
            for (int i = 0; i < EXPENESES; i++)
            {
                try
                {
                    companyDivisions[1].PayExpense(managementExpenses[i]);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine("\n>>> Paying Expenses by the divisions <<<");
            for (int i = 0; i < EXPENESES; i++)
            {
                try
                {
                    companyDivisions[2].PayExpense(HRExpenses[i]);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            //Print all divisions
            Console.WriteLine("\n>>> Printing Divisions' Information <<<"); //Using the ToString method
            for (int i = 0; i < companyDivisions.Length; i++)
            {
                Console.WriteLine(companyDivisions[i]);
            }

            //Using string interpolation
            Console.WriteLine("\n>>> Printing Company's Information <<<");
            Console.WriteLine($"{"Company Total Allowances:",-35} {Budget.CompanyBudget,20:c}");
            Console.WriteLine($"{"Company Total Expenses:",-35} {Budget.CompanyExpenses,20:c}");
            Console.WriteLine($"{"Company Total Denied Allowances:",-35} {Budget.CompanyDeniedAllowances,20:c}");
            Console.WriteLine($"{"Available Annual Funds:",-35} {AnnualFunds.AvailableFunds,20:c}");
            //Using place holders
            //Console.WriteLine(string.Format("{0,-35}{1,-20}", "Company Total Allowances:", Budget.CompanyBudget.ToString("c")));
            //Console.WriteLine(string.Format("{0,-35}{1,-20}", "Company Total Expenses:", Budget.CompanyExpenses.ToString("c")));
        }
    }
}