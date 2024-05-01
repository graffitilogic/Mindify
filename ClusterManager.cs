using MessagePack;
using Mindify;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindiFy
{
    public class ClusterManager
    {
        private Dictionary<int, string> clusterToFileMap = new Dictionary<int, string>();

        public void SaveNeuronCluster(List<Neuron> cluster, int clusterId)
        {
            var filePath = GetFilePathForCluster(clusterId);
            var bytes = MessagePackSerializer.Serialize(cluster);
            File.WriteAllBytes(filePath, bytes);
        }

        public List<Neuron> LoadNeuronCluster(int clusterId)
        {
            var filePath = GetFilePathForCluster(clusterId);
            var bytes = File.ReadAllBytes(filePath);
            return MessagePackSerializer.Deserialize<List<Neuron>>(bytes);
        }

        private string GetFilePathForCluster(int clusterId)
        {
            if (!clusterToFileMap.ContainsKey(clusterId))
            {
                var filePath = $"Cluster_{clusterId}.bin";
                clusterToFileMap[clusterId] = filePath;
            }
            return clusterToFileMap[clusterId];
        }
    }

}
