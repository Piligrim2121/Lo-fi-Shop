namespace Lo_Fi_Shop.Class
{
    public class Item
    {

        //ushort ID;
        public string Name;
        public string Description;
        public int Sell;
        public bool InInvenrory;

        /// <summary>
        /// Конструктор класса Item
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Sell"></param>
        /// <param name="Description"></param>
        /// <param name="InInvenrory"></param>
        public Item(/*ushort ID,*/ string Name, int Sell, string Description = "", bool InInvenrory = false)
        {
            //this.ID = ID;
            this.Name = Name;
            this.Sell = Sell;
            this.Description = Description;
            this.InInvenrory = InInvenrory;
        }
        /// <summary>
        /// Создание массива всех существующих предметов
        /// </summary>
        /// <returns>Массив всех существующих предметов </returns>
        public static Item[] CreateItems()
        {
            Item VideoCard = new Item(/*0,*/ "Начальная Видеокарта", 10000);
            Item CPU = new Item(/*1,*/ "Начальный Процессор", 6000);
            Item Kuller = new Item(/*2,*/ "Начальная Система охлаждения", 300);
            Item OZU = new Item(/*3,*/ "Начальная Оперативная память", 1500);
            Item MotherBoard = new Item(/*4,*/ "Начальная Материнская плата", 3000);
            Item Corpus = new Item(/*5,*/ "Начальный Корпус", 1100);
            Item BP = new Item(/*6,*/ "Начальный Блок питания", 900);
            Item HDD = new Item(/*7,*/ "Начальный Жесткий диск", 2500);

            Item[] items = { VideoCard, CPU, Kuller, OZU, MotherBoard, Corpus, BP, HDD };
            return items;

        }
    }
}
