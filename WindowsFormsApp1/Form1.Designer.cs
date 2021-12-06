
namespace WindowsFormsApp1
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
            this.select_button = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.user_query_button = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.add_data_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.delete_button = new System.Windows.Forms.Button();
            this.update_button = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.group_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // select_button
            // 
            this.select_button.Location = new System.Drawing.Point(391, 13);
            this.select_button.Name = "select_button";
            this.select_button.Size = new System.Drawing.Size(122, 23);
            this.select_button.TabIndex = 0;
            this.select_button.Text = "Выбрать таблицу";
            this.select_button.UseVisualStyleBackColor = true;
            this.select_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(30, 187);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(816, 236);
            this.dataGridView1.TabIndex = 2;
            // 
            // user_query_button
            // 
            this.user_query_button.Location = new System.Drawing.Point(391, 43);
            this.user_query_button.Name = "user_query_button";
            this.user_query_button.Size = new System.Drawing.Size(122, 23);
            this.user_query_button.TabIndex = 3;
            this.user_query_button.Text = "Свой запрос";
            this.user_query_button.UseVisualStyleBackColor = true;
            this.user_query_button.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(29, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(339, 24);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.Text = "Выберите таблицу";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(30, 43);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(339, 50);
            this.textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.Location = new System.Drawing.Point(29, 99);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(339, 66);
            this.textBox2.TabIndex = 6;
            // 
            // add_data_button
            // 
            this.add_data_button.Location = new System.Drawing.Point(392, 102);
            this.add_data_button.Name = "add_data_button";
            this.add_data_button.Size = new System.Drawing.Size(122, 23);
            this.add_data_button.TabIndex = 7;
            this.add_data_button.Text = "Добавить данные";
            this.add_data_button.UseVisualStyleBackColor = true;
            this.add_data_button.Click += new System.EventHandler(this.add_data_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(372, 128);
            this.label1.MaximumSize = new System.Drawing.Size(160, 40);
            this.label1.MinimumSize = new System.Drawing.Size(160, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 40);
            this.label1.TabIndex = 8;
            // 
            // delete_button
            // 
            this.delete_button.Location = new System.Drawing.Point(724, 8);
            this.delete_button.Name = "delete_button";
            this.delete_button.Size = new System.Drawing.Size(122, 23);
            this.delete_button.TabIndex = 9;
            this.delete_button.Text = "Удалить строку";
            this.delete_button.UseVisualStyleBackColor = true;
            this.delete_button.Click += new System.EventHandler(this.button4_Click);
            // 
            // update_button
            // 
            this.update_button.Location = new System.Drawing.Point(627, 70);
            this.update_button.Name = "update_button";
            this.update_button.Size = new System.Drawing.Size(122, 23);
            this.update_button.TabIndex = 10;
            this.update_button.Text = "Обновить строку";
            this.update_button.UseVisualStyleBackColor = true;
            this.update_button.Click += new System.EventHandler(this.button5_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(533, 99);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(145, 24);
            this.comboBox2.TabIndex = 11;
            this.comboBox2.Text = "Поле изменения";
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox3.Location = new System.Drawing.Point(533, 129);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(145, 41);
            this.textBox3.TabIndex = 13;
            // 
            // comboBox4
            // 
            this.comboBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(533, 39);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(145, 24);
            this.comboBox4.TabIndex = 14;
            this.comboBox4.Text = "Ключевое поле";
            this.comboBox4.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox4.Location = new System.Drawing.Point(697, 39);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(149, 22);
            this.textBox4.TabIndex = 15;
            // 
            // comboBox3
            // 
            this.comboBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(698, 99);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(149, 24);
            this.comboBox3.TabIndex = 16;
            this.comboBox3.Text = "Ключевое поле";
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox5.Location = new System.Drawing.Point(697, 129);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(150, 41);
            this.textBox5.TabIndex = 17;
            // 
            // group_button
            // 
            this.group_button.Location = new System.Drawing.Point(533, 8);
            this.group_button.Name = "group_button";
            this.group_button.Size = new System.Drawing.Size(103, 23);
            this.group_button.TabIndex = 18;
            this.group_button.Text = "Группировать по";
            this.group_button.UseVisualStyleBackColor = true;
            this.group_button.Click += new System.EventHandler(this.group_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 450);
            this.Controls.Add(this.group_button);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.update_button);
            this.Controls.Add(this.delete_button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.add_data_button);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.user_query_button);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.select_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button select_button;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button user_query_button;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button add_data_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button delete_button;
        private System.Windows.Forms.Button update_button;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button group_button;
    }
}

