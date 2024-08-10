using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Threading;
using ReactiveUI;

namespace ProgressBarMemoryLeakDemo.ViewModels;

public class MainViewModel : ViewModelBase
{
    public async Task RunTest()
    {
        var mainWindow =
            ((IClassicDesktopStyleApplicationLifetime)Application.Current!.ApplicationLifetime!).MainWindow!;

        for (int i = 0; i < 5; i++)
        {
            var progressWindow = new ProgressWindow();
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            Task.Delay(2000).ContinueWith(_ =>
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            {
                Dispatcher.UIThread.Invoke(() =>
                {
                    progressWindow.Close();
                });
            });

            await progressWindow.ShowDialog(mainWindow);
        }
    }
}
