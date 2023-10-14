using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sleepwise.Services.PartialMethods
{
    static partial class NotificationService
    {
        public static void ScheduleMorningAndNightNotifications(int daysScheduleAheadFor, TimeSpan morningTime, TimeSpan nightTime)
        {
            DoScheduleMorningAndNightNotifications(daysScheduleAheadFor, morningTime, nightTime);
        }
        public static void CancelNotifications()
        {
            DoCancelNotifications();
        }
        public static void GetScheduledToasts()
        {
            DoGetScheduledToasts();
        }
        public static void SendNotification(string title, string message, DateTime scheduleTime)
        {
            DoSendNotification(title, message, scheduleTime);
        }

        public static void CancelSpecificNotification(DateTime scheduleTime)
        {
            DoCancelSpecificNotification(scheduleTime);
        }

        static partial void DoScheduleMorningAndNightNotifications(int daysScheduleAheadFor, TimeSpan morningTime, TimeSpan nightTime);
        static partial void DoCancelNotifications();

        static partial void DoGetScheduledToasts();

        static partial void DoSendNotification(string title, string message, DateTime scheduleTime);

        static partial void DoCancelSpecificNotification(DateTime scheduleTime);
    }
}
