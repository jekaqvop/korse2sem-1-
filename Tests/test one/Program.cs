using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_one
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "jeka_master";
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("jekabog");
            test_2.Car car1 = new test_2.Car();
            
            car1.Icr_speed();



            Console.ReadLine();
            
        }
    }
}

namespace test_2
{
   public class Car
    {
        
       
        public class Carm
        {
            int speed;
            int mass;
           
        }
        public Car()
        {
            
        }
       ~Car()
        {
            Carm.speed = 0;
            mass = 0;
        }
        public int Speeding()
        {
            return this.speed;
        }
        public void Icr_speed()
        {
            this.speed++;
        }
    }
    
  
}