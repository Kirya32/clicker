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
           var result = MessageBox.Show("Need POWER X5?","POwer",  MessageBoxButton.YesNo, MessageBoxImage.Question);
           if (result == MessageBoxResult.Yes)
           {
               if (click >=25)
               {
                   click -= 25;
                   MessageBox.Show("POWER!", "power " + PowerClick.ToString());
                   PowerClick = PowerClick * 5; 
                   Score.Content = "Кликов: " + click.ToString();
               }
               else
               {
                   var b = (click <25);
                   MessageBox.Show("Что не хватает? Иди работай.","power");
               }
               
           }
           else if (result == MessageBoxResult.No)
           {
               click -= 5;
               PowerClick++;
               MessageBox.Show("POWER","power " );
               Score.Content = "Кликов: " + click.ToString();
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
