/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using Infrastructure.Read.MongoDb;

namespace Read.NationalSocietyFeatures
{
    public interface INationalSocieties : IExtendedReadModelRepositoryFor<NationalSociety>
    {
        IEnumerable<NationalSociety> GetAll();
        
        NationalSociety GetById(Guid id);
    }
}