namespace HallOfFame.Dtos.Person
{
    public class UpdatePersonDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = "Viktor";

        public string DisplayName { get; set; } = "ViktorWhite";

        public List<UpdateSkillDto> Skills { get; set; } = new List<UpdateSkillDto>();
    }
}
