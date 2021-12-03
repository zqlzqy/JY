namespace FBGroundControl.chao.views
{
    partial class StatusForm
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
            this.statusPanel = new System.Windows.Forms.Panel();
            this.tabControlactions = new System.Windows.Forms.TabControl();
            this.tabQuick = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelQuick = new System.Windows.Forms.TableLayoutPanel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.statusPanel.SuspendLayout();
            this.tabControlactions.SuspendLayout();
            this.tabQuick.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusPanel
            // 
            this.statusPanel.Controls.Add(this.tabControlactions);
            this.statusPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusPanel.Location = new System.Drawing.Point(0, 0);
            this.statusPanel.Name = "statusPanel";
            this.statusPanel.Size = new System.Drawing.Size(598, 379);
            this.statusPanel.TabIndex = 0;
            // 
            // tabControlactions
            // 
            this.tabControlactions.Controls.Add(this.tabQuick);
            this.tabControlactions.Controls.Add(this.tabPage2);
            this.tabControlactions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlactions.Location = new System.Drawing.Point(0, 0);
            this.tabControlactions.Name = "tabControlactions";
            this.tabControlactions.SelectedIndex = 0;
            this.tabControlactions.Size = new System.Drawing.Size(598, 379);
            this.tabControlactions.TabIndex = 0;
            // 
            // tabQuick
            // 
            this.tabQuick.Controls.Add(this.tableLayoutPanelQuick);
            this.tabQuick.Location = new System.Drawing.Point(4, 22);
            this.tabQuick.Name = "tabQuick";
            this.tabQuick.Padding = new System.Windows.Forms.Padding(3);
            this.tabQuick.Size = new System.Drawing.Size(590, 353);
            this.tabQuick.TabIndex = 0;
            this.tabQuick.Text = "表格";
            this.tabQuick.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelQuick
            // 
            this.tableLayoutPanelQuick.AutoScroll = true;
            this.tableLayoutPanelQuick.ColumnCount = 3;
            this.tableLayoutPanelQuick.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelQuick.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanelQuick.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanelQuick.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelQuick.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelQuick.Name = "tableLayoutPanelQuick";
            this.tableLayoutPanelQuick.RowCount = 5;
            this.tableLayoutPanelQuick.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelQuick.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelQuick.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelQuick.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelQuick.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelQuick.Size = new System.Drawing.Size(584, 347);
            this.tableLayoutPanelQuick.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(590, 353);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // StatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 379);
            this.Controls.Add(this.statusPanel);
            this.Name = "StatusForm";
            this.Text = "状态区";
            this.statusPanel.ResumeLayout(false);
            this.tabControlactions.ResumeLayout(false);
            this.tabQuick.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel statusPanel;
        private System.Windows.Forms.TabControl tabControlactions;
        private System.Windows.Forms.TabPage tabQuick;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelQuick;
        private System.Windows.Forms.TabPage tabPage2;
    }
}