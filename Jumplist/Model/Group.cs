using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jumplist.Model
{
    /// <summary>
    /// Group data.
    /// </summary>
    /// <typeparam name="T">Data type.</typeparam>
    public class Group<T> : IEnumerable<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Group{T}"/> class.
        /// </summary>
        /// <param name="name">Title name.</param>
        /// <param name="items">Items to group.</param>
        public Group(string name, IEnumerable<T> items)
        {
            this.Title = name;
            this.Items = new List<T>(items);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Group{T}"/> class.
        /// </summary>
        public Group()
        {
            // Default constructor
        }

        /// <summary>
        /// Gets or sets title name.
        /// </summary>
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the list contains data.
        /// </summary>
        public bool HasData { get; set; }

        /// <summary>
        /// Gets or sets grouped items.
        /// </summary>
        public IList<T> Items
        {
            get;
            set;
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
        /// </returns>
        /// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>. </param>
        public override bool Equals(object obj)
        {
            Group<T> that = obj as Group<T>;
            return that != null && this.Title.Equals(that.Title);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. 
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return this.Title.GetHashCode();
        }

        #region IEnumerable<T> Members

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<T> GetEnumerator()
        {
            return this.Items.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.Items.GetEnumerator();
        }

        #endregion
    }
}
