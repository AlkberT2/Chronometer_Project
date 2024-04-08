using Project.Business.Watch;

using System.Timers;
using System.Windows;

namespace Chronometer_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /* Properties */
        readonly Watch Watch = new();
        Timer Timer = new();


        /// <summary>
        /// Entry Point App
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            EnableDisableButtons(Start: true, Stop: false, Reset: false);
            StartTimer();
        }

        /// <summary>
        /// Start Timer
        /// </summary>
        private void StartTimer()
        {
            Timer = new Timer
            {
                Interval = 500
            };

            Timer.Elapsed += OnTimerElapsed;
            Timer.Start();
        }


        /// <summary>
        /// On Timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            SetTimes();
            PrintWindow();
        }

        #region Buttons

        /// <summary>
        /// Start Button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Start_Btn_Click(object sender, RoutedEventArgs e)
        {
            Watch.Stopwatch.Start();

            EnableDisableButtons(Start: false, Stop: true, Reset: false);

            PrintWindow();

        }

        /// <summary>
        /// Stop Button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Stop_Btn_Click(object sender, RoutedEventArgs e)
        {
            Watch.Stopwatch.Stop();

            Start_Btn.Content = "Restart";

            EnableDisableButtons(Start: true, Stop: false, Reset: true);

            PrintWindow();

        }

        /// <summary>
        /// Reset Button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Reset_Btn_Click(object sender, RoutedEventArgs e)
        {
            Watch.Stopwatch.Reset();

            Start_Btn.Content = "Start";

            EnableDisableButtons(Start: true, Stop: false, Reset: false);

            PrintWindow();

        }

        #endregion Buttons


        /// <summary>
        /// Print Values Watch
        /// </summary>
        private void PrintWindow()
        {
            Watch_Tb.Dispatcher.Invoke(() =>
            {
                Watch_Tb.Text = $"{Watch.Hours:00}:{Watch.Minutes:00}:{Watch.Seconds:00}";
            }
            );

        }


        /// <summary>
        /// Set Times for Watch
        /// </summary>
        private void SetTimes()
        {
            Watch.Hours = Watch.Stopwatch.Elapsed.Hours;
            Watch.Minutes = Watch.Stopwatch.Elapsed.Minutes;
            Watch.Seconds = Watch.Stopwatch.Elapsed.Seconds;
        }


        /// <summary>
        /// Set Enable Buttons
        /// </summary>
        /// <param name="Start"></param>
        /// <param name="Stop"></param>
        /// <param name="Reset"></param>
        private void EnableDisableButtons(bool Start, bool Stop, bool Reset)
        {
            Start_Btn.IsEnabled = Start;
            Stop_Btn.IsEnabled = Stop;
            Reset_Btn.IsEnabled = Reset;
        }


    }
}
