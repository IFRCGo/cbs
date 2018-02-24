/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
namespace Kafka
{
    /// <summary>
    /// Defines a system that can send events
    /// </summary>
    public interface IPublisher
    {
        /// <summary>
        /// Publish an event to a <see cref="Topic"/>
        /// </summary>
        /// <param name="topic"><see cref="Topic"/> to publsh to</param>
        /// <param name="json">Json string payload</param>
        void Publish(Topic topic, string json);
    }
}