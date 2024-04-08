using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_Produtividade_Industrial
{
    public class MachineSensorData
    {
        public string Machine { get; set; }
        public int OperatingSensor { get; set; }
        public int IdleSensor { get; set; }
        public int StopSensor { get; set; }
        public int MotorSensor { get; set; }
        public int MotorSpeed { get; set; }
        public string LocationDataReading { get; set; }
        public string MachineImage { get; set; }
    }
}
