using System.Globalization;
using System.Text;
using System.IO;
using System.Net.Http.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApp7;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    int click = 0;
    int PowerClick = 1; 
    int clickPerSecond = 1;
    private int autoClicker = 0;
    private int autoClikerCost = 10;
    private DispatcherTimer timer;
    
    public MainWindow()
    {
        timer = new DispatcherTimer();
        timer.Interval = TimeSpan.FromSeconds(1);
        timer.Tick += Timer_Tick;
        timer.Start();
        InitializeComponent();
    }

    private void Timer_Tick(object? sender, EventArgs e)
    {
        click += autoClicker;
    }
    

    private void Click_OnClick(object sender, RoutedEventArgs e)
    {
        click += PowerClick;
        Score.Content = "Кликов: " + click.ToString();
        
    }
    
    private void Powerup_OnClickp_OnClick(object sender, RoutedEventArgs e)
    {
        if (click >=5)
        {
            click -= 5;
           var result = MessageBox.Show("Need POWER?","POwer",  MessageBoxButton.YesNo, MessageBoxImage.Question);
           if (result == MessageBoxResult.Yes)
           {
           //try click += PowerClick * 5;
                MessageBox.Show("POWER!", "power " + PowerClick.ToString());
                PowerClick ++;
                Score.Content = "Кликов: " + click.ToString();
           }
           else if (result == MessageBoxResult.No)
           {
               MessageBox.Show("No power!?","power " );
               click += PowerClick;
               click += PowerClick;
               click += PowerClick;
               click += PowerClick;
           }
        }
    }

    private void Auto_OnClick(object sender, RoutedEventArgs e)
    {
        if (click >= 10)
        {
            click -= 10;
            autoClicker++;
            MessageBox.Show("Работяга: " + clickPerSecond.ToString());
        }
    }
}
