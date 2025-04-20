namespace AOEOAdvancedWindowsLibrary.ChampionMode.Extensions;
public static class ServiceExtensions
{
    // Registers basic services for Champion Mode tests.
    // The `additionalservices` action allows for further custom configurations.
    public static IServiceCollection RegisterAOEOTestsChampionMode<L>(this IServiceCollection services,
        Action<IServiceCollection> additionalservices
        )
        where L : class, IQuestLocatorService
    {
        services.RegisterBasicsForTesting(services =>
        {
            services.RegisterSpartanMonitorServices(); //this needs monitoring (even if no ocr,etc).
            services.AddSingleton<IQuestLocatorService, L>()
            .AddSingleton<IAddTechsToCharacterService, NoTechsCharacterService>();
            services.AddSingleton<IPlayQuestViewModel, ChampionTestSingleQuestViewModel>();
            services.RegisterCoreOfflineServices()
            .RegisterStandardQuestServices()
            .RegisterNoLaunchSpartanServices() //if they do this, no launcher for sparta.
            ;
            additionalservices.Invoke(services);
        });
        return services;
    }
    // Registers services for a complete AOEO test with OCR support and custom actions.
    // This registers services like OCR, standard quest services, and the default quest ending (Toast).
    // The `additionalActions` action allows for further custom configurations.
    public static IServiceCollection RegisterCompleteAOEOTestsUsingOcrChampionMode<L, I, O, P>(this IServiceCollection services, Action<IServiceCollection>? additionalActions)
        where L : class, IQuestLocatorService
        where I : class, ICaptureGrayScaleMask
        where O : class, IOcrProcessor
        where P : class, IClickLocationProvider

    {
        services.RegisterAOEOTestsChampionMode<L>(services =>
        {
            services.RegisterSpartanOcrServices<I, O, P>()
                .RegisterDefaultPopups()
                .RegisterToastQuestEndingServices();
            additionalActions?.Invoke(services);
        });
        return services;
    }
    // Registers services for basic autoclicking support without OCR.
    // Useful when launching manually and triggering clicks based on user input or timed popups.
    public static IServiceCollection RegisterCompleteAOEOTestsUsingAutoclickOnly<L, P>(this IServiceCollection services, Action<IServiceCollection>? additionalActions = null)
        where L : class, IQuestLocatorService
        where P : class, IClickLocationProvider
    {

        services.RegisterAOEOTestsChampionMode<L>(services =>
        {
           services.RegisterDefaultPopups()
                .RegisterSpartanAutoClickOnlyServices<P>();
            additionalActions?.Invoke(services);
        });
        return services;
    }
}