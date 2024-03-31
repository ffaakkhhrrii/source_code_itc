namespace LKS_Fakhrii
{
    partial class FormPayment
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
            this.tbCheckMember = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCheck = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.totalLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cashRB = new System.Windows.Forms.RadioButton();
            this.cardRB = new System.Windows.Forms.RadioButton();
            this.tbCardNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnPay = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(231, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 29);
            this.label1.TabIndex = 44;
            this.label1.Text = "Transaction Form";
            // 
            // tbCheckMember
            // 
            this.tbCheckMember.Location = new System.Drawing.Point(236, 84);
            this.tbCheckMember.Name = "tbCheckMember";
            this.tbCheckMember.Size = new System.Drawing.Size(196, 22);
            this.tbCheckMember.TabIndex = 53;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(115, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 16);
            this.label3.TabIndex = 52;
            this.label3.Text = "Member ID";
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(468, 81);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(115, 33);
            this.btnCheck.TabIndex = 54;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(115, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 16);
            this.label2.TabIndex = 55;
            this.label2.Text = "Total";
            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.Location = new System.Drawing.Point(248, 136);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(0, 16);
            this.totalLabel.TabIndex = 56;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(115, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 16);
            this.label4.TabIndex = 57;
            this.label4.Text = "Payment Type";
            // 
            // cashRB
            // 
            this.cashRB.AutoSize = true;
            this.cashRB.Location = new System.Drawing.Point(236, 190);
            this.cashRB.Name = "cashRB";
            this.cashRB.Size = new System.Drawing.Size(59, 20);
            this.cashRB.TabIndex = 58;
            this.cashRB.TabStop = true;
            this.cashRB.Text = "Cash";
            this.cashRB.UseVisualStyleBackColor = true;
            // 
            // cardRB
            // 
            this.cardRB.AutoSize = true;
            this.cardRB.Location = new System.Drawing.Point(318, 190);
            this.cardRB.Name = "cardRB";
            this.cardRB.Size = new System.Drawing.Size(57, 20);
            this.cardRB.TabIndex = 59;
            this.cardRB.TabStop = true;
            this.cardRB.Text = "Card";
            this.cardRB.UseVisualStyleBackColor = true;
            // 
            // tbCardNumber
            // 
            this.tbCardNumber.Location = new System.Drawing.Point(236, 241);
            this.tbCardNumber.Name = "tbCardNumber";
            this.tbCardNumber.Size = new System.Drawing.Size(196, 22);
            this.tbCardNumber.TabIndex = 61;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(115, 241);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 16);
            this.label5.TabIndex = 60;
            this.label5.Text = "Card Number";
            // 
            // btnPay
            // 
            this.btnPay.Location = new System.Drawing.Point(236, 284);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(115, 33);
            this.btnPay.TabIndex = 62;
            this.btnPay.Text = "Pay";
            this.btnPay.UseVisualStyleBackColor = true;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // FormPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 344);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.tbCardNumber);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cardRB);
            this.Controls.Add(this.cashRB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.totalLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.tbCheckMember);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "FormPayment";
            this.Text = "FormPayment";
            this.Load += new System.EventHandler(this.FormPayment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCheckMember;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton cashRB;
        private System.Windows.Forms.RadioButton cardRB;
        private System.Windows.Forms.TextBox tbCardNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnPay;
    }
}