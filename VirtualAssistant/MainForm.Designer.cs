namespace WhatsAppVirtualAssistant
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.FlowLayoutPanel pnlMessages;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlMessages = new System.Windows.Forms.FlowLayoutPanel();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnlMessages
            // 
            this.pnlMessages.AutoScroll = true;
            this.pnlMessages.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlMessages.WrapContents = false;
            this.pnlMessages.Location = new System.Drawing.Point(12, 12);
            this.pnlMessages.Name = "pnlMessages";
            this.pnlMessages.Size = new System.Drawing.Size(460, 400);
            this.pnlMessages.TabIndex = 0;
            this.pnlMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // txtMessage
            // 
            this.txtMessage.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMessage.Location = new System.Drawing.Point(12, 418);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.PlaceholderText = "Escribe un mensaje...";
            this.txtMessage.Size = new System.Drawing.Size(370, 25);
            this.txtMessage.TabIndex = 1;
            this.txtMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMessage_KeyDown);
            // 
            // btnSend
            // 
            this.btnSend.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSend.Location = new System.Drawing.Point(388, 418);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(84, 25);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Enviar ✅";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.pnlMessages);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnSend);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "🤖 Asistente Virtual";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}