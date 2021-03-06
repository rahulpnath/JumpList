﻿using Jumplist.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Jumplist.Repository
{
    public class DataRepository
    {
        private static ObservableCollection<Person> Persons { get; set; }

        public static IEnumerable<Group<Person>> GroupedPersons
        {
            get
            {
                List<Group<Person>> groupedArticles = new List<Group<Person>>();
                char[] az = Enumerable.Range('a', 26).Select(a => (char)a).ToArray();

                foreach (char letter in az)
                {
                    Group<Person> groupedLetter = new Group<Person>()
                    {
                        Title = letter.ToString(),
                        Items = Persons.Where(a => a.Name.StartsWith(letter.ToString(), StringComparison.CurrentCultureIgnoreCase)).Where(a => a != null).ToList()
                    };
                    groupedLetter.HasData = groupedLetter.Items.Any();
                    groupedArticles.Add(groupedLetter);
                }

                // Articles that start with a number should be added to # tag
                var list = groupedArticles.SelectMany(a => a.Items).ToList();
                var nonAlphabetIssues = Persons.Except(list);
                groupedArticles.Insert(
                    0,
                    new Group<Person>()
                    {
                        Items = nonAlphabetIssues.ToList(),
                        Title = "#",
                        HasData = nonAlphabetIssues.Any()
                    });

                return groupedArticles;
            }
        }

        static DataRepository()
        {
            Persons = new ObservableCollection<Person>()
            {
                new Person() { Name = "Bill Gates"},
                new Person() { Name = "Steve Jobs"},
                new Person() { Name = "Larry Page"},
                new Person() { Name = "Sergey Brin"},
                new Person() { Name = "Tim Berners-Lee"},
                new Person() { Name = "James Gosling"},
                new Person() { Name = "Linus Torvalds"},
                new Person() { Name = "Richard Stallman"},
                new Person() { Name = "Arthur C Clark"},   
                new Person() { Name = "Ted Codd"},
                new Person() { Name = "Steve Shirley"},
                new Person() { Name = "Martha Lane Fox"},
                new Person() { Name = "Mark  Elliot Zuckerberg"},
                new Person() { Name = "Azim Premji"}

            };
            
        }

        public static bool AddNewPerson(string Name)
        {   // Check if same name already exists 
            bool result = false;
            var person = Persons.FirstOrDefault(p => p.Name == Name);
            if (person == null)
            {
                Persons.Add(new Model.Person() { Name = Name });
                result = true;
            }

            return result;
        }

    }
}
