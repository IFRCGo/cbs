/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
namespace Infrastructure.Domain
{
    /// <summary>
    /// Represents a bounded context
    /// </summary>
    public class BoundedContext
    {
        /// <summary>
        /// Initializes a new instance of <see cref="BoundedContext"/>
        /// </summary>
        /// <param name="name">Name of the bounded context</param>
        public BoundedContext(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Gets the name of the <see cref="BoundedContext"/>
        /// </summary>
        /// <returns>String representing name</returns>
        public string Name { get; }


        /// <summary>
        /// Implicitly convert from string to <see cref="BoundedContext"/>
        /// </summary>
        /// <param name="name">Name of the bounded context</param>
        public static implicit operator BoundedContext(string name)
        {
            return new BoundedContext(name);
        }
    }
}