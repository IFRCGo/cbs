/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Artifacts;
using Dolittle.Events;

namespace Events.Reporting.DataCollectors
{
    [Artifact("950cef1b-5e9f-44e3-b410-67749573eda7")]
    public class DataCollectorCompletedTraining : IEvent
    {
        public DataCollectorCompletedTraining()
        {
        }
    }
}
