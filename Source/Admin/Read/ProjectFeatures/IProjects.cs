/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
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
    }
}