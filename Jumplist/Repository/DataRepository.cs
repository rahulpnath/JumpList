using Jumplist.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jumplist.Repository
{
    public class DataRepository
    {
        public static List<Person> Persons { get; internal set; }

        static DataRepository()
        {
            Persons = new List<Person>();
        }
    }
}
