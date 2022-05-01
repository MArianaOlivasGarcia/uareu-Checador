using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DPFP;
using DPFP.Capture;
using DPFP.Verification;
using MySql.Data.MySqlClient;
using SocketIOClient;
using Checador.Models;

namespace Checador
{
    public partial class ChecadorForm : Form, DPFP.Capture.EventHandler
    {
        // LECTOR BIOMETRICO
        private zkemkeeper.CZKEM axCZKEM1 = new zkemkeeper.CZKEM();
        private bool bIsConnected = false;
        // FIN LECTOR BIOMETRICO

        // DIGITALPERSONA
        private DPFP.Verification.Verification verificator;
        private DPFP.Capture.Capture capturer;
        // FIN DIGITALPERSONA

        // SOCKET SERVIDOR HORA
        //SocketService socket = new SocketService();


        private List<Employee> employees;
        private EmployeeDao employeeDao = new EmployeeDao();

        private MessageDao messageDao = new MessageDao();

        private DateTime dateTime = DateTime.Now;

        // Para el timer pantalla
        private DateTime dateChecked;
        private bool isCheking = false;



        public ChecadorForm()
        {
            InitializeComponent();
            System.Diagnostics.Debug.WriteLine("INICIO");


            timer.Start();
         
            InitDigitalPersona();
            InitZKTeco();

            employees = employeeDao.FindAll();


        }

        private void OnLoadForm(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("LOAD");
            System.Diagnostics.Debug.WriteLine(axCZKEM1.RegEvent(1, 65535));

            if (axCZKEM1.RegEvent(1, 65535))
            {
                axCZKEM1.OnAttTransactionEx += new zkemkeeper._IZKEMEvents_OnAttTransactionExEventHandler(attTransactionEx);
            }

        }


        // Digital Persona
        public void InitDigitalPersona()
        {
            try
            {
                capturer = new DPFP.Capture.Capture();

                if (null != capturer)
                {
                    capturer.EventHandler = this;

                    StartCapture();
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("NO SE PUDO INICIAR LA OPERACION DE CAPTURACION");
                }

            }
            catch
            {
                System.Diagnostics.Debug.WriteLine("OCURRIO UN ERROR GRAVE CAPTURACION");

            }
            verificator = new DPFP.Verification.Verification();

        }



        // Biometrico
        public void InitZKTeco()
        {
            // Establecer comunicación con lector biometrico
            bIsConnected = axCZKEM1.Connect_Net(Checador.Properties.Settings.Default.FACIAL_SERVER, Convert.ToInt32(Checador.Properties.Settings.Default.FACIAL_PORT));

            if (bIsConnected)
            {
                System.Diagnostics.Debug.WriteLine("CONEXION EXITOSA AL LECTOR BIOMETRICO");
            }
            else
            {
                DialogResult result = MessageBox.Show("No se pudo establecer conexión con lector ZKTeco. ¿Desea continuar?", "Alvertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    StopCapture();
                   // socket.Disconnect();
                    timer.Stop();
                    Application.Exit();
                }

            }
        }

        // Eventos ZKTeco
        private void attTransactionEx(
            string sEnrollNumber,
            int iIsInValid,
            int iAttState,
            int iVerifyMethod,
            int iYear,
            int iMonth,
            int iDay,
            int iHour,
            int iMinute,
            int iSecond,
            int iWorkCode)
        {

            dateChecked = DateTime.Now;
            isCheking = true;

            String date = iYear.ToString() + "-" + iMonth.ToString() + "-" + iDay.ToString() + " " + iHour.ToString() + ":" + iMinute.ToString() + ":" + iSecond.ToString(); ;
            System.Diagnostics.Debug.WriteLine("ID:", sEnrollNumber);

            Employee employee = employeeDao.FindById(Int32.Parse(sEnrollNumber));

            Boolean isValid = Validations(employee);

            if (!isValid) { return; }

            //ProcessCheck(employee, DateTime.Parse(date));
            ProcessCheck(employee, dateTime);

        }



        // Eventos digitalPersona

        public Employee AnalizeFingerprints(FeatureSet features)
        {
            Employee employee = null;
            Verification.Result result;

            foreach (Employee e in employees)
            {
                result = new Verification.Result();

                if (e.Huella != null)
                {
                    try
                    {
                        verificator.Verify(features, e.Huella, ref result);
                        if (result.Verified)
                        {
                            System.Diagnostics.Debug.WriteLine("Verificado huella1");
                            return employee = e;
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.Message);

                    }
                }
                result = new Verification.Result();
                if (e.Huella2 != null)
                {
                    try
                    {
                        verificator.Verify(features, e.Huella2, ref result);
                        if (result.Verified)
                        {
                            System.Diagnostics.Debug.WriteLine("Verificado huella 2 ");
                            return employee = e;
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.Message);

                    }
                }

            }

            return employee;

        }




        public void OnComplete(object Capture, string ReaderSerialNumber, Sample Sample)
        {
            System.Diagnostics.Debug.WriteLine("Lectura de huella completa");

            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            

            DrawHuella(ConvertSampleToBitmap(Sample));

            StopCapture(); //Se detiene el proceso de captura

            employeeImage.SizeMode = PictureBoxSizeMode.CenterImage;
            employeeImage.Image = Properties.Resources.loading;

            dateChecked = DateTime.Now;
            isCheking = true;

            FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification);
            Employee employee = AnalizeFingerprints(features);


            StartCapture();
            Boolean isValid = Validations(employee);

            
            if (!isValid) { return; }

            ProcessCheck(employee, dateTime);
             //Inicializar el proceso de captura

        }

        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {
            System.Diagnostics.Debug.WriteLine("OnFingerGone");

        }

        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {
            System.Diagnostics.Debug.WriteLine("OnFingerTouch");

        }

        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        {
            System.Diagnostics.Debug.WriteLine("OnReaderConnect");

        }

        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {
            System.Diagnostics.Debug.WriteLine("OnReaderDisconnect");

        }

        public void OnSampleQuality(object Capture, string ReaderSerialNumber, CaptureFeedback CaptureFeedback)
        {
            System.Diagnostics.Debug.WriteLine("OnSampleQuality");

        }

        public void DrawHuella(Bitmap bitmap)
        {
            CheckForIllegalCrossThreadCalls = false;

            pictureHuella.Visible = true;
            pictureHuella.Image = new Bitmap(bitmap, pictureHuella.Size);
        }


        protected Bitmap ConvertSampleToBitmap( DPFP.Sample Sample )
        {
            DPFP.Capture.SampleConversion Convertor = new DPFP.Capture.SampleConversion();
            Bitmap Bitmap = null;
            Convertor.ConvertToPicture(Sample, ref Bitmap);
            return Bitmap;

        }


        public void StartCapture()
        {
            if (null != capturer)
            {
                try
                {
                    capturer.StartCapture();
                }
                catch
                {
                    System.Diagnostics.Debug.WriteLine("ERROR AL EMPEZAR CAPTURA");

                }
            }
        }

        public void StopCapture()
        {
            if (null != capturer)
            {
                try
                {
                    capturer.StopCapture();
                }
                catch
                {
                    System.Diagnostics.Debug.WriteLine("ERROR AL DETENER CAPTURADOR");

                }
            }
        }




        protected DPFP.FeatureSet ExtractFeatures(DPFP.Sample Sample, DPFP.Processing.DataPurpose Purpose)
        {
            DPFP.Processing.FeatureExtraction Extractor = new DPFP.Processing.FeatureExtraction();
            DPFP.Capture.CaptureFeedback feedback = DPFP.Capture.CaptureFeedback.None;
            DPFP.FeatureSet features = new DPFP.FeatureSet();

            Extractor.CreateFeatureSet(Sample, Purpose, ref feedback, ref features);
            if (feedback == DPFP.Capture.CaptureFeedback.Good)
                return features;
            else
                return null;
        }



        // Proceso para validar y registrar checada
        public Boolean Validations(Employee employee)
        {
            ClearScreen();
            if (employee == null)
            {

                CheckForIllegalCrossThreadCalls = false;
                txtName.Text = "Empleado no encontrado.";
                System.Diagnostics.Debug.WriteLine("No existe el empleado.");
                //isCheking = false;
                return false;
            }

            if (!employeeDao.IsActive(employee.Id))
            {
                CheckForIllegalCrossThreadCalls = false;
                txtName.Text = "Empleado Inactivo. Favor de pasar a recursos humanos.";
                employeeImage.Image = employee.Foto;
                System.Diagnostics.Debug.WriteLine("Empleado Inactivo.");
               // isCheking = false;
                return false;
            }

            if (!employeeDao.HasWorkingHours(employee.Id))
            {
                CheckForIllegalCrossThreadCalls = false;
                txtName.Text = "No cuenta con horario. Favor de pasar con su jefe académico.";
                employeeImage.Image = employee.Foto;
                System.Diagnostics.Debug.WriteLine("No cuenta con horario.");
                //isCheking = false;
                return false;
            }

            return true;

        }



        public void ProcessCheck(Employee employee, DateTime dateTime)
        {
            CheckForIllegalCrossThreadCalls = false;

            Checking lastCheck = employeeDao.Check(employee.Id, dateTime);
            
            if ( lastCheck != null )
            {
                System.Diagnostics.Debug.WriteLine(lastCheck.Id);
                System.Diagnostics.Debug.WriteLine(lastCheck.Employee);
                System.Diagnostics.Debug.WriteLine(lastCheck.Date);
                System.Diagnostics.Debug.WriteLine(lastCheck.Time);
            }


            // Buscar mensajes

            Models.Message messagePersonal = messageDao.FindByEmployeId(employee.Id);
            Models.Message message = messageDao.FindGeneral();


            employeeImage.Image = employee.Foto;
            txtName.Text = $"{employee.Nombre} {employee.Paterno} {employee.Materno}";
            // txtDateTime.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToString("h:mm tt");
            txtDateTime.Text = lastCheck.Date.ToLongDateString() + " " + lastCheck.Time.ToString();

            if (messagePersonal != null)
            {
                labelMsgPersonalTitle.Text = messagePersonal.Asunto;
                labelMsgPersonalText.Text = messagePersonal.Mensaje;
                labelMsgPersonalTitle.Visible = true;
                labelMsgPersonalText.Visible = true;
            }

            if (message != null)
            {
                labelMsgTitle.Text = message.Asunto;
                labelMsgText.Text = message.Mensaje;
                labelMsgTitle.Visible = true;
                labelMsgText.Visible = true;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            StopCapture();
           // socket.Disconnect();
            timer.Stop();
            Application.Exit();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("EVENTO DEL RELOJ");
            txtTime.Text = DateTime.Now.ToString("h:mm tt");
            txtDate.Text = DateTime.Now.ToLongDateString().ToUpper();
            TimeSpan duration = DateTime.Now - dateChecked;

            if (isCheking && duration.Seconds >= 6)
            {
                System.Diagnostics.Debug.WriteLine("LIMPIAR");
                ClearScreen();
                isCheking = !isCheking;
            }



        }


        private void ClearScreen()
        {
            CheckForIllegalCrossThreadCalls = false;
            //labelName.Visible = false;
            //labelDateTime.Visible = false;
            txtName.Text = "";
            txtDateTime.Text = "";
            labelMsgPersonalTitle.Visible = false;
            labelMsgPersonalText.Visible = false;
            labelMsgTitle.Visible = false;
            labelMsgText.Visible = false;
            employeeImage.Image = null;

            pictureHuella.Visible = false;

        }

    }
}
