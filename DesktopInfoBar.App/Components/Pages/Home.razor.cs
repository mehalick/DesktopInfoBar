using Microsoft.AspNetCore.Components;

namespace DesktopInfoBar.App.Components.Pages;

public partial class Home : ComponentBase
{
    private TimeOnly _time = TimeOnly.FromDateTime(DateTime.Now);

    protected override void OnInitialized()
    {
        _ = new Timer(_ =>
        {
            InvokeAsync(() =>
            {
                var now = TimeOnly.FromDateTime(DateTime.Now);

                if (AreSame(_time, now))
                {
                    return;
                }

                _time = now;
                StateHasChanged();
            });
        }, null, 1000, 1000);
    }

    private static bool AreSame(TimeOnly a, TimeOnly b)
    {
        return a.Hour == b.Hour && a.Minute == b.Minute;
    }
}
