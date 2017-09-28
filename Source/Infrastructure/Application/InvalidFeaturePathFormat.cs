/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;

namespace Infrastructure.Application
{
    /// <summary>
    /// Exception that gets thrown when the format of a feature path is invalid
    /// </summary>
    public class InvalidFeaturePathFormat : ArgumentException
    {
        /// <summary>
        /// Initialize a new instance of <see cref="InvalidFeaturePathFormat"/>
        /// </summary>
        /// <param name="path">The path that is invalid</param>
        public InvalidFeaturePathFormat(string path) : base($"Format of the '{path}' is invalid - correct format is 'some/path/in/boundedContext'")
        {

        }
    }
}