
using System;
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
    public string Ram => "RAM usage is: " + _comp.RAMUsage();
    public string AIOTemp => "AIO Temp is: " + _comp.LiquidTemp();
    public string Motherboard => "Motherboard is: " + _comp.Motherboard();
    public double GpuTempDouble;
    public double GPUTempDouble
    {
        get => GpuTempDouble;
        set => this.RaiseAndSetIfChanged(ref GpuTempDouble, value);
    }
    public string? GPUTemp;
    public string? GpuTemp
    {
        get => GPUTemp;
        set => this.RaiseAndSetIfChanged(ref GPUTemp, value);
    }
    public string? CPUUsage;
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
        CpuUsage = "CPU Usage: " + Math.Round((double)_comp.CpuUsage()!, 2);
        GPUTempDouble = _comp.GpuTemp() ?? 0;
        _updateTimer = new Timer(1000); // Update every second (1000 ms)
        _updateTimer.Elapsed += OnTimedEvent!;
        _updateTimer.AutoReset = true;
        _updateTimer.Enabled = true;
    } 

    private void OnTimedEvent(object sender, ElapsedEventArgs e)
    {
        _comp.UpdateHardware(); // Update the hardware information
        GpuTemp = "GPU Temp: " + _comp.GpuTemp();
        CpuUsage = "CPU Usage: " + Math.Round((double)_comp.CpuUsage()!, 2);
        GPUTempDouble = _comp.GpuTemp() ?? 0;
    }
}
