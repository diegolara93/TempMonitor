
using Avalonia.Controls;
using TempMonitor.Models;

namespace TempMonitor.Views;

public partial class MainWindow : Window
{
    private  Monitor _comp = new Monitor();
    public MainWindow()
    {
        InitializeComponent();
    }
    
}