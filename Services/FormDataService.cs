using System.Collections.Generic;
using RTC.Models;

namespace RTC.Services
{
    public class FormDataService
    {
        public List<FormItem> GetMonths()
        {
            return new List<FormItem>
            {
                new FormItem("January", 1),
                new FormItem("February", 2),
                new FormItem("March", 3),
                new FormItem("April", 4),
                new FormItem("May", 5),
                new FormItem("June", 6),
                new FormItem("July", 7),
                new FormItem("August", 8),
                new FormItem("September", 9),
                new FormItem("October", 10),
                new FormItem("November", 11),
                new FormItem("December", 12)
            };
        }
    }
}