using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace GeniusApp.Services
{
    public class ReadWriteJsonService
    {


        public async Task WriteToFile(string content, string targetFileName)
        {
            try
            {
                string path = Path.Combine(FileSystem.AppDataDirectory, targetFileName);
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine(content);
                }

                using (StreamReader sr = File.OpenText(path))
                {
                    content = await sr.ReadToEndAsync();
                    //result = JsonSerializer.Deserialize<oClass>(content);
                }
            }
            catch (FileNotFoundException ex)
            {
                content = ex.Message;
            }
        }

        public async Task<string> ReadTextFile(string filePath)
        {
            var DataResourceText = "";
            try
            {
                string path = Path.Combine(FileSystem.AppDataDirectory, filePath);

                if (!File.Exists(path))
                {
                    StreamWriter streamWriter = new StreamWriter(path);
                    StreamWriter file = streamWriter;
                }

                using (StreamReader sr = File.OpenText(path))
                {
                    DataResourceText = await sr.ReadToEndAsync();
                    return DataResourceText;
                    //Users = JsonSerializer.Deserialize<UserM[]>(DataResourceText);
                }
            }
            catch (FileNotFoundException ex)
            {
                DataResourceText = ex.Message;
                return null;
            }
        }

    }
}
