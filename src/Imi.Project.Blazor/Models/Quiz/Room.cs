namespace Imi.Project.Blazor.Models.Quiz
{
    public class Room
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int playerAmount { get; set; }

        public int maxPlayerAmount { get; set; }


        public Room(string name, int maxPlayerAmount)
        {
            this.Name = name;
            this.maxPlayerAmount = maxPlayerAmount;
        }
    }
}
