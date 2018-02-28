namespace TaskManager_v1
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.hWndNameListBox = new System.Windows.Forms.ListBox();
            this.hWndListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // hWndNameListBox
            // 
            this.hWndNameListBox.FormattingEnabled = true;
            this.hWndNameListBox.ItemHeight = 12;
            this.hWndNameListBox.Location = new System.Drawing.Point(12, 190);
            this.hWndNameListBox.Name = "hWndNameListBox";
            this.hWndNameListBox.Size = new System.Drawing.Size(272, 232);
            this.hWndNameListBox.TabIndex = 0;
            // 
            // hWndListBox
            // 
            this.hWndListBox.FormattingEnabled = true;
            this.hWndListBox.ItemHeight = 12;
            this.hWndListBox.Location = new System.Drawing.Point(294, 190);
            this.hWndListBox.Name = "hWndListBox";
            this.hWndListBox.Size = new System.Drawing.Size(100, 232);
            this.hWndListBox.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 434);
            this.Controls.Add(this.hWndListBox);
            this.Controls.Add(this.hWndNameListBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox hWndNameListBox;
        private System.Windows.Forms.ListBox hWndListBox;
    }
}

