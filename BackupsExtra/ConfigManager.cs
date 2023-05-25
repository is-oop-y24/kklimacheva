using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace BackupsExtra
{
    public class ConfigManager : IConfigManager
    {
        public void Serialize(BackupJobExtra job, string configPath)
        {
            string jsonRes = JsonConvert.SerializeObject(new DataTransformer(job));
            using var writer = new StreamWriter(configPath, true);
            writer.WriteLine(jsonRes);
        }

        public List<DataTransformer> Deserialize(string config)
        {
            string[] jobsConfig = File.ReadAllLines(config);

            return jobsConfig.Select(JsonConvert.DeserializeObject<DataTransformer>).ToList();
        }
    }
}