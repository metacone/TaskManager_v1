using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_v1
{

    public class hWndListManager
    {
        public void Initialize(System.Windows.Forms.ListBox objListBox, System.Windows.Forms.ListBox objhWndBox)
        {
            MakeRunninghWndList(objListBox, objhWndBox);
        }
        public void RefreshListBox(System.Windows.Forms.ListBox objListBox, System.Windows.Forms.ListBox objhWndBox)
        {
            MakeRunninghWndList(objListBox, objhWndBox);
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
        [DllImport("user32.dll")]
        public static extern long GetWindowLong(int hWnd, int nIndex);
        const int GCL_HMODULE = -16;

        private void MakeRunninghWndList(System.Windows.Forms.ListBox objListBox, System.Windows.Forms.ListBox objhWndBox)
        {
            Process[] aProcessList = Process.GetProcesses();
            uint nRunningFlag = 0;
            
            IntPtr New = IntPtr.Zero;
            foreach(Process nProcess in aProcessList)
            {

                //윈도우 핸들로 그 윈도우의 스타일을 얻어옴
                UInt32 nWinstyle = (UInt32)GetWindowLong((int)nProcess.MainWindowHandle, GCL_HMODULE);
                //해당 윈도우의 캡션이 존재하는지 확인
                if ((nWinstyle & 0x10000000L) == 0x10000000L && (nWinstyle & 0x00C00000L) == 0x00C00000L)
                {
                    //EnumTheWindows(nProcess.MainWindowHandle, New);
                    int size = GetWindowTextLength(nProcess.MainWindowHandle);
                    if (size++ > 0 && IsWindowVisible(nProcess.MainWindowHandle))
                    {
                        if (GetParent((int)nProcess.MainWindowHandle) == 0)
                        {
                            StringBuilder shWndName = new StringBuilder(size);
                            GetWindowText(nProcess.MainWindowHandle, shWndName, size);

                            // Register on List Boxs
                            if(objhWndBox.Items.Contains(nProcess.MainWindowHandle) == false)
                            {                                
                                objhWndBox.Items.Add(nProcess.MainWindowHandle);
                                objListBox.Items.Add(shWndName);
                            }

                            // Running, set BitMap
                            int index = objhWndBox.Items.IndexOf(nProcess.MainWindowHandle);
                            nRunningFlag |= (uint)(0x1 << index);
                        }
                    }
                }
            }


            if (nRunningFlag != ((0x1 << objListBox.Items.Count) - 1))
            {
                objhWndBox.Items.Clear();
                objListBox.Items.Clear();
            }
            return ;
        }
    }
}
