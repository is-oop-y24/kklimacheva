using System.Collections.Generic;
using System.IO;
using System.Linq;
using Backups;
using Newtonsoft.Json;

namespace BackupsExtra
{
    public class Loader
    {
        public void Serialize(BackupJob job, string destinationPath)
        {
            DataTransferObject newDTO = new DataTransferObject(job);
            string data = JsonConvert.SerializeObject(newDTO);
            File.WriteAllText(destinationPath, data);
        }

        public List<DataTransferObject> Deserialize(string sourcePath)
        {
            string[] jobsConfig = File.ReadAllLines(sourcePath);

            return jobsConfig.Select(JsonConvert.DeserializeObject<DataTransferObject>).ToList();
        }
    }
}