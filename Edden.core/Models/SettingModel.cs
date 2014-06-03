using System.IO;
using KnpsToolkit.KnpsStream;

namespace Edden.core.Models
{
    public enum SettingHandlerSaveType
    {
        Xml,
        Json,
        Yaml
    }

    public class SettingModel 
    {
        public DatabaseModelSetting Database { get; set; }

        public SettingModel()
        {
            Database = new DatabaseModelSetting();
        }

        public static T Load<T>() where T : new()
        {
            var filename = Constants.SettingName + ".dat";
            var saver = new DataSaver<T>();
            var config = new T();

            if (!File.Exists(filename))
            {
                saver.Save(filename, config);
            }
            else
            {
                config = saver.Load(filename);
            }

            return config;
        }
    }
}
