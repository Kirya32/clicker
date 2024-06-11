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
    int clickPerSecond = 0;
    private DispatcherTimer timer;
    public MainWindow()
    {
        timer = new DispatcherTimer();
        timer.Interval = TimeSpan.FromSeconds(1);
        timer
        InitializeComponent();
    }

    private void UpdateDisplay()
    {
        clickPerSecond = 
    }

    private void Click_OnClick(object sender, RoutedEventArgs e)
    {
        click += PowerClick;
        Score.Content = "Кликов: " + click.ToString();
    }
    
    private void Powerup_OnClickp_OnClick(object sender, RoutedEventArgs e)
    {
        if (click >=25)
        {
            click -= 25;
            PowerClick ++;
            MessageBox.Show(MessageBoxButton.YesNo.ToString());
            MessageBox.Show("POWER!" + PowerClick.ToString());
            Score.Content = "Кликов: " + click.ToString();
        }
    }

    private void Auto_OnClick(object sender, RoutedEventArgs e)
    {
        if (click >= 50)
        {
            click -= 50;
            clickPerSecond++;
            MessageBox.Show("" + clickPerSecond.ToString());
            
        }
    }
}