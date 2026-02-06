namespace SoftwarePatterns.Creational.Builder.CustomerProfile
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var simpleCustomer = new SimpleCustomer(
                "Carlos",
                "Rua A, 123",
                "50000-000",
                "Recife",
                "Brasil",
                "81999999999"
            );

            var socialCustomer = new SocialCustomer(
                "https://site.com",
                "https://linkedin.com/in/carlos",
                "https://facebook.com/carlos",
                "https://twitter.com/carlos",
                "carlos@email.com",
                new DateOnly(1990, 1, 1)
            );

            var profile = new CustomerProfileBuilder.Builder()
                .SimpleCustomer(simpleCustomer)
                .SocialCustomer(socialCustomer)
                .Build();

            var simple = profile.GetSimpleCustomer();
            var social = profile.GetSocialCustomer();

            Console.WriteLine(simple);
            Console.WriteLine(social);
        }
    }
}