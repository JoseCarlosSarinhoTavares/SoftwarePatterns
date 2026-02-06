namespace SoftwarePatterns.Creational.Builder.CustomerProfile
{
    public class SocialCustomer
    {
        public string Homepage { get; private set; }
        public string Linkedin { get; private set; }
        public string Facebook { get; private set; }
        public string Twitter { get; private set; }
        public string Mail { get; private set; }
        public DateOnly DateBirth { get; private set; }

        public SocialCustomer(
            string homepage,
            string linkedin,
            string facebook,
            string twitter,
            string mail,
            DateOnly dateBirth)
        {
            Homepage = homepage;
            Linkedin = linkedin;
            Facebook = facebook;
            Twitter = twitter;
            Mail = mail;
            DateBirth = dateBirth;
        }

        public override string ToString()
        {
            return
                $"""
                ==============================
                       CLIENTE SOCIAL
                ==============================
                Homepage : {Homepage}
                LinkedIn : {Linkedin}
                Facebook : {Facebook}
                Twitter  : {Twitter}
                E-mail   : {Mail}
                Nascimento: {DateBirth:dd/MM/yyyy}
                """;
        }
    }
}