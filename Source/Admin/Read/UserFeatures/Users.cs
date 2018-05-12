/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Read;
using MongoDB.Driver;

namespace Read.UserFeatures
{
    public class Users : ExtendedReadModelRepositoryFor<User>,
        IUsers
    {
        public Users(IMongoDatabase database)
            : base(database, database.GetCollection<User>("User"))
        {
        }

        public User GetById(Guid id)
        {
            return GetOne(_ => _.Id == id);
        }

        IEnumerable<User> IUsers.GetByNationalSocietyId(Guid id)
        {
            return GetMany(_ => _.NationalSocietyId == id);
        }

        public Task<IEnumerable<User>> GetByNationalSocietyIdAsync(Guid id)
        {
            return GetManyAsync(_ => _.NationalSocietyId == id);
        }

        public IEnumerable<User> GetAll()
        {
            return GetMany(_ => true);
        }

        public Task<IEnumerable<User>> GetAllASync()
        {
            return GetManyAsync(_ => true);
        }
    }
}