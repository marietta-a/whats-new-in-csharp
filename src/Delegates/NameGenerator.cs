using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp.Delegates
{
    public class NameGenerator
    {
        /// <summary>
        /// Delegate that represents a function which composes a full name
        /// from a first name and a last name.
        /// </summary>
        /// <param name="firstName">The given first name.</param>
        /// <param name="lastName">The given last name.</param>
        /// <returns>The composed full name.</returns>
        public delegate string NameDelegate(string firstName, string lastName);

        /// <summary>
        /// Default formatter that concatenates first and last name with a space.
        /// Kept private because it's an internal implementation detail.
        /// </summary>
        private static string FullName(string firstName, string lastName)
        {
            return $"{firstName} {lastName}";
        }

        /// <summary>
        /// A handler instance initialized with the default <see cref="FullName"/> formatter.
        /// This can be reassigned to other <see cref="NameDelegate"/> implementations.
        /// </summary>
        public NameDelegate handler = FullName;

        /// <summary>
        /// Invokes the provided <see cref="NameDelegate"/> to generate a name and
        /// writes the result to the console.
        /// </summary>
        /// <param name="nameDelegate">The delegate used to compose the name.</param>
        /// <param name="firstName">The first name to use.</param>
        /// <param name="lastName">The last name to use.</param>
        public void GenerateName(NameDelegate nameDelegate, string firstName, string lastName)
        {
            // Invoke the delegate to produce the full name and print it.
            var fullName = nameDelegate(firstName, lastName);
            Console.WriteLine(fullName);
        }
    }
}
