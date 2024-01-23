using Coastr.Model;
using System.Text.Json;

namespace Coastr.Services.Impl
{
    public class SettingsService : ISettingsService
    {
        private const string SETTINGS_FILENAME = "Settings.dat";

        private string GetPath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CoastR");            
        }

        private StreamReader createReader(string filename)
        {
            var filePath = Path.Combine(GetPath(), filename);
            return File.OpenText(filePath);
        }
       
        private async Task<string> LoadFileAsync(string filename)
        {
            try
            {
                using StreamReader reader = createReader(filename);
                return await reader.ReadToEndAsync();
            }
            catch (Exception )
            {
                // do Nothing
            }
            return null;
        }

        private string LoadFile(string filename)
        {
            try
            {
                using StreamReader reader = createReader(filename);
                return reader.ReadToEnd();
            }
            catch (Exception )
            {
                // do Nothing
            }
            return null;
        }

        private StreamWriter createWriter(string filename)
        {
            var filePath = Path.Combine(GetPath(), filename);
            return File.CreateText(filePath);
        }

        private async Task SaveFileAsync(string filename, string data)
        {
            using StreamWriter writer = createWriter(filename);
            try
            {
                await writer.WriteAsync(data);
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            
        }

        public async Task<AppSettings> LoadSettingsAsync()
        {
            var data = await LoadFileAsync(SETTINGS_FILENAME);
            return data == null ? new AppSettings() : JsonSerializer.Deserialize<AppSettings>(data);
        }

        public AppSettings LoadSettings()
        {
            var data = LoadFile(SETTINGS_FILENAME);
            return data == null ? new AppSettings() : JsonSerializer.Deserialize<AppSettings>(data);

        }

        public async Task SaveSettingsAsync(AppSettings source)
        {
            var data = JsonSerializer.Serialize(source);
            await SaveFileAsync(SETTINGS_FILENAME, data);
        }       
    }
}
