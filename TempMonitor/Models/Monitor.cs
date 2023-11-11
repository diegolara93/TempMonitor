using System;
using LibreHardwareMonitor.Hardware;

namespace TempMonitor.Models;
/*
 * 0 is MOBO
 * 1 is CPU
 * 2 is RAM
 * 3 is GPU
 * 4 is HDD
 * 5 is SSD
 * 6 is NIC
 * 7 is Controller
 * 8 is Optical Drive
 */
public class Monitor
{
    private readonly Computer _computer = new Computer // Initialize the computer object with all hardware enabled MIGHT NEED ADMIN PERMS FOR CERTAIN HARDWARE
    {
        IsCpuEnabled = true,
        IsGpuEnabled = true,
        IsMemoryEnabled = true,
        IsMotherboardEnabled = true,
        IsControllerEnabled = true,
        IsNetworkEnabled = true,
        IsStorageEnabled = true
    };
    public string? ComputerCpu() // Computer CPU
    {
        _computer.Open();
        _computer.Accept(new UpdateVisitor());
        return _computer.Hardware[1].Name;
    }

    public string? ComputerGpu() // Computer GPU
    {
        _computer.Open();
        _computer.Accept(new UpdateVisitor());
        return _computer.Hardware[3].Name;
    }
    public string? GpuTemp()
    {
        _computer.Open();
        _computer.Accept(new UpdateVisitor());
        return _computer.Hardware[3].Sensors[0].Value.ToString();
    }
}