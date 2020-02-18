using System.IO;

namespace DesignPatterns._02_Mediator
{
    public class Magazine
    {
        public string Title { get; set; }
        public string Edition { get; set; }
        public Stream Content { get; set; }
    }
}
