using MessagePack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindiFy
{

    [MessagePackObject]
    public class NeuronTemplate
    {
        [Key(0)]
        public List<Synapse> PrototypeConnections { get; set; } = new List<Synapse>();
        [Key(1)]
        public double InitialState { get; set; }
    }

    [MessagePackObject]
    public class Neuron
    {
        [Key(0)]
        public List<Synapse> Connections { get; set; }
        [Key(1)]
        public double State { get; set; }
        [Key(2)]
        public double Output { get; set; }

        // Constructor that clones a template
        public Neuron(NeuronTemplate template)
        {
            Connections = new List<Synapse>(template.PrototypeConnections);
            State = template.InitialState;
        }
 
    public void Activate()
        {
            Output = 1.0 / (1.0 + Math.Exp(-State));
        }
    }

}
