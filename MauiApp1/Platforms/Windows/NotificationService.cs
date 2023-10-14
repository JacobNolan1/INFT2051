using Microsoft.Toolkit.Uwp.Notifications;
using Windows.UI.Notifications;

namespace Sleepwise.Services.PartialMethods
{
    static partial class NotificationService
    {
        public static ToastNotifierCompat notifier = ToastNotificationManagerCompat.CreateToastNotifier();

        static partial void DoScheduleMorningAndNightNotifications(int daysScheduleAheadFor, TimeSpan morningTime, TimeSpan nightTime)
        {
            for (int i = 0; i < daysScheduleAheadFor; i++)
            {
                DateTime morningTriggerTime = DateTime.Today.Add(morningTime).AddDays(i);
                DateTime nightTriggerTime = DateTime.Today.Add(nightTime).AddDays(i);

                if (morningTriggerTime > DateTime.Now)
                {
                    if (!DoesNotificationAlreadyExist(morningTriggerTime))
                    {
                        SendNotification("Sleepwise Reminder", "Good morning! Start your day on the right foot by completing your morning summary", morningTriggerTime);
                    }
                }

                if (nightTriggerTime > DateTime.Now)
                {
                    if (!DoesNotificationAlreadyExist(nightTriggerTime))
                    {
                        SendNotification("Sleepwise Reminder", "Don't forget to do your day summary - we can't wait to hear about your day's adventures!", nightTriggerTime);
                    }
                }
            }
        }
        public static bool DoesNotificationAlreadyExist(DateTime scheduleTime)
        {
            int epochTime = (int)(scheduleTime - new DateTime(1970, 1, 1)).TotalSeconds;
            string epochTimeString = epochTime.ToString();

            IReadOnlyList<ScheduledToastNotification> scheduledToasts = notifier.GetScheduledToastNotifications();
            var firstNotification = scheduledToasts.FirstOrDefault(i => i.Tag == epochTimeString && i.Group == "SLEEPWISE");
            if (firstNotification == null)
            {
                return false;
            }
            return true;
        }
        static partial void DoCancelNotifications()
        {
            ToastNotificationManagerCompat.History.Clear();
        }

        static partial void DoCancelSpecificNotification(DateTime scheduleTime)
        {
            int epochTime = (int)(scheduleTime - new DateTime(1970, 1, 1)).TotalSeconds;
            string epochTimeString = epochTime.ToString();

            IReadOnlyList<ScheduledToastNotification> scheduledToasts = notifier.GetScheduledToastNotifications();
            var toRemove = scheduledToasts.FirstOrDefault(i => i.Tag == epochTimeString && i.Group == "SLEEPWISE");
            if (toRemove != null)
            {
                notifier.RemoveFromSchedule(toRemove);
            }
        }
        static partial void DoSendNotification(string title, string message, DateTime scheduleTime)
        {
            ToastButton button = new ToastButton()
                .SetContent("See More")
                .AddArgument("action", "seemore")
                .SetAfterActivationBehavior(ToastAfterActivationBehavior.Default);

            Random rand = new Random();
            int randomID= rand.Next(100000, 1000000);
            int epochTime = (int)(scheduleTime - new DateTime(1970, 1, 1)).TotalSeconds;
            string epochTimeString = epochTime.ToString();

            new ToastContentBuilder()
                .AddArgument("action", "viewConversation")
                .AddArgument("conversationId", randomID)
                .AddText(title)
                .AddText(message)
                .AddButton(button)
                .Schedule(scheduleTime, toast =>
                  {
                      toast.Tag = epochTimeString;
                      toast.Group = "SLEEPWISE";
                  });
        }
        static partial void DoGetScheduledToasts()
        {
            IReadOnlyList<ScheduledToastNotification> scheduledToasts = notifier.GetScheduledToastNotifications();
            List<ScheduledToastNotification> list = scheduledToasts.ToList();
        }
    }
}