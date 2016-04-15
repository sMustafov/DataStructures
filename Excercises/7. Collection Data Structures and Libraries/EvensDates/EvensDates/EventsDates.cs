namespace EventsDates
{
    using System;
    using System.Globalization;
    using System.Threading;
    using Wintellect.PowerCollections;

    class EventsDates
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var events = new OrderedMultiDictionary<DateTime, string>(true);
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string eventEntry = Console.ReadLine();
                var eventTokens = eventEntry.Split('|');
                string eventName = eventTokens[0].Trim();
                DateTime eventDate = DateTime.Parse(eventTokens[1].Trim());
                events.Add(eventDate,eventName);
            }
            
            int m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                string[] date = Console.ReadLine().Split('|');
                DateTime startDate = DateTime.Parse(date[0].Trim());
                DateTime endDate = DateTime.Parse(date[1].Trim());

                var eventsInRange = events.Range(startDate, true, endDate, true);

                Console.WriteLine(eventsInRange.KeyValuePairs.Count);
                foreach (var e in eventsInRange)
                {
                    foreach (var eventName in e.Value)
                    {
                        Console.WriteLine("{0} | {1} ", eventName, e.Key);
                    }
                }
            }
        }
    }
}
