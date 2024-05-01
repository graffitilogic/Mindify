using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindiFy
{
    [Serializable]
    public class Neuron
    {
        public List<Synapse> Connections { get; set; }
        public double State { get; set; }
        public double Output { get; set; }

        public Neuron()
        {
            Connections = new List<Synapse>();
            State = 0;
        }

        public void Activate()
        {
            Output = 1.0 / (1.0 + Math.Exp(-State));
        }
    }

}
