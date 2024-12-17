using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onvif_test
{
    sealed public class DeviceTime
    {
        private Uri Uri { get; set; }
        private TimeSpan TimeDifference { get; set; }
        private bool QueriedDifference { get; set; }

        public DeviceTime(Uri uri)
        {
            Uri = uri;
        }

        public DeviceTime(string uri)
            : this(new Uri(uri))
        {
        }

        public DateTime DeviceTimestamp()
        {
            if (!QueriedDifference)
            {
                var deviceDateTime = DeviceClient.GetDeviceDateTime(Uri.ToString());
                TimeDifference = DateTime.UtcNow - deviceDateTime;
                QueriedDifference = true;
            }

            return DateTime.UtcNow - TimeDifference;
        }
    }
}
