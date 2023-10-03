using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sleepwise.Services.PartialMethods
{
    static partial class NotificationService
    {
        public static void SendNotification(string title, string message, DateTime scheduleTime)
        {
            DoSendNotification(title, message, scheduleTime);
        }
        static partial void DoSendNotification(string title, string message, DateTime scheduleTime);
    }
}
