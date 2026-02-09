using SoftwarePatterns.Creational.Prototype.ServerConfiguration.Interfaces;

namespace SoftwarePatterns.Creational.Prototype.ServerConfiguration
{
    public class ServerConfiguration : ICloneable<ServerConfiguration>
    {
        private string Name { get; set; }
        private string Ip { get; set; }
        private string Ram { get; set; }
        private string Disk { get; set; }
        private double Cpu { get; set; }
        private string Tmp { get; set; }
        private int HealthPort { get; set; }

        public ServerConfiguration(string name, string ip, string ram, string disk, double cpu, string tmp, int healthPort)
        {
            Name = name;
            Ip = ip;
            Ram = ram;
            Disk = disk;
            Cpu = cpu;
            Tmp = tmp;
            HealthPort = healthPort;
        }


        /// <summary>
        /// Cria e retorna um novo objeto <see cref="ServerConfiguration"/> com os mesmos valores da instância atual.
        /// </summary>
        /// <remarks>
        /// Este método realiza uma cópia superficial (shallow copy). Como os campos são do tipo <see cref="string"/> (imutáveis) e tipos primitivos,
        /// o comportamento é equivalente a um deep copy para este caso.
        /// </remarks>
        /// <returns>Uma cópia da configuração atual do servidor.</returns>
        public ServerConfiguration Clone()
        {
            return new ServerConfiguration(Name, Ip, Ram, Disk, Cpu, Tmp, HealthPort);
        }

        public string GetNome() => Name;
        public string GetIp() => Ip;
        public string GetRam() => Ram;
        public string GetDisco() => Disk;
        public double GetCpu() => Cpu;
        public string GetTmp() => Tmp;
        public int GetHealthPort() => HealthPort;

        public void SetNome(string name) => Name = name;
        public void SetIp(string ip) => Ip = ip;
        public void SetRam(string ram) => Ram = ram;
        public void SetDisco(string disk) => Disk = disk;
        public void SetCpu(double cpu) => Cpu = cpu;
        public void SetTmp(string tmp) => Tmp = tmp;
        public void SetHealthPort(int healthPort) => HealthPort = healthPort;

        /// <summary>
        /// Retorna uma representação legível da configuração do servidor,
        /// formatada em múltiplas linhas para facilitar a visualização em logs e console.
        /// </summary>
        /// <returns>Uma string com os valores atuais da configuração.</returns>
        public override string ToString()
        {
            return
                "Configuração do Servidor:\n" +
                $"  Nome       : {Name}\n" +
                $"  IP         : {Ip}\n" +
                $"  RAM        : {Ram}\n" +
                $"  Disco      : {Disk}\n" +
                $"  CPU        : {Cpu}\n" +
                $"  TMP        : {Tmp}\n" +
                $"  HealthPort : {HealthPort}\n";
        }
    }
}