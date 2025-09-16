using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BrighnessApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            trackBarBrightness.Scroll += (s, e) =>
                labelValue.Text = $"Brightness: {trackBarBrightness.Value}%";

            trackBarContrast.Scroll += (s, e) =>
                labelContrast.Text = $"Contrast: {trackBarContrast.Value}%";
        }

        // ===== Windows DDC/CI APIs =====
        [DllImport("dxva2.dll", SetLastError = true)]
        private static extern bool GetMonitorBrightness(IntPtr hMonitor, out uint min, out uint cur, out uint max);
        [DllImport("dxva2.dll", SetLastError = true)]
        private static extern bool SetMonitorBrightness(IntPtr hMonitor, uint newBrightness);

        [DllImport("dxva2.dll", SetLastError = true)]
        private static extern bool GetMonitorContrast(IntPtr hMonitor, out uint min, out uint cur, out uint max);
        [DllImport("dxva2.dll", SetLastError = true)]
        private static extern bool SetMonitorContrast(IntPtr hMonitor, uint newContrast);

        [DllImport("dxva2.dll", SetLastError = true)]
        private static extern bool GetPhysicalMonitorsFromHMONITOR(IntPtr hMonitor, uint count, [Out] PHYSICAL_MONITOR[] monitors);
        [DllImport("dxva2.dll", SetLastError = true)]
        private static extern bool DestroyPhysicalMonitors(uint count, PHYSICAL_MONITOR[] monitors);
        [DllImport("user32.dll")]
        private static extern bool EnumDisplayMonitors(IntPtr hdc, IntPtr clip, MonitorEnumProc callback, IntPtr data);

        private delegate bool MonitorEnumProc(IntPtr hMonitor, IntPtr hdcMonitor, IntPtr rect, IntPtr data);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        struct PHYSICAL_MONITOR
        {
            public IntPtr hPhysicalMonitor;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string description;
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            IntPtr foundMonitor = IntPtr.Zero;
            EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero,
                (hMonitor, hdc, rect, data) =>
                {
                    foundMonitor = hMonitor;   // just grab the first monitor
                    return false;              // stop enumerating
                }, IntPtr.Zero);

            if (foundMonitor == IntPtr.Zero) return;

            var mons = new PHYSICAL_MONITOR[1];
            if (GetPhysicalMonitorsFromHMONITOR(foundMonitor, 1, mons))
            {
                uint min, cur, max;

                // ----- Brightness -----
                if (GetMonitorBrightness(mons[0].hPhysicalMonitor, out min, out cur, out max))
                {
                    uint target = (uint)((trackBarBrightness.Value / 100.0) * (max - min) + min);
                    SetMonitorBrightness(mons[0].hPhysicalMonitor, target);
                }

                // ----- Contrast -----
                if (GetMonitorContrast(mons[0].hPhysicalMonitor, out min, out cur, out max))
                {
                    uint targetContrast = (uint)((trackBarContrast.Value / 100.0) * (max - min) + min);
                    SetMonitorContrast(mons[0].hPhysicalMonitor, targetContrast);
                }

                DestroyPhysicalMonitors(1, mons);
            }
        }
    }
}
