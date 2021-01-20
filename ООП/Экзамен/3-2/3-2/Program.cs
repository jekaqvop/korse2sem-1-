using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace _3_2
{
    interface PR<T>
    {
        T move(T obj);
    }
    class pr2 : IEnumerator<int>, IEnumerable
    {
        int[] arr;
        public pr2(int[] days)
        {
            this.arr = days;
        }
        public pr2 move(pr2 o)
        {
            return o;
        }
        int position = -1;
        public object Current
        {
            get
            {
                if (position == -1 || position >= arr.Length)
                    throw new InvalidOperationException();
                return arr[position];
            }
        }

        int IEnumerator<int>.Current => throw new NotImplementedException();


        public bool MoveNext()
        {
            if (position < arr.Length)
            {
                position++;
                return true;
            }

            else
                return false;
        }
        public void Reset()
        {
            position = -1;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            return arr.GetEnumerator();
        }
    }
    enum Stat
    {
        busy,
        free,
    }
    [Serializable]
    class Location
    {
        public float Lat;
        public float Long;
        public float Speed;

    }
    [Serializable]
    class Taxi
    {
        public Location Position = new Location();
        public string Number;
        public Stat Status;
    }
    [Serializable]
    class Park<T>
    {
        public List<T> park = new List<T>();
        public void Add(params T[] objs)
        {
            foreach (T obj in objs)
            {
                park.Add(obj);
            }
        }
        public void RemoveEl(T obj)
        {
            park.Remove(obj);
        }
        public void Clear()
        {
            park.Clear();
        }
        public T Find(Predicate<T> predicate)
        {
            foreach (T obj in park)
            {
                if (predicate(obj))
                    return obj;
            }
            return default(T);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Park<Taxi> Uber = new Park<Taxi>();
            Uber.Add(new Taxi() { Number = "1", Position = new Location() { Lat = 12.3439493f, Long = 483.129849384f, Speed = 63.2f }, Status = Stat.busy });
            Uber.Add(new Taxi() { Number = "2", Position = new Location() { Lat = 42.3439493f, Long = 452.129849384f, Speed = 0f }, Status = Stat.free });
            Uber.Add(new Taxi() { Number = "3", Position = new Location() { Lat = 22.3439493f, Long = 495.129849384f, Speed = 44.2f }, Status = Stat.free });
            Uber.Add(new Taxi() { Number = "4", Position = new Location() { Lat = 17.3439493f, Long = 457.129849384f, Speed = 68f }, Status = Stat.busy });

            Console.WriteLine("---Введите свои координаты---");
            Location UserLocation = new Location();
            Console.Write("Широта: ");
            UserLocation.Lat = float.Parse(Console.ReadLine());
            Console.Write("Долгота: ");
            UserLocation.Long = float.Parse(Console.ReadLine());

            List<Taxi> taxis = new List<Taxi>(Uber.park);
            var TaxisToUser = taxis.OrderBy(x => Math.Sqrt(Math.Pow(x.Position.Lat - UserLocation.Lat, 2) + Math.Pow(x.Position.Long - UserLocation.Long, 2)));
            foreach (var taxi in TaxisToUser)
                Console.WriteLine(taxi.Number);

            using (FileStream sw = new FileStream("Taxi.bin", FileMode.Create))
            {
                //XmlSerializer xml = new XmlSerializer(TaxisToUser.First().GetType());
                //xml.Serialize(sw, TaxisToUser.First());
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(sw, TaxisToUser.First());
            }





            //Task 2
            Program2.Task2();
            Console.ReadKey();

        }
    }
}

