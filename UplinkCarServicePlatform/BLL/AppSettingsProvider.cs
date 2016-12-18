using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lumos.BLL
{
    public class AppSettingsProvider
    {
        public int RoomSTBeforeHour
        {
            get
            {
                string value = ConfigurationManager.AppSettings["custom:RoomSTBeforeHour"];
                if (value != null)
                {
                    return int.Parse(value);
                }

                return 0;
            }
        }

        public int RoomSTBeforePerHourPrice
        {
            get
            {
                string value = ConfigurationManager.AppSettings["custom:RoomSTBeforePerHourPrice"];
                if (value != null)
                {
                    return int.Parse(value);
                }

                return 0;
            }
        }

        public int RoomSTPerHourPrice
        {
            get
            {
                string value = ConfigurationManager.AppSettings["custom:RoomSTPerHourPrice"];
                if (value != null)
                {
                    return int.Parse(value);
                }

                return 0;
            }
        }

        public int RoomANPerHourPrice
        {
            get
            {
                string value = ConfigurationManager.AppSettings["custom:RoomANPerHourPrice"];
                if (value != null)
                {
                    return int.Parse(value);
                }

                return 0;
            }
        }

        public string RoomANStartTime
        {
            get
            {
                string value = ConfigurationManager.AppSettings["custom:RoomANStartTime"];
                if (value != null)
                {
                    return value;
                }

                return "2:00";
            }
        }

        public decimal RoomDeposit
        {
            get
            {
                string value = ConfigurationManager.AppSettings["custom:RoomDeposit"];
                if (value != null)
                {
                    return decimal.Parse(value);
                }

                return 0;
            }
        }
    }
}
