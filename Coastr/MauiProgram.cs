using Coastr.Model;
using Coastr.Persistence;
using Coastr.Persistence.Impl;
using Coastr.Services;
using Coastr.Services.Common;
using Coastr.Services.Common.Impl;
using Coastr.Services.Impl;
using Microsoft.Extensions.Logging;
using MudBlazor;
using MudBlazor.Services;

namespace Coastr
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            // configure DI
            ConfigureServices(builder.Services);

            // build App
            var app = builder.Build();

            return app;
        }

        /// <summary>
        /// DI Service Configuration
        /// </summary>
        /// <param name="services"></param>
        private static void ConfigureServices(IServiceCollection services)
        {
            // 3rd Party
            services.AddMudServices(config =>
            {
                config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomLeft;

                config.SnackbarConfiguration.PreventDuplicates = true;
                config.SnackbarConfiguration.NewestOnTop = true;
                config.SnackbarConfiguration.ShowCloseIcon = true;
                config.SnackbarConfiguration.VisibleStateDuration = 5000;
                config.SnackbarConfiguration.HideTransitionDuration = 200;
                config.SnackbarConfiguration.ShowTransitionDuration = 200;
                config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
                config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopCenter;
            }
            );

            // App
            // Database
            services.AddDbContext<CoasterDBContext>();
            // repositories
            services.AddScoped<ICoasterRepository, CoasterRepository>();
            services.AddScoped<ICoasterItemRepository, CoasterItemRepository>();
            services.AddScoped<IVenueRepository, VenueRepository>();
            services.AddScoped<IMenuItemRepository, MenuItemRepository>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IBillItemRepository, BillItemRepository>();
            services.AddScoped<IBillRepository, BillRepository>();

            // State + Singletons
            services.AddSingleton<StateContainer>();
            services.AddSingleton<WindowStateHandler>();


            // Services
            services.AddScoped<IDomUtilities, DomUtilities>();

            services.AddSingleton<ISettingsService, SettingsService>();
            services.AddSingleton<IVenueService, VenueService>();
            services.AddSingleton<ICoasterService, CoasterService>();
            services.AddSingleton<ICoasterItemService, CoasterItemService>();
            services.AddSingleton<ILocationService, LocationService>();
            services.AddSingleton<IMenuItemService, MenuItemService>();
            services.AddSingleton<IMenuService, MenuService>();
            services.AddSingleton<IApplicationMessageService, ApplicationMessageService>();
            services.AddSingleton<IBillingService, BillingService>();
        }
    }
}