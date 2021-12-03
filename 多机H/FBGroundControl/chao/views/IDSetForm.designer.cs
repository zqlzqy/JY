namespace FBGroundControl.chao.views
{
    partial class IDSetForm
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.searchIDBtn = new System.Windows.Forms.Button();
            this.setIDBtn = new System.Windows.Forms.Button();
            this.system_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.current_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modify_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.system_id,
            this.current_id,
            this.modify_id});
            this.dataGridView.Location = new System.Drawing.Point(79, 12);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.Size = new System.Drawing.Size(339, 340);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView_RowPostPaint);
            // 
            // searchIDBtn
            // 
            this.searchIDBtn.Location = new System.Drawing.Point(129, 374);
            this.searchIDBtn.Name = "searchIDBtn";
            this.searchIDBtn.Size = new System.Drawing.Size(75, 23);
            this.searchIDBtn.TabIndex = 1;
            this.searchIDBtn.Text = "查询";
            this.searchIDBtn.UseVisualStyleBackColor = true;
            this.searchIDBtn.Click += new System.EventHandler(this.searchIDBtn_Click);
            // 
            // setIDBtn
            // 
            this.setIDBtn.Location = new System.Drawing.Point(289, 374);
            this.setIDBtn.Name = "setIDBtn";
            this.setIDBtn.Size = new System.Drawing.Size(75, 23);
            this.setIDBtn.TabIndex = 2;
            this.setIDBtn.Text = "设置";
            this.setIDBtn.UseVisualStyleBackColor = true;
            this.setIDBtn.Click += new System.EventHandler(this.setIDBtn_Click);
            // 
            // system_id
            // 
            this.system_id.DataPropertyName = "system_id";
            this.system_id.HeaderText = "编号";
            this.system_id.Name = "system_id";
            this.system_id.ReadOnly = true;
            // 
            // current_id
            // 
            this.current_id.DataPropertyName = "current_id";
            this.current_id.HeaderText = "当前ID";
            this.current_id.Name = "current_id";
            this.current_id.ReadOnly = true;
            // 
            // modify_id
            // 
            this.modify_id.DataPropertyName = "modify_id";
            this.modify_id.HeaderText = "更改ID";
            this.modify_id.Name = "modify_id";
            // 
            // IDSetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 425);
            this.Controls.Add(this.setIDBtn);
            this.Controls.Add(this.searchIDBtn);
            this.Controls.Add(this.dataGridView);
            this.Name = "IDSetForm";
            this.Text = "编号设置";
            this.Load += new System.EventHandler(this.IDSetForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button searchIDBtn;
        private System.Windows.Forms.Button setIDBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn system_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn current_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn modify_id;
    }
}