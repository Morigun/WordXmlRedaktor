/*
 * Сделано в SharpDevelop.
 * Пользователь: suvoroda
 * Дата: 14.06.2016
 * Время: 12:32
 */
namespace WordXmlRedaktor
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.OpenButton = new System.Windows.Forms.Button();
			this.SaveButton = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.GoToErrorTagButton = new System.Windows.Forms.Button();
			this.CloseFileButton = new System.Windows.Forms.Button();
			this.ExitButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// richTextBox1
			// 
			this.richTextBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.richTextBox1.Location = new System.Drawing.Point(12, 12);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(875, 440);
			this.richTextBox1.TabIndex = 0;
			this.richTextBox1.Text = "";
			// 
			// OpenButton
			// 
			this.OpenButton.BackColor = System.Drawing.SystemColors.Info;
			this.OpenButton.Location = new System.Drawing.Point(893, 10);
			this.OpenButton.Name = "OpenButton";
			this.OpenButton.Size = new System.Drawing.Size(75, 23);
			this.OpenButton.TabIndex = 1;
			this.OpenButton.Text = "Открыть";
			this.OpenButton.UseVisualStyleBackColor = false;
			this.OpenButton.Click += new System.EventHandler(this.Button1Click);
			// 
			// SaveButton
			// 
			this.SaveButton.BackColor = System.Drawing.SystemColors.Info;
			this.SaveButton.Enabled = false;
			this.SaveButton.Location = new System.Drawing.Point(893, 94);
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.Size = new System.Drawing.Size(75, 23);
			this.SaveButton.TabIndex = 2;
			this.SaveButton.Text = "Сохранить";
			this.SaveButton.UseVisualStyleBackColor = false;
			this.SaveButton.Click += new System.EventHandler(this.Button2Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			this.openFileDialog1.Filter = "Документ WORD (*.docx)|*.docx";
			// 
			// GoToErrorTagButton
			// 
			this.GoToErrorTagButton.BackColor = System.Drawing.SystemColors.Info;
			this.GoToErrorTagButton.Enabled = false;
			this.GoToErrorTagButton.Location = new System.Drawing.Point(893, 39);
			this.GoToErrorTagButton.Name = "GoToErrorTagButton";
			this.GoToErrorTagButton.Size = new System.Drawing.Size(75, 49);
			this.GoToErrorTagButton.TabIndex = 3;
			this.GoToErrorTagButton.Text = "Переход к ошибочному тэгу";
			this.GoToErrorTagButton.UseVisualStyleBackColor = false;
			this.GoToErrorTagButton.Click += new System.EventHandler(this.GoToErrorTagButtonClick);
			// 
			// CloseFileButton
			// 
			this.CloseFileButton.BackColor = System.Drawing.SystemColors.Info;
			this.CloseFileButton.Location = new System.Drawing.Point(893, 123);
			this.CloseFileButton.Name = "CloseFileButton";
			this.CloseFileButton.Size = new System.Drawing.Size(75, 23);
			this.CloseFileButton.TabIndex = 4;
			this.CloseFileButton.Text = "Закрыть";
			this.CloseFileButton.UseVisualStyleBackColor = false;
			this.CloseFileButton.Click += new System.EventHandler(this.CloseFileButtonClick);
			// 
			// ExitButton
			// 
			this.ExitButton.BackColor = System.Drawing.SystemColors.Info;
			this.ExitButton.Location = new System.Drawing.Point(893, 152);
			this.ExitButton.Name = "ExitButton";
			this.ExitButton.Size = new System.Drawing.Size(75, 23);
			this.ExitButton.TabIndex = 5;
			this.ExitButton.Text = "Выход";
			this.ExitButton.UseVisualStyleBackColor = false;
			this.ExitButton.Click += new System.EventHandler(this.ExitButtonClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.ClientSize = new System.Drawing.Size(980, 467);
			this.Controls.Add(this.ExitButton);
			this.Controls.Add(this.CloseFileButton);
			this.Controls.Add(this.GoToErrorTagButton);
			this.Controls.Add(this.SaveButton);
			this.Controls.Add(this.OpenButton);
			this.Controls.Add(this.richTextBox1);
			this.Name = "MainForm";
			this.Text = "Редактор XML Word документа";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFormFormClosed);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button ExitButton;
		private System.Windows.Forms.Button CloseFileButton;
		private System.Windows.Forms.Button GoToErrorTagButton;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Button SaveButton;
		private System.Windows.Forms.Button OpenButton;
		private System.Windows.Forms.RichTextBox richTextBox1;
	}
}
