using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Gestao_Produtividade_Industrial
{
    public partial class frmStatisticsDataCollection : Form
    {
        private DataIntegrationMachine dataIntegrationMachine;
        private List<int> productionDataHistory = new List<int>(); // Lista para armazenar o histórico de dados de produção
        private string machine;
        private int operationTimeStatistic;
        private int stopTimeStatistic;
        private System.Windows.Forms.Timer updateTimer;

        public frmStatisticsDataCollection(string machineSelected, int operationTime, int stopTime)
        {
            InitializeComponent();
            StartInterfaceUpdateTimer();

            dataIntegrationMachine = new DataIntegrationMachine(); // Inicializa a instância da classe de dados
            machine = machineSelected; // Atribui a máquina selecionada atualmente

            this.operationTimeStatistic = operationTime;
            this.stopTimeStatistic = stopTime;

            // Exibir os valores formatados dos tempos de operação e parada nos labels
            DisplayOperationAndStopTime(operationTime, stopTime);
        }

        private async void frmStatisticsDataCollection_Load(object sender, EventArgs e)
        {
            // Chamar o método para obter os dados de produção em tempo real
            await UpdateProductionData();
        }

        private void StartInterfaceUpdateTimer()
        {
            // Inicializar o Timer
            updateTimer = new System.Windows.Forms.Timer();
            updateTimer.Interval = 2000; // Intervalo de 2 segundos
            updateTimer.Tick += UpdateTimer_Tick;
            updateTimer.Start();
        }

        private async void UpdateTimer_Tick(object sender, EventArgs e)
        {
            // Chamar o método para atualizar os dados de produção
            await UpdateProductionData();
        }

        private async void btnUpdateStatistics_Click(object sender, EventArgs e)
        {
            await UpdateProductionData();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async Task UpdateProductionData()
        {
            try
            {
                MachineProductionData machineProductionData = new MachineProductionData();

                // obter os dados de produção em tempo real
                await dataIntegrationMachine.DataReadProduction(machineProductionData);

                // Adicionar a quantidade produzida ao histórico
                productionDataHistory.Add(machineProductionData.QuantityPieces);
                lbProductionQuantity.Text = Convert.ToString(machineProductionData.QuantityPieces);

                // Verificar se o formulário não está fechando
                if (!IsDisposed)
                {
                    // Verificar se chart1 não é nulo antes de chamar UpdateLineChart
                    if (chart1 != null)
                    {
                        // Exibir os dados de produção no gráfico de linhas
                        UpdateLineChart(chart1, machine, productionDataHistory);
                    }

                    // Verificar se chart2 não é nulo antes de chamar UpdateBarChart
                    if (chart2 != null)
                    {
                        // Exibir os dados de produção no gráfico de barras
                        UpdateBarChart(chart2, machine, productionDataHistory);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar dados de Produção: " + ex.Message);
            }
        }

        private void UpdateLineChart(Chart chart, string machine, List<int> productionDataHistory)
        {
            // Limpar gráfico
            chart.Series.Clear();

            // Criar nova série para os dados de quantidade produzida
            var series = new Series
            {
                Name = $"Quantidade Produzida/Lida\n Máquina atual: {machine}",
                Color = Color.DeepSkyBlue,
                IsVisibleInLegend = true,
                IsXValueIndexed = false,
                ChartType = SeriesChartType.Line
            };

            for (int i = 0; i < productionDataHistory.Count; i++)
            {
                // Adicionar o valor da quantidade produzida e o índice correspondente como o tempo
                series.Points.AddXY(i, productionDataHistory[i]);
            }

            // Adicionar a série ao gráfico
            chart.Series.Add(series);
        }

        private void UpdateBarChart(Chart chart, string machine, List<int> productionDataHistory)
        {
            chart.Series.Clear();

            var series = new Series
            {
                Name = $"Quantidade Produzida/Lida\n Máquina atual: {machine}",
                Color = Color.DeepSkyBlue,
                IsVisibleInLegend = true,
                IsXValueIndexed = false,
                ChartType = SeriesChartType.Column
            };

            for (int i = 0; i < productionDataHistory.Count; i++)
            {
                series.Points.AddXY(i, productionDataHistory[i]);
            }

            chart.Series.Add(series);
        }

        private void DisplayOperationAndStopTime(int operationTimeSeconds, int stopTimeSeconds)
        {
            // Converter os segundos para TimeSpan
            TimeSpan operationTimeSpan = TimeSpan.FromSeconds(operationTimeSeconds);
            TimeSpan stopTimeSpan = TimeSpan.FromSeconds(stopTimeSeconds);

            // Ajustar a unidade de tempo para minutos e segundos antes de formatar
            int operationMinutes = (int)operationTimeSpan.TotalMinutes;
            int stopMinutes = (int)stopTimeSpan.TotalMinutes;

            // Formatar os tempos para exibir corretamente
            string formattedOperationTime = string.Format("{0:00}:{1:00}:00", operationMinutes, operationTimeSpan.Seconds);
            string formattedStopTime = string.Format("{0:00}:{1:00}:00", stopMinutes, stopTimeSpan.Seconds);

            // Exibir os valores formatados nos labels
            lbOperationTime.Text = formattedOperationTime;
            lbStopTime.Text = formattedStopTime;
        }
    }
}