/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Autofac;
using Domain.Admin;
using Domain.Projects;
using Domain.AutomaticReplyMessages;

namespace Domain.RuleImplementations
{
    public class RuleModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProjectHealthRiskRules>().As<IProjectHealthRiskRules>();
            builder.RegisterType<ProjectRules>().As<IProjectRules>();
            builder.RegisterType<UserRules>().As<IUserRules>();
            builder.RegisterType<ReplyMessagesConfigRules>().As<IReplyMessagesConfigRules>();
        }
    }
}