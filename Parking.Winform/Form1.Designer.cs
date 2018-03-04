namespace Parking.Winform
{
	partial class Form1
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
			this.dtpEntry = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.dtpExit = new System.Windows.Forms.DateTimePicker();
			this.button1 = new System.Windows.Forms.Button();
			this.result = new System.Windows.Forms.RichTextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// dtpEntry
			// 
			this.dtpEntry.CustomFormat = "dd/MM/yyyy HH:mm";
			this.dtpEntry.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpEntry.Location = new System.Drawing.Point(36, 193);
			this.dtpEntry.Name = "dtpEntry";
			this.dtpEntry.Size = new System.Drawing.Size(200, 20);
			this.dtpEntry.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(36, 174);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(57, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Entry Time";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(301, 174);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(50, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Exit Time";
			// 
			// dtpExit
			// 
			this.dtpExit.CustomFormat = "dd/MM/yyyy HH:mm";
			this.dtpExit.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpExit.Location = new System.Drawing.Point(304, 193);
			this.dtpExit.Name = "dtpExit";
			this.dtpExit.Size = new System.Drawing.Size(200, 20);
			this.dtpExit.TabIndex = 3;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(234, 241);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 4;
			this.button1.Text = "Calculate";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// result
			// 
			this.result.Location = new System.Drawing.Point(36, 315);
			this.result.Name = "result";
			this.result.ReadOnly = true;
			this.result.Size = new System.Drawing.Size(468, 222);
			this.result.TabIndex = 5;
			this.result.Text = "";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.Blue;
			this.label3.Location = new System.Drawing.Point(31, 31);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(462, 114);
			this.label3.TabIndex = 6;
			this.label3.Text = "This works only for Early Bird Rate && Standard Rate.  Implementation for the res" +
    "t of the rate modes will be similar to these";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(545, 561);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.result);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.dtpExit);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dtpEntry);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DateTimePicker dtpEntry;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dtpExit;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.RichTextBox result;
		private System.Windows.Forms.Label label3;
	}
}

