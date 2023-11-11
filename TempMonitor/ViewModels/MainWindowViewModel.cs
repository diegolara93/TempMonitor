

using TempMonitor.Models;

namespace TempMonitor.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    Monitor _comp = new Monitor();
    public string Cpu => "CPU is: " + _comp.ComputerCpu();

    public string Gpu => "GPU is: " + _comp.ComputerGpu();
    public string GpuTemp => "GPU Temp is: " + _comp.GpuTemp();

}