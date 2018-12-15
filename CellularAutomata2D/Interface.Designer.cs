namespace CellularAutomata2D {
    partial class Interface {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.visualBox = new System.Windows.Forms.PictureBox();
            this.reset = new System.Windows.Forms.Button();
            this.nextStep = new System.Windows.Forms.Button();
            this.playPause = new System.Windows.Forms.Button();
            this.random = new System.Windows.Forms.Button();
            this.mode = new System.Windows.Forms.ComboBox();
            this.neighboorhood = new System.Windows.Forms.ComboBox();
            this.boundaryCondition = new System.Windows.Forms.ComboBox();
            this.grains = new System.Windows.Forms.TextBox();
            this.radius = new System.Windows.Forms.TextBox();
            this.generateGrains = new System.Windows.Forms.Button();
            this.sizeAvg = new System.Windows.Forms.Label();
            this.borderLengthSum = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.visualBox)).BeginInit();
            this.SuspendLayout();
            // 
            // visualBox
            // 
            this.visualBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.visualBox.Location = new System.Drawing.Point(28, 8);
            this.visualBox.Name = "visualBox";
            this.visualBox.Size = new System.Drawing.Size(500, 500);
            this.visualBox.TabIndex = 0;
            this.visualBox.TabStop = false;
            this.visualBox.Click += new System.EventHandler(this.VisualBox_Click);
            // 
            // reset
            // 
            this.reset.Location = new System.Drawing.Point(534, 8);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(117, 23);
            this.reset.TabIndex = 1;
            this.reset.Text = "Reset grid";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // nextStep
            // 
            this.nextStep.Location = new System.Drawing.Point(534, 66);
            this.nextStep.Name = "nextStep";
            this.nextStep.Size = new System.Drawing.Size(117, 23);
            this.nextStep.TabIndex = 2;
            this.nextStep.Text = "Next step";
            this.nextStep.UseVisualStyleBackColor = true;
            this.nextStep.Click += new System.EventHandler(this.NextStep_Click);
            // 
            // playPause
            // 
            this.playPause.Location = new System.Drawing.Point(534, 485);
            this.playPause.Name = "playPause";
            this.playPause.Size = new System.Drawing.Size(117, 23);
            this.playPause.TabIndex = 3;
            this.playPause.Text = "Play";
            this.playPause.UseVisualStyleBackColor = true;
            this.playPause.Click += new System.EventHandler(this.PlayPause_Click);
            // 
            // random
            // 
            this.random.Location = new System.Drawing.Point(534, 37);
            this.random.Name = "random";
            this.random.Size = new System.Drawing.Size(117, 23);
            this.random.TabIndex = 4;
            this.random.Text = "Chaotic random";
            this.random.UseVisualStyleBackColor = true;
            this.random.Click += new System.EventHandler(this.Random_Click);
            // 
            // mode
            // 
            this.mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mode.FormattingEnabled = true;
            this.mode.Items.AddRange(new object[] {
            "point",
            "static",
            "oscillator",
            "spaceship"});
            this.mode.Location = new System.Drawing.Point(534, 115);
            this.mode.Margin = new System.Windows.Forms.Padding(2);
            this.mode.Name = "mode";
            this.mode.Size = new System.Drawing.Size(117, 21);
            this.mode.TabIndex = 5;
            // 
            // neighboorhood
            // 
            this.neighboorhood.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.neighboorhood.FormattingEnabled = true;
            this.neighboorhood.Items.AddRange(new object[] {
            "thegameoflife",
            "neumann",
            "moore",
            "hexleft",
            "hexright",
            "hexrandom",
            "pexleft",
            "pexright",
            "pexrandom"});
            this.neighboorhood.Location = new System.Drawing.Point(534, 141);
            this.neighboorhood.Name = "neighboorhood";
            this.neighboorhood.Size = new System.Drawing.Size(117, 21);
            this.neighboorhood.TabIndex = 6;
            this.neighboorhood.SelectedIndexChanged += new System.EventHandler(this.Neighboorhood_SelectedIndexChanged);
            // 
            // boundaryCondition
            // 
            this.boundaryCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boundaryCondition.FormattingEnabled = true;
            this.boundaryCondition.Items.AddRange(new object[] {
            "periodic",
            "setfalse"});
            this.boundaryCondition.Location = new System.Drawing.Point(534, 168);
            this.boundaryCondition.Name = "boundaryCondition";
            this.boundaryCondition.Size = new System.Drawing.Size(117, 21);
            this.boundaryCondition.TabIndex = 7;
            this.boundaryCondition.SelectedIndexChanged += new System.EventHandler(this.BoundaryCondition_SelectedIndexChanged);
            // 
            // grains
            // 
            this.grains.Location = new System.Drawing.Point(534, 271);
            this.grains.Name = "grains";
            this.grains.Size = new System.Drawing.Size(117, 20);
            this.grains.TabIndex = 8;
            this.grains.Text = "10";
            // 
            // radius
            // 
            this.radius.Location = new System.Drawing.Point(534, 297);
            this.radius.Name = "radius";
            this.radius.Size = new System.Drawing.Size(117, 20);
            this.radius.TabIndex = 9;
            this.radius.Text = "3";
            // 
            // generateGrains
            // 
            this.generateGrains.Location = new System.Drawing.Point(534, 323);
            this.generateGrains.Name = "generateGrains";
            this.generateGrains.Size = new System.Drawing.Size(117, 23);
            this.generateGrains.TabIndex = 10;
            this.generateGrains.Text = "Smart radom";
            this.generateGrains.UseVisualStyleBackColor = true;
            this.generateGrains.Click += new System.EventHandler(this.GenerateGrains_Click);
            // 
            // sizeAvg
            // 
            this.sizeAvg.AutoSize = true;
            this.sizeAvg.Location = new System.Drawing.Point(532, 466);
            this.sizeAvg.Name = "sizeAvg";
            this.sizeAvg.Size = new System.Drawing.Size(0, 13);
            this.sizeAvg.TabIndex = 11;
            // 
            // borderLengthSum
            // 
            this.borderLengthSum.AutoSize = true;
            this.borderLengthSum.Location = new System.Drawing.Point(534, 448);
            this.borderLengthSum.Name = "borderLengthSum";
            this.borderLengthSum.Size = new System.Drawing.Size(0, 13);
            this.borderLengthSum.TabIndex = 12;
            // 
            // Interface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 523);
            this.Controls.Add(this.borderLengthSum);
            this.Controls.Add(this.sizeAvg);
            this.Controls.Add(this.generateGrains);
            this.Controls.Add(this.radius);
            this.Controls.Add(this.grains);
            this.Controls.Add(this.boundaryCondition);
            this.Controls.Add(this.neighboorhood);
            this.Controls.Add(this.mode);
            this.Controls.Add(this.random);
            this.Controls.Add(this.playPause);
            this.Controls.Add(this.nextStep);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.visualBox);
            this.MaximizeBox = false;
            this.Name = "Interface";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "CellularAutomata2D";
            ((System.ComponentModel.ISupportInitialize)(this.visualBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox visualBox;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.Button nextStep;
        private System.Windows.Forms.Button playPause;
        private System.Windows.Forms.Button random;
        private System.Windows.Forms.ComboBox mode;
        private System.Windows.Forms.ComboBox neighboorhood;
        private System.Windows.Forms.ComboBox boundaryCondition;
        private System.Windows.Forms.TextBox grains;
        private System.Windows.Forms.TextBox radius;
        private System.Windows.Forms.Button generateGrains;
        private System.Windows.Forms.Label sizeAvg;
        private System.Windows.Forms.Label borderLengthSum;
    }
}

