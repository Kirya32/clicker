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
    private int click;
    private int powerClick = 1;
    private int clickPerSecond = 1;
    private int upgradePrice = 2;
    private int upgradeCost = 25;
    private int autoClicker;
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
        if (click == 100)
        {
            MessageBox.Show("Вау, ну ты крутой","тип ачивка");
        }
        click += powerClick;
        Score.Content = "Кликов: " + click.ToString();
    }
    
    private void Powerup_OnClickp_OnClick(object sender, RoutedEventArgs e)
    {
        if (click < 5) return;
        var result = MessageBox.Show("Need POWER X5?","POwer",  MessageBoxButton.YesNo, MessageBoxImage.Question);
        switch (result)
        {
            case MessageBoxResult.Yes when click >=upgradeCost:
                click -= upgradeCost;
                upgradeCost *= upgradePrice;
                MessageBox.Show("POWER!", "power " + powerClick.ToString());
                powerClick = powerClick * 5; 
                Score.Content = "Кликов: " + click.ToString();
                break;
            case MessageBoxResult.Yes:
            {
                var b = (click <upgradeCost);
                MessageBox.Show("Что не хватает? Иди работай.","power");
                break;
            }
            case MessageBoxResult.No:
                click -= 5;
                powerClick++;
                MessageBox.Show("POWER","power " );
                Score.Content = "Кликов: " + click.ToString();
                break;
        }
    }

    private void Auto_OnClick(object sender, RoutedEventArgs e)
    {
        if (click < 10) return;
        click -= 10;
        autoClicker++;
        MessageBox.Show("Работяга: " + clickPerSecond.ToString());
    }
}
