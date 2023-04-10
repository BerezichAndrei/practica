using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;

namespace ConsoleApp1
{
    class Item //класс товар
    {
        public string name;
        public int id;
        public string unit_of_measurement;
        public int year;
        public double cost;

        public Item(string a, int b, string c, int d, double e)
        {
            this.name = a;
            this.id = b;
            this.unit_of_measurement = c;
            this.year = d;
            this.cost = e;
        }

        public void show_info()
        {
            Console.WriteLine("Наименование: {0}; Код: {1}; Ед. измерения: {2}; Год выпуска: {3}; Цена: {4}", this.name, this.id, this.unit_of_measurement, this.year, this.cost);
        }

        public string return_name()
        {
            return this.name;
        }
    }

    class Company //класс предприятие
    {
        public string name;
        public string phone;
        public string address;
        public string status;

        public Company(string a, string b, string c, string d)
        {
            this.name = a;
            this.phone = b;
            this.address = c;
            this.status = d;
        }

        public void show_info()
        {
            Console.WriteLine("Наименование: {0}; Телефон: {1}; Адрес: {2}; Статус: {3}", this.name, this.phone, this.address, this.status);
        }

        public string return_name()
        {
            return this.name;
        }
    }

    class Deal //клас сделка
    {
        public Item item;
        public Company company;
        public string date;
        public int count;
        public int id;

        public Deal(Item a, Company b, string c, int d, int e)
        {
            this.item = a;
            this.company = b;
            this.date = c;
            this.count = d;
            this.id = e;
        }

        public void show_info()
        {
            Console.WriteLine("Товар: {0}; Предприятие: {1}; Дата: {2}; Количество: {3}; Номер документа: {4}", item.return_name(), company.return_name(), date, count, id);
        }
    }
    class Program
    {
        static void item_menu(ref ArrayList list) //метод для меню товаров
        {
            int mode;
            while (true)
            {
                Console.Clear();
                mode = 0;
                Console.WriteLine("Товары:\n[1] Список товаров\n[2] Добавить товар\n[3] Удалить товар\n[4] Выход");

                try
                {
                    mode = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Введено неверное значение!");
                    Console.Write("Нажмите Enter");
                    Console.ReadLine();
                }

                switch (mode)
                {
                    case 1:
                        foreach (Item i in list) { i.show_info(); }
                        Console.Write("Нажмите Enter");
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Введите Наименование товара, код, еденицу измерения, год выпуска и цену:");
                        try
                        {
                            list.Add(new Item(Console.ReadLine(), int.Parse(Console.ReadLine()), Console.ReadLine(), int.Parse(Console.ReadLine()), double.Parse(Console.ReadLine())));
                        }
                        catch
                        {
                            Console.WriteLine("Введено неверное значение!");
                            Console.Write("Нажмите Enter");
                            Console.ReadLine();
                        } 
                        break;
                    case 3:
                        Console.WriteLine("Введите код товара:");
                        try
                        {
                            mode = int.Parse(Console.ReadLine());
                            for(var i = 0; i < list.Count;i++)
                            {
                                Item buf = (Item)list[i];
                                if (buf.id == mode)
                                {
                                    list.RemoveAt(i);
                                }
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Введено неверное значение!");
                            Console.Write("Нажмите Enter");
                            Console.ReadLine();
                        }
                        break;
                    default:
                        if (mode != 4)
                        {
                            Console.WriteLine("Введено невеное значение!");
                            Console.Write("Нажмите Enter");
                            Console.ReadLine();
                        }
                        break;
                }

                if (mode == 4) { break; }
            }
        }
        static void company_menu(ref ArrayList list) //метод для меню предприятия
        {
            int mode;
            while (true)
            {
                Console.Clear();
                mode = 0;
                Console.WriteLine("Предприятия:\n[1] Список предприятий\n[2] Добавить предприятие\n[3] Удалить предприятие\n[4] Выход");
                try
                {
                    mode = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Введено неверное значение!");
                    Console.Write("Нажмите Enter");
                    Console.ReadLine();
                }

                switch (mode)
                {
                    case 1:
                        foreach (Company i in list) { i.show_info(); }
                        Console.Write("Нажмите Enter");
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Введите наименование, телефон, адрес и статус предприятия:");
                        try
                        {
                            list.Add(new Company(Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine()));
                        }
                        catch
                        {
                            Console.WriteLine("Введено неверное значение!");
                            Console.Write("Нажмите Enter");
                            Console.ReadLine();
                        }
                        break;
                    case 3:
                        Console.WriteLine("Введите наименование предприятия:");
                        try
                        {
                            string name = Console.ReadLine();
                            for (var i = 0; i < list.Count; i++)
                            {
                                Company buf = (Company)list[i];
                                if (buf.name == name)
                                {
                                    list.RemoveAt(i);
                                }
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Введено неверное значение!");
                            Console.Write("Нажмите Enter");
                            Console.ReadLine();
                        }
                        break;
                    default:
                        if (mode != 4)
                        {
                            Console.WriteLine("Введено невеное значение!");
                            Console.Write("Нажмите Enter");
                            Console.ReadLine();
                        }
                        break;
                }

                if (mode == 4) { break; }
            }
        }

        static void deal_menu(ref ArrayList main_list, ArrayList items, ArrayList companies) //метод для меню прихода/расхода
        {
            int mode;
            while (true)
            {
                Console.Clear();
                mode = 0;
                Console.WriteLine("Расход/Приход:\n[1] Вывести Расход/Приход\n[2] Создать Расход/Приход\n[3] Удалить Расход/Приход\n[4] Выход");
                try
                {
                    mode = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Введено неверное значение!");
                }

                switch (mode)
                {
                    case 1:
                        foreach (Deal i in main_list) { i.show_info(); }
                        Console.Write("Нажмите Enter");
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Товары:");
                        foreach (Item i in items) { i.show_info(); }
                        Console.WriteLine("\nПредприятия:");
                        foreach (Company i in companies) { i.show_info(); }
                        Console.WriteLine("\nВведите товар, предприятие, дату, количество товаров и номер документа:");
                        try
                        {
                            int a = int.Parse(Console.ReadLine());
                            int b = int.Parse(Console.ReadLine());
                            string c = Console.ReadLine();
                            int d = int.Parse(Console.ReadLine());
                            int e = int.Parse(Console.ReadLine());
                            main_list.Add(new Deal((Item)items[a - 1], (Company)companies[b - 1], c, d, e));
                        }
                        catch
                        {
                            Console.WriteLine("Введено неверное значение!");
                            Console.Write("Нажмите Enter");
                            Console.ReadLine();
                        }
                        break;
                    case 3:
                        Console.WriteLine("Введите номер документа:");
                        try
                        {
                            mode = int.Parse(Console.ReadLine());

                            for (var i = 0; i < main_list.Count; i++)
                            {
                                Deal buf = (Deal)main_list[i];
                                if (buf.id == mode)
                                {
                                    main_list.RemoveAt(i);
                                }
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Введено неверное значение!");
                            Console.Write("Нажмите Enter");
                            Console.ReadLine();
                        }
                        break;
                    default:
                        if (mode != 4)
                        {
                            Console.WriteLine("Введено невеное значение!");
                            Console.Write("Нажмите Enter");
                            Console.ReadLine();
                        }
                        break;
                }

                if (mode == 4) { break; }
            }
        }
        static void Main(string[] args)
        {
            ArrayList items = new ArrayList(); //список товаров
            items.Add(new Item("Монитор", 1, "Штуки", 2019, 159.99));
            items.Add(new Item("Клавиатура", 2, "Штуки", 2018, 69.99));
            items.Add(new Item("Компьютерная мышь", 3, "Штуки", 2019, 59.99));

            ArrayList companies = new ArrayList(); //список предприятий
            companies.Add(new Company("Азот", "+375447678956", "г.Гродно", "Хим. промышленность"));
            companies.Add(new Company("Этикет серис", "+375447634556", "г.Гродно", "IT компания"));

            ArrayList dealList = new ArrayList(); //список расход/приход
            int mode;

            while (true) //основное меню
            {
                Console.Clear();
                mode = 0;
                Console.WriteLine("Главное меню:\n[1] Товары\n[2] Предприятия\n[3] Расход/Приход\n[4] Выход");
                try
                {
                    mode = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Введено неверное значение!");
                    Console.Write("Нажмите Enter");
                    Console.ReadLine();
                }

                switch (mode)
                {
                    case 1:
                        item_menu(ref items);
                        break;
                    case 2:
                        company_menu(ref companies);
                        break;
                    case 3:
                        deal_menu(ref dealList, items, companies);
                        break;
                    case 4:
                    default:
                        if (mode != 4)
                        {
                            Console.WriteLine("Введено невеное значение!");
                            Console.Write("Нажмите Enter");
                            Console.ReadLine();
                        }
                        break;
                }

                if (mode == 4) { break; }
            }
        }
    }
}
