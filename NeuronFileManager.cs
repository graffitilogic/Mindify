using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using MessagePack;

namespace MindiFy
{
    class NeuronFileManager
    {
        private const string BasePath = "Neurons/";

        public void SaveNeuron(Neuron neuron, int neuronId)
        {
            var filePath = $"{BasePath}Neuron_{neuronId}.bin";
            var bytes = MessagePackSerializer.Serialize(neuron);
            File.WriteAllBytes(filePath, bytes);
        }

        public Neuron LoadNeuron(int neuronId)
        {
            var filePath = $"{BasePath}Neuron_{neuronId}.bin";
            var bytes = File.ReadAllBytes(filePath);
            return MessagePackSerializer.Deserialize<Neuron>(bytes);
        }
    }
}
