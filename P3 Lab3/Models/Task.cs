using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_Lab3.Models
{
    public class Task
    {
        // Data members
        private string _summary;
        private string _details;
        private DateTime _dueDate;


        // Constructor that initializes Task summary with today's date as default due date
        public Task(string summary)
        {
            Summary = summary;
            DueDate = DateTime.Today;
            Details = string.Empty;
        }

        // Constructor that initializes Task summary and due date
        public Task(string summary, DateTime dueDate) : this(summary)
        {
            DueDate = dueDate;
        }

        // Properties
        public string Summary
        {
            get { return _summary; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Summary cannot be null or empty.");
                }

                _summary = value;
            }
        }

        public string Details
        {
            get { return _details; }
            set { _details = value ?? string.Empty; }
        }

        public DateTime DueDate
        {
            get { return _dueDate; }
            set
            {
                if (value < DateTime.Today.AddMonths(-1))
                {
                    throw new ArgumentException("Due date cannot be older than one month.", nameof(value));
                }

                _dueDate = value;
            }
        }

        public bool IsCompleted { get; set; }

        // Calculated property to check if task is overdue and not completed
        public bool IsOverDue
        {
            get { return DueDate < DateTime.Now && !IsCompleted; }
        }

        // Calculated property to return task information
        public string Info
        {
            get
            {
                return $"Task: {Summary} - Due Date: {DueDate} - " +
                              $"{(IsCompleted ? "Completed" : "Not Completed")} " +
                              $"{(IsOverDue ? "- Over Due" : string.Empty)}";
            }
        }

        // Override ToString method
        public override string ToString()
        {
            return Info;
        }
    }
}
