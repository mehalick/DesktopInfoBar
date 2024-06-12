using Microsoft.AspNetCore.Components;
using Timer = System.Timers.Timer;

namespace DesktopInfoBar.App.Components.Pages;

public partial class Home : ComponentBase
{
    private TimeOnly _timeLtz = TimeOnly.FromDateTime(DateTime.Now);
    private TimeOnly _timeUtc = TimeOnly.FromDateTime(DateTime.UtcNow);
    private string _icon = "fa-clock";

    private static readonly Timer _timer = new Timer(1000);

    protected override void OnInitialized()
    {
        _icon = _clocks.FirstOrDefault(i => i.Key < _timeLtz).Value;

        _timer.Elapsed += async (_, _) =>
        {
            var now = TimeOnly.FromDateTime(DateTime.Now);

            if (AreSame(_timeLtz, now))
            {
                return;
            }

            _timeLtz = TimeOnly.FromDateTime(DateTime.Now);
            _timeUtc = TimeOnly.FromDateTime(DateTime.UtcNow);
            _icon = _clocks.FirstOrDefault(i => i.Key < _timeLtz).Value;

            await InvokeAsync(StateHasChanged);
        };
        _timer.AutoReset = true;
        _timer.Enabled = true;
    }

    private readonly Dictionary<TimeOnly, string> _clocks = new Dictionary<TimeOnly, string>
    {
        [new(23, 59, 59, 999, 999)] = "fa-clock-twelve",
        [new(23, 30)] = "fa-clock-eleven-thirty",
        [new(23, 00)] = "fa-clock-eleven",
        [new(22, 30)] = "fa-clock-ten-thirty",
        [new(22, 00)] = "fa-clock-ten",
        [new(21, 30)] = "fa-clock-nine-thirty",
        [new(21, 00)] = "fa-clock-nine",
        [new(20, 30)] = "fa-clock-eight-thirty",
        [new(20, 00)] = "fa-clock-eight",
        [new(19, 30)] = "fa-clock-seven-thirty",
        [new(19, 00)] = "fa-clock-seven",
        [new(18, 30)] = "fa-clock-six-thirty",
        [new(18, 00)] = "fa-clock-six",
        [new(17, 30)] = "fa-clock-five-thirty",
        [new(17, 00)] = "fa-clock-five",
        [new(16, 30)] = "fa-clock-four-thirty",
        [new(16, 00)] = "fa-clock-four",
        [new(15, 30)] = "fa-clock-three-thirty",
        [new(15, 00)] = "fa-clock-three",
        [new(14, 30)] = "fa-clock-two-thirty",
        [new(14, 00)] = "fa-clock-two",
        [new(13, 30)] = "fa-clock-one-thirty",
        [new(13, 00)] = "fa-clock-one",
        [new(12, 30)] = "fa-clock-twelve-thirty",
        [new(12, 00)] = "fa-clock-twelve",
        [new(11, 30)] = "fa-clock-eleven-thirty",
        [new(11, 00)] = "fa-clock-eleven",
        [new(10, 30)] = "fa-clock-ten-thirty",
        [new(10, 00)] = "fa-clock-ten",
        [new(09, 30)] = "fa-clock-nine-thirty",
        [new(09, 00)] = "fa-clock-nine",
        [new(08, 30)] = "fa-clock-eight-thirty",
        [new(08, 00)] = "fa-clock-eight",
        [new(07, 30)] = "fa-clock-seven-thirty",
        [new(07, 00)] = "fa-clock-seven",
        [new(06, 30)] = "fa-clock-six-thirty",
        [new(06, 00)] = "fa-clock-six",
        [new(05, 30)] = "fa-clock-five-thirty",
        [new(05, 00)] = "fa-clock-five",
        [new(04, 30)] = "fa-clock-four-thirty",
        [new(04, 00)] = "fa-clock-four",
        [new(03, 30)] = "fa-clock-three-thirty",
        [new(03, 00)] = "fa-clock-three",
        [new(02, 30)] = "fa-clock-two-thirty",
        [new(02, 00)] = "fa-clock-two",
        [new(01, 30)] = "fa-clock-one-thirty",
        [new(01, 00)] = "fa-clock-one",
        [new(00, 30)] = "fa-clock-twelve-thirty"
    };

    private static bool AreSame(TimeOnly a, TimeOnly b)
    {
        return a.Hour == b.Hour && a.Minute == b.Minute;
    }
}
