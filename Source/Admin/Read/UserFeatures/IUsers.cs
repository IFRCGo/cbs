/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Read.UserFeatures
{
    public interface IUsers
    {
        User GetById(Guid id);

        Task<IEnumerable<User>> GetByNationalSocietyId(Guid id);

        void Save(User user);

        IEnumerable<User> GetAll();

        Task<IEnumerable<User>> GetAllASync();
    }
}