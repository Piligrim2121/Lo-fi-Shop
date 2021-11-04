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
        public Item(/*ushort ID,*/ string Name, int Sell, string Path, string Description = "", bool InInventory = false)
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
            Item HDD = new Item(/*7,*/ "Начальный Жёсткий диск", 2000, "Resources/drawable/Easy_mem.png", "Устройство начального уровня, используемое для хранения цифрового содержимого и других данных на компьютерах.");
            //Medium
            Item MediumVideoCard = new Item(/*0,*/ "Средняя Видеокарта", 40000, "Resources/drawable/Medium_Vid.png", "Устройство среднего уровня, преобразующее графический образ, хранящийся как содержимое памяти компьютера, в форму, пригодную для дальнейшего вывода на экран монитора.");
            Item MediumCPU = new Item(/*1,*/ "Средний Процессор", 14000, "Resources/drawable/Medium_Proc.png", "Центральная часть компьютера среднего уровня, выполняющая заданные программой преобразования информации и осуществляющая управление всем вычислительным процессом.");
            Item MediumKuller = new Item(/*2,*/ "Средняя Система охлаждения", 1000, "Resources/drawable/Medium_Cooler.png", "Сборка вентилятора с радиатором среднего уровня, устанавливаемая для воздушного охлаждения электронных компонентов компьютера с повышенным тепловыделением (обычно более 5 Вт)");
            Item MediumOZU = new Item(/*3,*/ "Средняя Оперативная память", 3000, "Resources/drawable/Medium_ram.png", "Энергозависимая часть системы компьютерной памяти среднего уровня, в которой во время работы компьютера хранится выполняемый машинный код.");
            Item MediumMotherBoard = new Item(/*4,*/ "Средняя Материнская плата", 8000, "Resources/drawable/Medium_Mother.png", "Печатная плата среднего уровня, являющаяся основой построения модульного устройства.");
            Item MediumCorpus = new Item(/*5,*/ "Средний Корпус", 5000, "Resources/drawable/Medium_corpus.png", "Базовая несущая конструкция среднего уровня, которая предназначена для последующего наполнения аппаратным обеспечением с целью создания компьютера.");
            Item MediumBP = new Item(/*6,*/ "Средний Блок Питания", 1500, "Resources/drawable/Medium_Power.png", "Устройство среднего уровня, предназначенное для преобразования напряжения переменного тока от сети в напряжение постоянного тока с целью питания компьютера или компьютер-сервера.");
            Item MediumHDD = new Item(/*7,*/ "Средний Жёсткий диск", 3500, "Resources/drawable/Medium_mem.png", "Устройство среднего уровня, используемое для хранения цифрового содержимого и других данных на компьютерах.");
            //Hard
            Item HardVideoCard = new Item(/*0,*/ "Дорогая Видеокарта", 100000, "Resources/drawable/Hard_Vid.png", "Устройство высшего уровня, преобразующее графический образ, хранящийся как содержимое памяти компьютера, в форму, пригодную для дальнейшего вывода на экран монитора.");
            Item HardCPU = new Item(/*1,*/ "Дорогой Процессор", 25000, "Resources/drawable/Hard_Proc.png", "Центральная часть компьютера высшего уровня, выполняющая заданные программой преобразования информации и осуществляющая управление всем вычислительным процессом.");
            Item HardKuller = new Item(/*2,*/ "Дорогая Система охлаждения", 2000, "Resources/drawable/Hard_Cooler.png", "Сборка вентилятора с радиатором высшего уровня, устанавливаемая для воздушного охлаждения электронных компонентов компьютера с повышенным тепловыделением (обычно более 5 Вт)");
            Item HardOZU = new Item(/*3,*/ "Дорогая Оперативная память", 6500, "Resources/drawable/Hard_ram.png", "Энергозависимая часть системы компьютерной памяти высшего уровня, в которой во время работы компьютера хранится выполняемый машинный код.");
            Item HardMotherBoard = new Item(/*4,*/ "Дорогая Материнская плата", 15000, "Resources/drawable/Hard_Mother.png", "Печатная плата высшего уровня, являющаяся основой построения модульного устройства.");
            Item HardCorpus = new Item(/*5,*/ "Дорогой Корпус", 10000, "Resources/drawable/Hard_corpus.png", "Базовая несущая конструкция высшего уровня, которая предназначена для последующего наполнения аппаратным обеспечением с целью создания компьютера.");
            Item HardBP = new Item(/*6,*/ "Дорогой Блок Питания", 2500, "Resources/drawable/Hard_Power.png", "Устройство высшего уровня, предназначенное для преобразования напряжения переменного тока от сети в напряжение постоянного тока с целью питания компьютера или компьютер-сервера.");
            Item HardHDD = new Item(/*7,*/ "Дорогой Жёсткий диск", 6000, "Resources/drawable/Hard_mem.png", "Устройство высшего уровня, используемое для хранения цифрового содержимого и других данных на компьютерах.");
            Item[] items = { VideoCard, CPU, Kuller, OZU, MotherBoard, Corpus, BP, HDD, MediumVideoCard, MediumCPU, MediumKuller, MediumOZU, MediumMotherBoard, MediumCorpus, MediumBP, MediumHDD, HardVideoCard, HardCPU, HardKuller, HardOZU, HardMotherBoard, HardCorpus, HardBP, HardHDD };
            return items;

        }
        public static Item[] CreatePC()
        {
            Item EasyPC = new Item("Бюджетный ПК", 0, "Resources/drawable/Easy_DonePC.png", "");
            Item[] pcs = { EasyPC };
            return pcs;

        }
    }
}
