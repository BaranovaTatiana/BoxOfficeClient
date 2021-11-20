namespace BoxOffice
{
    public class RowFood
    {
        public int Id;
        public string Name;
        public double Price;
        public int ColorId;
        public int TypeId;

        public RowFood(int id, string name, int typeId, int colorId, double price)
        {
            Id = id;
            Name = name;
            Price = price;
            ColorId = colorId;
            TypeId = typeId;
        }
    }
}