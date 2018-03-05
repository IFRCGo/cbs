/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Microsoft.AspNetCore.Mvc;
using System.IO;
using MongoDB.Driver;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using System.Linq;
using Read.HealthRisks;
using Infrastructure.AspNet;
using Events;
using Events.External;
using Infrastructure.TextMessaging;
using Read.CaseReports;
using Read.DataCollectors;
using Read.AutomaticReplyMessages;
using Concepts;
using Read.Projects;
using doLittle.Events;
using Microsoft.Extensions.Configuration;

namespace Web
{
    [Route("api/testdatagenerator")]
    public class TestDataGeneratorController : BaseController
    {
        private readonly IMongoDatabase _database;
        private readonly ITextMessageProcessors _textMessageProcessors;

        private string[] _phoneNumbers = new[] {
            "",         // missing
            "11111111", // DataCollector #1
            "22222222", // DataCollector #2
            "33333333", // DataCollector #3
            "00000000"  // Non existing data collector
        };

        public TestDataGeneratorController(IMongoDatabase database, ITextMessageProcessors textMessageProcessors)
        {
            _textMessageProcessors = textMessageProcessors;
            _database = database;
        }

        [HttpGet("all")]
        public void CreateAll()
        {
            CreateHealthRisks();
            CreateDataCollectors();
            CreateTextMessages();
            CreateDefaultAutomaticReplyMessages();
            CreateDefaultAutomaticReplyKeyMessages();
            CreateProjects();
            CreateAutomaticReplyMessages();
            CreateAutomaticReplyKeyMessages();
        }

        [HttpGet("serverhost")]
        public string Connection()
        {
            return _database.Client.Settings.Server.Host;
        }


        [HttpGet("healthrisks")]
        public void CreateHealthRisks()
        {
            var _collection = _database.GetCollection<HealthRisk>("HealthRisk");
            _collection.DeleteMany(v => true);

            var healthRisks = JsonConvert.DeserializeObject<HealthRiskCreated[]>(System.IO.File.ReadAllText("./TestData/HealthRisks.json"));
            foreach (var healthRisk in healthRisks)
                Apply(healthRisk.Id, healthRisk);
        }

        [HttpGet("datacollectors")]
        public void CreateDataCollectors()
        {
            var _collection = _database.GetCollection<DataCollector>("DataCollector");
            _collection.DeleteMany(v => true);

            var dataCollectors = JsonConvert.DeserializeObject<DataCollectorAdded[]>(System.IO.File.ReadAllText("./TestData/DataCollectors.json"));

            int i = 0;
            foreach (var dataCollector in dataCollectors)
            {
                Apply(dataCollector.Id, dataCollector);
                Apply(Guid.NewGuid(), new PhoneNumberAddedToDataCollector
                {
                    DataCollectorId = dataCollector.Id,
                    PhoneNumber = _phoneNumbers[1 + (i++ % 3)] // Only using the middle 3 phone numbers
                });
            }
        }


        [HttpGet("producejsonfortextmessages")]
        public void ProduceJsonForTextMessages()
        {
            var events = new List<TextMessage>();
            var randomizer = new Random();
            var keywords = new[] { "" };
            var healthRisks = _database.GetCollection<HealthRisk>("HealthRisk").Find(Builders<HealthRisk>.Filter.Empty).ToList();
            var healthRiskIds = healthRisks.Take(5).Select(v => v.ReadableId).ToArray();
            var numbers = _phoneNumbers;

            for (int i = 0; i < 100; i++)
            {
                var message = randomizer.NextDouble() < 0.9 ? CreateValidMessage(healthRiskIds) : CreateInvalidMessage();

                var textMessage = new TextMessage()
                {
                    Id = Guid.NewGuid(),
                    Keyword = keywords[randomizer.Next(keywords.Length)],
                    OriginNumber = numbers[randomizer.Next(numbers.Length)],
                    Sent = DateTimeOffset.Now.AddSeconds(-randomizer.NextDouble() * 60 * 60 * 24 * 7 * 26), // last 26 weeks
                    ReceivedAtGatewayNumber = "0123456789",
                    Message = message
                };

                // Create location for half the messages
                if (randomizer.NextDouble() > 0.5)
                {
                    textMessage.Latitude = -80d + randomizer.NextDouble() * 80d;    // Latitude between -80 and 80 degrees
                    textMessage.Longitude = randomizer.NextDouble() * 360d;         // Longitude between 0 and 360 degrees
                }

                events.Add(textMessage);
            }

            System.IO.File.WriteAllText("./TestData/TextMessagesReceived.json", JsonConvert.SerializeObject(events, Formatting.Indented));
        }

        private string CreateInvalidMessage()
        {
            Random randomizer = new Random();
            if (randomizer.NextDouble() < 0.5)
                return "1#2#1#1#2#1";
            else
                return "Hello! My report is #1#0#0#2#3#0#2#3#0#2#3#0#2#3#0";
        }

        private string CreateValidMessage(int[] healthRiskIds)
        {
            Random randomizer = new Random();

            if (randomizer.NextDouble() > 0.7)
            {
                // Aggregate event: health risk # males under 5 # males over 5 # female under 5 # female over 5
                var incidents = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 2, 2, 3 };
                return $"{healthRiskIds[randomizer.Next(healthRiskIds.Length)]}#{incidents[randomizer.Next(incidents.Length)]}#{incidents[randomizer.Next(incidents.Length)]}#{incidents[randomizer.Next(incidents.Length)]}#{incidents[randomizer.Next(incidents.Length)]}";
            }
            else
            {
                // Single event: healt risk # sex # age
                return $"{healthRiskIds[randomizer.Next(healthRiskIds.Length)]}#{randomizer.Next(2) + 1}#{randomizer.Next(70) + 1}";
            }
        }


        [HttpGet("textmessages")]
        public void CreateTextMessages()
        {
            var _caseReportsCollection = _database.GetCollection<CaseReport>("CaseReport");
            _caseReportsCollection.DeleteMany(v => true);

            var textMessagesEvents = JsonConvert.DeserializeObject<TextMessage[]>(System.IO.File.ReadAllText("./TestData/TextMessages.json"));
            foreach (var message in textMessagesEvents)
            {
                try
                {
                    _textMessageProcessors.Process(message);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.ToString());
                }
            }

        }



        [HttpGet("defaultautomaticreplymessages")]
        public void CreateDefaultAutomaticReplyMessages()
        {
            var _collection = _database.GetCollection<DefaultAutomaticReply>("DefaultAutomaticReply");
            _collection.DeleteMany(v => true);

            var events = JsonConvert.DeserializeObject<DefaultAutomaticReplyDefined[]>(System.IO.File.ReadAllText("./TestData/DefaultAutomaticReplies.json"));
            foreach (var @event in events)
            {
                try
                {
                    Apply(@event.Id, @event);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.ToString());
                }
            }

        }
        [HttpGet("producejsonfordefaultautomaticreplymessages")]
        public void ProduceJsonForDefaultAutomaticReplyMessages()
        {
            var events = new List<DefaultAutomaticReplyDefined>();
            var randomizer = new Random();

            var messages = new Dictionary<string, Dictionary<AutomaticReplyType, string>>
            {
                ["nb-NO"] = new Dictionary<AutomaticReplyType, string>()
                {
                    { AutomaticReplyType.UnknownSender, "Ditt telefonnummer er ikke registrert som en frivillig hos oss, vennligst registrer deg"},
                    { AutomaticReplyType.InvalidReport, "Rapporten var ikke korrekt formatert, vennligst kontroller og send på ny" },
                    { AutomaticReplyType.ZeroIncidents, "Takk for din rapport! Vi er glad for å høre at det ikke har vært observert noen" },
                    { AutomaticReplyType.Incidents, "Takk for du rapporterer om {event} i {location}. {nationalsociety} følger situasjonen. {keymessage}" }
                },
                ["en-US"] = new Dictionary<AutomaticReplyType, string>()
                {
                    { AutomaticReplyType.UnknownSender, "Your phone number is not registered with us, please register"},
                    { AutomaticReplyType.InvalidReport, "Your report was not correctly formatted and could not be read. Please check and resend" },
                    { AutomaticReplyType.ZeroIncidents, "Thank you for letting us know there have been no health events detected" },
                    { AutomaticReplyType.Incidents, "Thsnks for reporting {event} in {location}. {nationalsociety} is monitoring the situation. {keymessage}" }
                }
            };

            foreach (var language in messages.Keys)
            {
                foreach(var type in messages[language].Keys)
                {
                    events.Add(new DefaultAutomaticReplyDefined()
                    {
                        Id = Guid.NewGuid(),
                        Language = language,
                        Message = messages[language][type],
                        Type = (int)type
                    });
                }
            }

            System.IO.File.WriteAllText("./TestData/DefaultAutomaticReplies.json", JsonConvert.SerializeObject(events, Formatting.Indented));
        }


        [HttpGet("automaticreplymessages")]
        public void CreateAutomaticReplyMessages()
        {
            var _collection = _database.GetCollection<AutomaticReply>("AutomaticReply");
            _collection.DeleteMany(v => true);

            var events = JsonConvert.DeserializeObject<AutomaticReplyDefined[]>(System.IO.File.ReadAllText("./TestData/AutomaticReplies.json"));
            foreach (var @event in events)
            {
                try
                {
                    Apply(@event.Id, @event);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.ToString());
                }
            }
        }

        [HttpGet("producejsonforautomaticreplymessages")]
        public void ProduceJsonForAutomaticReplyMessages()
        {
            var events = new List<IEvent>();
            var randomizer = new Random();

            var replies = new Dictionary<string, Dictionary<AutomaticReplyType, string>>()
            {
                ["nb-NO"] = new Dictionary<AutomaticReplyType, string>()
                {
                    { AutomaticReplyType.UnknownSender, "Din henvendelse kunne ikke behandles, vennligst kontakt Norges Røde Kors for assistanse. {keymessage}"},
                },
                ["en-US"] = new Dictionary<AutomaticReplyType, string>()
                {
                    { AutomaticReplyType.InvalidReport, "Your report was incorrectly formatted. It should be RiskID#Incidents#Gender" }
                }
            };

            // Make some reply messages for the first project only
            var project = JsonConvert.DeserializeObject<ProjectCreated[]>(System.IO.File.ReadAllText("./TestData/Projects.json")).First();

            foreach (var language in replies.Keys)
            {
                foreach (var type in replies[language].Keys)
                {
                    events.Add(new AutomaticReplyDefined()
                    {
                        Id = Guid.NewGuid(),
                        ProjectId = project.Id,
                        Language = language,
                        Message = replies[language][type],
                        Type = (int)type
                    });
                }
            }

            System.IO.File.WriteAllText("./TestData/AutomaticReplies.json", JsonConvert.SerializeObject(events, Formatting.Indented));
        }

        [HttpGet("producejsonforautomaticreplykeymessages")]
        public void ProduceJsonForAutomaticReplyKeyMessages()
        {
            var events = new List<IEvent>();

            var CholeraHealthRiskId = new Guid("51b92f4d-f14f-4ce9-9134-d766db5c3f80");

            var keymessages = new Dictionary<string, Dictionary<Guid, Dictionary<AutomaticReplyKeyMessageType, string>>>()
            {
                ["nb-NO"] = new Dictionary<Guid, Dictionary<AutomaticReplyKeyMessageType, string>>()
                {
                    [CholeraHealthRiskId] = new Dictionary<AutomaticReplyKeyMessageType, string>()
                    {
                        { AutomaticReplyKeyMessageType.KeyMessage, "Flom i kloakk har forurenset drikkevann og forårsaker Kolera" },
                        { AutomaticReplyKeyMessageType.Action, "Prioriter stasjoner for testing ut utlevering av rent vann" }
                    }
                },
                ["en-US"] = new Dictionary<Guid, Dictionary<AutomaticReplyKeyMessageType, string>>()
                {
                    [CholeraHealthRiskId] = new Dictionary<AutomaticReplyKeyMessageType, string>()
                    {
                        { AutomaticReplyKeyMessageType.KeyMessage, "Flooding in sewer systems is causing contaminated drinking water and causes Cholera" },
                        { AutomaticReplyKeyMessageType.Action, "Prioritize stations for testing and distribution of drinking water" }
                    }
                }
            };

            // Make some reply messages for the first project only
            var project = JsonConvert.DeserializeObject<ProjectCreated[]>(System.IO.File.ReadAllText("./TestData/Projects.json")).First();

            foreach (var language in keymessages.Keys)
            {
                foreach (var healthRiskId in keymessages[language].Keys)
                {
                    foreach (var type in keymessages[language][healthRiskId].Keys)
                    {
                        events.Add(new AutomaticReplyKeyMessageDefined()
                        {
                            Id = Guid.NewGuid(),
                            HealthRiskId = healthRiskId,
                            ProjectId = project.Id,
                            Language = language,
                            Message = keymessages[language][healthRiskId][type],
                            Type = (int)type
                        });
                    }
                }
            }

            System.IO.File.WriteAllText("./TestData/AutomaticReplyKeyMessages.json", JsonConvert.SerializeObject(events, Formatting.Indented));
        }


        [HttpGet("producejsonfordefaultautomaticreplykeymessages")]
        public void ProduceJsonFordefaultAutomaticReplyKeyMessages()
        {
            var events = new List<IEvent>();

            var CholeraHealthRiskId = new Guid("51b92f4d-f14f-4ce9-9134-d766db5c3f80");
            var PlagueHealthRiskId = new Guid("40d28dcb-b423-4e9d-ac83-690227f9da72");

            var keymessages = new Dictionary<string, Dictionary<Guid, Dictionary<AutomaticReplyKeyMessageType, string>>>()
            {
                ["nb-NO"] = new Dictionary<Guid, Dictionary<AutomaticReplyKeyMessageType, string>>()
                {
                    [CholeraHealthRiskId] = new Dictionary<AutomaticReplyKeyMessageType, string>()
                    {
                        { AutomaticReplyKeyMessageType.KeyMessage, "Mat og drikke forurenset av menneskers avføring er største kilde til Kolera" },
                        { AutomaticReplyKeyMessageType.Action, "Sørg for rikelig tilgang til rent vann for å hindre dehydrering" }
                    },
                    [PlagueHealthRiskId] = new Dictionary<AutomaticReplyKeyMessageType, string>()
                    {
                        { AutomaticReplyKeyMessageType.KeyMessage, "Pest spres bakterielt mellom mennesker og dyr via lopper" },
                        { AutomaticReplyKeyMessageType.Action, "Sørg for snarlig behandling med anibiotika" }
                    }
                },
                ["en-US"] = new Dictionary<Guid, Dictionary<AutomaticReplyKeyMessageType, string>>()
                {
                    [CholeraHealthRiskId] = new Dictionary<AutomaticReplyKeyMessageType, string>()
                    {
                        { AutomaticReplyKeyMessageType.KeyMessage, "Food and water contaminated by human waste is the main source for Cholera" },
                        { AutomaticReplyKeyMessageType.Action, "Ensure good access to clean water to prevent dehydration" }
                    },
                    [PlagueHealthRiskId] = new Dictionary<AutomaticReplyKeyMessageType, string>()
                    {
                        { AutomaticReplyKeyMessageType.KeyMessage, "Pleague is caused by bacterias and transmitted between people and animals via fleas" },
                        { AutomaticReplyKeyMessageType.Action, "Ensure early treatment by antibiotics" }
                    }
                }
            };

            foreach (var language in keymessages.Keys)
            {
                foreach (var healthRiskId in keymessages[language].Keys)
                {
                    foreach (var type in keymessages[language][healthRiskId].Keys)
                    {
                        events.Add(new DefaultAutomaticReplyKeyMessageDefined()
                        {
                            Id = Guid.NewGuid(),
                            HealthRiskId = healthRiskId,
                            Language = language,
                            Message = keymessages[language][healthRiskId][type],
                            Type = (int)type
                        });
                    }
                }
            }

            System.IO.File.WriteAllText("./TestData/DefaultAutomaticReplyKeyMessages.json", JsonConvert.SerializeObject(events, Formatting.Indented));
        }

        [HttpGet("automaticreplykeymessages")]
        public void CreateAutomaticReplyKeyMessages()
        {
            var _collection = _database.GetCollection<AutomaticReplyKeyMessage>("AutomaticReplyKeyMessage");
            _collection.DeleteMany(v => true);

            var events = JsonConvert.DeserializeObject<AutomaticReplyKeyMessageDefined[]>(System.IO.File.ReadAllText("./TestData/AutomaticReplyKeyMessages.json"));
            foreach (var @event in events)
            {
                try
                {
                    Apply(@event.Id, @event);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.ToString());
                }
            }
        }


        [HttpGet("defaultautomaticreplykeymessages")]
        public void CreateDefaultAutomaticReplyKeyMessages()
        {
            var _collection = _database.GetCollection<DefaultAutomaticReplyKeyMessage>("DefaultAutomaticReplyKeyMessage");
            _collection.DeleteMany(v => true);

            var events = JsonConvert.DeserializeObject<DefaultAutomaticReplyKeyMessageDefined[]>(System.IO.File.ReadAllText("./TestData/DefaultAutomaticReplyKeyMessages.json"));
            foreach (var @event in events)
            {
                try
                {
                    Apply(@event.Id, @event);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.ToString());
                }
            }
        }


        [HttpGet("createprojects")]
        public void CreateProjects()
        {
            var _collection = _database.GetCollection<Project>("Project");
            _collection.DeleteMany(v => true);

            var projects = JsonConvert.DeserializeObject<ProjectCreated[]>(System.IO.File.ReadAllText("./TestData/Projects.json"));
            foreach (var project in projects)
                Apply(project.Id, project);
        }

        [HttpGet("testDelete")]
        public void TestDelete()
        {
            var events = JsonConvert.DeserializeObject<AutomaticReplyRemoved[]>(System.IO.File.ReadAllText("./TestData/AutomaticReplyRemoved.json"));

            foreach (var @event in events)
            {
                try
                {
                    Apply(@event.Id, @event);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.ToString());
                }
            }
        }
        [HttpGet("testChangeMessage")]
        public void TestChangeMessage()
        {
            var events = JsonConvert.DeserializeObject<AutomaticReplyDefined[]>(System.IO.File.ReadAllText("./TestData/AutomaticReplyChangeTest.json"));

            foreach (var @event in events)
            {
                try
                {
                    Apply(@event.Id, @event);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.ToString());
                }
            }
        }

    }
}
