/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Concepts;

namespace Infrastructure.Kafka
{
    public class Topic : ConceptAs<string>
    {
        public static implicit operator Topic(string topic)
        {
            return new Topic { Value = topic };
        }
    }
}