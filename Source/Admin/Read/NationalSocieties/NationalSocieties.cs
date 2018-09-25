/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using Infrastructure.Read;
using Infrastructure.Read.MongoDb;
using MongoDB.Driver;

namespace Read.NationalSocieties
{
    public class NationalSocieties : ExtendedReadModelRepositoryFor<NationalSociety>,
        INationalSocieties
    {
        public NationalSocieties(IMongoDatabase database)
            : base(database, database.GetCollection<NationalSociety>("NationalSociety"))
        {
        }

        public IEnumerable<NationalSociety> GetAll()
        {
            return GetMany(_ => true);
        }

        public NationalSociety GetById(Guid id)
        {
            return GetOne(_ => _.Id == id);
        }

    }
}