using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;
namespace HookDemo
{
    public partial class Form1 : Form
    {
        /*声明API函数*/
        // 安装钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);
 
        // 卸载钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(int idHook);

        // 继续下一个钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(int idHook, int nCode, Int32 wParam, IntPtr lParam);

        // 取得当前线程编号
        [DllImport("kernel32.dll")]
        static extern int GetCurrentThreadId();

        /*声明定义*/
        public delegate int HookProc(int nCode, Int32 wParam, IntPtr lParam);
        static int hKeyboardHook = 0;
        private static int hMouseHook = 0;
        HookProc KeyboardHookProcedure;
        HookProc MouseHookProcedure;


        private int KeyboardHookProc(int nCode, Int32 wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                tbxInput.Text ="I'm a Keyboard";
                return 1;
            }
            return CallNextHookEx(hKeyboardHook, nCode, wParam, lParam);
        }

        private int MouseHookProc(int nCode, Int32 wParam, IntPtr lParam)
        {
            if (wParam >0)
            {
                tbxInput.Text = "按下键盘";
                return 1;
            }
            else
            {
                tbxInput.Text = "键盘抬起";
            }
            return CallNextHookEx(hMouseHook, nCode, wParam, lParam);
        }

        public Form1()
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
                KeyboardHookProcedure = new HookProc(KeyboardHookProc);

                // 设置线程钩子
                hKeyboardHook = SetWindowsHookEx(2, KeyboardHookProcedure, IntPtr.Zero,
                    GetCurrentThreadId());

                // 如果设置钩子失败
                if (hKeyboardHook == 0)
                {
                    KeyboardHookStop();
                    throw new Exception("SetWindowsHookEx failed.");
                }
            }
        }


        /// <summary>
        /// 安装鼠标钩子
        /// </summary>
        public void MouseHookStart()
        {
            if (hMouseHook == 0)
            {
                // 创建HookProc实例
                MouseHookProcedure = new HookProc(MouseHookProc);

                // 设置线程钩子
                hMouseHook = SetWindowsHookEx(7, MouseHookProcedure, IntPtr.Zero,
                   GetCurrentThreadId());

                // 如果设置钩子失败
                if (hMouseHook == 0)
                {
                    MouseHookStop();
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
                retKeyboard = UnhookWindowsHookEx(hKeyboardHook);
                hKeyboardHook = 0;
            }
            if (!(retKeyboard))
                throw new Exception("UnhookWindowsHookEx failed.");
        }

        /// <summary>
        /// 卸载鼠标钩子
        /// </summary>
        public void MouseHookStop()
        {
            bool retMouse = true;
            if (hMouseHook != 0)
            {
                retMouse = UnhookWindowsHookEx(hMouseHook);
                hMouseHook = 0;
            }
            if (!(retMouse))
                throw new Exception("UnhookWindowsHookEx failed.");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            KeyboardHookStart(); //安装键盘钩子
            MouseHookStart();    //安装鼠标钩子
        }
    }
}
