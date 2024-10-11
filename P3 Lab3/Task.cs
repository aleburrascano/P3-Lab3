using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_Lab3
{
    internal class Task
    {
        private string _taskSummary;
        private string _taskDetails;
        private DateTime _dueDate;
        private bool _isCompleted;

        public string TaskSummary
        {
            get { return this._taskSummary; }
            set { this._taskSummary = ValidateTaskSummary(value);  }
        }

        public string TaskDetails
        {
            get { return this._taskDetails; }
            set { this._taskDetails = ValidateTaskDetails(value); }
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
            get { return DateTime.Now > DueDate; }
        }

        public string Info
        {
            get { return ToString(); }
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

        

        public Task()
        {
           
        }

        public override string ToString()
        {
            return ($"Task: {TaskSummary} - Due Date: {DueDate} - {GetStringComplete()}");
        }
    }
}
