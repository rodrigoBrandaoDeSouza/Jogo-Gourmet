namespace JogoGourmet
{
    public class Dish
    {
        public Dish(string name, string type)
        {
            Name = name;
            Type = type;
        }

        public string Name { get; set; }

        public string Type { get; set; }
    }
}
