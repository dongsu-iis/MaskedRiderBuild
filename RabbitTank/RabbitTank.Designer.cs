namespace RabbitTank
{
    partial class RabbitTank
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RabbitTank));
            this.btnBuild = new System.Windows.Forms.Button();
            this.dataGridViewProject = new System.Windows.Forms.DataGridView();
            this.comboBoxVersion = new System.Windows.Forms.ComboBox();
            this.txtBoxTargetFol = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBoxOutputFol = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBoxLogFol = new System.Windows.Forms.TextBox();
            this.btnTarget = new System.Windows.Forms.Button();
            this.btnOut = new System.Windows.Forms.Button();
            this.btnLog = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxBit = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBuild
            // 
            this.btnBuild.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnBuild.Location = new System.Drawing.Point(709, 56);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(128, 59);
            this.btnBuild.TabIndex = 0;
            this.btnBuild.Text = "ビルド！！";
            this.btnBuild.UseVisualStyleBackColor = true;
            this.btnBuild.Click += new System.EventHandler(this.BtnBuild_Click);
            // 
            // dataGridViewProject
            // 
            this.dataGridViewProject.AllowUserToAddRows = false;
            this.dataGridViewProject.AllowUserToDeleteRows = false;
            this.dataGridViewProject.AllowUserToOrderColumns = true;
            this.dataGridViewProject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProject.Location = new System.Drawing.Point(26, 275);
            this.dataGridViewProject.Name = "dataGridViewProject";
            this.dataGridViewProject.ReadOnly = true;
            this.dataGridViewProject.RowHeadersVisible = false;
            this.dataGridViewProject.RowTemplate.Height = 21;
            this.dataGridViewProject.Size = new System.Drawing.Size(672, 209);
            this.dataGridViewProject.TabIndex = 1;
            // 
            // comboBoxVersion
            // 
            this.comboBoxVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVersion.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboBoxVersion.FormattingEnabled = true;
            this.comboBoxVersion.Items.AddRange(new object[] {
            "v3.5",
            "v4.5.2",
            "v4.6",
            "v4.6.1",
            "v4.7"});
            this.comboBoxVersion.Location = new System.Drawing.Point(248, 65);
            this.comboBoxVersion.Name = "comboBoxVersion";
            this.comboBoxVersion.Size = new System.Drawing.Size(134, 28);
            this.comboBoxVersion.TabIndex = 3;
            // 
            // txtBoxTargetFol
            // 
            this.txtBoxTargetFol.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtBoxTargetFol.Location = new System.Drawing.Point(246, 24);
            this.txtBoxTargetFol.Name = "txtBoxTargetFol";
            this.txtBoxTargetFol.ReadOnly = true;
            this.txtBoxTargetFol.Size = new System.Drawing.Size(397, 27);
            this.txtBoxTargetFol.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(20, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "ビルド対象フォルダ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(20, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = ".NET Frameworkバージョン";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(20, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "出力フォルダ";
            // 
            // txtBoxOutputFol
            // 
            this.txtBoxOutputFol.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtBoxOutputFol.Location = new System.Drawing.Point(246, 102);
            this.txtBoxOutputFol.Name = "txtBoxOutputFol";
            this.txtBoxOutputFol.ReadOnly = true;
            this.txtBoxOutputFol.Size = new System.Drawing.Size(397, 27);
            this.txtBoxOutputFol.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(20, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(190, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "ビルド結果のログフォルダ";
            // 
            // txtBoxLogFol
            // 
            this.txtBoxLogFol.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtBoxLogFol.Location = new System.Drawing.Point(246, 134);
            this.txtBoxLogFol.Name = "txtBoxLogFol";
            this.txtBoxLogFol.ReadOnly = true;
            this.txtBoxLogFol.Size = new System.Drawing.Size(397, 27);
            this.txtBoxLogFol.TabIndex = 4;
            // 
            // btnTarget
            // 
            this.btnTarget.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnTarget.Location = new System.Drawing.Point(650, 24);
            this.btnTarget.Name = "btnTarget";
            this.btnTarget.Size = new System.Drawing.Size(44, 27);
            this.btnTarget.TabIndex = 6;
            this.btnTarget.Text = "…";
            this.btnTarget.UseVisualStyleBackColor = true;
            this.btnTarget.Click += new System.EventHandler(this.BtnTarget_Click);
            // 
            // btnOut
            // 
            this.btnOut.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnOut.Location = new System.Drawing.Point(650, 102);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(44, 27);
            this.btnOut.TabIndex = 6;
            this.btnOut.Text = "…";
            this.btnOut.UseVisualStyleBackColor = true;
            this.btnOut.Click += new System.EventHandler(this.BtnOut_Click);
            // 
            // btnLog
            // 
            this.btnLog.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnLog.Location = new System.Drawing.Point(650, 133);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(44, 27);
            this.btnLog.TabIndex = 6;
            this.btnLog.Text = "…";
            this.btnLog.UseVisualStyleBackColor = true;
            this.btnLog.Click += new System.EventHandler(this.BtnLog_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(22, 249);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 23);
            this.label5.TabIndex = 5;
            this.label5.Text = "プロジェクト一覧";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RabbitTank.Properties.Resources.kiryu;
            this.pictureBox1.Location = new System.Drawing.Point(704, 275);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(166, 209);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLanguage.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Items.AddRange(new object[] {
            "*.vbproj",
            "*csproj"});
            this.comboBoxLanguage.Location = new System.Drawing.Point(246, 167);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(134, 28);
            this.comboBoxLanguage.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(20, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 23);
            this.label6.TabIndex = 5;
            this.label6.Text = "言語";
            // 
            // comboBoxBit
            // 
            this.comboBoxBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBit.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboBoxBit.FormattingEnabled = true;
            this.comboBoxBit.Items.AddRange(new object[] {
            "x86",
            "x64",
            "AnyCPU"});
            this.comboBoxBit.Location = new System.Drawing.Point(246, 201);
            this.comboBoxBit.Name = "comboBoxBit";
            this.comboBoxBit.Size = new System.Drawing.Size(134, 28);
            this.comboBoxBit.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(20, 206);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 23);
            this.label7.TabIndex = 5;
            this.label7.Text = "ビット";
            // 
            // RabbitTank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 496);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnLog);
            this.Controls.Add(this.btnOut);
            this.Controls.Add(this.btnTarget);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBoxLogFol);
            this.Controls.Add(this.txtBoxOutputFol);
            this.Controls.Add(this.txtBoxTargetFol);
            this.Controls.Add(this.comboBoxBit);
            this.Controls.Add(this.comboBoxLanguage);
            this.Controls.Add(this.comboBoxVersion);
            this.Controls.Add(this.dataGridViewProject);
            this.Controls.Add(this.btnBuild);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RabbitTank";
            this.Text = "戦兎";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuild;
        private System.Windows.Forms.DataGridView dataGridViewProject;
        private System.Windows.Forms.ComboBox comboBoxVersion;
        private System.Windows.Forms.TextBox txtBoxTargetFol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBoxOutputFol;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBoxLogFol;
        private System.Windows.Forms.Button btnTarget;
        private System.Windows.Forms.Button btnOut;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox comboBoxLanguage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxBit;
        private System.Windows.Forms.Label label7;
    }
}

