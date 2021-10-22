namespace Lo_Fi_Shop.Class
{
    public class Item
    {

        //ushort ID;
        public string Name;
        public string Description;
        public int Sell;
        public string Path;
        public bool InInvenrory;
        public static Item[] items;
        /// <summary>
        /// Конструктор класса Item
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Sell"></param>
        /// <param name="Description"></param>
        /// <param name="InInvenrory"></param>
        public Item(/*ushort ID,*/ string Name, int Sell, string Path, string Description = "", bool InInvenrory = false)
        {
            //this.ID = ID;
            this.Name = Name;
            this.Sell = Sell;
            this.Description = Description;
            this.InInvenrory = InInvenrory;
            this.Path = Path;
        }
        /// <summary>
        /// Создание массива всех существующих предметов
        /// </summary>
        /// <returns>Массив всех существующих предметов </returns>
        public static Item[] CreateItems()
        {
            Item VideoCard = new Item(/*0,*/ "Начальная Видеокарта", 10000, "Resources/drawable/Easy_Vid.png");
            Item CPU = new Item(/*1,*/ "Начальный Процессор", 6000, "Resources/drawable/Easy_Proc.png");
            Item Kuller = new Item(/*2,*/ "Начальная Система охлаждения", 300, "Resources/drawable/Easy_Cooler.png");
            Item OZU = new Item(/*3,*/ "Начальная Оперативная память", 1500, "Resources/drawable/Easy_ram.png");
            Item MotherBoard = new Item(/*4,*/ "Начальная Материнская плата", 3000, "Resources/drawable/Easy_Mother.png");
            Item Corpus = new Item(/*5,*/ "Начальный Корпус", 1100, "Resources/drawable/Easy_corpus.png");
            Item BP = new Item(/*6,*/ "Начальный Блок Питания", 900, "Resources/drawable/Easy_Power.png");
            Item HDD = new Item(/*7,*/ "Начальный Жёсткий диск", 2500, "Resources/drawable/Easy_mem.png");

            Item[] items = { VideoCard, CPU, Kuller, OZU, MotherBoard, Corpus, BP, HDD };
            return items;

        }
    }
}
