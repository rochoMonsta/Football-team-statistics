using Footbal_team_wpf.Models;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Footbal_team_wpf
{
    sealed class JsonReader
    {
        public Season ReadFromJsonFile(string jsonFileName)
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(Season));

            using (var file = new FileStream(jsonFileName, FileMode.Open))
            {
                var season = jsonFormatter.ReadObject(file) as Season;

                if (season != null) return season;
            }
            return null;
        }
    }
}
