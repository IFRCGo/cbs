/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Autofac;

namespace Domain.RuleImplementations
{
    public class RuleModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProjectHealthRiskRules>().As<IProjectHealthRiskRules>();
            builder.RegisterType<ProjectRules>().As<IProjectRules>();
            builder.RegisterType<UserRules>().As<IUserRules>();
        }
    }
}
