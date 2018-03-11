using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace TaskManager_v1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            hWndListManager objWndListManager = new hWndListManager();
            objWndListManager.Initialize(hWndNameListBox, hWndListBox);

            // Timer Start
            System.Timers.Timer objTimer = new System.Timers.Timer();
            objTimer.Interval = 100;
            objTimer.Elapsed += new ElapsedEventHandler(OneHdred_ms);
            objTimer.Start();
        }

        delegate void RefreshListBoxDelegate(System.Windows.Forms.ListBox objListBox, System.Windows.Forms.ListBox objhWndBox);

        public void OneHdred_ms(object sender, ElapsedEventArgs e)
        {
            hWndListManager objWndListManager = new hWndListManager();

            if(hWndNameListBox.InvokeRequired == true || hWndListBox.InvokeRequired == true)
            {
                RefreshListBoxDelegate ListBoxDelegator = new RefreshListBoxDelegate(objWndListManager.RefreshListBox);
                this.Invoke(ListBoxDelegator, hWndNameListBox , hWndListBox);

            }
            else
            {
                objWndListManager.RefreshListBox(hWndNameListBox, hWndListBox);
            }
            
        }
    }
}
