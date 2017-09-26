using System;

namespace Infrastructure.Domain
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