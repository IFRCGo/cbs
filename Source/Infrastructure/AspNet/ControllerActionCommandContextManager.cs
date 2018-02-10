/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Threading;
using doLittle.Runtime.Commands;

namespace Infrastructure.AspNet
{
    public class ControllerActionCommandContextManager : ICommandContextManager
    {
        readonly ICommandContextFactory _factory;

        static AsyncLocal<ICommandContext> _currentContext = new AsyncLocal<ICommandContext>();

        static ICommandContext CurrentContext
        {
            get { return _currentContext.Value; }
            set { _currentContext.Value = value; }
        }

        /// <summary>
        /// Reset context
        /// </summary>
        public static void ResetContext()
        {
            CurrentContext = null;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="CommandContextManager">CommandContextManager</see>
        /// </summary>
        /// <param name="factory">A <see cref="ICommandContextFactory"/> to use for building an <see cref="ICommandContext"/></param>
        public ControllerActionCommandContextManager(ICommandContextFactory factory)
        {
            _factory = factory;
        }

        private static bool IsInContext(CommandRequest command)
        {
            var inContext = null != CurrentContext && CurrentContext.Command.Equals(command);
            return inContext;
        }

        /// <inheritdoc/>
        public bool HasCurrent
        {
            get { return CurrentContext != null; }
        }

        /// <inheritdoc/>
        public ICommandContext GetCurrent()
        {
            if (!HasCurrent)
            {
                throw new InvalidOperationException("Command not established");
            }

            return CurrentContext;
        }

        /// <inheritdoc/>
        public ICommandContext EstablishForCommand(CommandRequest command)
        {
            if (!IsInContext(command))
            {
                var commandContext = _factory.Build(command);
                CurrentContext = commandContext;
            }

            return CurrentContext;
        }
    }
}