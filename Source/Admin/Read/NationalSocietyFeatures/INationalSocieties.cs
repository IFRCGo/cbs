/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Collections.Generic;

namespace Read.NationalSocietyFeatures
{
    public interface INationalSocieties
    {
		IEnumerable<NationalSociety> GetAll();

        void Save(NationalSociety nationalSociety);
    }
}
