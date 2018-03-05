/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Reflection;
using doLittle.Applications;
using doLittle.Assemblies;
using doLittle.Assemblies.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Infrastructure.AspNet
{
    /// <summary>
    /// ***************************    
    /// ******* DANGER ZONE *******
    /// ***************************    
    /// This place exists only for infrastructural purposes and mostly from a startup perspective
    /// DO NOT MAKE THIS A DUMPING GROUND FOR THINGS YOU'D LIKE TO HAVE EASILY ACCESSIBLE
    /// ADHERE TO DEPENDENCY INVERSION!!  PS: ALSO - KEEP THIS INTERNAL TO THIS PROJECT ONLY
    /// </summary>
    internal class Internals
    {
        public static BoundedContext BoundedContext;
        public static IConfiguration Configuration;
        public static ILoggerFactory LoggerFactory;
        public static IEnumerable<Assembly> AllAssemblies;
        public static IServiceProvider ServiceProvider;

        public static IAssemblyFilters AssemblyFilters;
        public static AssembliesConfiguration AssembliesConfiguration;
        public static IAssemblyProvider AssemblyProvider;
        public static IAssemblies Assemblies;
    }
}