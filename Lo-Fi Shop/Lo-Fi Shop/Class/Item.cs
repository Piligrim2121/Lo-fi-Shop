using System.Collections.Generic;

namespace Lo_Fi_Shop.Class
{
    public class Item
    {

        //ushort ID;
        public string Name;
        public string Description;
        public int Sell;
        public string Path;
        public bool InInventory;
        public static Item[] InInvItems = CreateItems();
       static public List<Item> PC = new List<Item>();
       
        /// <summary>
        /// Конструктор класса Item
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Sell"></param>
        /// <param name="Description"></param>
        /// <param name="InInventory"></param>
        public Item(/*ushort ID,*/ string Name, int Sell, string Path, string Description="", bool InInventory = false)
        {
            //this.ID = ID;
            this.Name = Name;
            this.Sell = Sell;
            this.Description = Description;
            this.InInventory = InInventory;
            this.Path = Path;
        }
        /// <summary>
        /// Создание массива всех существующих предметов
        /// </summary>
        /// <returns>Массив всех существующих предметов </returns>
        public static Item[] CreateItems()
        {
            Item VideoCard = new Item(/*0,*/ "Начальная Видеокарта", 10000, "Resources/drawable/Easy_Vid.png", "Устройство начального уровня, преобразующее графический образ, хранящийся как содержимое памяти компьютера, в форму, пригодную для дальнейшего вывода на экран монитора.");
            Item CPU = new Item(/*1,*/ "Начальный Процессор", 6000, "Resources/drawable/Easy_Proc.png", "Центральная часть компьютера начального уровня, выполняющая заданные программой преобразования информации и осуществляющая управление всем вычислительным процессом.");
            Item Kuller = new Item(/*2,*/ "Начальная Система охлаждения", 300, "Resources/drawable/Easy_Cooler.png", "Сборка вентилятора с радиатором начального уровня, устанавливаемая для воздушного охлаждения электронных компонентов компьютера с повышенным тепловыделением (обычно более 5 Вт)");
            Item OZU = new Item(/*3,*/ "Начальная Оперативная память", 1500, "Resources/drawable/Easy_ram.png", "Энергозависимая часть системы компьютерной памяти начального уровня, в которой во время работы компьютера хранится выполняемый машинный код.");
            Item MotherBoard = new Item(/*4,*/ "Начальная Материнская плата", 3000, "Resources/drawable/Easy_Mother.png", "Печатная плата начального уровня, являющаяся основой построения модульного устройства.");
            Item Corpus = new Item(/*5,*/ "Начальный Корпус", 1100, "Resources/drawable/Easy_corpus.png", "Базовая несущая конструкция начального уровня, которая предназначена для последующего наполнения аппаратным обеспечением с целью создания компьютера.");
            Item BP = new Item(/*6,*/ "Начальный Блок Питания", 900, "Resources/drawable/Easy_Power.png", "Устройство начального уровня, предназначенное для преобразования напряжения переменного тока от сети в напряжение постоянного тока с целью питания компьютера или компьютер-сервера.");
            Item HDD = new Item(/*7,*/ "Начальный Жёсткий диск", 2500, "Resources/drawable/Easy_mem.png", "Устройство начального уровня, используемое для хранения цифрового содержимого и других данных на компьютерах.");
            Item[] items = { VideoCard, CPU, Kuller, OZU, MotherBoard, Corpus, BP, HDD };
            return items;

        }
        public static Item[] CreatePC()
        {
            Item EasyPC = new Item("Бюджетный ПК", 0, "Resources/drawable/Easy_DonePC.png", "");
                Item[] pcs = { EasyPC};
            return pcs;
           
        }
    }
}
