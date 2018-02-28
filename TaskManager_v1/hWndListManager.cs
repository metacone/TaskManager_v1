using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_v1
{
    struct hWndList
    {
        int hWnd;
        string Name;
    }

    public class hWndListManager
    {
        public void Initialize(System.Windows.Forms.ListBox objListBox, System.Windows.Forms.ListBox objhWndBox)
        {
            MakeRunninghWndList(objListBox, objhWndBox);
        }
        private void InsertBox()
        {

        }
        
        protected delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        protected static extern int GetWindowText(IntPtr hWnd, StringBuilder strText, int maxCount);
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        protected static extern int GetWindowTextLength(IntPtr hWnd);
        [DllImport("user32.dll")]
        protected static extern bool IsWindowVisible(IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern int GetParent(int hWnd);
        


        private hWndList MakeRunninghWndList(System.Windows.Forms.ListBox objListBox, System.Windows.Forms.ListBox objhWndBox)
        {
            hWndList objhWndList = new hWndList();
            Process[] aProcessList = Process.GetProcesses();

            uint nPID = 0;
            IntPtr New = IntPtr.Zero;
            foreach(Process nProcess in aProcessList)
            {
                
                //GetWindowThreadProcessId(nProcess.Handle);
                if (nProcess.Id != 0 && nProcess.MainWindowHandle != IntPtr.Zero)
                {
                    //EnumTheWindows(nProcess.MainWindowHandle, New);
                    int size = GetWindowTextLength(nProcess.MainWindowHandle);
                    if (size++ > 0 && IsWindowVisible(nProcess.MainWindowHandle))
                    {
                        if (GetParent((int)nProcess.MainWindowHandle) == 0)
                        {
                            StringBuilder sb = new StringBuilder(size);
                            GetWindowText(nProcess.MainWindowHandle, sb, size);
                            if(objhWndBox.Items.Contains((int)nProcess.MainWindowHandle) == false)
                            {
                                objhWndBox.Items.Add((int)nProcess.MainWindowHandle);
                                objListBox.Items.Add(sb);
                            }
                            Console.WriteLine(sb.ToString());
                        }
                    }
                    Debug.WriteLine(nProcess.ProcessName);
                }
            }

            return objhWndList;
        }
    }
}
