/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Concepts.NationalSocieties;
using Dolittle.Commands;
using Concepts.Projects;
using Concepts.Users;

namespace Domain.Projects
{
    public class CreateProject : ICommand
    {
        public ProjectId Id { get; set; }

        public ProjectName Name { get; set; }

        public NationalSocietyId NationalSocietyId { get; set; }

        public UserId DataOwnerId { get; set; }
        
        public int SurveillanceContext { get; set; }
    }
}