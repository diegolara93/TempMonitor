using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using LibreHardwareMonitor.Hardware;
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