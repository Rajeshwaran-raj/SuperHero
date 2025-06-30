namespace SuperHeroAPI
{
    public class SuperHero
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public string Origin { get; set; } = String.Empty;
    }
}
