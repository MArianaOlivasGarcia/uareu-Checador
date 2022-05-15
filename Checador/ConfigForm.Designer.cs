namespace Checador
{

    partial class ConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            this.btnSave = new System.Windows.Forms.Button();
            this.btnTestBio = new System.Windows.Forms.Button();
            this.btnTestDB = new System.Windows.Forms.Button();
            this.txtBioPort = new System.Windows.Forms.TextBox();
            this.txtBioIP = new System.Windows.Forms.TextBox();
            this.txtDBPassword = new System.Windows.Forms.TextBox();
            this.txtDBUser = new System.Windows.Forms.TextBox();
            this.txtDBName = new System.Windows.Forms.TextBox();
            this.txtDBIP = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(81, 354);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(125, 27);
            this.btnSave.TabIndex = 41;
            this.btnSave.Text = "GUARDAR";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnTestBio
            // 
            this.btnTestBio.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnTestBio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestBio.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestBio.ForeColor = System.Drawing.Color.White;
            this.btnTestBio.Location = new System.Drawing.Point(153, 301);
            this.btnTestBio.Name = "btnTestBio";
            this.btnTestBio.Size = new System.Drawing.Size(125, 27);
            this.btnTestBio.TabIndex = 40;
            this.btnTestBio.Text = "PROBAR";
            this.btnTestBio.UseVisualStyleBackColor = false;
            this.btnTestBio.Click += new System.EventHandler(this.btnTestBio_Click);
            // 
            // btnTestDB
            // 
            this.btnTestDB.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnTestDB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestDB.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestDB.ForeColor = System.Drawing.Color.White;
            this.btnTestDB.Location = new System.Drawing.Point(153, 173);
            this.btnTestDB.Name = "btnTestDB";
            this.btnTestDB.Size = new System.Drawing.Size(125, 27);
            this.btnTestDB.TabIndex = 38;
            this.btnTestDB.Text = "PROBAR";
            this.btnTestDB.UseVisualStyleBackColor = false;
            this.btnTestDB.Click += new System.EventHandler(this.btnTestDB_Click);
            // 
            // txtBioPort
            // 
            this.txtBioPort.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBioPort.Location = new System.Drawing.Point(153, 264);
            this.txtBioPort.Name = "txtBioPort";
            this.txtBioPort.Size = new System.Drawing.Size(125, 25);
            this.txtBioPort.TabIndex = 37;
            // 
            // txtBioIP
            // 
            this.txtBioIP.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBioIP.Location = new System.Drawing.Point(15, 264);
            this.txtBioIP.Name = "txtBioIP";
            this.txtBioIP.Size = new System.Drawing.Size(125, 25);
            this.txtBioIP.TabIndex = 36;
            // 
            // txtDBPassword
            // 
            this.txtDBPassword.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDBPassword.Location = new System.Drawing.Point(153, 131);
            this.txtDBPassword.Name = "txtDBPassword";
            this.txtDBPassword.PasswordChar = '•';
            this.txtDBPassword.Size = new System.Drawing.Size(125, 25);
            this.txtDBPassword.TabIndex = 34;
            // 
            // txtDBUser
            // 
            this.txtDBUser.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDBUser.Location = new System.Drawing.Point(15, 131);
            this.txtDBUser.Name = "txtDBUser";
            this.txtDBUser.Size = new System.Drawing.Size(125, 25);
            this.txtDBUser.TabIndex = 33;
            // 
            // txtDBName
            // 
            this.txtDBName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDBName.Location = new System.Drawing.Point(153, 76);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.Size = new System.Drawing.Size(125, 25);
            this.txtDBName.TabIndex = 32;
            // 
            // txtDBIP
            // 
            this.txtDBIP.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDBIP.Location = new System.Drawing.Point(15, 76);
            this.txtDBIP.Name = "txtDBIP";
            this.txtDBIP.Size = new System.Drawing.Size(125, 25);
            this.txtDBIP.TabIndex = 31;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(13, 245);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(19, 16);
            this.label10.TabIndex = 30;
            this.label10.Text = "IP";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(150, 245);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 16);
            this.label9.TabIndex = 29;
            this.label9.Text = "PORT";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label8.Location = new System.Drawing.Point(11, 215);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 20);
            this.label8.TabIndex = 28;
            this.label8.Text = "Lector Facial";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(150, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 16);
            this.label5.TabIndex = 25;
            this.label5.Text = "Contraseña";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 16);
            this.label4.TabIndex = 24;
            this.label4.Text = "Usuario";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(150, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 23;
            this.label3.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 16);
            this.label2.TabIndex = 22;
            this.label2.Text = "IP Servidor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 20);
            this.label1.TabIndex = 21;
            this.label1.Text = "Base de Datos";
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 406);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnTestBio);
            this.Controls.Add(this.btnTestDB);
            this.Controls.Add(this.txtBioPort);
            this.Controls.Add(this.txtBioIP);
            this.Controls.Add(this.txtDBPassword);
            this.Controls.Add(this.txtDBUser);
            this.Controls.Add(this.txtDBName);
            this.Controls.Add(this.txtDBIP);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuraciones";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnTestBio;
        private System.Windows.Forms.Button btnTestDB;
        private System.Windows.Forms.TextBox txtBioPort;
        private System.Windows.Forms.TextBox txtBioIP;
        private System.Windows.Forms.TextBox txtDBPassword;
        private System.Windows.Forms.TextBox txtDBUser;
        private System.Windows.Forms.TextBox txtDBName;
        private System.Windows.Forms.TextBox txtDBIP;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }

}