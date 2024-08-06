using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using Data;
using Utilities;

namespace UI.TimePanel
{
    public class TimeViewObserver
    {
        private const string TIME_TEXT_FORMAT = "ID: {0}\nConnection time data: {1}\nDisconnection time data: {2}";

        private readonly TimeView _view;
        private readonly TimeSystem _timeSystem;

        public TimeViewObserver(TimeView view, TimeSystem timeSystem)
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
                        userTimeData.TimesData.Where(time => time.Type == (int)TimeType.Connection).ToText(),
                        userTimeData.TimesData.Where(time => time.Type == (int)TimeType.Disconnection).ToText()
                    ));
                
                text.Append(TryGetChestsTime(userTimeData));
                text.AppendLine();
                text.Append(TryGetGameSessionTime(userTimeData));
                text.Append("\n\n");
            }

            _view.SetText(text.ToString());
        }

        private string TryGetChestsTime(UserTimeData userTimeData)
        {
            var text = new StringBuilder();

            foreach (var timeData in userTimeData.TimesData)
            {
                if (timeData.Type == (int)ChestType.WoodType)
                {
                    text.Append($"\nWood Type Opening Time: {timeData.DateTime}");
                }
                else if (timeData.Type == (int)ChestType.SteelType)
                {
                    text.Append($"\nSteel Type Opening Time: {timeData.DateTime}");
                }
                else if (timeData.Type == (int)ChestType.GoldType)
                {
                    text.Append($"\nGold Type Opening Time: {timeData.DateTime}");
                }
            }
            
            return text.ToString();
        }

        private string TryGetGameSessionTime(UserTimeData userTimeData)
        {
            var text = string.Empty;
            
            var connectionsData =
                userTimeData.TimesData
                    .Where(data => data.Type == (int)TimeType.Connection)
                    .ToArray();

            var disconnectionsData =
                userTimeData.TimesData
                    .Where(data => data.Type == (int)TimeType.Disconnection)
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