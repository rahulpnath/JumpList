using Jumplist.Model;
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
            Persons = new ObservableCollection<Person>();
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
