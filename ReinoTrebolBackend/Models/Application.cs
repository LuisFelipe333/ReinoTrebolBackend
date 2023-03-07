using ReinoTrebolBackend.Models.Enum;

namespace ReinoTrebolBackend.Models
{
    public class Application
    {
        public int idSolicitud { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public string identification { get; set; }
        public int age { get; set; }
        public string magicalAff { get; set; }
        public bool status { get; set; }
        public GrimoireLevel grimoireLevel { get; set;}
    }
}
