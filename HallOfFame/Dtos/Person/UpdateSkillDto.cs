namespace HallOfFame.Dtos.Person
{
    public class UpdateSkillDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public byte Level { get; set; }
    }
}
