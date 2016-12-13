using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HookDemo
{
    public partial class FrmTask : Form
    {
        public FrmTask()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 键盘钩子
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHookKeyboard_Click(object sender, EventArgs e)
        {
            FrmHookKeyboardDemo hookKeyboard=new FrmHookKeyboardDemo();
            hookKeyboard.Show();
        }

        private void btnHookMouse_Click(object sender, EventArgs e)
        {
            FrmHookMouseDemo hookMouse=new FrmHookMouseDemo();
            hookMouse.Show();
        }
    }
}
