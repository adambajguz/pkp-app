﻿namespace TrainsOnline.Desktop.Services
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Toolkit.Uwp.Helpers;
    using TrainsOnline.Desktop.Views;
    using Windows.ApplicationModel.Core;
    using Windows.UI.Core;

    // For instructions on testing this service see https://github.com/Microsoft/WindowsTemplateStudio/tree/master/docs/features/whats-new-prompt.md
    public static class WhatsNewDisplayService
    {
        private static bool shown = false;

        internal static async Task ShowIfAppropriateAsync()
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                CoreDispatcherPriority.Normal, async () =>
                {
                    if (SystemInformation.IsAppUpdated && !shown)
                    {
                        shown = true;
                        WhatsNewDialog dialog = new WhatsNewDialog();
                        await dialog.ShowAsync();
                    }
                });
        }
    }
}
