namespace HallOfFame.Models
{
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; } = "Viktor";

        public string DisplayName { get; set; } = "ViktorWhite";

        public List<Skill> Skills { get; set; }
    }
}
