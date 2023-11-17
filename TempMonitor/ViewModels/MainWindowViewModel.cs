
using System;
using ReactiveUI;
using TempMonitor.Models;
using System.Timers;


namespace TempMonitor.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    static Monitor _comp = new Monitor();
    private Timer _updateTimer;
    public string Cpu => "CPU is: " + _comp.ComputerCpu(); // Displays CPU
    public string Gpu => "GPU is: " + _comp.ComputerGpu(); // Displays GPU
    public string Cooler => "CPU Cooler is: " + _comp.Cooler(); // Displays CPU Cooler
    public string Ram => "RAM usage is: " + _comp.RAMUsage(); // Displays RAM usage
    public string AIOTemp => "AIO Temp is: " + _comp.LiquidTemp(); // Displays AIO Temp
    public string Motherboard => "Motherboard is: " + _comp.Motherboard(); // Displays Motherboard
    public double GpuTempDouble; // Double for GPU Temp
    public double GPUTempDouble // Double for GPU Temp
    {
        get => GpuTempDouble;
        set => this.RaiseAndSetIfChanged(ref GpuTempDouble, value);
    }
    public string? GPUTemp; // String for GPU Temp
    public string? GpuTemp // String for GPU Temp
    {
        get => GPUTemp;
        set => this.RaiseAndSetIfChanged(ref GPUTemp, value);
    }
    public string? CPUUsage; // String for CPU Usage
    public string? CpuUsage // String for CPU Usage
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
        _updateTimer.Elapsed += OnTimedEvent!; // Call OnTimedEvent every second
        _updateTimer.AutoReset = true; // Reset the timer
        _updateTimer.Enabled = true; // Enable the timer
    } 

    private void OnTimedEvent(object sender, ElapsedEventArgs e)
    {
        _comp.UpdateHardware(); // Update the hardware information
        GpuTemp = "GPU Temp: " + _comp.GpuTemp();
        CpuUsage = "CPU Usage: " + Math.Round((double)_comp.CpuUsage()!, 2);
        GPUTempDouble = _comp.GpuTemp() ?? 0;
    }
}
