namespace EncriptionDecription
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEnCrypt = new System.Windows.Forms.TextBox();
            this.txtCypher = new System.Windows.Forms.TextBox();
            this.txtDecript = new System.Windows.Forms.TextBox();
            this.CypherText = new System.Windows.Forms.Label();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Text To Encrypt";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "a";
            // 
            // txtEnCrypt
            // 
            this.txtEnCrypt.Location = new System.Drawing.Point(30, 51);
            this.txtEnCrypt.Name = "txtEnCrypt";
            this.txtEnCrypt.Size = new System.Drawing.Size(427, 20);
            this.txtEnCrypt.TabIndex = 2;
            // 
            // txtCypher
            // 
            this.txtCypher.Location = new System.Drawing.Point(30, 142);
            this.txtCypher.Name = "txtCypher";
            this.txtCypher.Size = new System.Drawing.Size(427, 20);
            this.txtCypher.TabIndex = 3;
            // 
            // txtDecript
            // 
            this.txtDecript.Location = new System.Drawing.Point(30, 220);
            this.txtDecript.Name = "txtDecript";
            this.txtDecript.Size = new System.Drawing.Size(427, 20);
            this.txtDecript.TabIndex = 4;
            // 
            // CypherText
            // 
            this.CypherText.AutoSize = true;
            this.CypherText.Location = new System.Drawing.Point(27, 194);
            this.CypherText.Name = "CypherText";
            this.CypherText.Size = new System.Drawing.Size(77, 13);
            this.CypherText.TabIndex = 5;
            this.CypherText.Text = "DecryptedText";
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(581, 86);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(75, 23);
            this.btnEncrypt.TabIndex = 6;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(598, 172);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(75, 23);
            this.btnDecrypt.TabIndex = 7;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 261);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.CypherText);
            this.Controls.Add(this.txtDecript);
            this.Controls.Add(this.txtCypher);
            this.Controls.Add(this.txtEnCrypt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEnCrypt;
        private System.Windows.Forms.TextBox txtCypher;
        private System.Windows.Forms.TextBox txtDecript;
        private System.Windows.Forms.Label CypherText;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnDecrypt;
    }
}

