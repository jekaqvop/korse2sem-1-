using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace подготовка_к_ООП_экзамен
{
    interface IAction<T>
    {
        void Del(T obj);
        void Add(T obj);
        void Clear();
        void Show();
    }
    class ExamCard<T> : IAction<T>
    {
        public List<T> list = new List<T>();

        public void Del(T obj)
        {
            try
            {
                if (list.Count == 0)
                    throw new NullSizeCollection("НЕТ ЭЛЕМЕНТОВ");
                else
                    list.Remove(obj);
            }
            catch(NullSizeCollection ex)
            {
                Console.WriteLine(ex.Messege);
            }
           
        }
        public void Add(T obj)
        {
            list.Add(obj);
        }
        public void Clear()
        {
            try
            {
                if (list.Count == 0)
                    throw new NullSizeCollection("НЕТ ЭЛЕМЕНТОВ");
                else
                    list.Clear();
            }
            catch (NullSizeCollection ex)
            {
                Console.WriteLine(ex.Messege);
            }
        }
        public void Show()
        {
            string str = "";
            foreach(T obj in list)
            {
                str += obj;
            }
            Console.WriteLine(str);
        }

       
    }
    class NullSizeCollection : System.Exception
    {
        string messege;
        public string Messege 
        {
            get
            {
                return messege;
            }
            set
            {
                messege = value;
            }
        }
        public NullSizeCollection(string messege)
        {
            Messege = messege;
        }
    }
    class Student
    {
        public string name;
        public int mark;
        string Subject;
        public Student(string name, int mark, string subject)
        {
            this.name = name;
            this.mark = mark;
            this.Subject = subject;
        }
    }
    static class StudentExtension
    {
        public static int UpMark(this int i)
        {
            Random rn = new Random(DateTime.Now.Second);
            i += rn.Next() % 4;
            return i;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student st1 = new Student("st1", 3, "math");
            Student st2 = new Student("st1", 4, "math");
            Student st3 = new Student("st1", 5, "math");
            Student st4 = new Student("st1", 6, "math");
            Student st5 = new Student("st1", 7, "math");

            ExamCard<Student> card1 = new ExamCard<Student>();
            card1.Add(st1);
            card1.Add(st2);
            card1.Add(st3);
            card1.Add(st4);
            card1.Add(st5);
            card1.Show();

            var card2 = from stud in card1.list
                        where stud.mark >= 4
                        select stud;
            int sredMark = 0;
            foreach(Student stud in card1.list)
            {
                sredMark += stud.mark;
            }
            sredMark = sredMark / card1.list.Count;
            st1.mark = st1.mark.UpMark();
        }
    }
}
