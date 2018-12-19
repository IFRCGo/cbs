/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using MongoDB.Driver;
using System.Collections.Generic;
using Concepts.Project;

namespace Read.Projects
{
    public class Projects : ExtendedReadModelRepositoryFor<Project>,
        IProjects
    {
        public Projects(IMongoDatabase database)
            : base(database)
        {
        }

        public IEnumerable<Project> GetAll()
        {
            return GetMany(_ => true);
        }

        public Project GetById(ProjectId projectId)
        {
            return GetOne(p => p.Id == projectId);
        }

        public void SaveProject(ProjectId id, string name)
        {
            Update(new Project
            {
                Id = id,
                Name = name
            });
        }

        public UpdateResult UpdateProject(ProjectId id, string name)
        {
            return Update(p => p.Id == id,
                Builders<Project>.Update.Set(p => p.Name, name));
        }
    }
}
