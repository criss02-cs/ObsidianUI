using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObsidianUI.Components.Interfaces;
using ObsidianUI.Components.Models;

namespace ObsidianUI.Components.Utils
{
    internal static class CalendarCache
    {
        private static Dictionary<ICalendar, View> _calendars = [];


        public static View GetView(ICalendar calendar)
        {
            if (_calendars.TryGetValue(calendar, out var view))
            {
                return view;
            }

            if (calendar is not Month month) return null;
            var ui = new MonthBuilder(month, month.Culture)
                .SetDefinitions()
                .PopulateData(month.Days, month.DayWeeks)
                .Build();
            _calendars.Add(month, ui);
            return _calendars[month];

        }
    }
}
