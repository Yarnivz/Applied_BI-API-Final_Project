namespace Red_Cross_Bloedvoorraden.Models
{
    public class Bloedzakje
    {
        public string Bloedzakje_ID { get; set; }

        public string Bloedgroep { get; set; }
        public double Volume { get; set; }
        public DateTime Verzamelingsdatum { get; set; }
        public DateTime Vervaldatum { get; set; }
    }
}
