namespace AOEOAdvancedWindowsLibrary.Shared.Extensions;
public static class ServiceExtensions
{
    //this can happen without ocr.
    public static IServiceCollection RegisterSpartanMonitorServices(this IServiceCollection services)
    {
        services.AddSingleton<ISpartanMonitor, SpartanMonitorService>()
            .AddSingleton<ISpartanExitHandler, ToastAndExitHandler>();
        return services;
    }
    public static IServiceCollection RegisterDefaultPopups(this IServiceCollection services)
    {
        services.AddSingleton<IOpenTimedPopup, TimerWPFPopupClass>()
            .AddSingleton<IOpenSimplePopup, SimpleWPFPopupClass>();
        return services;
    }
    //this is when you want ocr registrations.
    public static IServiceCollection RegisterSpartanOcrServices<I, O, P>(this IServiceCollection services)
        where I : class, ICaptureGrayScaleMask
        where O : class, IOcrProcessor
        where P : class, IClickLocationProvider
    {
        //this is the same regardless of whether champion, or testing or complex system'
        services.AddSingleton<ICaptureGrayScaleMask, I>();
        services.AddSingleton<IOcrProcessor, O>();
        services.AddSingleton<ISpartanLaunchHandler, OcrDetectionSpartanLaunchHandler>();
        services.AddSingleton<ISpartanQuestRequested, SpartanQuestResultMonitor>()
            .AddSingleton<ISpartanReady, QuestAutoClicker>()
            .RegisterAutoClickServices<P>()
            ;
        return services;
    }
    public static IServiceCollection RegisterAutoClickServices<P>(this IServiceCollection services)
        where P : class, IClickLocationProvider
    {
        services.AddSingleton<LocationContainer>()
            .AddSingleton<IClickLocationProvider, P>();
        return services;
    }
    public static IServiceCollection RegisterSpartanAutoClickOnlyServices<P>(this IServiceCollection services)
        where P : class, IClickLocationProvider
    {
        services.AddSingleton<ISpartanLaunchHandler, SpartanLaunchPopupHandler>()
            .AddSingleton<IAfterCloseSimplePopup, QuestAutoClicker>()
            .AddSingleton<ISpartanQuestRequested, DoNothingQuestMonitor>()
            .RegisterAutoClickServices<P>()
            ;
        return services;
    }
    public static IServiceCollection RegisterStandardQuestServices(this IServiceCollection services)
    {
        services.AddSingleton<IQuestSettings, SimpleQuestSettings>()
            .AddSingleton<IQuestConfigurator, NoOpQuestConfigurator>()
            .AddSingleton<IGlobalTechStrategy, NoGlobalTechStrategy>()
            .AddSingleton<IUnitRegistry, NoUnitService>();
        return services;
    }
    public static IServiceCollection RegisterToastQuestEndingServices(this IServiceCollection services)
    {
        services.AddSingleton<ISpartaQuestEnded, ToastQuestEnder>();
        return services;
    }
    public static IServiceCollection RegisterNoLaunchSpartanServices(this IServiceCollection services)
    {
        //this requires nothing else.
        services.AddSingleton<ISpartanLaunchHandler, DoNothingSpartanLaunchHandler>();
        return services;
    }
    public static IServiceCollection RegisterCoreOfflineServices(this IServiceCollection services)
    {
        //anything else that could be needed but are advanced services.
        services.AddSingleton<ITechBusinessService, TechBusinessService>();
        services.AddSingleton<ITacticsBusinessService, BasicTacticsBusinessService>();
        services.AddSingleton<ITacticsAutomation, CustomTacticsClass>();
        services.AddSingleton<IUnitProcessor, StandardUnitProcessor>();
        return services;
    }
    internal static IServiceCollection RegisterCoreQuestQuestProcessorServices(this IServiceCollection services)
    {
        services.RegisterBasicsForTesting(services =>
        {
            services.AddSingleton<QuestFileContainer>();
        });
        return services;
    }
}