namespace JogoGourmet
{
    partial class GuessAnDish
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GuessAnDish));
            btnOk = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnOk
            // 
            btnOk.Font = new Font("Segoe UI", 9F);
            btnOk.Location = new Point(115, 52);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(100, 30);
            btnOk.TabIndex = 0;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(70, 21);
            label1.Name = "label1";
            label1.Size = new Size(196, 15);
            label1.TabIndex = 1;
            label1.Text = "Pense em um prato que voce gosta.";
            // 
            // GuessAnDish
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(334, 91);
            Controls.Add(label1);
            Controls.Add(btnOk);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "GuessAnDish";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Jogo Gourmet";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnOk;
        private Label label1;
    }
}
