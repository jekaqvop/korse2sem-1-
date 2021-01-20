using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_3
{
    enum Chek
    {
        cheked, 
        uncheked,
    }
    class Button
    {
        public string caption;
        public int[] startpoint = { 0, 0 };
        public int heigth;
        public int width;
    }
    class CheckButton : Button
    {
        public CheckButton(string caption, int height, int width, params int[] startpoint)
        {
            this.caption = caption;
            this.heigth = height;
            this.width = width;
            this.startpoint[0] = startpoint[0];
            this.startpoint[1] = startpoint[1];
        }
        public Chek state = Chek.uncheked;
        public override string ToString()
        {
            return caption.ToString();
        }
        public override bool Equals(object obj1)
        {
            CheckButton obj = (CheckButton)obj1;
            if (this.caption == obj.caption && this.heigth == obj.heigth && this.width == obj.width)
                return true;
            else
                return false;
        }
        public void Check()
        {
            if (state == Chek.cheked)
            {
                state = Chek.uncheked;
                
            }               
            else
            {
                state = Chek.cheked;
               
            }                
        }
        public void Zoom(int a)
        {
            this.heigth = heigth / 100 * (100 - a);
            this.width = width / 100 * (100 - a);
        }
        
    }
    class User
    {
        public delegate void One();
        public event One Click;
        public void ClickBt() => Click?.Invoke();
        public delegate void Two(int a);
        public event Two Resize;
        public void Resize1(int a) => Resize?.Invoke(a);
    }
    class Program
    {
        static void Main(string[] args)
        {
            CheckButton button1 = new CheckButton("Button1", 100, 100, 100, 100);
            CheckButton button2 = new CheckButton("Button2", 200, 100, 200, 100);
            CheckButton button3 = new CheckButton("Button3", 300, 100, 300, 100);
            CheckButton button4 = new CheckButton("Button4", 100, 100, 100, 100);
            Button button5 = new Button();
            User user = new User();
            user.Click += button1.Check;
            user.Click += button2.Check;
            user.Resize += button3.Zoom;
            user.Resize += button4.Zoom;

            user.ClickBt();
            user.Resize1(15);

            Console.WriteLine("button1: {0}", button1.state);
            Console.WriteLine("button2: {0}", button2.state);
            Console.WriteLine("button3: {0}", button3.state);
            Console.WriteLine("button4: {0}", button4.state);

            Console.WriteLine("button1: {0} {1}", button1.width, button1.heigth);
            Console.WriteLine("button2: {0} {1}", button2.width, button2.heigth);
            Console.WriteLine("button3: {0} {1}", button3.width, button3.heigth);
            Console.WriteLine("button4: {0} {1}", button4.width, button4.heigth);

            LinkedList<CheckButton> but = new LinkedList<CheckButton>();
            but.AddLast(button1);
            but.AddLast(button2);
            but.AddLast(button3);
            but.AddLast(button4);
            //but.AddLast(button5)
            var sqr = from i in but
                      where i.width * i.heigth == 10000
                      select i;
            var l = from i in but
                    where i.GetType() == Type.GetType("CheckButton")
                    select i;
            Console.ReadKey();
        }
    }
}
