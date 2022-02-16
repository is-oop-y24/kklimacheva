using System.Collections.Generic;

namespace BackupsExtra
{
    public interface IConfigManager
    {
        void Serialize(BackupJobExtra job, string configPath);
        List<DataTransformer> Deserialize(string config);
    }
}