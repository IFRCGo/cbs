/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
namespace Infrastructure.Application
{
    /// <summary>
    /// Represents information about the running application
    /// </summary>
    public class ApplicationInformation
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ApplicationInformation"/>
        /// </summary>
        /// <param name="boundedContext">The <see cref="BoundedContext"/> for the running process</param>
        public ApplicationInformation(BoundedContext boundedContext)
        {
            BoundedContext = boundedContext;
        }

        /// <summary>
        /// Gets the <see cref="BoundedContext"/> for the currently running application/process
        /// </summary>
        public BoundedContext BoundedContext { get; }
    }
}