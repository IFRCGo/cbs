/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Text.RegularExpressions;

namespace Domain
{
    /// <summary>
    /// Represents a location within a <see cref="BoundedContext"/>
    /// </summary>
    public class Feature
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Feature"/>
        /// </summary>
        /// <param name="path"></param>
        /// <remarks>
        /// Only use / as separator
        /// </remarks>
        public Feature(string path)
        {
            ThrowIfInvalidFormat(path);

            Path = path;
        }

        /// <summary>
        /// Gets the actual location within a <see cref="BoundedContext"/>
        /// </summary>
        /// <returns></returns>
        public string Path { get; }

        /// <summary>
        /// Implicitly convert from a string representation of a location to <see cref="Feature"/>
        /// </summary>
        /// <param name="path">Path e.g. 'Some/Location/In/My/BoundedContext/"</param>
        public static implicit operator Feature(string path)
        {
            return new Feature(path);
        }


        void ThrowIfInvalidFormat(string path)
        {
            var regex = new Regex("([a-zA-Z/]+)+");
            var result = regex.Match(path);

            Console.WriteLine("Result : "+result.Success);
        }
    }
}