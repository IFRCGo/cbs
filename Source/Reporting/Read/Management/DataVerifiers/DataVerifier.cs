/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Concepts.DataVerifiers;
using Dolittle.ReadModels;

namespace Read.Management.DataVerifiers
{
    public class DataVerifier : IReadModel
    {
        public DataVerifierId Id { get; set; }
        public string FullName { get; set; }
    }
}