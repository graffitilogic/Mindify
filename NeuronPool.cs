using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MindiFy
{

    public class NeuronPool
    {

        private Queue<Neuron> availableNeurons = new Queue<Neuron>();
        private const string storagePath = "LongTerm.Memory";
        private const int MAX_SHORT_TERM_MEMORY = 2048;
        public Neuron GetNeuron()
        {
            if (availableNeurons.Count > 0)
            {
                return availableNeurons.Dequeue();
            }
            else
            {
                // Try to load from disk
                return LoadNeuronFromDisk();
            }
        }

        public void ReleaseNeuron(Neuron neuron)
        {
            if (availableNeurons.Count < MAX_SHORT_TERM_MEMORY)  // the threshold for in-memory storage
            {
                availableNeurons.Enqueue(neuron);
            }
            else
            {
                // Save to disk
                SaveNeuronToDisk(neuron);
            }
        }

        private void SaveNeuronToDisk(Neuron neuron)
        {
            using (var stream = new FileStream(storagePath, FileMode.Append))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, neuron);
            }
        }

        private Neuron LoadNeuronFromDisk()
        {
            if (File.Exists(storagePath))
            {
                using (var stream = new FileStream(storagePath, FileMode.Open))
                {
                    if (stream.Length > 0)
                    {
                        var formatter = new BinaryFormatter();
                        var neuron = (Neuron)formatter.Deserialize(stream);
                        return neuron;
                    }
                }
            }
            return new Neuron();
        }
    }
}
