/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using MongoDB.Driver;
using System.Collections.Generic;

namespace Read.NationalSocietyFeatures
{
    public class NationalSocieties : INationalSocieties
	{
		readonly IMongoDatabase _database;
		readonly IMongoCollection<NationalSociety> _collection;

		public NationalSocieties(IMongoDatabase database)
		{
			_database = database;
            _collection = database.GetCollection<NationalSociety>("NationalSociety");
		}

        public IEnumerable<NationalSociety> GetAll()
		{
			return _collection.Find(_ => true).ToList();
		}

        public void Save(NationalSociety nationalSociety)
		{            			
            _collection.InsertOne(nationalSociety);
		}
	}
}
