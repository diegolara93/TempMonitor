
using ReactiveUI;
using TempMonitor.Models;
using System.Timers;


namespace TempMonitor.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    static Monitor _comp = new Monitor();
    private Timer _updateTimer;
    public string Cpu => "CPU is: " + _comp.ComputerCpu();
    public string Gpu => "GPU is: " + _comp.ComputerGpu();
    public string Cooler => "CPU Cooler is: " + _comp.Cooler();
    public string? GpuTemp;
    public string? CPUUsage;
    public string? GPUTemp
    {
        get => GpuTemp;
        set => this.RaiseAndSetIfChanged(ref GpuTemp, value);
    }
    public string? CpuUsage
    {
        get => CPUUsage;
        set => this.RaiseAndSetIfChanged(ref CPUUsage, value);
    }
    /*
     * If ViewModel is changed MAKE SURE TO DISABLE TIMER TO AVOID MEMORY LEAKS
     */
    public MainWindowViewModel()
    {
        GpuTemp = "GPU Temp: " + _comp.GpuTemp();
        CpuUsage = "CPU Usage: " + _comp.CpuUsage();
        _updateTimer = new Timer(1000); // Update every second (1000 ms)
        _updateTimer.Elapsed += OnTimedEvent!;
        _updateTimer.AutoReset = true;
        _updateTimer.Enabled = true;
    } 

    private void OnTimedEvent(object sender, ElapsedEventArgs e)
    {
        _comp.UpdateHardware(); // Update the hardware information
        GPUTemp = "GPU Temp: " + _comp.GpuTemp();
        CpuUsage = "CPU Usage: " + _comp.CpuUsage();
        
    }
}
