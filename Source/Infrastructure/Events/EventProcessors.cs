/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using doLittle.Collections;
using doLittle.DependencyInversion;
using doLittle.Types;

namespace Infrastructure.Events
{
    /// <summary>
    /// Represents an implementation of <see cref="IEventProcessors"/>
    /// </summary>
    public class EventProcessors : IEventProcessors
    {
        /// <summary>
        /// The name of the process method looked for by convention
        /// </summary>
        public const string ProcessMethodName = "Process";
        
       
        readonly IDictionary<Type, IList<MethodInfo>> _eventProcessors = new Dictionary<Type, IList<MethodInfo>>();
        readonly IContainer _container;

        /// <summary>
        /// Initializes a new instance of <see cref="EventProcessors"/>
        /// </summary>
        /// <param name="eventProcessors"><see cref="IImplementationsOf{IEventProcessor}">Implementations of event processors - types</see></param>
        /// <param name="container"><see cref="IContainer"/></param>
        public EventProcessors(IImplementationsOf<IEventProcessor> eventProcessors, IContainer container)
        {
            PopulateProcessMethodsFrom(eventProcessors);
            _container = container;
        }

        /// <inheritdoc/>
        public void Process(EventEnvelope @event)
        {
            Process(new[] { @event });
        }

        /// <inheritdoc/>
        public void Process(IEnumerable<EventEnvelope> events)
        {
            events.ForEach(envelope => 
            {   
                var eventType = envelope.Event.GetType();
                if( _eventProcessors.ContainsKey(eventType) )
                    _eventProcessors[eventType].ForEach(method => 
                    {
                        var instance = _container.Get(method.DeclaringType);
                        if( instance != null ) 
                        {
                            method.Invoke(instance, new[] { envelope.Event });
                        }
                    });
            });
        }


        void PopulateProcessMethodsFrom(IImplementationsOf<IEventProcessor> eventProcessors)
        {
            eventProcessors.ForEach(eventProcessorType =>
            {
                var methods = eventProcessorType.GetMethods(BindingFlags.Instance|BindingFlags.Public).Where(method => {
                    var parameters = method.GetParameters();

                    return method.Name == ProcessMethodName &&
                            parameters.Length == 1 &&
                            typeof(IEvent).GetTypeInfo().IsAssignableFrom(parameters[0].ParameterType.GetTypeInfo());
                    
                });

                methods.ForEach(RegisterProcessMethod);
            });
        }


        void RegisterProcessMethod(MethodInfo method)
        {
            var eventType = method.GetParameters()[0].ParameterType;
            IList<MethodInfo> processMethods;
            if( _eventProcessors.ContainsKey(eventType) ) processMethods = _eventProcessors[eventType];
            else 
            {
                processMethods = new List<MethodInfo>();
                _eventProcessors[eventType] = processMethods;
            }
            processMethods.Add(method);
        }
    }
}