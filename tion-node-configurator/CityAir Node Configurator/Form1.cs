using System;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace CityAir_Node_Configurator
{
    public partial class ConfiguratorForm : Form
    {

        private string lastCommand = "";
        private const int writeDelay = 350;

        public ConfiguratorForm()
        {
            InitializeComponent();
        }

        // Сканирование доступных COM-портов
        private void scanForPorts()
        {
            try
            {
                string[] serialPortNames = SerialPort.GetPortNames();
                portComboBox.Items.Clear();

                foreach (string portName in serialPortNames) portComboBox.Items.Add(portName);

                if (serialPortNames.Length > 0)
                {
                    portComboBox.Text = portComboBox.Items[0].ToString();
                    connectButton.Enabled = true;
                }

                else connectButton.Enabled = false;
            }

            catch (Exception ex)
            {
                 MessageBox.Show(ex.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Повторное сканирование портов
        private void rescanButton_Click(object sender, EventArgs e)
        {
            scanForPorts();
        }

        // Подключение и отключение COM-порта
        private void connectButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!serialPort.IsOpen)
                {
                    connectButton.Text = "Disconnect";
                    rescanButton.Enabled = false;
                    readButton.Enabled = true;
                    writeButton.Enabled = true;

                    serialPort.PortName = portComboBox.SelectedItem.ToString().Trim();
                    serialPort.NewLine = "\n";
                    serialPort.BaudRate = 9600;
                    serialPort.ReadTimeout = 3000;
                    serialPort.WriteTimeout = 3000;
                    serialPort.Open();
                }

                else
                {
                    connectButton.Text = "Connect";
                    rescanButton.Enabled = true;
                    readButton.Enabled = false;
                    writeButton.Enabled = false;

                    serialPort.Close();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Получение данных из COM-порта
        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                lastCommand = serialPort.ReadLine().Trim();
                Invoke(new EventHandler(executeLastCommand));
            }

            catch (Exception ex)
            {
                 MessageBox.Show(ex.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Выполнение последней команды
        private void executeLastCommand(object sender, EventArgs e)
        {
            try
            {
                log("in: ", lastCommand);

                if (lastCommand.Contains(":"))
                {
                    string firstPart = lastCommand.Substring(0, lastCommand.IndexOf(":"));
                    string secondPart = lastCommand.Substring(lastCommand.IndexOf(":") + 1);

                    if (firstPart.Equals("ID")) idTextBox.Text = secondPart;
                    if (firstPart.Equals("LATITUDE")) latitudeTextBox.Text = secondPart;
                    if (firstPart.Equals("LONGITUDE")) longitudeTextBox.Text = secondPart;
                    if (firstPart.Equals("ALTITUDE")) altitudeTextBox.Text = secondPart;

                    if (firstPart.Equals("LOOPTIME")) looptimeTextBox.Text = secondPart;
                    if (firstPart.Equals("MEASURETIMES")) measuretimesTextBox.Text = secondPart;
                    if (firstPart.Equals("DEBUG")) debugCheckBox.Checked = Convert.ToBoolean(Convert.ToInt32(secondPart));
                    if (firstPart.Equals("DEBUG_GSM")) debuggsmCheckBox.Checked = Convert.ToBoolean(Convert.ToInt32(secondPart));

                    if (firstPart.Equals("GPRS_APN")) apnTextBox.Text = secondPart;
                    if (firstPart.Equals("GPRS_USERNAME")) usernameTextBox.Text = secondPart;
                    if (firstPart.Equals("GPRS_PASSWORD")) passwordTextBox.Text = secondPart;
                    if (firstPart.Equals("URL")) urlTextBox.Text = secondPart;
                }
            }

            catch (Exception ex)
            {
                 MessageBox.Show(ex.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Заполнение значениями по умолчанию
        private void defaultButton_Click(object sender, EventArgs e)
        {
            try
            {
                idTextBox.Text = "101";
                latitudeTextBox.Text = "54.854441";
                longitudeTextBox.Text = "83.112921";
                altitudeTextBox.Text = "159.1";

                looptimeTextBox.Text = "180000";
                measuretimesTextBox.Text = "30";
                debugCheckBox.Checked = false;
                debuggsmCheckBox.Checked = false;

                apnTextBox.Text = "internet";
                usernameTextBox.Text = "gdata";
                passwordTextBox.Text = "gdata";
                urlTextBox.Text = "104.155.87.12:8080/postPacket?authkey=J3UK0ex9RUVhzgFi9BeI";
            }

            catch (Exception ex)
            {
                 MessageBox.Show(ex.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Считывание параметров
        private void readButton_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort.WriteLine("PRINT2SERIAL");
                log("", "");
                log("out: ", "PRINT2SERIAL");
            }

            catch (Exception ex)
            {
                 MessageBox.Show(ex.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Запись параметров
        private void writeButton_Click(object sender, EventArgs e)
        {
            try
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
                groupBox4.Enabled = false;
                groupBox5.Enabled = false;
                groupBox6.Enabled = false;
                groupBox7.Enabled = false;
                log("", "");

                // ID
                int id;
                bool success = false;

                if (int.TryParse(idTextBox.Text.Trim(), out id))
                {
                    if ((id >= 100) && (id <= 32767))
                    {
                        serialPort.WriteLine("ID:" + id.ToString());
                        log("out: ", "ID:" + id.ToString());
                        Thread.Sleep(writeDelay);
                        success = true;
                    }
                }

                if (!success) MessageBox.Show("Wrong value of \"ID\"!\nRequired - int, (id >= 100) && (id <= 32767)", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                success = false;

                // LATITUDE
                float latitude;

                if (float.TryParse(latitudeTextBox.Text.Trim().Replace('.', ','), out latitude))
                {
                    if ((latitude >= -90) && (latitude <= 90))
                    {
                        serialPort.WriteLine("LATITUDE:" + latitude.ToString("#.000000").Replace(',', '.'));
                        log("out: ", "LATITUDE:" + latitude.ToString("#.000000").Replace(',', '.'));
                        Thread.Sleep(writeDelay);
                        success = true;
                    }
                }

                if (!success) MessageBox.Show("Wrong value of \"LATITUDE\"!\nRequired - float, (latitude >= -90) && (latitude <= 90)", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                success = false;

                // LONGITUDE
                float longitude;

                if (float.TryParse(longitudeTextBox.Text.Trim().Replace('.', ','), out longitude))
                {
                    if ((longitude >= -180) && (longitude <= 180))
                    {
                        serialPort.WriteLine("LONGITUDE:" + longitude.ToString("#.000000").Replace(',', '.'));
                        log("out: ", "LONGITUDE:" + longitude.ToString("#.000000").Replace(',', '.'));
                        Thread.Sleep(writeDelay);
                        success = true;
                    }
                }

                if (!success) MessageBox.Show("Wrong value of \"LONGITUDE\"!\nRequired - float, (longitude >= -180) && (longitude <= 180)", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                success = false;

                // ALTITUDE
                float altitude;

                if (float.TryParse(altitudeTextBox.Text.Trim().Replace('.', ','), out altitude))
                {
                    if ((altitude >= 0) && (altitude <= 9999))
                    {
                        serialPort.WriteLine("ALTITUDE:" + altitude.ToString("#.0").Replace(',', '.'));
                        log("out: ", "ALTITUDE:" + altitude.ToString("#.0").Replace(',', '.'));
                        Thread.Sleep(writeDelay);
                        success = true;
                    }
                }

                if (!success) MessageBox.Show("Wrong value of \"ALTITUDE\"!\nRequired - float, (altitude >= 0) && (altitude <= 9999)", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                success = false;

                // LOOPTIME
                int looptime;

                if (int.TryParse(looptimeTextBox.Text.Trim(), out looptime))
                {
                    if ((looptime >= 60000) && (looptime <= 86400000))
                    {
                        serialPort.WriteLine("LOOPTIME:" + looptime.ToString());
                        log("out: ", "LOOPTIME:" + looptime.ToString());
                        Thread.Sleep(writeDelay);
                        success = true;
                    }
                }

                if (!success) MessageBox.Show("Wrong value of \"LOOPTIME\"!\nRequired - int, (looptime >= 60000) && (looptime <= 86400000)", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                success = false;

                // MEASURETIMES
                int measuretimes;

                if (int.TryParse(measuretimesTextBox.Text.Trim(), out measuretimes))
                {
                    if ((measuretimes >= 10) && (measuretimes <= 300))
                    {
                        serialPort.WriteLine("MEASURETIMES:" + measuretimes.ToString());
                        log("out: ", "MEASURETIMES:" + measuretimes.ToString());
                        Thread.Sleep(writeDelay);
                        success = true;
                    }
                }

                if (!success) MessageBox.Show("Wrong value of \"MEASURETIMES\"!\nRequired - int, (measuretimes >= 10) && (measuretimes <= 300)", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // DEBUG
                int debug = 0;
                if (debugCheckBox.Checked) debug = 1;

                serialPort.WriteLine("DEBUG:" + debug.ToString());
                log("out: ", "DEBUG:" + debug.ToString());
                Thread.Sleep(writeDelay);

                // DEBUG_GSM
                int debuggsm = 0;
                if (debuggsmCheckBox.Checked) debuggsm = 1;

                serialPort.WriteLine("DEBUG_GSM:" + debuggsm.ToString());
                log("out: ", "DEBUG_GSM:" + debuggsm.ToString());
                Thread.Sleep(writeDelay);

                // GPRS_APN
                serialPort.WriteLine("GPRS_APN:" + apnTextBox.Text.Trim());
                log("out: ", "GPRS_APN:" + apnTextBox.Text.Trim());
                Thread.Sleep(writeDelay);

                // GPRS_USERNAME
                serialPort.WriteLine("GPRS_USERNAME:" + usernameTextBox.Text.Trim());
                log("out: ", "GPRS_USERNAME:" + usernameTextBox.Text.Trim());
                Thread.Sleep(writeDelay);

                // GPRS_PASSWORD
                serialPort.WriteLine("GPRS_PASSWORD:" + passwordTextBox.Text.Trim());
                log("out: ", "GPRS_PASSWORD:" + passwordTextBox.Text.Trim());
                Thread.Sleep(writeDelay);

                // URL
                serialPort.WriteLine("URL:" + urlTextBox.Text.Trim());
                log("out: ", "URL:" + urlTextBox.Text.Trim());
                Thread.Sleep(writeDelay);

                serialPort.WriteLine("WRITE2EEPROM");
                log("out: ", "WRITE2EEPROM");
                Thread.Sleep(writeDelay);

                groupBox1.Enabled = true;
                groupBox2.Enabled = true;
                groupBox3.Enabled = true;
                groupBox4.Enabled = true;
                groupBox5.Enabled = true;
                groupBox6.Enabled = true;
                groupBox7.Enabled = true;
            }

            catch (Exception ex)
            {
                 MessageBox.Show(ex.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Лог
        private void log(String prefix, String text)
        {
            logTextBox.AppendText(prefix + text + System.Environment.NewLine);
        }

        // Загрузка формы
        private void configuratorForm_Load(object sender, EventArgs e)
        {
            scanForPorts();    
        }

        // Закрытие формы
        private void configuratorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort.IsOpen) serialPort.Close();
        }
    }
}
