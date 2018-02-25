/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
namespace Infrastructure.Kafka
{
    /// <summary>
    /// Defines a system that is capable of consuming events
    /// </summary>
    public interface IConsumer
    {
        /// <summary>
        /// Subscribe to a topic
        /// </summary>
        /// <param name="topic"><see cref="Topic"/> to subscribe to</param>
        /// <param name="received"><see cref="EventReceived"/> that gets called when there is an event received</param>
        void SubscribeTo(ConsumerName consumerName, Topic topic, EventReceived received);
    }
}