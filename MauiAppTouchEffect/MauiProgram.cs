using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Compatibility.Hosting;
using Xamarin.CommunityToolkit.Effects;

namespace MauiAppTouchEffect;

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
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
            .ConfigureMauiHandlers(options => options.AddCompatibilityRenderers(typeof(TouchEffect).Assembly))
            .ConfigureEffects(options =>
            {
                options.AddCompatibilityEffects(typeof(TouchEffect).Assembly);
				
#if ANDROID
				// https://github.com/xamarin/XamarinCommunityToolkit/issues/1905#issuecomment-1254311606
				options.Add(typeof(TouchEffect), typeof(Xamarin.CommunityToolkit.Android.Effects.PlatformTouchEffect));
#endif
            })
            .UseMauiCommunityToolkit()
            .UseMauiCompatibility();

		builder.Services.AddTransient(typeof(ProductsPage));
		builder.Services.AddTransient(typeof(ProductsViewModel));

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}