using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_Lab3
{
    internal class Task
    {
        private string _summary;
        private string _details;
        private DateTime _dueDate;
        private bool _isCompleted;

        public string Summary
        {
            get { return this._summary; }
            set { this._summary = ValidateTaskSummary(value);  }
        }

        public string Details
        {
            get { return this._details; }
            set { this._details = ValidateTaskDetails(value); }
        }
        
        public DateTime DueDate
        {
            get { return this._dueDate; }
            set { this._dueDate = ValidateDueDate(value); }
        }

        public bool IsCompleted
        {
            get { return this._isCompleted; }
            set { this._isCompleted = value; }
        }

        public bool IsOverDue
        {
            get { return DateTime.Now > DueDate && !IsCompleted; }
        }

        public string Info
        {
            get 
            {
                if (this.IsOverDue)
                    return $"Task: {Summary} - Due Date: {DueDate} - {GetStringComplete()} - Overdue";
                else
                    return $"Task: {Summary} - Due Date: {DueDate} - {GetStringComplete()}"; 
            }
        }

        private string ValidateTaskSummary(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Your task summary cannot be empty!", nameof(value));

            return value;
        }

        private string ValidateTaskDetails(string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            return value;
        }

        private DateTime ValidateDueDate(DateTime value)
        {
            if (value.AddMonths(1)
                < DateTime.Now)
                throw new ArgumentException("The due date cannot be older than a month!", nameof(_dueDate));

            return value;
        }

        private string GetStringComplete()
        {
            return IsCompleted ? "Completed" : "Not Completed";
        }

        public Task(string summary)
        {
            Summary = summary; 
        }

        public Task(string summary, DateTime dueDate) : this(summary)
        {
            DueDate = dueDate;
        }

        public override string ToString()
        {
            return Info;
        }
    }
}
