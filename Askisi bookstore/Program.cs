using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Askisi_bookstore
{
    //Create application that will reflect library which has books, magazines, tracts, readers, workers.
    //Consider creating following entities: publication as abstract. 
    //Then make magazine, book inherit from publication.
    //Humans in library can be represented in the following way: author, librarian, reader.
    //All of them can be implementation of basic class person.

    public enum Personel { Author, Librarian, Reader, Cleaner}

    
    class Program
    {
        static void Main(string[] args)
        {

            List<IBorrow> books = new List<IBorrow>();
            List<IPersonel> personel = new List<IPersonel>();

            IBorrow book1 = new Book(12, "vivlio1", 352);
            IBorrow book2 = new Book(16, "vivlio2", 420);
            IBorrow mag1 = new Magazine(34,"periodiko1", 65);
            IBorrow mag2 = new Magazine(34, "periodiko1", 65);

            book1.Borrow();

            books.Add(book1);
            books.Add(book2);
            books.Add(mag1);
            books.Add(mag2);

            IPersonel i1 = new Person(120492, "Nikos Paulidis", Personel.Librarian, 8243.34);
            IPersonel i2 = new Person(120492, "Stauros Nikolaidis", Personel.Cleaner, 3500.65);
            IPersonel i3 = new Person(120492, "Kosmas Aitolos", Personel.Reader, 330.54);
            IPersonel i4 = new Person(120492, "Giannis Klarinos", Personel.Librarian, 10330.54);
            IPersonel i5 = new Person(120492, "Mitsos Floriniotis", Personel.Reader, 630.54);
            IPersonel i6 = new Person(120492, "Giorgos Magkas", Personel.Reader, 360.54);


            i1.Job();
            i2.Job();
            i3.Job();

            personel.Add(i1);
            personel.Add(i2);
            personel.Add(i3);
            personel.Add(i4);
            personel.Add(i5);
            personel.Add(i6);


            IEnumerable<IPersonel> HighBudget = personel.Where(person => person.Salary >= 5000);
            IEnumerable<IPersonel> LowBudget = personel.Where(person => person.Salary < 5000);
            Predicate<IPersonel> customer = (x) => x.Myjob == Personel.Reader;




            ShowMisthoi(HighBudget);
            ShowMisthoi(LowBudget);
            ShowPelates(personel, customer);

        }

         public static void ShowMisthoi(IEnumerable<IPersonel> wages)
        {
            Console.WriteLine("*********<Employee wages>**********");
            foreach (var item in wages)
            {
                Console.WriteLine();
                Console.WriteLine("-------------------------------");
                Action ShowYpsilomisthoi = () => item.Job();
                Action ShowYpsilomisthoi2 = () => Console.WriteLine($"Salary: {item.Salary}  euros");
                Console.WriteLine("-------------------------------");

                ShowYpsilomisthoi.Invoke();
                ShowYpsilomisthoi2.Invoke();
            }
        }

        public static void ShowPelates(List<IPersonel> proswpiko, Predicate<IPersonel> pelatis)
        {
            Console.WriteLine("**********************");
            Console.WriteLine("Customers this moment: ");
            int count = 0;
            foreach (var item in proswpiko)
            {
                if (pelatis(item)) count++;
            }
            Console.WriteLine(count);
            Console.WriteLine();
        }


    }

    interface IBorrow
    {

        void Borrow();
        
    }

    interface IPersonel
    {
        void Job();

        Personel Myjob { get; set; }

        double Salary { get; set; }


    }



    abstract class Publication : IBorrow
    {
        protected abstract int Id { get; set; }
        protected abstract string Title { get; set; }
        protected abstract int Pages { get; set; }

        protected Publication()
        {

        }

        public Publication(int id, string title, int pages)
        {
            Id = id;
            Title = title;
            Pages = pages;
        }

        public void Borrow() => Console.WriteLine("Available to Borrow!");
        
    }



    class Book : Publication
    {
        protected override int Id { get ; set; }
        protected override string Title { get; set ; }
        protected override int Pages { get ; set; }

        public Book(int id, string title, int pages)
        {
            Id = id;
            Title = title;
            Pages = pages;
        }



    }


    class Magazine : Publication
    {
        protected override int Id { get; set; }
        protected override string Title { get; set; }
        protected override int Pages { get; set; }


        public Magazine(int id, string title, int pages)
        {
            Id = id;
            Title = title;
            Pages = pages;
        }
    }




     class Person : IPersonel
     {
        protected int IdNumber { get; set; }
        protected  string Name { get; set; }
        protected  Personel Job { get; set; }
        public double Salary { get; set ; }
        public Personel Myjob { get; set; } 

        public Person(int idNumber, string name, Personel job, double salary)
        {
            IdNumber = idNumber;
            Name = name;
            Job = job;
            Salary = salary;
            Myjob = Job;
        }

        void IPersonel.Job()
        {
            Console.WriteLine($" I am a {Job} .");
        }

       
    }






}
