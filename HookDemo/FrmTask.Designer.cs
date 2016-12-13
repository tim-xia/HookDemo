namespace HookDemo
{
    partial class FrmTask
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnHookMouse = new System.Windows.Forms.Button();
            this.btnHookKeyboard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnHookMouse
            // 
            this.btnHookMouse.Location = new System.Drawing.Point(48, 50);
            this.btnHookMouse.Name = "btnHookMouse";
            this.btnHookMouse.Size = new System.Drawing.Size(124, 95);
            this.btnHookMouse.TabIndex = 0;
            this.btnHookMouse.Text = "鼠标钩子";
            this.btnHookMouse.UseVisualStyleBackColor = true;
            this.btnHookMouse.Click += new System.EventHandler(this.btnHookMouse_Click);
            // 
            // btnHookKeyboard
            // 
            this.btnHookKeyboard.Location = new System.Drawing.Point(258, 50);
            this.btnHookKeyboard.Name = "btnHookKeyboard";
            this.btnHookKeyboard.Size = new System.Drawing.Size(124, 95);
            this.btnHookKeyboard.TabIndex = 1;
            this.btnHookKeyboard.Text = "键盘钩子";
            this.btnHookKeyboard.UseVisualStyleBackColor = true;
            this.btnHookKeyboard.Click += new System.EventHandler(this.btnHookKeyboard_Click);
            // 
            // FrmTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 406);
            this.Controls.Add(this.btnHookKeyboard);
            this.Controls.Add(this.btnHookMouse);
            this.Name = "FrmTask";
            this.Text = "FrmTask";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnHookMouse;
        private System.Windows.Forms.Button btnHookKeyboard;
    }
}