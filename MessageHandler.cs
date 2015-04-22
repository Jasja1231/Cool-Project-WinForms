using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Data;
using System.Windows.Forms;

namespace GradedLab3P4
{
    class MessageHandler : IMessageFilter
    {
        [DllImport("User32.DLL")]
        public static extern int SendMessage(IntPtr hWnd, UInt32 Msg, Int32 wParam, Int32 lParam);

        const int WM_LBUTTONDOWN = 0x201;
        const int WM_LBUTTONUP = 0x202;
        const int WM_RBUTTONDOWN = 0x204;
        const int WM_RBUTTONUP = 0x205;

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == WM_LBUTTONDOWN)
            {
                SendMessage(m.HWnd, WM_RBUTTONDOWN, m.WParam.ToInt32(), m.LParam.ToInt32());
                return true;
            }
            if (m.Msg == WM_RBUTTONDOWN)
            {
                SendMessage(m.HWnd, WM_LBUTTONDOWN, m.WParam.ToInt32(), m.LParam.ToInt32());
                return true;
            }
            if (m.Msg == WM_LBUTTONUP)
            {
                SendMessage(m.HWnd, WM_RBUTTONUP, m.WParam.ToInt32(), m.LParam.ToInt32());
                return true;
            }
            if (m.Msg == WM_RBUTTONUP)
            {
                SendMessage(m.HWnd, WM_LBUTTONUP, m.WParam.ToInt32(), m.LParam.ToInt32());
                return true;
            }
            return false;
        }
    }
}
