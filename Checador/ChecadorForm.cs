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
using MySql.Data.MySqlClient;
using SocketIOClient;
using Checador.Models;
using DPUruNet;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using DPFP;
using DPFP.Capture;

namespace Checador
{
    public partial class ChecadorForm : Form
    {
        // LECTOR BIOMETRICO
        private zkemkeeper.CZKEM axCZKEM1 = new zkemkeeper.CZKEM();
        private bool bIsConnected = false;
        // FIN LECTOR BIOMETRICO

      

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
                    //StopCapture();
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

            if (lastCheck != null)
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
            //StopCapture();
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


        /// PRUEBA U ARE U 
        private Reader currentReader;
        public Reader CurrentReader
        {
            get { return currentReader; }
            set
            {
                currentReader = value;
            }
        }

        public bool Reset
        {
            get { return reset; }
            set { reset = value; }
        }
        private bool reset;

        private ReaderCollection _readers;
        private Fmd firstFinger;
        DataResult<Fmd> resultEnrollment;
        List<Fmd> preenrollmentFmds;
        int count = 0;
        private void InitDigitalPersona()
        {


            try
            {
                _readers = ReaderCollection.GetReaders();

                // String text = "TODO OK";
                // String caption = "Conección al lector huella exitosa";
                // MessageBox.Show(text, caption);


                firstFinger = null;
                resultEnrollment = null;
                preenrollmentFmds = new List<Fmd>();
                //pbFingerprint.Image = null;
                pictureHuella.Image = null;
                if (CurrentReader != null)
                {
                    CurrentReader.Dispose();
                    CurrentReader = null;
                }
                CurrentReader = _readers[0];
                System.Diagnostics.Debug.WriteLine("READERRRRRRR" + CurrentReader.ToString());

                if (!OpenReader())
                {
                    //this.Close();
                }

                if (!StartCaptureAsync(this.OnCaptured))
                {
                    //this.Close();
                }

                
            }
            catch (Exception ex)
            {
                //message box:
                String text = ex.Message;
                text += "\r\n\r\nPlease check if DigitalPersona service has been started";
                String caption = "Cannot access readers";
                MessageBox.Show(text, caption);
            }
        }



        /// Open a device and check result for errors.
        public bool OpenReader()
        {
            using (Tracer tracer = new Tracer("Form_Main::OpenReader"))
            {
                reset = false;
                Constants.ResultCode result = Constants.ResultCode.DP_DEVICE_FAILURE;

                // Open reader
                result = currentReader.Open(Constants.CapturePriority.DP_PRIORITY_COOPERATIVE);

                if (result != Constants.ResultCode.DP_SUCCESS)
                {
                    MessageBox.Show("Error:  " + result);
                    reset = true;
                    return false;
                }

                return true;
            }
        }

        /// Hookup capture handler and start capture.
        public bool StartCaptureAsync(Reader.CaptureCallback OnCaptured)
        {
            using (Tracer tracer = new Tracer("Form_Main::StartCaptureAsync"))
            {
                // Activate capture handler
                currentReader.On_Captured += new Reader.CaptureCallback(OnCaptured);

                // Call capture
                if (!CaptureFingerAsync())
                {
                    return false;
                }

                return true;
            }
        }

        /// Function to capture a finger. Always get status first and calibrate or wait if necessary.  Always check status and capture errors.
        public bool CaptureFingerAsync()
        {
            using (Tracer tracer = new Tracer("Form_Main::CaptureFingerAsync"))
            {
                try
                {
                    GetStatus();

                    Constants.ResultCode captureResult = currentReader.CaptureAsync(Constants.Formats.Fid.ANSI, Constants.CaptureProcessing.DP_IMG_PROC_DEFAULT, currentReader.Capabilities.Resolutions[0]);
                    if (captureResult != Constants.ResultCode.DP_SUCCESS)
                    {
                        reset = true;
                        throw new Exception("" + captureResult);
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:  " + ex.Message);
                    return false;
                }
            }
        }

        /// Check the device status before starting capture.
        public void GetStatus()
        {
            using (Tracer tracer = new Tracer("Form_Main::GetStatus"))
            {
                Constants.ResultCode result = currentReader.GetStatus();

                if ((result != Constants.ResultCode.DP_SUCCESS))
                {
                    reset = true;
                    throw new Exception("" + result);
                }

                if ((currentReader.Status.Status == Constants.ReaderStatuses.DP_STATUS_BUSY))
                {
                    Thread.Sleep(50);
                }
                else if ((currentReader.Status.Status == Constants.ReaderStatuses.DP_STATUS_NEED_CALIBRATION))
                {
                    currentReader.Calibrate();
                }
                else if ((currentReader.Status.Status != Constants.ReaderStatuses.DP_STATUS_READY))
                {
                    throw new Exception("Reader Status - " + currentReader.Status.Status);
                }
            }
        }




        /// Handler for when a fingerprint is captured.
        public void OnCaptured(CaptureResult captureResult)
           {
               try
               {

                //MessageBox.Show("ENTRO AL OnCaptured. Realizar validación" + captureResult.ToString() );

                // Check capture quality and throw an error if bad.
                if (!CheckCaptureResult(captureResult)) return;

                   // Create bitmap
                   foreach (Fid.Fiv fiv in captureResult.Data.Views)
                   {
                       SendMessage(Action.SendBitmap, CreateBitmap(fiv.RawImage, fiv.Width, fiv.Height));
                   }

                   //Verification Code
                   try
                   {
                       // Check capture quality and throw an error if bad.
                       if (!CheckCaptureResult(captureResult)) return;

                    // SendMessage(Action.SendMessage, "A finger was captured.");

                    

                       DataResult<Fmd> resultConversion = FeatureExtraction.CreateFmdFromFid(captureResult.Data, Constants.Formats.Fmd.ANSI);
                    if (resultConversion.ResultCode != Constants.ResultCode.DP_SUCCESS)
                       {
                           if (resultConversion.ResultCode != Constants.ResultCode.DP_TOO_SMALL_AREA)
                           {
                               Reset = true;
                           }
                           throw new Exception(resultConversion.ResultCode.ToString());
                       }

                       firstFinger = resultConversion.Data;

                       //SendMessage(Action.SendMessage, firstFinger.ToString());

                       List<string> lstledgerIds = new List<string>();
                       count = 0;

                    for (int i = 0; i < employees.LongCount(); i++)
                    {
                        lstledgerIds.Add(employees[i].Id.ToString());



                        
                        // Fmd val = Fmd.DeserializeXml(employees[i].Huella1);

                        var conversionFormat = Convert.ToInt32(Constants.Formats.Fmd.DP_REGISTRATION);

                        Fmd fmd = new Fmd(employees[i].Huella, conversionFormat, Constants.WRAPPER_VERSION);

                        CompareResult compare = Comparison.Compare(firstFinger, 0, fmd, 0);


                        if (compare.ResultCode != Constants.ResultCode.DP_SUCCESS)
                        {
                            Reset = true;
                            //throw new Exception(compare.ResultCode.ToString());
                            SendMessage(Action.SendMessage, "No se pudo comparar." + compare.ResultCode);
                        }

                        int PROBABILITY_ONE = 0x7fffffff;

                        if ( compare.Score < (PROBABILITY_ONE / 100000) )
                        {
                            SendMessage(Action.SendMessage, "Empleado ID : " + lstledgerIds[i].ToString());

                            count++;
                            break;
                        }



                    }
                    if (count == 0)
                       {
                           SendMessage(Action.SendMessage, "Fingerprint not registered.");
                       }
                   }
                   catch (Exception ex)
                   {
                       // Send error message, then close form
                       SendMessage(Action.SendMessage, "Linea 510 Error:  " + ex.Message);

                   }



               }
               catch (Exception ex)
               {
                   SendMessage(Action.SendMessage, "Error:  " + ex.Message);
               }
        }


        public void OnCaptured2(CaptureResult captureResult)
        {
            try
            {
                // Check capture quality and throw an error if bad.
                if (!CheckCaptureResult(captureResult)) return;

                // Create bitmap
                foreach (Fid.Fiv fiv in captureResult.Data.Views)
                {
                    SendMessage(Action.SendBitmap, CreateBitmap(fiv.RawImage, fiv.Width, fiv.Height));
                }

                //Enrollment Code:
                try
                {
                    count++;
                    // Check capture quality and throw an error if bad.
                    DataResult<Fmd> resultConversion = FeatureExtraction.CreateFmdFromFid(captureResult.Data, Constants.Formats.Fmd.ANSI);

                    MessageBox.Show("A finger was captured.  \r\nCount:  " + (count));

                    if (resultConversion.ResultCode != Constants.ResultCode.DP_SUCCESS)
                    {
                        Reset = true;
                        throw new Exception(resultConversion.ResultCode.ToString());
                    }

                    preenrollmentFmds.Add(resultConversion.Data);

                    if (count >= 4)
                    {
                        resultEnrollment = DPUruNet.Enrollment.CreateEnrollmentFmd(Constants.Formats.Fmd.ANSI, preenrollmentFmds);

                        if (resultEnrollment.ResultCode == Constants.ResultCode.DP_SUCCESS)
                        {
                            preenrollmentFmds.Clear();
                            count = 0;
                            //obj_bal_ForAll.BAL_StoreCustomerFPData("tbl_Finger", txtledgerId.Text, Fmd.SerializeXml(resultEnrollment.Data));
                            MessageBox.Show("Customer Finger Print was successfully enrolled.");
                            string seriablizable = Fmd.SerializeXml(resultEnrollment.Data);
                            employeeDao.AddHuella(911, seriablizable);

                            return;
                        }
                        else if (resultEnrollment.ResultCode == Constants.ResultCode.DP_ENROLLMENT_INVALID_SET)
                        {
                            SendMessage(Action.SendMessage, "Enrollment was unsuccessful.  Please try again.");
                            preenrollmentFmds.Clear();
                            count = 0;
                            return;
                        }
                    }
                    MessageBox.Show("Now place the same finger on the reader.");
                }
                catch (Exception ex)
                {
                    // Send error message, then close form
                    SendMessage(Action.SendMessage, "Error:  " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                // Send error message, then close form
                SendMessage(Action.SendMessage, "Error:  " + ex.Message);
            }
        }

        /// Create a bitmap from raw data in row/column format.
        public Bitmap CreateBitmap(byte[] bytes, int width, int height)
        {
            byte[] rgbBytes = new byte[bytes.Length * 3];

            for (int i = 0; i <= bytes.Length - 1; i++)
            {
                rgbBytes[(i * 3)] = bytes[i];
                rgbBytes[(i * 3) + 1] = bytes[i];
                rgbBytes[(i * 3) + 2] = bytes[i];
            }
            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

            for (int i = 0; i <= bmp.Height - 1; i++)
            {
                IntPtr p = new IntPtr(data.Scan0.ToInt64() + data.Stride * i);
                System.Runtime.InteropServices.Marshal.Copy(rgbBytes, i * bmp.Width * 3, p, bmp.Width * 3);
            }

            bmp.UnlockBits(data);
            return bmp;
        }




        /// Check quality of the resulting capture.
        public bool CheckCaptureResult(CaptureResult captureResult)
        {
            using (Tracer tracer = new Tracer("Form_Main::CheckCaptureResult"))
            {
                if (captureResult.Data == null || captureResult.ResultCode != Constants.ResultCode.DP_SUCCESS)
                {
                    if (captureResult.ResultCode != Constants.ResultCode.DP_SUCCESS)
                    {
                        reset = true;
                        throw new Exception(captureResult.ResultCode.ToString());
                    }

                    // Send message if quality shows fake finger
                    if ((captureResult.Quality != Constants.CaptureQuality.DP_QUALITY_CANCELED))
                    {
                        throw new Exception("Quality - " + captureResult.Quality);
                    }
                    return false;
                }

                return true;
            }
        }


        private enum Action
        {
            UpdateReaderState,
            SendBitmap,
            SendMessage
        }
        private delegate void SendMessageCallback(Action state, object payload);
        private void SendMessage(Action action, object payload)
        {
            try
            {
                if (this.pictureHuella.InvokeRequired)
                {
                    SendMessageCallback d = new SendMessageCallback(SendMessage);
                    this.Invoke(d, new object[] { action, payload });
                }
                else
                {
                    switch (action)
                    {
                        case Action.SendMessage:
                            MessageBox.Show((string)payload);
                            break;
                        case Action.SendBitmap:
                            pictureHuella.Image = (Bitmap)payload;
                            pictureHuella.Refresh();
                            break;
                    }
                }
            }
            catch (Exception)
            {
            }
        }






        private List<Fmd> preEnrollmentFmd, preEnrollmentFmd1;
        private DataResult<Fmd> enrolledFmd = null;

        private DataResult<Fmd> ExtractFmdfromBmp(Bitmap img)
        {
            preEnrollmentFmd = new List<Fmd>();
            byte[] imageByte = ExtractByteArray(img);
            int i = 0;
            //height, width and resolution must be same as those of image in ExtractByteArray
            DataResult<Fmd> fmd = DPUruNet.FeatureExtraction.CreateFmdFromRaw(imageByte, 0, 1, img.Width, img.Height, CurrentReader.Capabilities.Resolutions[0], Constants.Formats.Fmd.DP_PRE_REGISTRATION);
            // DataResult<Fmd> fmd = DPUruNet.FeatureExtraction.CreateFmdFromRaw(imageByte, 0, 1, 504, 648, 1000, Constants.Formats.Fmd.DP_PRE_REGISTRATION);
            if (fmd.ResultCode == Constants.ResultCode.DP_SUCCESS)
            {
                while (i < 4)
                {
                    preEnrollmentFmd.Add(fmd.Data);
                    i++;
                }
                enrolledFmd = DPUruNet.Enrollment.CreateEnrollmentFmd(Constants.Formats.Fmd.DP_REGISTRATION, preEnrollmentFmd);
                if (enrolledFmd.ResultCode != Constants.ResultCode.DP_SUCCESS)
                { MessageBox.Show("fmd.ResultCode = " + fmd.ResultCode); }
            }
            else
                MessageBox.Show("fmd.ResultCode = " + fmd.ResultCode);

            return enrolledFmd;
        }





        private static byte[] ExtractByteArray(Bitmap img)
        {
            byte[] rawData = null;
            byte[] bitData = null;
            //ToDo: CreateFmdFromRaw only works on 8bpp bytearrays. As such if we have an image with 24bpp then average every 3 values in Bitmapdata and assign it to bitdata
            if (img.PixelFormat == PixelFormat.Format8bppIndexed)
            {

                //Lock the bitmap's bits
                BitmapData bitmapdata = img.LockBits(new System.Drawing.Rectangle(0, 0, img.Width, img.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, img.PixelFormat);
                //Declare an array to hold the bytes of bitmap
                byte[] imgData = new byte[bitmapdata.Stride * bitmapdata.Height]; //stride=360, height 392

                //Copy bitmapdata into array
                Marshal.Copy(bitmapdata.Scan0, imgData, 0, imgData.Length);//imgData.length =141120

                bitData = new byte[bitmapdata.Width * bitmapdata.Height];//ditmapdata.width =357, height = 392

                for (int y = 0; y < bitmapdata.Height; y++)
                {
                    for (int x = 0; x < bitmapdata.Width; x++)
                    {
                        bitData[bitmapdata.Width * y + x] = imgData[y * bitmapdata.Stride + x];
                    }
                }

                rawData = new byte[bitData.Length];

                for (int i = 0; i < bitData.Length; i++)
                {
                    int avg = (img.Palette.Entries[bitData[i]].R + img.Palette.Entries[bitData[i]].G + img.Palette.Entries[bitData[i]].B) / 3;
                    rawData[i] = (byte)avg;
                }
            }

            else
            {
                bitData = new byte[img.Width * img.Height];//ditmapdata.width =357, height = 392, bitdata.length=139944
                for (int y = 0; y < img.Height; y++)
                {
                    for (int x = 0; x < img.Width; x++)
                    {
                        Color pixel = img.GetPixel(x, y);
                        bitData[img.Width * y + x] = (byte)((Convert.ToInt32(pixel.R) + Convert.ToInt32(pixel.G) + Convert.ToInt32(pixel.B)) / 3);
                    }
                }

            }

            return bitData;
        }


        // FIN PRUEBA

        

    }

}
