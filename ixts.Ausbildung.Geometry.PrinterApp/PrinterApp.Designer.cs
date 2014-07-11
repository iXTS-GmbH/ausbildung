namespace ixts.Ausbildung.Geometry.PrinterApp
{
    partial class PrinterApp
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnl_drawField = new System.Windows.Forms.Panel();
            this.btn_moveUp = new System.Windows.Forms.Button();
            this.btn_moveRight = new System.Windows.Forms.Button();
            this.btn_moveDown = new System.Windows.Forms.Button();
            this.btn_moveLeft = new System.Windows.Forms.Button();
            this.btn_zoomMinus = new System.Windows.Forms.Button();
            this.btn_zoomPlus = new System.Windows.Forms.Button();
            this.lb_ListofForms = new System.Windows.Forms.ListBox();
            this.btn_Erase = new System.Windows.Forms.Button();
            this.btn_Draw = new System.Windows.Forms.Button();
            this.dd_Polygons = new System.Windows.Forms.ComboBox();
            this.tb_coordinates = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // pnl_drawField
            // 
            this.pnl_drawField.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnl_drawField.Location = new System.Drawing.Point(53, 110);
            this.pnl_drawField.Name = "pnl_drawField";
            this.pnl_drawField.Size = new System.Drawing.Size(250, 200);
            this.pnl_drawField.TabIndex = 0;
            // 
            // btn_moveUp
            // 
            this.btn_moveUp.Location = new System.Drawing.Point(150, 81);
            this.btn_moveUp.Name = "btn_moveUp";
            this.btn_moveUp.Size = new System.Drawing.Size(54, 23);
            this.btn_moveUp.TabIndex = 1;
            this.btn_moveUp.Text = "Oben";
            this.btn_moveUp.UseVisualStyleBackColor = true;
            this.btn_moveUp.Click += new System.EventHandler(this.btn_moveUp_Click);
            // 
            // btn_moveRight
            // 
            this.btn_moveRight.Location = new System.Drawing.Point(309, 200);
            this.btn_moveRight.Name = "btn_moveRight";
            this.btn_moveRight.Size = new System.Drawing.Size(59, 23);
            this.btn_moveRight.TabIndex = 2;
            this.btn_moveRight.Text = "Rechts";
            this.btn_moveRight.UseVisualStyleBackColor = true;
            // 
            // btn_moveDown
            // 
            this.btn_moveDown.Location = new System.Drawing.Point(151, 317);
            this.btn_moveDown.Name = "btn_moveDown";
            this.btn_moveDown.Size = new System.Drawing.Size(53, 23);
            this.btn_moveDown.TabIndex = 3;
            this.btn_moveDown.Text = "Unten";
            this.btn_moveDown.UseVisualStyleBackColor = true;
            // 
            // btn_moveLeft
            // 
            this.btn_moveLeft.Location = new System.Drawing.Point(1, 200);
            this.btn_moveLeft.Name = "btn_moveLeft";
            this.btn_moveLeft.Size = new System.Drawing.Size(46, 23);
            this.btn_moveLeft.TabIndex = 4;
            this.btn_moveLeft.Text = "Links";
            this.btn_moveLeft.UseVisualStyleBackColor = true;
            // 
            // btn_zoomMinus
            // 
            this.btn_zoomMinus.Location = new System.Drawing.Point(121, 32);
            this.btn_zoomMinus.Name = "btn_zoomMinus";
            this.btn_zoomMinus.Size = new System.Drawing.Size(27, 23);
            this.btn_zoomMinus.TabIndex = 5;
            this.btn_zoomMinus.Text = "-";
            this.btn_zoomMinus.UseVisualStyleBackColor = true;
            // 
            // btn_zoomPlus
            // 
            this.btn_zoomPlus.Location = new System.Drawing.Point(90, 32);
            this.btn_zoomPlus.Name = "btn_zoomPlus";
            this.btn_zoomPlus.Size = new System.Drawing.Size(25, 23);
            this.btn_zoomPlus.TabIndex = 6;
            this.btn_zoomPlus.Text = "+";
            this.btn_zoomPlus.UseVisualStyleBackColor = true;
            // 
            // lb_ListofForms
            // 
            this.lb_ListofForms.FormattingEnabled = true;
            this.lb_ListofForms.Location = new System.Drawing.Point(396, 303);
            this.lb_ListofForms.Name = "lb_ListofForms";
            this.lb_ListofForms.Size = new System.Drawing.Size(120, 95);
            this.lb_ListofForms.TabIndex = 7;
            // 
            // btn_Erase
            // 
            this.btn_Erase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_Erase.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Erase.Location = new System.Drawing.Point(425, 237);
            this.btn_Erase.Name = "btn_Erase";
            this.btn_Erase.Size = new System.Drawing.Size(75, 23);
            this.btn_Erase.TabIndex = 8;
            this.btn_Erase.Text = "Erase";
            this.btn_Erase.UseVisualStyleBackColor = false;
            this.btn_Erase.Click += new System.EventHandler(this.btn_Erase_Click);
            // 
            // btn_Draw
            // 
            this.btn_Draw.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btn_Draw.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Draw.Location = new System.Drawing.Point(425, 184);
            this.btn_Draw.Name = "btn_Draw";
            this.btn_Draw.Size = new System.Drawing.Size(75, 23);
            this.btn_Draw.TabIndex = 9;
            this.btn_Draw.Text = "Draw";
            this.btn_Draw.UseVisualStyleBackColor = false;
            this.btn_Draw.Click += new System.EventHandler(this.btn_Draw_Click);
            // 
            // dd_Polygons
            // 
            this.dd_Polygons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dd_Polygons.FormattingEnabled = true;
            this.dd_Polygons.Items.AddRange(new object[] {
            "Triangle",
            "Quadliteral"});
            this.dd_Polygons.Location = new System.Drawing.Point(396, 72);
            this.dd_Polygons.Name = "dd_Polygons";
            this.dd_Polygons.Size = new System.Drawing.Size(121, 21);
            this.dd_Polygons.TabIndex = 10;
            // 
            // tb_coordinates
            // 
            this.tb_coordinates.Location = new System.Drawing.Point(400, 120);
            this.tb_coordinates.Name = "tb_coordinates";
            this.tb_coordinates.Size = new System.Drawing.Size(100, 20);
            this.tb_coordinates.TabIndex = 11;
            // 
            // PrinterApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 501);
            this.Controls.Add(this.tb_coordinates);
            this.Controls.Add(this.dd_Polygons);
            this.Controls.Add(this.btn_Draw);
            this.Controls.Add(this.btn_Erase);
            this.Controls.Add(this.lb_ListofForms);
            this.Controls.Add(this.btn_zoomPlus);
            this.Controls.Add(this.btn_zoomMinus);
            this.Controls.Add(this.btn_moveLeft);
            this.Controls.Add(this.btn_moveDown);
            this.Controls.Add(this.btn_moveRight);
            this.Controls.Add(this.btn_moveUp);
            this.Controls.Add(this.pnl_drawField);
            this.Name = "PrinterApp";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_drawField;
        private System.Windows.Forms.Button btn_moveUp;
        private System.Windows.Forms.Button btn_moveRight;
        private System.Windows.Forms.Button btn_moveDown;
        private System.Windows.Forms.Button btn_moveLeft;
        private System.Windows.Forms.Button btn_zoomMinus;
        private System.Windows.Forms.Button btn_zoomPlus;
        private System.Windows.Forms.ListBox lb_ListofForms;
        private System.Windows.Forms.Button btn_Erase;
        private System.Windows.Forms.Button btn_Draw;
        private System.Windows.Forms.ComboBox dd_Polygons;
        private System.Windows.Forms.TextBox tb_coordinates;
    }
}

