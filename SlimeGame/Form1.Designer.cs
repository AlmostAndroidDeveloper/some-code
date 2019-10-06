using System;

namespace SilmeGame
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.ButtonUp = new System.Windows.Forms.Button();
            this.ButtonLeft = new System.Windows.Forms.Button();
            this.ButtonRight = new System.Windows.Forms.Button();
            this.ButtonDown = new System.Windows.Forms.Button();
            this.RestartLevelButton = new System.Windows.Forms.Button();
            this.PassLevelButton = new System.Windows.Forms.Button();
            this.MainText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ButtonUp
            // 
            this.ButtonUp.Location = new System.Drawing.Point(710, 203);
            this.ButtonUp.Name = "ButtonUp";
            this.ButtonUp.Size = new System.Drawing.Size(75, 44);
            this.ButtonUp.TabIndex = 0;
            this.ButtonUp.TabStop = false;
            this.ButtonUp.Text = "Вверх";
            this.ButtonUp.UseVisualStyleBackColor = true;
            this.ButtonUp.Click += new System.EventHandler(this.ButtonUp_Click);
            // 
            // ButtonLeft
            // 
            this.ButtonLeft.Location = new System.Drawing.Point(645, 253);
            this.ButtonLeft.Name = "ButtonLeft";
            this.ButtonLeft.Size = new System.Drawing.Size(75, 44);
            this.ButtonLeft.TabIndex = 0;
            this.ButtonLeft.TabStop = false;
            this.ButtonLeft.Text = "Влево";
            this.ButtonLeft.UseVisualStyleBackColor = true;
            this.ButtonLeft.Click += new System.EventHandler(this.ButtonLeft_Click);
            // 
            // ButtonRight
            // 
            this.ButtonRight.Location = new System.Drawing.Point(776, 253);
            this.ButtonRight.Name = "ButtonRight";
            this.ButtonRight.Size = new System.Drawing.Size(75, 44);
            this.ButtonRight.TabIndex = 0;
            this.ButtonRight.TabStop = false;
            this.ButtonRight.Text = "Вправо";
            this.ButtonRight.UseVisualStyleBackColor = true;
            this.ButtonRight.Click += new System.EventHandler(this.ButtonRight_Click);
            // 
            // ButtonDown
            // 
            this.ButtonDown.Location = new System.Drawing.Point(710, 303);
            this.ButtonDown.Name = "ButtonDown";
            this.ButtonDown.Size = new System.Drawing.Size(75, 44);
            this.ButtonDown.TabIndex = 0;
            this.ButtonDown.TabStop = false;
            this.ButtonDown.Text = "Вниз";
            this.ButtonDown.UseVisualStyleBackColor = true;
            this.ButtonDown.Click += new System.EventHandler(this.ButtonDown_Click);
            // 
            // RestartLevelButton
            // 
            this.RestartLevelButton.Location = new System.Drawing.Point(677, 399);
            this.RestartLevelButton.Name = "RestartLevelButton";
            this.RestartLevelButton.Size = new System.Drawing.Size(145, 23);
            this.RestartLevelButton.TabIndex = 1;
            this.RestartLevelButton.TabStop = false;
            this.RestartLevelButton.Text = "Перезапустить уровень";
            this.RestartLevelButton.UseVisualStyleBackColor = true;
            this.RestartLevelButton.Click += new System.EventHandler(this.RestartLevelButton_Click);
            // 
            // PassLevelButton
            // 
            this.PassLevelButton.Location = new System.Drawing.Point(677, 445);
            this.PassLevelButton.Name = "PassLevelButton";
            this.PassLevelButton.Size = new System.Drawing.Size(145, 23);
            this.PassLevelButton.TabIndex = 2;
            this.PassLevelButton.TabStop = false;
            this.PassLevelButton.Text = "Пройти уровень";
            this.PassLevelButton.UseVisualStyleBackColor = true;
            this.PassLevelButton.Click += new System.EventHandler(this.PassLevelButton_Click);
            // 
            // MainText
            // 
            this.MainText.Location = new System.Drawing.Point(645, 12);
            this.MainText.Multiline = true;
            this.MainText.Name = "MainText";
            this.MainText.ReadOnly = true;
            this.MainText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.MainText.Size = new System.Drawing.Size(206, 140);
            this.MainText.TabIndex = 3;
            this.MainText.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(860, 640);
            this.Controls.Add(this.MainText);
            this.Controls.Add(this.PassLevelButton);
            this.Controls.Add(this.RestartLevelButton);
            this.Controls.Add(this.ButtonDown);
            this.Controls.Add(this.ButtonRight);
            this.Controls.Add(this.ButtonLeft);
            this.Controls.Add(this.ButtonUp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Location = new System.Drawing.Point(100, 100);
            this.Name = "Form1";
            this.Text = "SlimeGame";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private System.Windows.Forms.Button ButtonUp;
        private System.Windows.Forms.Button ButtonLeft;
        private System.Windows.Forms.Button ButtonRight;
        private System.Windows.Forms.Button ButtonDown;
        private System.Windows.Forms.Button RestartLevelButton;
        private System.Windows.Forms.Button PassLevelButton;
        public  System.Windows.Forms.TextBox MainText;
    }
}

