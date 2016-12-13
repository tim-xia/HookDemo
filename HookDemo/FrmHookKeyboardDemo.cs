using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;
namespace HookDemo
{
    public partial class FrmHookKeyboardDemo : Form
    {
        
        /*声明定义*/
        static int hKeyboardHook = 0;
        ClsCommon.HookProc KeyboardHookProcedure;
        private  DataTable dataTable = new DataTable();  //定义全局变量dataTable


        /// <summary>
        /// 键盘消息
        /// </summary>
        public struct KeyMsg
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }


        private int KeyboardHookProc(int nCode, Int32 wParam, IntPtr lParam)
        {
            //KeyMsg m = (KeyMsg)Marshal.PtrToStructure(lParam, typeof(KeyMsg));
            dataTable.Rows.Add(nCode, wParam, lParam);
            dgvLogKeyboard.DataSource = dataTable;
            return ClsCommon.CallNextHookEx(hKeyboardHook, nCode, wParam, lParam);
        }


        public FrmHookKeyboardDemo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 安装键盘钩子
        /// </summary>
        public void KeyboardHookStart()
        {
            if (hKeyboardHook == 0)
            {
                // 创建HookProc实例
                KeyboardHookProcedure = new ClsCommon.HookProc(KeyboardHookProc);
                // 设置线程钩子
                //idHook=2 线程钩子 idHook=13 全局钩子
                hKeyboardHook = ClsCommon.SetWindowsHookEx(2, KeyboardHookProcedure, IntPtr.Zero,
                    ClsCommon.GetCurrentThreadId());
                //hKeyboardHook = ClsCommon.SetWindowsHookEx(13, KeyboardHookProcedure,
                //    Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]), 0);
                // 如果设置钩子失败
                if (hKeyboardHook == 0)
                {
                    KeyboardHookStop();
                    throw new Exception("SetWindowsHookEx failed.");
                }
            }
        }

        /// <summary>
        /// 卸载键盘钩子
        /// </summary>
        public void KeyboardHookStop()
        {
            bool retKeyboard = true;
            bool retMouse = true;
            if (hKeyboardHook != 0)
            {
                retKeyboard = ClsCommon.UnhookWindowsHookEx(hKeyboardHook);
                hKeyboardHook = 0;
            }
            if (!(retKeyboard))
                throw new Exception("UnhookWindowsHookEx failed.");
        }




        private void Form1_Load(object sender, EventArgs e)
        {
            dataTable.Columns.Add("nCode", typeof(string));
            dataTable.Columns.Add("wParam", typeof(string));
            dataTable.Columns.Add("lParam", typeof(string));
            KeyboardHookStart(); //安装键盘钩子
        }
    }
}
