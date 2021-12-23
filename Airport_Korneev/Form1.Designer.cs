
namespace Flight_Schedule_App
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
            this.table = new System.Windows.Forms.DataGridView();
            this.moreButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.airlineInput = new System.Windows.Forms.TextBox();
            this.dateInput = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.flightNumberInput = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.table)).BeginInit();
            this.SuspendLayout();
            // 
            // table
            // 
            this.table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table.Location = new System.Drawing.Point(12, 105);
            this.table.Name = "table";
            this.table.RowHeadersWidth = 51;
            this.table.RowTemplate.Height = 24;
            this.table.Size = new System.Drawing.Size(830, 257);
            this.table.TabIndex = 0;
            this.table.SelectionChanged += new System.EventHandler(this.table_SelectionChanged);
            // 
            // moreButton
            // 
            this.moreButton.Location = new System.Drawing.Point(13, 378);
            this.moreButton.Name = "moreButton";
            this.moreButton.Size = new System.Drawing.Size(139, 42);
            this.moreButton.TabIndex = 1;
            this.moreButton.Text = "Подробнее";
            this.moreButton.UseVisualStyleBackColor = true;
            this.moreButton.Click += new System.EventHandler(this.moreButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Номер рейса";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(157, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Авиакомпания";
            // 
            // airlineInput
            // 
            this.airlineInput.Location = new System.Drawing.Point(160, 66);
            this.airlineInput.Name = "airlineInput";
            this.airlineInput.Size = new System.Drawing.Size(424, 22);
            this.airlineInput.TabIndex = 7;
            this.airlineInput.TextChanged += new System.EventHandler(this.airlineInput_TextChanged);
            // 
            // dateInput
            // 
            this.dateInput.Location = new System.Drawing.Point(641, 66);
            this.dateInput.Name = "dateInput";
            this.dateInput.Size = new System.Drawing.Size(200, 22);
            this.dateInput.TabIndex = 8;
            this.dateInput.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dateInput.ValueChanged += new System.EventHandler(this.dateInput_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(638, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Вылет не раньше";
            // 
            // flightNumberInput
            // 
            this.flightNumberInput.Location = new System.Drawing.Point(13, 66);
            this.flightNumberInput.MaxLength = 4;
            this.flightNumberInput.Name = "flightNumberInput";
            this.flightNumberInput.Size = new System.Drawing.Size(93, 22);
            this.flightNumberInput.TabIndex = 10;
            this.flightNumberInput.TextChanged += new System.EventHandler(this.flightNumberInput_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 450);
            this.Controls.Add(this.flightNumberInput);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateInput);
            this.Controls.Add(this.airlineInput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.moreButton);
            this.Controls.Add(this.table);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.table)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView table;
        private System.Windows.Forms.Button moreButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox airlineInput;
        private System.Windows.Forms.DateTimePicker dateInput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox flightNumberInput;
    }
}

