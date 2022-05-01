using Checador.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Checador
{
    public partial class LoginForm : Form
    {
        private UserDao userDao = new UserDao();
        private Boolean isLoading = false;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Login(object sender, EventArgs e)
        {

            if (isLoading == true) { return; }

            isLoading = true;
            btnLogin.Enabled = false;

            if (txtUser.Text.Length == 0 && txtPassword.Text.Length == 0)
            {
                labelUserError.Visible = true;
                labelPasswordError.Visible = true;
                isLoading = false;
                btnLogin.Enabled = true;
                return;

            }
            else if (txtUser.Text.Length == 0)
            {
                labelUserError.Visible = true;
                labelPasswordError.Visible = false;
                isLoading = false;
                btnLogin.Enabled = true;
                return;

            }
            else if (txtPassword.Text.Length == 0)
            {
                labelUserError.Visible = false;
                labelPasswordError.Visible = true;
                isLoading = false;
                btnLogin.Enabled = true;
                return;

            }

            labelUserError.Visible = false;
            labelPasswordError.Visible = false;

            Dictionary<string, dynamic> resp = userDao.Login(txtUser.Text, txtPassword.Text);

            if (resp["status"] == false)
            {
                labelError.Visible = true;
                labelError.Text = resp["message"];
                isLoading = false;
                btnLogin.Enabled = true;
                return;
            }

            this.Hide();
            ChecadorForm checadorForm = new ChecadorForm();
            checadorForm.Show();

            isLoading = false;
            btnLogin.Enabled = true;


        }

        private void linkConf_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ConfigForm configForm = new ConfigForm();
            configForm.Show();
        }

    }

}
