using System;
using LibreHardwareMonitor.Hardware;

namespace TempMonitor.Models;
/*
 * 0 is MOBO
 * 1 is CPU
 * 2 is RAM
 * 3 is GPU
 * 4 is AIO
 * 5 is Ethernet
 * 6 is WiFi
 */
public class Monitor
{
    private readonly Computer _computer;
    public Monitor()
    {

           _computer = new Computer // Initialize the computer object with all hardware enabled
            {
                IsCpuEnabled = true,
                IsGpuEnabled = true,
                IsMemoryEnabled = true,
                IsMotherboardEnabled = true,
                IsControllerEnabled = true,
                IsNetworkEnabled = true,
                IsStorageEnabled = true
            };
    _computer.Open();
}
    public void UpdateHardware()
    {
        _computer.Accept(new UpdateVisitor()); // Update hardware status
    }

    public string? ComputerCpu() // Computer CPU
    {
        return _computer.Hardware[1].Name;
    }

    public string? ComputerGpu() // Computer GPU
    {
        return _computer.Hardware[3].Name;
    }
    public double? GpuTemp() // GPU Temp
    {
        return _computer.Hardware[3].Sensors[0].Value;
    }
    public double? LiquidTemp() // AIO Temp 
    {
        return _computer.Hardware[4].Sensors[0].Value;
    }
    public double? CpuUsage() // CPU Usage
    {
        return _computer.Hardware[1].Sensors[1].Value;
    }

    public string? Cooler() // CPU Cooler
    {
        return _computer.Hardware[4].Name;
    }

    public double? RAMUsage() // RAM Usage
    {
        return _computer.Hardware[2].Sensors[0].Value;
    }
    public string? Motherboard() // Motherboard
    {
        return _computer.Hardware[0].Name;
    }
}