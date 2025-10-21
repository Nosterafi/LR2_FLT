namespace UI
{
    partial class FormMain
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
            richTextBoxInput = new RichTextBox();
            buttonAnalyze = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            richTextBoxMessages = new RichTextBox();
            label6 = new Label();
            label7 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // richTextBoxInput
            // 
            richTextBoxInput.Location = new Point(29, 302);
            richTextBoxInput.Margin = new Padding(4, 5, 4, 5);
            richTextBoxInput.Name = "richTextBoxInput";
            richTextBoxInput.Size = new Size(1037, 392);
            richTextBoxInput.TabIndex = 1;
            richTextBoxInput.Text = "abc aac001\nacc";
            // 
            // buttonAnalyze
            // 
            buttonAnalyze.Location = new Point(464, 725);
            buttonAnalyze.Margin = new Padding(4, 5, 4, 5);
            buttonAnalyze.Name = "buttonAnalyze";
            buttonAnalyze.Size = new Size(183, 52);
            buttonAnalyze.TabIndex = 2;
            buttonAnalyze.Text = "Анализировать текст";
            buttonAnalyze.UseVisualStyleBackColor = true;
            buttonAnalyze.Click += buttonAnalyze_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 277);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(110, 20);
            label1.TabIndex = 3;
            label1.Text = "Входной текст:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 14);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(369, 20);
            label2.TabIndex = 4;
            label2.Text = "Слова первого типа: числа формата (011)*001(010)*\r\n";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 51);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(770, 20);
            label3.TabIndex = 5;
            label3.Text = "Слова второго типа: идентификаторы (состоят из букв) формата (a|b|c|d)+, которые не оканчиваются на \"aa\"";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 86);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(284, 20);
            label4.TabIndex = 6;
            label4.Text = "Комментарий: многострочный  {  ........  }";
            // 
            // richTextBoxMessages
            // 
            richTextBoxMessages.Location = new Point(29, 818);
            richTextBoxMessages.Margin = new Padding(4, 5, 4, 5);
            richTextBoxMessages.Name = "richTextBoxMessages";
            richTextBoxMessages.Size = new Size(1037, 126);
            richTextBoxMessages.TabIndex = 10;
            richTextBoxMessages.Text = "";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(25, 794);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(94, 20);
            label6.TabIndex = 11;
            label6.Text = "Сообщения:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(25, 132);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(0, 20);
            label7.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(25, 132);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(135, 100);
            label5.TabIndex = 13;
            label5.Text = "Грамматика:\r\nS => BBS'\r\nS'=> AS' | epsilon\r\nA => <2>AA | <1>\r\nB => <2>";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1095, 965);
            Controls.Add(label5);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(richTextBoxMessages);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(buttonAnalyze);
            Controls.Add(richTextBoxInput);
            Margin = new Padding(4, 5, 4, 5);
            Name = "FormMain";
            Text = "Лабораторная работа № 2 - Разработка синтаксического анализатора";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxInput;
        private System.Windows.Forms.Button buttonAnalyze;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox richTextBoxMessages;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private Label label5;
    }
}
