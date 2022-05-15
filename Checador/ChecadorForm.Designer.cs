namespace Checador
{
    partial class ChecadorForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChecadorForm));
            this.employeeImage = new System.Windows.Forms.PictureBox();
            this.labelName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.Label();
            this.labelDateTime = new System.Windows.Forms.Label();
            this.txtDateTime = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.Label();
            this.labelMsgPersonalText = new System.Windows.Forms.Label();
            this.labelMsgPersonalTitle = new System.Windows.Forms.Label();
            this.labelMsgText = new System.Windows.Forms.Label();
            this.labelMsgTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.pictureHuella = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.employeeImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureHuella)).BeginInit();
            this.SuspendLayout();
            // 
            // employeeImage
            // 
            this.employeeImage.BackColor = System.Drawing.Color.Transparent;
            this.employeeImage.Location = new System.Drawing.Point(25, 25);
            this.employeeImage.Name = "employeeImage";
            this.employeeImage.Size = new System.Drawing.Size(156, 191);
            this.employeeImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.employeeImage.TabIndex = 0;
            this.employeeImage.TabStop = false;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.BackColor = System.Drawing.Color.Transparent;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.ForeColor = System.Drawing.Color.White;
            this.labelName.Location = new System.Drawing.Point(196, 25);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(110, 31);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Nombre";
            // 
            // txtName
            // 
            this.txtName.AutoSize = true;
            this.txtName.BackColor = System.Drawing.Color.Transparent;
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.ForeColor = System.Drawing.Color.White;
            this.txtName.Location = new System.Drawing.Point(195, 56);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(0, 42);
            this.txtName.TabIndex = 2;
            // 
            // labelDateTime
            // 
            this.labelDateTime.AutoSize = true;
            this.labelDateTime.BackColor = System.Drawing.Color.Transparent;
            this.labelDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDateTime.ForeColor = System.Drawing.Color.White;
            this.labelDateTime.Location = new System.Drawing.Point(196, 115);
            this.labelDateTime.Name = "labelDateTime";
            this.labelDateTime.Size = new System.Drawing.Size(319, 31);
            this.labelDateTime.TabIndex = 3;
            this.labelDateTime.Text = "Fecha y hora de checada";
            // 
            // txtDateTime
            // 
            this.txtDateTime.AutoSize = true;
            this.txtDateTime.BackColor = System.Drawing.Color.Transparent;
            this.txtDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDateTime.ForeColor = System.Drawing.Color.White;
            this.txtDateTime.Location = new System.Drawing.Point(195, 148);
            this.txtDateTime.Name = "txtDateTime";
            this.txtDateTime.Size = new System.Drawing.Size(0, 42);
            this.txtDateTime.TabIndex = 4;
            // 
            // txtDate
            // 
            this.txtDate.AutoSize = true;
            this.txtDate.BackColor = System.Drawing.Color.Transparent;
            this.txtDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDate.ForeColor = System.Drawing.Color.Black;
            this.txtDate.Location = new System.Drawing.Point(742, 532);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(444, 39);
            this.txtDate.TabIndex = 5;
            this.txtDate.Text = "sábado, 1 de enero de 2022";
            this.txtDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTime
            // 
            this.txtTime.AutoSize = true;
            this.txtTime.BackColor = System.Drawing.Color.Transparent;
            this.txtTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 84F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTime.ForeColor = System.Drawing.Color.Black;
            this.txtTime.Location = new System.Drawing.Point(728, 571);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(538, 126);
            this.txtTime.TabIndex = 6;
            this.txtTime.Text = "00:00 PM";
            // 
            // labelMsgPersonalText
            // 
            this.labelMsgPersonalText.AutoSize = true;
            this.labelMsgPersonalText.BackColor = System.Drawing.Color.Transparent;
            this.labelMsgPersonalText.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMsgPersonalText.Location = new System.Drawing.Point(408, 429);
            this.labelMsgPersonalText.Name = "labelMsgPersonalText";
            this.labelMsgPersonalText.Size = new System.Drawing.Size(185, 37);
            this.labelMsgPersonalText.TabIndex = 14;
            this.labelMsgPersonalText.Text = "Texto Mensaje";
            this.labelMsgPersonalText.Visible = false;
            // 
            // labelMsgPersonalTitle
            // 
            this.labelMsgPersonalTitle.AutoSize = true;
            this.labelMsgPersonalTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelMsgPersonalTitle.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMsgPersonalTitle.ForeColor = System.Drawing.Color.Firebrick;
            this.labelMsgPersonalTitle.Location = new System.Drawing.Point(408, 392);
            this.labelMsgPersonalTitle.Name = "labelMsgPersonalTitle";
            this.labelMsgPersonalTitle.Size = new System.Drawing.Size(191, 37);
            this.labelMsgPersonalTitle.TabIndex = 13;
            this.labelMsgPersonalTitle.Text = "Titulo Mensaje";
            this.labelMsgPersonalTitle.Visible = false;
            // 
            // labelMsgText
            // 
            this.labelMsgText.AutoSize = true;
            this.labelMsgText.BackColor = System.Drawing.Color.Transparent;
            this.labelMsgText.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMsgText.Location = new System.Drawing.Point(408, 339);
            this.labelMsgText.Name = "labelMsgText";
            this.labelMsgText.Size = new System.Drawing.Size(185, 37);
            this.labelMsgText.TabIndex = 12;
            this.labelMsgText.Text = "Texto Mensaje";
            this.labelMsgText.Visible = false;
            // 
            // labelMsgTitle
            // 
            this.labelMsgTitle.AutoSize = true;
            this.labelMsgTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelMsgTitle.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMsgTitle.ForeColor = System.Drawing.Color.Firebrick;
            this.labelMsgTitle.Location = new System.Drawing.Point(408, 302);
            this.labelMsgTitle.Name = "labelMsgTitle";
            this.labelMsgTitle.Size = new System.Drawing.Size(191, 37);
            this.labelMsgTitle.TabIndex = 11;
            this.labelMsgTitle.Text = "Titulo Mensaje";
            this.labelMsgTitle.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(1263, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 31);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "Cerrar";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // pictureHuella
            // 
            this.pictureHuella.BackColor = System.Drawing.Color.Transparent;
            this.pictureHuella.Location = new System.Drawing.Point(81, 115);
            this.pictureHuella.Name = "pictureHuella";
            this.pictureHuella.Size = new System.Drawing.Size(100, 101);
            this.pictureHuella.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureHuella.TabIndex = 16;
            this.pictureHuella.TabStop = false;
            // 
            // ChecadorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.BackgroundImage = global::Checador.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.labelMsgPersonalText);
            this.Controls.Add(this.labelMsgPersonalTitle);
            this.Controls.Add(this.labelMsgText);
            this.Controls.Add(this.labelMsgTitle);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.txtDateTime);
            this.Controls.Add(this.labelDateTime);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.pictureHuella);
            this.Controls.Add(this.employeeImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChecadorForm";
            this.Text = "Cheacador";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.OnLoadForm);
            ((System.ComponentModel.ISupportInitialize)(this.employeeImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureHuella)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox employeeImage;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label txtName;
        private System.Windows.Forms.Label labelDateTime;
        private System.Windows.Forms.Label txtDateTime;
        private System.Windows.Forms.Label txtDate;
        private System.Windows.Forms.Label txtTime;
        private System.Windows.Forms.Label labelMsgPersonalText;
        private System.Windows.Forms.Label labelMsgPersonalTitle;
        private System.Windows.Forms.Label labelMsgText;
        private System.Windows.Forms.Label labelMsgTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox pictureHuella;
    }
}

