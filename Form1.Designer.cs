using Point = System.Drawing.Point;
using Size = System.Drawing.Size;
using SizeF = System.Drawing.SizeF;

namespace ReadPolarBear
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ImportExcel = new Button();
            dataGridView1 = new DataGridView();
            Save = new Button();
            provinceListbox = new ListBox();
            ClearExltable = new Button();
            DeleteProvince = new Button();
            ClearListbox = new Button();
            TradeListbox = new ListBox();
            ExportOne = new Button();
            ExportAll = new Button();
            TotalLabel = new Label();
            TotalSkillNum = new Label();
            ExportTemp = new Button();
            ExportAllTemp = new Button();
            label1 = new Label();
            ProvinceNum = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // ImportExcel
            // 
            ImportExcel.Location = new Point(17, 444);
            ImportExcel.Name = "ImportExcel";
            ImportExcel.Size = new Size(84, 42);
            ImportExcel.TabIndex = 0;
            ImportExcel.Text = "Import";
            ImportExcel.UseVisualStyleBackColor = true;
            ImportExcel.Click += ImportExcel_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(17, 43);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(299, 395);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Save
            // 
            Save.Location = new Point(113, 444);
            Save.Name = "Save";
            Save.Size = new Size(84, 42);
            Save.TabIndex = 2;
            Save.Text = "Save";
            Save.UseVisualStyleBackColor = true;
            Save.Click += Save_Click;
            // 
            // provinceListbox
            // 
            provinceListbox.FormattingEnabled = true;
            provinceListbox.ItemHeight = 15;
            provinceListbox.Location = new Point(388, 43);
            provinceListbox.Name = "provinceListbox";
            provinceListbox.Size = new Size(179, 394);
            provinceListbox.TabIndex = 4;
            provinceListbox.SelectedIndexChanged += provinceListbox_SelectedIndexChanged;
            // 
            // ClearExltable
            // 
            ClearExltable.Location = new Point(209, 444);
            ClearExltable.Name = "ClearExltable";
            ClearExltable.Size = new Size(84, 42);
            ClearExltable.TabIndex = 5;
            ClearExltable.Text = "Clear";
            ClearExltable.UseVisualStyleBackColor = true;
            ClearExltable.Click += ClearExltable_Click;
            // 
            // DeleteProvince
            // 
            DeleteProvince.Location = new Point(388, 443);
            DeleteProvince.Name = "DeleteProvince";
            DeleteProvince.Size = new Size(84, 42);
            DeleteProvince.TabIndex = 6;
            DeleteProvince.Text = "Delete";
            DeleteProvince.UseVisualStyleBackColor = true;
            DeleteProvince.Click += DeleteProvince_Click;
            // 
            // ClearListbox
            // 
            ClearListbox.Location = new Point(478, 443);
            ClearListbox.Name = "ClearListbox";
            ClearListbox.Size = new Size(84, 42);
            ClearListbox.TabIndex = 7;
            ClearListbox.Text = "Clear";
            ClearListbox.UseVisualStyleBackColor = true;
            ClearListbox.Click += ClearListbox_Click;
            // 
            // TradeListbox
            // 
            TradeListbox.FormattingEnabled = true;
            TradeListbox.ItemHeight = 15;
            TradeListbox.Location = new Point(628, 43);
            TradeListbox.Name = "TradeListbox";
            TradeListbox.Size = new Size(335, 394);
            TradeListbox.TabIndex = 4;
            TradeListbox.SelectedIndexChanged += provinceListbox_SelectedIndexChanged;
            // 
            // ExportOne
            // 
            ExportOne.Location = new Point(628, 443);
            ExportOne.Name = "ExportOne";
            ExportOne.Size = new Size(84, 42);
            ExportOne.TabIndex = 8;
            ExportOne.Text = "Export";
            ExportOne.UseVisualStyleBackColor = true;
            ExportOne.Click += ExportOne_Click;
            // 
            // ExportAll
            // 
            ExportAll.Location = new Point(737, 444);
            ExportAll.Name = "ExportAll";
            ExportAll.Size = new Size(84, 42);
            ExportAll.TabIndex = 9;
            ExportAll.Text = "Export All";
            ExportAll.UseVisualStyleBackColor = true;
            ExportAll.Click += ExportAll_Click;
            // 
            // TotalLabel
            // 
            TotalLabel.AutoSize = true;
            TotalLabel.Location = new Point(881, 25);
            TotalLabel.Name = "TotalLabel";
            TotalLabel.Size = new Size(35, 15);
            TotalLabel.TabIndex = 10;
            TotalLabel.Text = "Total:";
            TotalLabel.Click += TotalLabel_Click;
            // 
            // TotalSkillNum
            // 
            TotalSkillNum.AutoSize = true;
            TotalSkillNum.Location = new Point(920, 25);
            TotalSkillNum.Name = "TotalSkillNum";
            TotalSkillNum.Size = new Size(13, 15);
            TotalSkillNum.TabIndex = 11;
            TotalSkillNum.Text = "0";
            // 
            // ExportTemp
            // 
            ExportTemp.Location = new Point(628, 506);
            ExportTemp.Name = "ExportTemp";
            ExportTemp.Size = new Size(84, 42);
            ExportTemp.TabIndex = 12;
            ExportTemp.Text = "ExportTemp";
            ExportTemp.UseVisualStyleBackColor = true;
            ExportTemp.Click += ExportTemp_Click;
            // 
            // ExportAllTemp
            // 
            ExportAllTemp.Location = new Point(737, 506);
            ExportAllTemp.Name = "ExportAllTemp";
            ExportAllTemp.Size = new Size(99, 42);
            ExportAllTemp.TabIndex = 13;
            ExportAllTemp.Text = "ExportAllTemp";
            ExportAllTemp.UseVisualStyleBackColor = true;
            ExportAllTemp.Click += ExportAllTemp_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(478, 25);
            label1.Name = "label1";
            label1.Size = new Size(35, 15);
            label1.TabIndex = 10;
            label1.Text = "Total:";
            label1.Click += TotalLabel_Click;
            // 
            // ProvinceNum
            // 
            ProvinceNum.AutoSize = true;
            ProvinceNum.Location = new Point(519, 25);
            ProvinceNum.Name = "ProvinceNum";
            ProvinceNum.Size = new Size(13, 15);
            ProvinceNum.TabIndex = 14;
            ProvinceNum.Text = "0";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1062, 612);
            Controls.Add(ProvinceNum);
            Controls.Add(ExportAllTemp);
            Controls.Add(ExportTemp);
            Controls.Add(TotalSkillNum);
            Controls.Add(label1);
            Controls.Add(TotalLabel);
            Controls.Add(ExportAll);
            Controls.Add(ExportOne);
            Controls.Add(ClearListbox);
            Controls.Add(DeleteProvince);
            Controls.Add(ClearExltable);
            Controls.Add(TradeListbox);
            Controls.Add(provinceListbox);
            Controls.Add(Save);
            Controls.Add(dataGridView1);
            Controls.Add(ImportExcel);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ImportExcel;
        private DataGridView dataGridView1;
        private Button Save;
        private ListBox provinceListbox;
        private Button ClearExltable;
        private Button DeleteProvince;
        private Button ClearListbox;
        private ListBox TradeListbox;
        private Button ExportOne;
        private Button ExportAll;
        private Label TotalLabel;
        private Label TotalSkillNum;
        private Button ExportTemp;
        private Button ExportAllTemp;
        private Label label1;
        private Label ProvinceNum;
    }
}