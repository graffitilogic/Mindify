using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindiFy
{
    [Serializable]
    public class Synapse
    {
        public Neuron FromNeuron { get; set; }
        public Neuron ToNeuron { get; set; }
        public double Weight { get; set; }
        public bool IsActive { get; set; } = true;

        public Synapse(Neuron fromNeuron, Neuron toNeuron, double weight)
        {
            FromNeuron = fromNeuron;
            ToNeuron = toNeuron;
            Weight = weight;
        }
    }
}
