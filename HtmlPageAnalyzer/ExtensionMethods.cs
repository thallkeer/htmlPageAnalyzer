using System;
using System.Collections.Generic;

namespace HtmlPageAnalyzer
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Iterate over a sequence, calling the delegate for each element.
        /// </summary>
        /// <typeparam name="T">
        /// The type of object in the sequence.
        /// </typeparam>
        /// <param name="list">
        /// The sequence.
        /// </param>
        /// <param name="action">
        /// The action to invoke for each object.
        /// </param>
        public static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
        {
            foreach (T item in list)
            {
                action(item);
            }
        }
    }
}
