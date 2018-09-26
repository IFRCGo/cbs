/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Read;
using Infrastructure.Read.MongoDb;
using MongoDB.Driver;

namespace Read.Projects
{
    public class Projects : ExtendedReadModelRepositoryFor<Project>, 
        IProjects
    {

        public Projects(IMongoDatabase database) 
            : base(database)
        {
        }

        public Project GetById(Guid id)
        {
            return GetOne(_ => _.Id == id);
        }

        public IEnumerable<Project> GetAll()
        {
            return GetMany(_ => true);
        }
    }
}