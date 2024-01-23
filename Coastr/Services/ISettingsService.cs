using Coastr.Model;

namespace Coastr.Services
{
    public interface ISettingsService
    {
        Task<AppSettings> LoadSettingsAsync();
        AppSettings LoadSettings();
        Task SaveSettingsAsync(AppSettings source);        
    }
}