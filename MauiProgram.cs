using Microsoft.Extensions.Logging;
using Microsoft.Maui.Handlers;


namespace Passes;

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
				fonts.AddFont("Jost-Bold.ttf", "JostBold");
				fonts.AddFont("Jost-SemiBold.ttf", "JostSemiBold");
				fonts.AddFont("Jost-Light.ttf", "JostLight");
				fonts.AddFont("Jost-Medium.ttf", "JostMedium");
				fonts.AddFont("Jost-Regular.ttf", "JostRegular");
			});
		EntryHandler.Mapper.AppendToMapping("CustomEntry", (handler, view)=>
		{
#if ANDROID
			handler.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Android.Graphics.Color.ParseColor("#f6f6f8"));
			handler.PlatformView.SetPadding(20, 0, 20, 0);
#endif
        });
        PickerHandler.Mapper.AppendToMapping("CustomPicker", (handler, view) =>
        {
#if ANDROID
			handler.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Android.Graphics.Color.ParseColor("#f6f6f8"));
			handler.PlatformView.SetPadding(20, 0, 20, 0);
#endif
        });

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
