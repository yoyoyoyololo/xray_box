namespace usb_xraybox
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button2_Clink = new System.Windows.Forms.Button();
            this.open_device_button = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.start_check_button = new System.Windows.Forms.Button();
            this.stop_check_button = new System.Windows.Forms.Button();
            this.sel_fcheck_button = new System.Windows.Forms.Button();
            this.shut_button = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 178);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(189, 126);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(338, 18);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(165, 21);
            this.textBox2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(267, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "设备序列号";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(240, 178);
            this.textBox4.Margin = new System.Windows.Forms.Padding(2);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(193, 126);
            this.textBox4.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 155);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "发送框";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(238, 155);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "接收框";
            // 
            // button2_Clink
            // 
            this.button2_Clink.Location = new System.Drawing.Point(456, 279);
            this.button2_Clink.Margin = new System.Windows.Forms.Padding(2);
            this.button2_Clink.Name = "button2_Clink";
            this.button2_Clink.Size = new System.Drawing.Size(64, 24);
            this.button2_Clink.TabIndex = 9;
            this.button2_Clink.Text = "结束";
            this.button2_Clink.UseVisualStyleBackColor = true;
            this.button2_Clink.Click += new System.EventHandler(this.button2_Clink_Click);
            // 
            // open_device_button
            // 
            this.open_device_button.Location = new System.Drawing.Point(14, 30);
            this.open_device_button.Margin = new System.Windows.Forms.Padding(2);
            this.open_device_button.Name = "open_device_button";
            this.open_device_button.Size = new System.Drawing.Size(63, 21);
            this.open_device_button.TabIndex = 10;
            this.open_device_button.Text = "打开设备";
            this.open_device_button.UseVisualStyleBackColor = true;
            this.open_device_button.Click += new System.EventHandler(this.open_device_button_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(394, 54);
            this.button9.Margin = new System.Windows.Forms.Padding(2);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(64, 23);
            this.button9.TabIndex = 11;
            this.button9.Text = "测试按钮";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // start_check_button
            // 
            this.start_check_button.Location = new System.Drawing.Point(14, 70);
            this.start_check_button.Margin = new System.Windows.Forms.Padding(2);
            this.start_check_button.Name = "start_check_button";
            this.start_check_button.Size = new System.Drawing.Size(63, 21);
            this.start_check_button.TabIndex = 12;
            this.start_check_button.Text = "开始检测";
            this.start_check_button.UseVisualStyleBackColor = true;
            this.start_check_button.Click += new System.EventHandler(this.start_check_button_Click);
            // 
            // stop_check_button
            // 
            this.stop_check_button.Location = new System.Drawing.Point(98, 70);
            this.stop_check_button.Margin = new System.Windows.Forms.Padding(2);
            this.stop_check_button.Name = "stop_check_button";
            this.stop_check_button.Size = new System.Drawing.Size(63, 21);
            this.stop_check_button.TabIndex = 13;
            this.stop_check_button.Text = "停止检测";
            this.stop_check_button.UseVisualStyleBackColor = true;
            this.stop_check_button.Click += new System.EventHandler(this.stop_check_button_Click);
            // 
            // sel_fcheck_button
            // 
            this.sel_fcheck_button.Location = new System.Drawing.Point(98, 30);
            this.sel_fcheck_button.Margin = new System.Windows.Forms.Padding(2);
            this.sel_fcheck_button.Name = "sel_fcheck_button";
            this.sel_fcheck_button.Size = new System.Drawing.Size(63, 21);
            this.sel_fcheck_button.TabIndex = 14;
            this.sel_fcheck_button.Text = "仪器自检";
            this.sel_fcheck_button.UseVisualStyleBackColor = true;
            this.sel_fcheck_button.Click += new System.EventHandler(this.self_check_button_Click);
            // 
            // shut_button
            // 
            this.shut_button.Location = new System.Drawing.Point(14, 103);
            this.shut_button.Margin = new System.Windows.Forms.Padding(2);
            this.shut_button.Name = "shut_button";
            this.shut_button.Size = new System.Drawing.Size(63, 21);
            this.shut_button.TabIndex = 15;
            this.shut_button.Text = "关机";
            this.shut_button.UseVisualStyleBackColor = true;
            this.shut_button.Click += new System.EventHandler(this.shut_button_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.open_device_button);
            this.groupBox1.Controls.Add(this.stop_check_button);
            this.groupBox1.Controls.Add(this.shut_button);
            this.groupBox1.Controls.Add(this.sel_fcheck_button);
            this.groupBox1.Controls.Add(this.start_check_button);
            this.groupBox1.Location = new System.Drawing.Point(16, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(202, 142);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(240, 113);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 21);
            this.textBox5.TabIndex = 18;
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.DiscardNull = true;
            this.serialPort1.PortName = "COM13";
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.port_DataReceived);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 360);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button2_Clink);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Xray-Box";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2_Clink;
        private System.Windows.Forms.Button open_device_button;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button start_check_button;
        private System.Windows.Forms.Button stop_check_button;
        private System.Windows.Forms.Button sel_fcheck_button;
        private System.Windows.Forms.Button shut_button;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox5;
        private System.IO.Ports.SerialPort serialPort1;
    }
}

