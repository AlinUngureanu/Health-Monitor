namespace DataPresentation
{
    partial class DataPresentation
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
            this.components = new System.ComponentModel.Container();
            this.dgSensorValueList = new System.Windows.Forms.DataGridView();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeStampDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeStampStringDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Patient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sensorValueBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cbPatientCodeStart = new System.Windows.Forms.ComboBox();
            this.bStartPumping = new System.Windows.Forms.Button();
            this.bStopPumping = new System.Windows.Forms.Button();
            this.tbTimePeriod = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bReceivedData = new System.Windows.Forms.Button();
            this.bDisplayData = new System.Windows.Forms.Button();
            this.dayCalendar = new System.Windows.Forms.MonthCalendar();
            this.cbPacientFilter = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgSensorValueList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sensorValueBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgSensorValueList
            // 
            this.dgSensorValueList.AutoGenerateColumns = false;
            this.dgSensorValueList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSensorValueList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.typeDataGridViewTextBoxColumn,
            this.valueDataGridViewTextBoxColumn,
            this.timeStampDataGridViewTextBoxColumn,
            this.timeStampStringDataGridViewTextBoxColumn,
            this.Patient});
            this.dgSensorValueList.DataSource = this.sensorValueBindingSource;
            this.dgSensorValueList.Location = new System.Drawing.Point(12, 111);
            this.dgSensorValueList.Name = "dgSensorValueList";
            this.dgSensorValueList.RowHeadersWidth = 51;
            this.dgSensorValueList.RowTemplate.Height = 24;
            this.dgSensorValueList.Size = new System.Drawing.Size(729, 147);
            this.dgSensorValueList.TabIndex = 1;
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            this.typeDataGridViewTextBoxColumn.HeaderText = "Type";
            this.typeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            this.typeDataGridViewTextBoxColumn.Width = 125;
            // 
            // valueDataGridViewTextBoxColumn
            // 
            this.valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
            this.valueDataGridViewTextBoxColumn.HeaderText = "Value";
            this.valueDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            this.valueDataGridViewTextBoxColumn.Width = 125;
            // 
            // timeStampDataGridViewTextBoxColumn
            // 
            this.timeStampDataGridViewTextBoxColumn.DataPropertyName = "TimeStamp";
            this.timeStampDataGridViewTextBoxColumn.HeaderText = "TimeStamp";
            this.timeStampDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.timeStampDataGridViewTextBoxColumn.Name = "timeStampDataGridViewTextBoxColumn";
            this.timeStampDataGridViewTextBoxColumn.Width = 125;
            // 
            // timeStampStringDataGridViewTextBoxColumn
            // 
            this.timeStampStringDataGridViewTextBoxColumn.DataPropertyName = "TimeStampString";
            this.timeStampStringDataGridViewTextBoxColumn.HeaderText = "TimeStampString";
            this.timeStampStringDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.timeStampStringDataGridViewTextBoxColumn.Name = "timeStampStringDataGridViewTextBoxColumn";
            this.timeStampStringDataGridViewTextBoxColumn.Width = 125;
            // 
            // Patient
            // 
            this.Patient.DataPropertyName = "PatientCode";
            this.Patient.HeaderText = "Patient";
            this.Patient.MinimumWidth = 6;
            this.Patient.Name = "Patient";
            this.Patient.Width = 125;
            // 
            // sensorValueBindingSource
            // 
            this.sensorValueBindingSource.DataSource = typeof(SensorValue.SensorValue);
            // 
            // cbPatientCodeStart
            // 
            this.cbPatientCodeStart.FormattingEnabled = true;
            this.cbPatientCodeStart.Location = new System.Drawing.Point(34, 29);
            this.cbPatientCodeStart.Name = "cbPatientCodeStart";
            this.cbPatientCodeStart.Size = new System.Drawing.Size(121, 24);
            this.cbPatientCodeStart.TabIndex = 2;
            // 
            // bStartPumping
            // 
            this.bStartPumping.Location = new System.Drawing.Point(187, 23);
            this.bStartPumping.Name = "bStartPumping";
            this.bStartPumping.Size = new System.Drawing.Size(114, 34);
            this.bStartPumping.TabIndex = 3;
            this.bStartPumping.Text = "Start Pumping";
            this.bStartPumping.UseVisualStyleBackColor = true;
            this.bStartPumping.Click += new System.EventHandler(this.bStartPumping_Click);
            // 
            // bStopPumping
            // 
            this.bStopPumping.Location = new System.Drawing.Point(372, 19);
            this.bStopPumping.Name = "bStopPumping";
            this.bStopPumping.Size = new System.Drawing.Size(114, 34);
            this.bStopPumping.TabIndex = 4;
            this.bStopPumping.Text = "Stop Pumping";
            this.bStopPumping.UseVisualStyleBackColor = true;
            this.bStopPumping.Click += new System.EventHandler(this.bStopPumping_Click);
            // 
            // tbTimePeriod
            // 
            this.tbTimePeriod.Location = new System.Drawing.Point(593, 72);
            this.tbTimePeriod.Name = "tbTimePeriod";
            this.tbTimePeriod.Size = new System.Drawing.Size(77, 22);
            this.tbTimePeriod.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bReceivedData);
            this.groupBox1.Controls.Add(this.bDisplayData);
            this.groupBox1.Controls.Add(this.dayCalendar);
            this.groupBox1.Controls.Add(this.cbPacientFilter);
            this.groupBox1.Location = new System.Drawing.Point(767, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(415, 313);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data Filter";
            // 
            // bReceivedData
            // 
            this.bReceivedData.Location = new System.Drawing.Point(16, 260);
            this.bReceivedData.Name = "bReceivedData";
            this.bReceivedData.Size = new System.Drawing.Size(185, 23);
            this.bReceivedData.TabIndex = 3;
            this.bReceivedData.Text = "Display Received Data";
            this.bReceivedData.UseVisualStyleBackColor = true;
            this.bReceivedData.Click += new System.EventHandler(this.bReceivedData_Click);
            // 
            // bDisplayData
            // 
            this.bDisplayData.Location = new System.Drawing.Point(232, 260);
            this.bDisplayData.Name = "bDisplayData";
            this.bDisplayData.Size = new System.Drawing.Size(183, 23);
            this.bDisplayData.TabIndex = 2;
            this.bDisplayData.Text = "Display Selected Data";
            this.bDisplayData.UseVisualStyleBackColor = true;
            this.bDisplayData.Click += new System.EventHandler(this.bDisplayData_Click);
            // 
            // dayCalendar
            // 
            this.dayCalendar.Location = new System.Drawing.Point(82, 42);
            this.dayCalendar.Name = "dayCalendar";
            this.dayCalendar.TabIndex = 1;
            // 
            // cbPacientFilter
            // 
            this.cbPacientFilter.FormattingEnabled = true;
            this.cbPacientFilter.Location = new System.Drawing.Point(135, 11);
            this.cbPacientFilter.Name = "cbPacientFilter";
            this.cbPacientFilter.Size = new System.Drawing.Size(121, 24);
            this.cbPacientFilter.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Location = new System.Drawing.Point(768, 342);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(393, 102);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Communication Channel";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(272, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Server IP";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(275, 35);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 2;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(15, 59);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(184, 20);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Send only to this computer";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(15, 22);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(191, 20);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Send also through TCP / IP ";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // DataPresentation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 525);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbTimePeriod);
            this.Controls.Add(this.bStopPumping);
            this.Controls.Add(this.bStartPumping);
            this.Controls.Add(this.cbPatientCodeStart);
            this.Controls.Add(this.dgSensorValueList);
            this.Name = "DataPresentation";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgSensorValueList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sensorValueBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgSensorValueList;
        private System.Windows.Forms.BindingSource sensorValueBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeStampDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeStampStringDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Patient;
        private System.Windows.Forms.ComboBox cbPatientCodeStart;
        private System.Windows.Forms.Button bStartPumping;
        private System.Windows.Forms.Button bStopPumping;
        private System.Windows.Forms.TextBox tbTimePeriod;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MonthCalendar dayCalendar;
        private System.Windows.Forms.ComboBox cbPacientFilter;
        private System.Windows.Forms.Button bDisplayData;
        private System.Windows.Forms.Button bReceivedData;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}

