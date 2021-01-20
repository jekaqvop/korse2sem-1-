using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bstu_student
{
    enum Spect
    {
        poit, 
        isit,
        web,
        mobile,
    }
    class BSTUSudent
    {
        public string name;
        public int group;
        public int course;
        public int[] marks = new int[4];
        public Spect spect;
        public BSTUSudent(string name, int group, int course,  Spect spect, params int[] marks)
        {
            this.name = name;
            this.group = group;
            this.course = course;
            this.spect = spect;
            this.marks[0] = marks[0];
            this.marks[1] = marks[1];
            this.marks[2] = marks[2];
            this.marks[3] = marks[3];
        }
        public (int min, int max, int avr) Getmarks()
        {

            var result = (min: 0, max: 0, avr: 0);           
            result.max = marks.Max();
            result.min = marks.Min();
            result.avr = (int)marks.Average();
            return result;
        }
    }
    class Group
    {
        public ArrayList groups = new ArrayList();
    }
    class Program
    {
        static void Main(string[] args)
        {
            BSTUSudent st1 = new BSTUSudent("NONAME1", 1, 2, Spect.isit, 5, 6, 7, 9);
            BSTUSudent st2 = new BSTUSudent("NONAME2", 1, 2, Spect.isit, 3, 6, 7, 8);
            BSTUSudent st3 = new BSTUSudent("NONAME3", 1, 2, Spect.isit, 2, 6, 7, 8);
            BSTUSudent st4 = new BSTUSudent("NONAME4", 1, 2, Spect.isit, 5, 6, 4, 8);

            Group group1 = new Group();
            group1.groups.Add(st1);
            group1.groups.Add(st2);
            group1.groups.Add(st3);
            group1.groups.Add(st4);
            var sortformarks = from BSTUSudent s in group1.groups
                               orderby s.marks.Average()
                               select s;
            
        }
    }
}
