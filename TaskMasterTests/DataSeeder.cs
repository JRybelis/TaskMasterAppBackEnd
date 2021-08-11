using System.Linq;
using TaskMasterApp.Data;
using TaskmasterCore.Models;

namespace TaskMasterTests
{
    public static class DataSeeder
    {
        public static void SeedData(DataContext context)
        {
            if (!context.Tasks.Any())
            {
                context.Tasks.Add(new TaskItem()
                {
                    Text = "Test task item number 1",
                    Day = "Sunday",
                    Reminder = false
                });

                context.SaveChangesAsync();

            }
        }
    }
}
