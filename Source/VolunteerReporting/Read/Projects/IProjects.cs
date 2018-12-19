/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Collections.Generic;
using MongoDB.Driver;
using Concepts.Project;

namespace Read.Projects
{
    public interface IProjects : IExtendedReadModelRepositoryFor<Project>
    {
        IEnumerable<Project> GetAll();
        Project GetById(ProjectId project);

        void SaveProject(ProjectId id, string name);

        UpdateResult UpdateProject(ProjectId id, string name);
    }
}
