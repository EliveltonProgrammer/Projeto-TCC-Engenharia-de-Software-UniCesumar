using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace Gestao_Produtividade_Industrial
{
    public class DataIntegrationMachine
    {
        private string jsonSensorsFilePath = @"C:\MachineSensorControl\Sensors.json";
        private string jsonProductionFilePath = @"C:\MachineSensorControl\Production.json";

        // Lê cadastros das máquinas para uso nas interfaces
        public async Task<(string machineName, string machineImage)> LoadMachineName()
        {
            string machineName = null;
            string machineImage = null;

            try
            {
                string jsonText = await File.ReadAllTextAsync(jsonSensorsFilePath);
                JObject json = JObject.Parse(jsonText);

                // Obtenha o nome da máquina e a imagem
                machineName = json["Machine"].ToString();
                machineImage = json["MachineImage"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados do JSON: " + ex.Message);
            }

            return (machineName, machineImage);
        }

        // Leitura de dados sensores (estados da máquina)
        public async Task DataReadSensors(string machineName, MachineSensorData machineData)
        {
            try
            {
                string jsonText = await File.ReadAllTextAsync(jsonSensorsFilePath);
                JObject json = JObject.Parse(jsonText);

                // Filtra a máquina correspondente selecionada
                JToken machineNode = json;

                // Verifica se a máquina está presente no JSON
                if (machineName != null && json["Machine"].ToString() == machineName.Trim())
                {
                    // Obter valores dos sensores para controle real de status
                    machineData.OperatingSensor = Convert.ToInt32(json["OperatingSensor"]);
                    machineData.IdleSensor = Convert.ToInt32(json["IdleSensor"]);
                    machineData.StopSensor = Convert.ToInt32(json["StopSensor"]);
                    machineData.MotorSensor = Convert.ToInt32(json["MotorSensor"]);
                    machineData.MotorSpeed = Convert.ToInt32(json["Speed"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados do JSON: " + ex.Message);
            }
        }

        // Leitura de dados Produção
        public async Task DataReadProduction(MachineProductionData machineProductData)
        {
            try
            {
                string jsonText = await File.ReadAllTextAsync(jsonProductionFilePath);
                JObject json = JObject.Parse(jsonText);

                // Obter quantidade da Produção atual
                machineProductData.QuantityPieces = Convert.ToInt32(json["QuantityPieces"]);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados do JSON: " + ex.Message);
            }
        }

        // Controle da máquina em geral (atualiza valores para a máquina)
        public async Task MachineControl(MachineSensorData machineData)
        {
            try
            {
                string jsonText = await File.ReadAllTextAsync(jsonSensorsFilePath);
                JObject json = JObject.Parse(jsonText);

                // Atualize diretamente os valores no objeto JSON
                json["OperatingSensor"] = machineData.OperatingSensor;
                json["IdleSensor"] = machineData.IdleSensor;
                json["StopSensor"] = machineData.StopSensor;
                json["MotorSensor"] = machineData.MotorSensor;
                json["Speed"] = machineData.MotorSpeed;

                // Salvar alterações no arquivo JSON
                await File.WriteAllTextAsync(jsonSensorsFilePath, json.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao controlar Operações na Máquina: " + ex.Message);
            }
        }
    }
}