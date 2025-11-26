using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Savchuk.TaskPlanner.Domain.Models;
using Savchuk.TaskPlanner.Domain.Models.Enums;
using Savchuk.TaskPlanner.Domain.Logic;


namespace Savchuk.TaskPlanner.ConsoleRunner
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<WorkItem> items = new();

            Console.WriteLine("=== Task Planner ===");
            Console.WriteLine("Вводьте задачi. Щоб завершити — залиште Title порожнiм.");
            Console.WriteLine();

            while (true)
            {
                Console.Write("Title: ");
                string title = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(title))
                    break;

                Console.Write("Description: ");
                string desc = Console.ReadLine();

                Console.Write("Due date (dd.MM.yyyy): ");
                DateTime dueDate = DateTime.Parse(Console.ReadLine());

                Console.Write("Priority (None, Low, Medium, High, Urgent): ");
                Priority priority = Enum.Parse<Priority>(Console.ReadLine(), ignoreCase: true);

                Console.Write("Complexity (None, Minutes, Hours, Days, Weeks): ");
                Complexity complexity = Enum.Parse<Complexity>(Console.ReadLine(), ignoreCase: true);

                WorkItem item = new WorkItem
                {
                    Title = title,
                    Description = desc,
                    CreationDate = DateTime.Now,
                    DueDate = dueDate,
                    Priority = priority,
                    Complexity = complexity,
                    IsCompleted = false
                };

                items.Add(item);

                Console.WriteLine("Задачу додано!\n");
            }

            Console.WriteLine("\n=== Sorted Plan ===");

            var planner = new SimpleTaskPlanner();
            var sorted = planner.CreatePlan(items.ToArray());

            foreach (var item in sorted)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nГотово!");
        }
    }
}
