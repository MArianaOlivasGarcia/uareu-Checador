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
    public partial class ConfigForm : Form
    {

        private bool bIsConnected = false;
        private bool dbIsConnected = false;

        public ConfigForm()
        {
            InitializeComponent();

            txtDBIP.Text = Checador.Properties.Settings.Default.DB_SERVER;
            txtDBName.Text = Checador.Properties.Settings.Default.DB_NAME;
            txtDBUser.Text = Checador.Properties.Settings.Default.DB_USER;
            txtDBPassword.Text = Checador.Properties.Settings.Default.DB_PASSWORD;

            txtTimeIp.Text = Checador.Properties.Settings.Default.TIME_SERVER;

            txtBioIP.Text = Checador.Properties.Settings.Default.FACIAL_SERVER;
            txtBioPort.Text = Checador.Properties.Settings.Default.FACIAL_PORT;

        }



        public void saveConfig()
        {
            Checador.Properties.Settings.Default.DB_SERVER = txtDBIP.Text;
            Checador.Properties.Settings.Default.DB_NAME = txtDBName.Text;
            Checador.Properties.Settings.Default.DB_USER = txtDBUser.Text;
            Checador.Properties.Settings.Default.DB_PASSWORD = txtDBPassword.Text;

            Checador.Properties.Settings.Default.TIME_SERVER = txtTimeIp.Text;


            Checador.Properties.Settings.Default.FACIAL_SERVER = txtBioIP.Text;
            Checador.Properties.Settings.Default.FACIAL_PORT = txtBioPort.Text;

            Checador.Properties.Settings.Default.Save();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult result;

            if (!bIsConnected || !dbIsConnected)
            {
                result = MessageBox.Show("No se recomienda guardar la configuración porque no se ha probado la conexión o alguna de ellas fallo. ¿Desea continuar?", "¿Está seguro?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            }
            else
            {
                result = MessageBox.Show("¿Quieres guardar los cambios?", "¿Está seguro?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            }


            if (result == DialogResult.No)
            {
                return;
            }

            saveConfig();

            MessageBox.Show("Los cambios se han guardado con éxito", "Guardado");



        }





        // ======================
        // LECTOR BIOMETRICO
        // ======================

        private void btnTestBio_Click(object sender, EventArgs e)
        {
            btnTestBio.Text = "Probando...";
            btnTestBio.Enabled = false;
            checkZKTeco();
            btnTestBio.Text = "PROBAR";
            btnTestBio.Enabled = true;

        }


        public void checkZKTeco()
        {

            zkemkeeper.CZKEM axCZKEM1 = new zkemkeeper.CZKEM();

            bIsConnected = axCZKEM1.Connect_Net(txtBioIP.Text, Convert.ToInt32(txtBioPort.Text));

            if (bIsConnected)
            {
                DialogResult result = MessageBox.Show("Conexión con el lector ZKTeco éxitosa.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.None);
                btnTestBio.BackColor = System.Drawing.Color.Green;
            }
            else
            {
                DialogResult result = MessageBox.Show("No se pudo establecer conexión con lector ZKTeco.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnTestBio.BackColor = System.Drawing.Color.Red;

            }
        }

        // ======================
        // FIN LECTOR BIOMETRICO
        // ======================





        // ======================
        // SERVIDOR HORA
        // ======================

        private void btnTestTime_Click(object sender, EventArgs e)
        {
            checkTimeServer();



        }

        public void checkTimeServer()
        {

        }


        // ======================
        // FIN SERVIDOR HORA
        // ======================


        private void btnTestDB_Click(object sender, EventArgs e)
        {
            btnTestDB.Text = "Probando...";
            btnTestDB.Enabled = false;
            checkDB();
            btnTestDB.Text = "PROBAR";
            btnTestDB.Enabled = true;

        }
        public void checkDB()
        {
            ConnectionDb connectionDb = new ConnectionDb();

            dbIsConnected = connectionDb.checkConnection(txtDBIP.Text, txtDBUser.Text, txtDBPassword.Text, txtDBName.Text);

            if (dbIsConnected)
            {
                DialogResult result = MessageBox.Show("Conexión con la base de datos éxitosa.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.None);
                btnTestDB.BackColor = System.Drawing.Color.Green;
            }
            else
            {
                DialogResult result = MessageBox.Show("No se pudo establecer conexión con la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnTestDB.BackColor = System.Drawing.Color.Red;
            }

        }

    }
}
