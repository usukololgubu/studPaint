namespace studPiant_VS2008
{
    partial class MainScreen
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.grBox_Instruments = new System.Windows.Forms.GroupBox();
            this.rdButt_Cross = new System.Windows.Forms.RadioButton();
            this.rdButt_Lines = new System.Windows.Forms.RadioButton();
            this.grBox_Instruments.SuspendLayout();
            this.SuspendLayout();
            // 
            // grBox_Instruments
            // 
            this.grBox_Instruments.Controls.Add(this.rdButt_Lines);
            this.grBox_Instruments.Controls.Add(this.rdButt_Cross);
            this.grBox_Instruments.Location = new System.Drawing.Point(481, 373);
            this.grBox_Instruments.Name = "grBox_Instruments";
            this.grBox_Instruments.Size = new System.Drawing.Size(139, 68);
            this.grBox_Instruments.TabIndex = 0;
            this.grBox_Instruments.TabStop = false;
            this.grBox_Instruments.Text = "ИНСТРУМЕНТЫ";
            // 
            // rdButt_Cross
            // 
            this.rdButt_Cross.AutoSize = true;
            this.rdButt_Cross.Location = new System.Drawing.Point(6, 19);
            this.rdButt_Cross.Name = "rdButt_Cross";
            this.rdButt_Cross.Size = new System.Drawing.Size(70, 17);
            this.rdButt_Cross.TabIndex = 0;
            this.rdButt_Cross.TabStop = true;
            this.rdButt_Cross.Text = "КРЕСТЫ";
            this.rdButt_Cross.UseVisualStyleBackColor = true;
            this.rdButt_Cross.CheckedChanged += new System.EventHandler(this.rdButt_Cross_CheckedChanged);
            // 
            // rdButt_Lines
            // 
            this.rdButt_Lines.AutoSize = true;
            this.rdButt_Lines.Location = new System.Drawing.Point(6, 42);
            this.rdButt_Lines.Name = "rdButt_Lines";
            this.rdButt_Lines.Size = new System.Drawing.Size(65, 17);
            this.rdButt_Lines.TabIndex = 1;
            this.rdButt_Lines.TabStop = true;
            this.rdButt_Lines.Text = "ЛИНИИ";
            this.rdButt_Lines.UseVisualStyleBackColor = true;
            this.rdButt_Lines.CheckedChanged += new System.EventHandler(this.rdButt_Lines_CheckedChanged);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.grBox_Instruments);
            this.Name = "MainScreen";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainScreen_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainScreen_MouseDown);
            this.grBox_Instruments.ResumeLayout(false);
            this.grBox_Instruments.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grBox_Instruments;
        private System.Windows.Forms.RadioButton rdButt_Lines;
        private System.Windows.Forms.RadioButton rdButt_Cross;

    }
}

