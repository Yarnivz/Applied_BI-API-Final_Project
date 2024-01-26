namespace Red_Cross_Bloedvoorraden.Models
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }

        public Bloedzakje Bloedzakje { get; set; }
        public List<Bloedzakje> bloodbagList { get; set; }
    }
}
