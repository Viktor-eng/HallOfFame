using HallOfFame.Models;

namespace HallOfFame.Dtos.Person
{
    public class GetPersonDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = "Viktor";

        public string DisplayName { get; set; } = "ViktorWhite";

        public List<Skill> Skills { get; set; }
    }
}
