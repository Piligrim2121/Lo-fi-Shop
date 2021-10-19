namespace Lo_Fi_Shop.Class
{
    public class Item
    {

        ushort ID;
        string Name;
        string Description;
        int Sell;
        bool InInvenrory;


        private Item(ushort ID, string Name, int Sell, string Description = "", bool InInvenrory = false)
        {
            this.ID = ID;
            this.Name = Name;
            this.Sell = Sell;
            this.Description = Description;
            this.InInvenrory = InInvenrory;
        }
        /// <summary>
        /// Создание массива всех существующих объектов
        /// </summary>
        /// <returns>Массив всех существующих предметов </returns>
        public static Item[] CreateItems()
        {
            Item VideoCard = new Item(0, "Видеокарта", 30000);
            Item CPU = new Item(1, "ЦП", 10000);
            Item Kuller = new Item(2, "Охладитель", 800);
            Item OZU = new Item(3, "Оперативная память", 1500);
            Item MotherBoard = new Item(4, "Материнская плата",9000);
            Item Corpus = new Item(5, "Корпус", 500);
            Item BP = new Item(6, "Блок питания",5500);
            Item HDD = new Item(7, "Жесткий диск", 4500);

            Item[] items = { VideoCard, CPU, Kuller, OZU, MotherBoard, Corpus, BP, HDD };
            return items;

        }
    }
}
