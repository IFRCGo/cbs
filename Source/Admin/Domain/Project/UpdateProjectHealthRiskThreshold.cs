/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Commands;

namespace Domain.Project
{
    public class UpdateProjectHealthRiskThreshold : ICommand
    {
        //TODO: Probaly needs an project ID aswell
        public int Threshold { get; set; }
    }
}