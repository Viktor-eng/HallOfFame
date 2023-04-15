namespace HallOfFame.Models
{
    public class Skill
    {
        private byte _level;

        public int Id { get; set; }

        public string Name { get; set; }

        public byte Level
        {
            get
            {
                if (_level < 1 || _level > 10)
                {
                    throw new Exception("range must be from 1 to 10");
                }

                return _level;
            }
            set
            {
                _level = value;
            }
        }
    }
}
