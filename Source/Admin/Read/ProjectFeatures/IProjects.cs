/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Read.ProjectFeatures
{
    public interface IProjects
    {
        Project GetById(Guid id);

        void Save(Project project);

        IEnumerable<Project> GetAll();

        Task<IEnumerable<Project>> GetAllASync();
        void Delete(Guid id);
    }
}