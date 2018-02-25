/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using doLittle.Concepts;

namespace Infrastructure.Kafka
{
    public class KafkaConnectionString : ConceptAs<string>
    {
        public static implicit operator KafkaConnectionString(string connectionString)
        {
            return new KafkaConnectionString { Value = connectionString };
        }
    }
}