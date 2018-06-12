/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Read.MongoDb;

namespace Read.UserFeatures
{
    public interface IUsers : IExtendedReadModelRepositoryFor<User>
    {
        User GetById(Guid id);

        IEnumerable<User> GetByNationalSocietyId(Guid id);

        IEnumerable<User> GetAll();
    }
}