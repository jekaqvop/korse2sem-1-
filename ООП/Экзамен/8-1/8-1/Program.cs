using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_1
{
    class Item
    {
        public string Name
        {
            get;
            set;
        }
        public int ID { get; set; }
        public int Price { get; set; }
        public Item(string name, int id, int price)
        {
            Name = name;
            ID = id;
            Price = price;
        }
        public void Price50()
        {
            this.Price = Price / 2;
        }
    }
    class Manager
    {            
        public delegate void ForEvent();
        public event ForEvent Sale;
        public void Sale1() => Sale?.Invoke();
    }
    class Shop : IEnumerable
    {
        public Queue<Item> items = new Queue<Item>();
        public void Add(Item obj)
        {
            items.Enqueue(obj);
        }
        public Item DelFirst()
        {
            return items.Dequeue();
        }
        public void Clear()
        {
            items.Clear();
        }
        public override string ToString()
        {
            string str = "";
            foreach(Item i in items)
            {
                str += "\nPrice: " + i.Price + "\nName: " + i.Name;
            }
            return str;
        }
        public override int GetHashCode()
        {
            return items.GetHashCode();
        }

        public IEnumerator GetEnumerator()
        {
            return items.GetEnumerator();
        }
        public static Shop operator +(Shop shops, Item i)
        {            
            shops.Add(i);
            return shops;
        }
        public static Shop operator --(Shop shops)
        {
            shops.DelFirst();
            return shops;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Item item1 = new Item("NONAME", 1, 10);
            Item item2 = new Item("NONAME1", 1, 10);
            Item item3 = new Item("NONAME", 1, 10);
            Item item4 = new Item("NONAME", 1, 10);
            Manager man = new Manager();
            man.Sale += item1.Price50;
            man.Sale += item2.Price50;
            man.Sale += item3.Price50;
            man.Sale += item4.Price50;
            
            Shop shop = new Shop();
            shop.Add(item1);
            shop.Add(item2);
            shop.Add(item3);
            shop.Add(item4);
            string str = "ТОВАРЫ: ";
            foreach(Item i in shop)
            {
                str += i.Price + "\n";
            }
            Console.WriteLine(str);
            man.Sale1();
            string str2 = "ТОВАРЫ: ";
            foreach (Item i in shop)
            {
                str2 += i.Price + "\n";
            }
            Console.WriteLine(str2);
            shop += item1;
            shop --;

            var shops = from l in shop.items
                        where l.Name == "NONAME1"
                        select l;
            int FullPrice = 0;
            foreach (Item it in shops)
                FullPrice += it.Price;
            Console.WriteLine(FullPrice);

            Console.ReadKey();
        }
    }
}
