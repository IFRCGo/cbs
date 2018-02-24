/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
namespace Kafka.BoundedContexts
{
    public class BoundedContextListenerConfiguration
    {
        public BoundedContextListenerConfiguration(Topic topic)
        {
            Topic = topic;

        }

        public Topic Topic { get; }
    }
}