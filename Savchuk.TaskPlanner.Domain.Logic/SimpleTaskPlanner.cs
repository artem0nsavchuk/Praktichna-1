using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Savchuk.TaskPlanner.Domain.Models;
using Savchuk.TaskPlanner.Domain.Models.Enums;


namespace Savchuk.TaskPlanner.Domain.Logic
{
    public class SimpleTaskPlanner  
    {
        public WorkItem[] CreatePlan(WorkItem[] items)
        {
            var list = items.ToList();
            list.Sort(CompareWorkItems);
            return list.ToArray();
        }

        private static int CompareWorkItems(WorkItem a, WorkItem b)
        {
            // 1. Priority — спадання (Urgent перший)
            int priorityCompare = b.Priority.CompareTo(a.Priority);
            if (priorityCompare != 0)
                return priorityCompare;

            // 2. DueDate — зростання (раніше — перше)
            int dateCompare = a.DueDate.CompareTo(b.DueDate);
            if (dateCompare != 0)
                return dateCompare;

            // 3. Title — алфавітно
            return string.Compare(a.Title, b.Title, StringComparison.OrdinalIgnoreCase);
        }
    }
}
