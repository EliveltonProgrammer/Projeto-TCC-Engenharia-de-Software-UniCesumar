using System;
using System.Windows.Forms;
using System.Drawing;
using System.Threading.Tasks;
using System.Xml;
using System.Timers;
using System.Diagnostics;
using Newtonsoft.Json.Linq;

namespace Gestao_Produtividade_Industrial
{
    public partial class frmSensorsDataCollection : Form
    {
        private bool machineOn;
        private bool machineIdle;
        private bool machineOff;
        private int machineSpeed;
        private int quantityPiecesProduction;
        private System.Timers.Timer updateTimer;
        DataIntegrationMachine machineData = new DataIntegrationMachine();
        MachineSensorData machineParm = new MachineSensorData();

        public frmSensorsDataCollection()
        {
            InitializeComponent();
            StartInterfaceUpdateTimer();
        }

        private async void frmSensorsDataCollection_Load(object sender, EventArgs e)
        {
            LoadScreenFunctions();
            await LoadMachines();
            SetOperationsButtonsAvailability();
        }

        private void cbxSelectMachine_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectMachine();
        }

        private async void btnOn_Click(object sender, EventArgs e)
        {
            await TurnOnMachine();
        }

        private async void btnIdle_Click(object sender, EventArgs e)
        {
            await SetMachineIdle();
        }

        private async void btnOff_Click(object sender, EventArgs e)
        {
            await TurnOffMachine();
        }

        private async void btnEmergencyStop_Click(object sender, EventArgs e)
        {
            await EmergencyStop();
        }

        private void btnIncreaseSpeed_Click(object sender, EventArgs e)
        {
            IncrementSpeed();
        }

        private void btnDecreaseSpeed_Click(object sender, EventArgs e)
        {
            DecrementSpeed();
        }

        // Evento de altera��o da Velocidade e atualizar os dados
        private bool isEventEnabled = false;
        private async void tbxSpeedMachine_TextChanged(object sender, EventArgs e)
        {
            if (isEventEnabled)
            {
                await SpeedControl();
            }
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            Parameters iniFrm = new Parameters();
            iniFrm.Show();
        }

        private async void btnUpdateSensors_Click(object sender, EventArgs e)
        {
            await ReadAndUpdateSensors();
        }

        private async void btnViewStatistics_Click(object sender, EventArgs e)
        {
            await OpenAndGetStatistics();
        }

        private void DefaultMachine()
        {
            cbxSelectMachine.SelectedIndex = 0;
        }

        private void StartInterfaceUpdateTimer()
        {
            // Inicializa e configura o temporizador
            updateTimer = new System.Timers.Timer();
            updateTimer.Interval = 2000; // Configura o intervalo para 2 segundos
            updateTimer.AutoReset = true;
            updateTimer.Elapsed += async (sender, e) =>
            {
                Invoke(new Action(async () => await ReadAndUpdateSensors()));
            };

            updateTimer.Start(); // Inicia o timer
        }

        private void LoadScreenFunctions()
        {
            // Valida regra para uso da fun��o de Velocidade ao carregar interface
            if (machineOn)
            {
                btnIncreaseSpeed.Enabled = true;
                btnDecreaseSpeed.Enabled = true;
            }
            else
            {
                btnIncreaseSpeed.Enabled = false;
                btnDecreaseSpeed.Enabled = false;
            }

            // Valida regra para uso da fun��o Estatisticas ao carregar interface
            if (!String.IsNullOrWhiteSpace(tbxOperationTime.Text) && !String.IsNullOrWhiteSpace(tbxStopTime.Text))
            {
                btnViewStatistics.Enabled = true;
            }
            else
            {
                btnViewStatistics.Enabled = false;
            }
        }

        // Ler e carregar m�quinas registradas
        private async Task LoadMachines()
        {
            try
            {
                DataIntegrationMachine json = new DataIntegrationMachine();
                (string machineName, string machineImage) = await json.LoadMachineName();

                if (!string.IsNullOrEmpty(machineName))
                {
                    cbxSelectMachine.Items.Add(machineName);
                    cbxSelectMachine.SelectedIndex = 0;
                }

                // Acionar ReadAndUpdateSensors para atualizar estados ao carregar as m�quinas
                DefaultMachine();
                await ReadAndUpdateSensors();
                SetOperationsButtonsAvailability();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar M�quinas: " + ex.Message);
            }
        }

        // Selecionar m�quina em evento de altera��o para outra m�quina
        private async Task SelectMachine()
        {
            try
            {
                DataIntegrationMachine json = new DataIntegrationMachine();
                (string machineName, string machineImage) = await json.LoadMachineName();

                // Carregar imagem da m�quina selecionada
                picImgMachine.SizeMode = PictureBoxSizeMode.Zoom;
                picImgMachine.ImageLocation = machineImage; // Utilizando o caminho da imagem retornado

                await ReadAndUpdateSensors();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar imagens das M�quinas: " + ex.Message);
            }
        }

        // Ler e atualizar sensores de estado
        private async Task ReadAndUpdateSensors()
        {
            try
            {
                // Armazena a m�quina selecionada
                string selectedMachineName = cbxSelectMachine.SelectedItem?.ToString();

                if (selectedMachineName != null)
                {
                    machineParm.Machine = selectedMachineName;

                    await machineData.DataReadSensors(selectedMachineName, machineParm);

                    // Atualizar as vari�veis de Controle de acordo com os valores dos Sensores
                    machineOn = machineParm.OperatingSensor == 1;
                    machineIdle = machineParm.IdleSensor == 1;
                    machineOff = machineParm.StopSensor == 1 || machineParm.StopSensor == 2;
                    machineSpeed = Convert.ToInt32(machineParm.MotorSpeed);
                    tbxSpeedMachine.Text = machineSpeed.ToString().Trim();

                    // Atualiza Informa��es de estado no Painel
                    if (machineParm.OperatingSensor == 1)
                    {
                        this.Text = "Painel Sensores | Coleta de dados - M�quina Em Opera��o (Ligada)";
                        lbInformationInterface.Text = "M�quina Em Opera��o";
                    }
                    if (machineParm.IdleSensor == 1)
                    {
                        this.Text = "Painel Sensores | Coleta de dados - M�quina Ociosa (Sem Leitura)";
                        lbInformationInterface.Text = "M�quina Ociosa";
                    }
                    if (machineParm.StopSensor == 1)
                    {
                        this.Text = "Painel Sensores | Coleta de dados - M�quina Em Parada (Desligada)";
                        lbInformationInterface.Text = "M�quina em Parada";
                    }
                    if (machineParm.StopSensor == 2)
                    {
                        this.Text = "Painel Sensores | Coleta de dados - M�quina Em Parada de Emerg�ncia (Parada)";
                        lbInformationInterface.Text = "M�quina em Parada Emerg�ncia";
                    }

                    // Obter quantidade produ��o em tempo real
                    await GetProduction();

                    // Atualizar a disponibilidade dos bot�es na interface
                    SetOperationsButtonsAvailability();

                    // Atualizar indicadores (piscar) de estado na interface
                    await BlinkLedSensors(tbxStatusLed1, tbxStatusLed2, tbxStatusLed3, tbxStatusLed4);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados de Sensores: " + ex.Message);
            }
        }

        // Obter Produ��o atual
        private async Task GetProduction()
        {
            MachineProductionData machineProduct = new MachineProductionData();

            try
            {
                // Verifique se a m�quina est� selecionada
                if (cbxSelectMachine.SelectedItem != null)
                {
                    await machineData.DataReadProduction(machineProduct);

                    // Armazena a quantidade Produzida/Lida na vari�vel
                    quantityPiecesProduction = machineProduct.QuantityPieces;

                    if (machineProduct.QuantityPieces == 0)
                    {
                        tbxProductionPieces.Text = "0";
                        tbxProductionGoodPieces.Text = "0";
                    }
                    else
                    {
                        tbxProductionPieces.Text = Convert.ToString(quantityPiecesProduction);
                        tbxProductionGoodPieces.Text = Convert.ToString(quantityPiecesProduction);
                    }

                    tbxProductionDefectivePieces.Text = "0"; // Simula valor 0 para Pe�as com defeito
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao recuperar dados: " + ex.Message);
            }
        }

        // Abrir e Gerar gr�ficos estatisticos
        private async Task OpenAndGetStatistics()
        {
            try
            {
                // Obter valores dos Tempos de Opera��o e Parada da m�quina selecionada
                string machineSelected = cbxSelectMachine.SelectedItem.ToString().Trim();
                TimeSpan operationTime = TimeSpan.Parse(tbxOperationTime.Text);
                TimeSpan stopTime = TimeSpan.Parse(tbxStopTime.Text);

                // Converter valores de tempo para minutos
                int operationTimeMinutes = (int)operationTime.TotalMinutes;
                int stopTimeMinutes = (int)stopTime.TotalMinutes;

                // Inst�ncia de frmStatisticsDataCollection passar os valores dos tempos como par�metros
                frmStatisticsDataCollection statisticsForm = new frmStatisticsDataCollection(machineSelected, operationTimeMinutes, stopTimeMinutes);

                // Exibir o formul�rio
                statisticsForm.Show();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Error parsing time: " + ex.Message);
            }
        }

        // Ligar
        private async Task TurnOnMachine()
        {
            try
            {
                // Passa os valores nos par�metros para atualizar dados de integra��o
                machineParm.Machine = cbxSelectMachine.SelectedItem.ToString().Trim();
                machineParm.OperatingSensor = 1;
                machineParm.IdleSensor = 0;
                machineParm.StopSensor = 0;
                machineParm.MotorSensor = 1;
                machineParm.MotorSpeed = 5;

                await PerformMachineOperation(machineParm);
                StopOperationTimer();
                StartOperationTimer();
                StopStopTimer();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao definir M�quina Ligada: " + ex.Message);
            }
        }

        // Estado ocioso
        private async Task SetMachineIdle()
        {
            try
            {
                machineParm.Machine = cbxSelectMachine.SelectedItem.ToString().Trim();
                machineParm.OperatingSensor = 1;
                machineParm.IdleSensor = 1;
                machineParm.StopSensor = 0;
                machineParm.MotorSensor = 1;

                await PerformMachineOperation(machineParm);
                StopOperationTimer();
                StartOperationTimer();
                StopStopTimer();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao definir M�quina Ociosa: " + ex.Message);
            }
        }

        // Desligar
        private async Task TurnOffMachine()
        {
            try
            {
                machineParm.Machine = cbxSelectMachine.SelectedItem.ToString().Trim();
                machineParm.OperatingSensor = 0;
                machineParm.IdleSensor = 0;
                machineParm.StopSensor = 1;
                machineParm.MotorSensor = 0;
                machineParm.MotorSpeed = 0;

                await PerformMachineOperation(machineParm);
                StopOperationTimer();
                StartStopTimer();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao definir M�quina Desligada: " + ex.Message);
            }
        }

        // Acionar Parada de emerg�ncia
        private async Task EmergencyStop()
        {
            try
            {
                machineParm.Machine = cbxSelectMachine.SelectedItem.ToString().Trim();
                machineParm.OperatingSensor = 0;
                machineParm.IdleSensor = 0;
                machineParm.StopSensor = 2;
                machineParm.MotorSensor = 0;

                await PerformMachineOperation(machineParm);
                StopOperationTimer();
                StartStopTimer();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao definir M�quina estado Emerg�ncia: " + ex.Message);
            }
        }

        // Fun��o aumentar velocidade / atualizar dados com o evento SpeedControl no Textbox de Velocidade
        private void IncrementSpeed()
        {
            isEventEnabled = false;

            int currentValue = Convert.ToInt32(tbxSpeedMachine.Text);
            if (currentValue < 10)
            {
                currentValue++;
                tbxSpeedMachine.Text = currentValue.ToString();
            }

            isEventEnabled = true;

            // Atualizar a velocidade ap�s alterar
            SpeedControl();
        }

        // Fun��o diminuir velocidade
        private void DecrementSpeed()
        {
            isEventEnabled = false;

            int currentValue = Convert.ToInt32(tbxSpeedMachine.Text);
            if (currentValue > 1)
            {
                currentValue--;
                tbxSpeedMachine.Text = currentValue.ToString();
            }

            isEventEnabled = true;

            // Atualizar a velocidade ap�s alterar
            SpeedControl();
        }


        private async Task SpeedControl()
        {
            try
            {
                machineSpeed = Convert.ToInt32(tbxSpeedMachine.Text.ToString().Trim());
                machineParm.MotorSpeed = machineSpeed;

                await PerformMachineOperation(machineParm);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao definir Velocidade da M�quina: " + ex.Message);
            }
        }

        // Executar qualquer opera��o acionada na m�quina e painel (opera��es de interface/grava��o de dados)
        private async Task PerformMachineOperation(MachineSensorData machineParm)
        {
            await machineData.MachineControl(machineParm);
            await ReadAndUpdateSensors();
            SetOperationsButtonsAvailability();
            await BlinkLedSensors(tbxStatusLed1, tbxStatusLed2, tbxStatusLed3, tbxStatusLed4);
        }

        private void SetOperationsButtonsAvailability()
        {
            btnOn.Enabled = (!machineOn && !machineIdle) || (machineIdle && machineOff);
            btnIdle.Enabled = machineOn && !machineIdle && !machineOff;
            btnOff.Enabled = machineOn && !machineIdle && !machineOff;
            btnEmergencyStop.Enabled = machineOn && !machineIdle && !machineOff;

            // Quando a m�quina est� desligada
            if (!machineOn && !machineIdle && machineOff)
            {
                btnOn.Enabled = true;
                btnIdle.Enabled = false;
                btnOff.Enabled = false;
                btnEmergencyStop.Enabled = false;
            }
            // Quando a m�quina est� ociosa
            else if (machineOn && machineIdle && !machineOff)
            {
                btnOn.Enabled = true;
                btnOff.Enabled = true;
            }

            // Valida regra para uso da fun��o de Velocidade ao carregar interface
            if (machineOn)
            {
                btnIncreaseSpeed.Enabled = true;
                btnDecreaseSpeed.Enabled = true;
                lbStatus.Text = "[ Ligada ]";
            }
            else
            {
                btnIncreaseSpeed.Enabled = false;
                btnDecreaseSpeed.Enabled = false;
                lbStatus.Text = "[ Desligada ]";
            }

            // Valida regra para uso da fun��o Estatisticas ao carregar interface
            if (!String.IsNullOrWhiteSpace(tbxOperationTime.Text) && !String.IsNullOrWhiteSpace(tbxStopTime.Text))
            {
                btnViewStatistics.Enabled = true;
            }
            else
            {
                btnViewStatistics.Enabled = false;
            }
        }

        private async Task BlinkLedSensors(TextBox tbxLed1, TextBox tbxLed2, TextBox tbxLed3, TextBox tbxLed4)
        {
            tbxLed1.Visible = true;
            tbxLed2.Visible = true;
            tbxLed3.Visible = true;
            tbxLed4.Visible = true;

            // Ligada
            if (machineOn)
            {
                tbxLed1.BackColor = Color.LimeGreen;
                tbxLed2.BackColor = Color.LimeGreen;
                tbxLed3.BackColor = Color.LimeGreen;
                tbxLed4.BackColor = Color.LimeGreen;
            }
            // Ociosa
            if (machineIdle)
            {
                tbxLed1.BackColor = Color.Yellow;
                tbxLed2.BackColor = Color.Yellow;
                tbxLed3.BackColor = Color.Yellow;
                tbxLed4.BackColor = Color.Yellow;
            }
            // Desligada
            if (machineOff)
            {
                tbxLed1.BackColor = Color.Red;
                tbxLed2.BackColor = Color.Red;
                tbxLed3.BackColor = Color.Red;
                tbxLed4.BackColor = Color.Red;
            }

            await Task.Delay(1000);

            tbxLed1.Visible = false;
            tbxLed2.Visible = false;
            tbxLed3.Visible = false;
            tbxLed4.Visible = false;
        }

        // Vari�veis para rastrear o tempo de opera��o e parada
        private int operationSeconds = 0;
        private int stopSeconds = 0;

        // Timers para o tempo de opera��o e parada
        private System.Timers.Timer operationTimer;
        private System.Timers.Timer stopTimer;

        private void StartOperationTimer()
        {
            // Inicia o timer de opera��o
            operationTimer = new System.Timers.Timer();
            operationTimer.Interval = 1000;
            operationTimer.Elapsed += (sender, e) =>
            {
                operationSeconds++;

                // Atualiza o tempo de opera��o 
                UpdateOperationTime(operationSeconds);
            };

            operationTimer.Start();
        }

        private void StopOperationTimer()
        {
            // Interrompe o timer de opera��o
            operationTimer?.Stop();
        }

        private void StartStopTimer()
        {
            // Inicia o timer de parada
            stopTimer = new System.Timers.Timer();
            stopTimer.Interval = 1000;
            stopTimer.Elapsed += (sender, e) =>
            {
                stopSeconds++;

                // Atualiza o tempo de parada
                UpdateStopTime(stopSeconds);
            };

            stopTimer.Start();
        }

        private void StopStopTimer()
        {
            // Interrompe o timer de parada
            stopTimer?.Stop();
        }

        private void UpdateOperationTime(int seconds)
        {
            TimeSpan operationTime = TimeSpan.FromSeconds(seconds);

            // Atualiza o tempo de opera��o
            if (tbxOperationTime.InvokeRequired)
            {
                tbxOperationTime.BeginInvoke(new Action(() => tbxOperationTime.Text = operationTime.ToString(@"hh\:mm\:ss")));
            }
            else
            {
                tbxOperationTime.Text = operationTime.ToString(@"hh\:mm\:ss");
            }
        }

        private void UpdateStopTime(int seconds)
        {
            TimeSpan stopTime = TimeSpan.FromSeconds(seconds);

            // Atualiza o tempo de parada
            if (tbxStopTime.InvokeRequired)
            {
                tbxStopTime.BeginInvoke(new Action(() => tbxStopTime.Text = stopTime.ToString(@"hh\:mm\:ss")));
            }
            else
            {
                tbxStopTime.Text = stopTime.ToString(@"hh\:mm\:ss");
            }
        }
    }
}