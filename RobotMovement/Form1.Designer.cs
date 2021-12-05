
namespace RobotMovement
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.moveRobotForwardBTN = new System.Windows.Forms.Button();
            this.DownDirectionBTN = new System.Windows.Forms.Button();
            this.directionTB = new System.Windows.Forms.TextBox();
            this.LeftDirectionBTN = new System.Windows.Forms.Button();
            this.UpDirectionBTN = new System.Windows.Forms.Button();
            this.RightDirectionBTN = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.rotateRobotRightBTN = new System.Windows.Forms.Button();
            this.spawnRobotBTN = new System.Windows.Forms.Button();
            this.generateMapBTN = new System.Windows.Forms.Button();
            this.mapSizeYUpDown = new System.Windows.Forms.NumericUpDown();
            this.mapSizeXUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.gameGrid = new System.Windows.Forms.DataGridView();
            this.gridPanel = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.perlinNoiseRBTN = new System.Windows.Forms.RadioButton();
            this.randomGenRBTN = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapSizeYUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapSizeXUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameGrid)).BeginInit();
            this.gridPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ширина карты";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.moveRobotForwardBTN);
            this.panel1.Controls.Add(this.DownDirectionBTN);
            this.panel1.Controls.Add(this.directionTB);
            this.panel1.Controls.Add(this.LeftDirectionBTN);
            this.panel1.Controls.Add(this.UpDirectionBTN);
            this.panel1.Controls.Add(this.RightDirectionBTN);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.rotateRobotRightBTN);
            this.panel1.Controls.Add(this.spawnRobotBTN);
            this.panel1.Controls.Add(this.generateMapBTN);
            this.panel1.Controls.Add(this.mapSizeYUpDown);
            this.panel1.Controls.Add(this.mapSizeXUpDown);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(762, 12);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(157, 521);
            this.panel1.TabIndex = 2;
            // 
            // moveRobotForwardBTN
            // 
            this.moveRobotForwardBTN.Location = new System.Drawing.Point(7, 487);
            this.moveRobotForwardBTN.Name = "moveRobotForwardBTN";
            this.moveRobotForwardBTN.Size = new System.Drawing.Size(140, 25);
            this.moveRobotForwardBTN.TabIndex = 11;
            this.moveRobotForwardBTN.Text = "На 1 вперед";
            this.moveRobotForwardBTN.UseVisualStyleBackColor = true;
            this.moveRobotForwardBTN.Click += new System.EventHandler(this.moveRobotForwardBTN_Click);
            // 
            // DownDirectionBTN
            // 
            this.DownDirectionBTN.Location = new System.Drawing.Point(62, 326);
            this.DownDirectionBTN.Margin = new System.Windows.Forms.Padding(0);
            this.DownDirectionBTN.Name = "DownDirectionBTN";
            this.DownDirectionBTN.Size = new System.Drawing.Size(28, 28);
            this.DownDirectionBTN.TabIndex = 10;
            this.DownDirectionBTN.Text = "▼";
            this.DownDirectionBTN.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.DownDirectionBTN.UseVisualStyleBackColor = true;
            this.DownDirectionBTN.Click += new System.EventHandler(this.DownDirectionBTN_Click);
            // 
            // directionTB
            // 
            this.directionTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.directionTB.Location = new System.Drawing.Point(62, 295);
            this.directionTB.Multiline = true;
            this.directionTB.Name = "directionTB";
            this.directionTB.ReadOnly = true;
            this.directionTB.Size = new System.Drawing.Size(28, 28);
            this.directionTB.TabIndex = 9;
            this.directionTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LeftDirectionBTN
            // 
            this.LeftDirectionBTN.Location = new System.Drawing.Point(31, 295);
            this.LeftDirectionBTN.Margin = new System.Windows.Forms.Padding(0);
            this.LeftDirectionBTN.Name = "LeftDirectionBTN";
            this.LeftDirectionBTN.Size = new System.Drawing.Size(28, 28);
            this.LeftDirectionBTN.TabIndex = 8;
            this.LeftDirectionBTN.Text = "◀";
            this.LeftDirectionBTN.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.LeftDirectionBTN.UseVisualStyleBackColor = true;
            this.LeftDirectionBTN.Click += new System.EventHandler(this.LeftDirectionBTN_Click);
            // 
            // UpDirectionBTN
            // 
            this.UpDirectionBTN.Location = new System.Drawing.Point(62, 264);
            this.UpDirectionBTN.Margin = new System.Windows.Forms.Padding(0);
            this.UpDirectionBTN.Name = "UpDirectionBTN";
            this.UpDirectionBTN.Size = new System.Drawing.Size(28, 28);
            this.UpDirectionBTN.TabIndex = 7;
            this.UpDirectionBTN.Text = "▲";
            this.UpDirectionBTN.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.UpDirectionBTN.UseVisualStyleBackColor = true;
            this.UpDirectionBTN.Click += new System.EventHandler(this.UpDirectionBTN_Click);
            // 
            // RightDirectionBTN
            // 
            this.RightDirectionBTN.Location = new System.Drawing.Point(93, 295);
            this.RightDirectionBTN.Margin = new System.Windows.Forms.Padding(0);
            this.RightDirectionBTN.Name = "RightDirectionBTN";
            this.RightDirectionBTN.Size = new System.Drawing.Size(28, 28);
            this.RightDirectionBTN.TabIndex = 6;
            this.RightDirectionBTN.Text = "▶";
            this.RightDirectionBTN.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.RightDirectionBTN.UseVisualStyleBackColor = true;
            this.RightDirectionBTN.Click += new System.EventHandler(this.RightDirectionBTN_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 236);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Направление робота";
            // 
            // rotateRobotRightBTN
            // 
            this.rotateRobotRightBTN.Location = new System.Drawing.Point(7, 430);
            this.rotateRobotRightBTN.Name = "rotateRobotRightBTN";
            this.rotateRobotRightBTN.Size = new System.Drawing.Size(140, 51);
            this.rotateRobotRightBTN.TabIndex = 4;
            this.rotateRobotRightBTN.Text = "Повернуть робота вправо";
            this.rotateRobotRightBTN.UseVisualStyleBackColor = true;
            this.rotateRobotRightBTN.Click += new System.EventHandler(this.rotateRobotRightBTN_Click);
            // 
            // spawnRobotBTN
            // 
            this.spawnRobotBTN.Location = new System.Drawing.Point(7, 399);
            this.spawnRobotBTN.Name = "spawnRobotBTN";
            this.spawnRobotBTN.Size = new System.Drawing.Size(140, 25);
            this.spawnRobotBTN.TabIndex = 3;
            this.spawnRobotBTN.Text = "Поставить робота";
            this.spawnRobotBTN.UseVisualStyleBackColor = true;
            this.spawnRobotBTN.Click += new System.EventHandler(this.spawnRobotBTN_Click);
            // 
            // generateMapBTN
            // 
            this.generateMapBTN.Location = new System.Drawing.Point(7, 208);
            this.generateMapBTN.Name = "generateMapBTN";
            this.generateMapBTN.Size = new System.Drawing.Size(140, 25);
            this.generateMapBTN.TabIndex = 3;
            this.generateMapBTN.Text = "Сгенерировать";
            this.generateMapBTN.UseVisualStyleBackColor = true;
            this.generateMapBTN.Click += new System.EventHandler(this.generateMapBTN_Click);
            // 
            // mapSizeYUpDown
            // 
            this.mapSizeYUpDown.Location = new System.Drawing.Point(7, 85);
            this.mapSizeYUpDown.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.mapSizeYUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.mapSizeYUpDown.Name = "mapSizeYUpDown";
            this.mapSizeYUpDown.Size = new System.Drawing.Size(140, 25);
            this.mapSizeYUpDown.TabIndex = 2;
            this.mapSizeYUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // mapSizeXUpDown
            // 
            this.mapSizeXUpDown.Location = new System.Drawing.Point(7, 23);
            this.mapSizeXUpDown.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.mapSizeXUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.mapSizeXUpDown.Name = "mapSizeXUpDown";
            this.mapSizeXUpDown.Size = new System.Drawing.Size(140, 25);
            this.mapSizeXUpDown.TabIndex = 2;
            this.mapSizeXUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Длина карты";
            // 
            // gameGrid
            // 
            this.gameGrid.AllowUserToAddRows = false;
            this.gameGrid.AllowUserToDeleteRows = false;
            this.gameGrid.AllowUserToResizeColumns = false;
            this.gameGrid.AllowUserToResizeRows = false;
            this.gameGrid.ColumnHeadersHeight = 30;
            this.gameGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gameGrid.ColumnHeadersVisible = false;
            this.gameGrid.Location = new System.Drawing.Point(3, 3);
            this.gameGrid.Name = "gameGrid";
            this.gameGrid.ReadOnly = true;
            this.gameGrid.RowHeadersVisible = false;
            this.gameGrid.RowHeadersWidth = 30;
            this.gameGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gameGrid.RowTemplate.Height = 50;
            this.gameGrid.RowTemplate.ReadOnly = true;
            this.gameGrid.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gameGrid.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.gameGrid.ShowEditingIcon = false;
            this.gameGrid.Size = new System.Drawing.Size(738, 558);
            this.gameGrid.TabIndex = 3;
            this.gameGrid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gameGrid_MouseDown);
            // 
            // gridPanel
            // 
            this.gridPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridPanel.Controls.Add(this.gameGrid);
            this.gridPanel.Location = new System.Drawing.Point(12, 12);
            this.gridPanel.Name = "gridPanel";
            this.gridPanel.Size = new System.Drawing.Size(744, 564);
            this.gridPanel.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.randomGenRBTN);
            this.groupBox1.Controls.Add(this.perlinNoiseRBTN);
            this.groupBox1.Location = new System.Drawing.Point(7, 117);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(140, 85);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Режим";
            // 
            // perlinNoiseRBTN
            // 
            this.perlinNoiseRBTN.AutoSize = true;
            this.perlinNoiseRBTN.Checked = true;
            this.perlinNoiseRBTN.Location = new System.Drawing.Point(6, 24);
            this.perlinNoiseRBTN.Name = "perlinNoiseRBTN";
            this.perlinNoiseRBTN.Size = new System.Drawing.Size(112, 23);
            this.perlinNoiseRBTN.TabIndex = 0;
            this.perlinNoiseRBTN.TabStop = true;
            this.perlinNoiseRBTN.Text = "Шум Перлина";
            this.perlinNoiseRBTN.UseVisualStyleBackColor = true;
            // 
            // randomGenRBTN
            // 
            this.randomGenRBTN.AutoSize = true;
            this.randomGenRBTN.Location = new System.Drawing.Point(6, 54);
            this.randomGenRBTN.Name = "randomGenRBTN";
            this.randomGenRBTN.Size = new System.Drawing.Size(77, 23);
            this.randomGenRBTN.TabIndex = 1;
            this.randomGenRBTN.TabStop = true;
            this.randomGenRBTN.Text = "Random";
            this.randomGenRBTN.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 588);
            this.Controls.Add(this.gridPanel);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapSizeYUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapSizeXUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameGrid)).EndInit();
            this.gridPanel.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown mapSizeXUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown mapSizeYUpDown;
        private System.Windows.Forms.Button generateMapBTN;
        private System.Windows.Forms.DataGridView gameGrid;
        private System.Windows.Forms.Button spawnRobotBTN;
        private System.Windows.Forms.Button rotateRobotRightBTN;
        private System.Windows.Forms.Panel gridPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button RightDirectionBTN;
        private System.Windows.Forms.TextBox directionTB;
        private System.Windows.Forms.Button LeftDirectionBTN;
        private System.Windows.Forms.Button UpDirectionBTN;
        private System.Windows.Forms.Button DownDirectionBTN;
        private System.Windows.Forms.Button moveRobotForwardBTN;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton perlinNoiseRBTN;
        private System.Windows.Forms.RadioButton randomGenRBTN;
    }
}

