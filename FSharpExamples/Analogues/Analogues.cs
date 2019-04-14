using System;
using System.Collections.Generic;
// ReSharper disable MemberCanBePrivate.Global

namespace FSharpExamples.Analogues
{

    public class Person
    {
        public Person(string name, string surname, int age)
        {
            Name = name;
            Surname = surname;
            Age = age;
        }

        public string Name { get; }

        public string Surname { get; }

        public int Age { get; }

        public override bool Equals(object obj) =>
            obj is Person person &&
            Name == person.Name &&
            Surname == person.Surname &&
            Age == person.Age;

        /// <inheritdoc />
        public override string ToString() => $@"{nameof(Name)}: {Name},
                                                {nameof(Surname)}: {Surname},
                                                {nameof(Age)}: {Age}";

        public override int GetHashCode() => HashCode.Combine(Name, Surname, Age);
    }

    public class Shpora
    {
        public Person MainManager { get; }

        public int Year { get; }

        public Person[] Shporuns { get; }

        public Person[] Mentors { get; }

        public Shpora(int year, Person[] shporuns, Person[] mentors)
        {
            Year = year;
            Shporuns = shporuns;
            Mentors = mentors;
        }

        /// <inheritdoc />
        public override string ToString() => $@"{nameof(Year)}: {Year},
                                                {nameof(Shporuns)}: {Shporuns},
                                                {nameof(Mentors)}: {Mentors}";

        public override bool Equals(object obj) =>
            obj is Shpora shpora &&
            Year == shpora.Year &&
            EqualityComparer<Person[]>.Default.Equals(Shporuns, shpora.Shporuns) &&
            EqualityComparer<Person[]>.Default.Equals(Mentors, shpora.Mentors);

        public override int GetHashCode() => HashCode.Combine(Year, Shporuns, Mentors);
    }
}
