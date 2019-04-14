using System;
using Domain.Shpora;

namespace FSharpExamples
{
    using static Mentor;
    using static ShporunStatus;

    public class Usages
    {
        public void SomeMethod()
        {
            /*var shporuns = new[]
            {
                Shporun.NewShporun(new Person("Anton", "Ivanoff", 20)),
                Shporun.NewShporun(new Person("Boris", "Britva", 45))
            };
            var mentors = Enumerable.Range(1, 4)
                                    .Select(i => Mentor.NewMentor(new Person("Mentor has no name", $"Mentor_{i}",
                                                                             20 + i)))
                                    .ToArray();
            var courses = new[]
            {
                Course.NewIntensive(new Unit("Web", mentors.Skip(2).Take(1), DateTime.Today)),
                Course.NewUsual(new Unit("Clean Code", mentors.Take(1), DateTime.Now))
            };
            var mentor = mentors.First();
            var shpora2019 = new Shpora(2019, shporuns, mentors, courses);
            // Console.WriteLine(shpora2019);
            var shporun = shporuns[0].ToString();
            Console.WriteLine(shporun);*/

            var person = new Person("Василий", "Фамилиев", 20);
            person.SayName(); // "Василий"
            var petya = person.With("Petya");
            petya.SayName(); // "Petya"

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            var mentor = NewMentor(new Person("Василий", "Фамилиев", 20));

            var status = NewHasInterview(DateTime.Today);

            var vasya = new Person("Василий", "Фамилиев", 20);

            var shporun = new Shporun(vasya, status);

            Print(shporun);
            Console.WriteLine();
            Console.WriteLine();

            mentor.Item.SayName();
            var p = mentor.Item.With("");
            var shpora =
                new Shpora(2019,
                           new[]
                           {
                               NewMentor(new Person("Василий", "Фамилиев", 20)),
                               NewMentor(new Person("Василий", "Стажерович", 19)),
                               NewMentor(new Person("Василий", "Шпорунович", 20))
                           },
                           new[]
                           {
                               new Shporun(new Person("Егор", "Менторович", 25), NewHasMentor(mentor)),
                               new Shporun(new Person("Егор", "Менторович", 25), None),
                               new Shporun(new Person("Егор", "Менторович", 25), NewHasInterview(DateTime.Today))
                           });
            Console.WriteLine(shpora.ToString());
        }

        public void Print(Shporun shporun)
        {
            var status = shporun.Status;
            if (status.IsHasInterview)
                Console.WriteLine($"This {shporun} has interview sheduled at {((HasInterview) status).Item}");
            else if (status.IsHasMentor)
                Console.WriteLine($"{shporun} has a great team of {((HasMentor) status).Item}");
            else if (status.IsNone)
                Console.WriteLine($"This {shporun} still has no team :(");
        }
    }

    public static class PersonExtensions
    {
        public static void SayName(this Person person) => Console.WriteLine(person.Name);

        public static Person With(this Person person, string name) => new Person(name, person.Surname, person.Age);
    }
}
