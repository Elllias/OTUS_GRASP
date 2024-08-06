using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using Data;
using Utilities;

namespace UI.TimePanel
{
    public class TimeViewController
    {
        private const string TIME_TEXT_FORMAT = "ID: {0}\nConnection time data: {1}\nDisconnection time data: {2}";

        private readonly TimeView _view;
        private readonly TimeSystem _timeSystem;

        public TimeViewController(TimeView view, TimeSystem timeSystem)
        {
            _view = view;
            _timeSystem = timeSystem;

            _timeSystem.UsersTimeDataInitialized += OnUsersTimeDataUpdated;
            _timeSystem.UsersTimeDataUpdated += OnUsersTimeDataUpdated;
        }

        private void OnUsersTimeDataUpdated(List<UserTimeData> usersTimeData)
        {
            var text = new StringBuilder();

            foreach (var userTimeData in usersTimeData)
            {
                text.Append(string
                    .Format(
                        TIME_TEXT_FORMAT,
                        userTimeData.UserId,
                        userTimeData.TimesData.Where(time => time.TimeType == TimeType.Connection).ToText(),
                        userTimeData.TimesData.Where(time => time.TimeType == TimeType.Disconnection).ToText()
                    ));

                text.Append(TryGetGameSessionTime(userTimeData));
                text.Append("\n\n");
            }

            _view.SetText(text.ToString());
        }

        private string TryGetGameSessionTime(UserTimeData userTimeData)
        {
            var text = string.Empty;
            
            var connectionsData =
                userTimeData.TimesData
                    .Where(data => data.TimeType == TimeType.Connection)
                    .ToArray();

            var disconnectionsData =
                userTimeData.TimesData
                    .Where(data => data.TimeType == TimeType.Disconnection)
                    .ToArray();

            if (connectionsData.Length > 0 && disconnectionsData.Length > 0)
            {
                var lastConnectionData = connectionsData.Last();
                var lastDisconnectionData = disconnectionsData
                    .FirstOrDefault(data => data.DateTime >= lastConnectionData.DateTime);

                if (lastDisconnectionData.DateTime != default)
                {
                    text = "\nGame session time: " +
                                    (lastDisconnectionData.DateTime - lastConnectionData.DateTime) + "\n";
                }
            }

            return text;
        }
    }
}