using System.ComponentModel.DataAnnotations.Schema;

namespace SuperHeroAPI
{
    public class SuperHero
    {
        [Column(TypeName = "uuid")]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Place { get; set; } = string.Empty;
    }
}
