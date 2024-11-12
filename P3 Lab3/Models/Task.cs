using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_Lab3
{
    public class Task
    {
        // Data members
        private string _summary;
        private string _details;
        private DateTime _dueDate;
        private bool _isCompleted;

        // No default constructor because for a task to exist, it needs to have a summary and that is something a user must fill in on their own, it's not our job.
        // Constructor that initializes Task summary with today's date as default due date
        public Task(string summary)
        {
            Summary = summary;
            DueDate = DateTime.Today;
            Details = string.Empty;
            IsCompleted = false;
        }

        // Constructor that initializes Task summary and due date
        public Task(string summary, DateTime dueDate) : this(summary)
        {
            DueDate = dueDate;
        }

        // Properties
        public string Summary
        {
            get { return this._summary; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Summary cannot be null or empty.", nameof(value));

                this._summary = value;
            }
        }

        public string Details
        {
            get { return this._details; }
            set { this._details = value ?? string.Empty; }
        }

        public DateTime DueDate
        {
            get { return this._dueDate; }
            set
            {
                if (value < DateTime.Today.AddMonths(-1))
                    throw new ArgumentException("Due date cannot be older than one month.", nameof(value));

                this._dueDate = value;
            }
        }

        // No validation required for this property because a boolean is either true or false, cannot be anything more than that.
        public bool IsCompleted
        {
            get { return this._isCompleted; }
            set { this._isCompleted = value; }
        }

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
