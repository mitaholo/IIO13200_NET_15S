using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava7
{
    public static class SonOfJ
    {
        public static List<Station> fetchStations()
        {
            string json = htmlRequest("http://rata.digitraffic.fi/api/v1/metadata/station");
            List<Station> stations = JsonConvert.DeserializeObject<List<Station>>(json);
            return stations;
        }

        public static DataTable fetchTrains(string station)
        {
            string json = htmlRequest("http://rata.digitraffic.fi/api/v1/live-trains?station=" + station);

            List<Train> trains = JsonConvert.DeserializeObject<List<Train>>(json);

            DataTable dt = new DataTable();

            dt.Columns.Add("TrainNumber");
            dt.Columns.Add("Cancelled");
            dt.Columns.Add("DepartureDate");
            foreach (Train train in trains)
            {
                DataRow row = dt.NewRow();

                row["TrainNumber"] = train.TrainNumber;
                row["Cancelled"] = train.Cancelled.ToString();
                row["DepartureDate"] = train.DepartureDate;

                dt.Rows.Add(row);
            }

            return dt;
        }

        private static string htmlRequest(string url)
        {
            string response = "";
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Encoding = System.Text.Encoding.UTF8;
                    response = client.DownloadString(url);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }
    }
}
