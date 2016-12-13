namespace HookDemo
{
    partial class FrmHookKeyboardDemo
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvLogKeyboard = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogKeyboard)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLogKeyboard
            // 
            this.dgvLogKeyboard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLogKeyboard.Location = new System.Drawing.Point(12, 42);
            this.dgvLogKeyboard.Name = "dgvLogKeyboard";
            this.dgvLogKeyboard.RowTemplate.Height = 27;
            this.dgvLogKeyboard.Size = new System.Drawing.Size(847, 373);
            this.dgvLogKeyboard.TabIndex = 0;
            // 
            // FrmHookKeyboardDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 419);
            this.Controls.Add(this.dgvLogKeyboard);
            this.Name = "FrmHookKeyboardDemo";
            this.Text = "键盘钩子例子";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogKeyboard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLogKeyboard;
    }
}

