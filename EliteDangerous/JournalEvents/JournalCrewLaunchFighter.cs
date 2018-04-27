﻿/*
 * Copyright © 2017 EDDiscovery development team
 *
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not use this
 * file except in compliance with the License. You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software distributed under
 * the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF
 * ANY KIND, either express or implied. See the License for the specific language
 * governing permissions and limitations under the License.
 *
 * EDDiscovery is not affiliated with Frontier Developments plc.
 */
using Newtonsoft.Json.Linq;
using System.Linq;

namespace EliteDangerousCore.JournalEvents
{
    //    When written: When another player joins your ship's crew
    //Parameters:
    //•	Crew: player's commander name
    //{ "timestamp":"2017-04-19T20:12:53Z", "event":"CrewLaunchFighter", "Crew":"[cmdr name]" }

    [JournalEntryType(JournalTypeEnum.CrewLaunchFighter)]
    public class JournalCrewLaunchFighter : JournalEntry
    {
        public JournalCrewLaunchFighter(JObject evt) : base(evt, JournalTypeEnum.CrewLaunchFighter)
        {
            Crew = evt["Crew"].Str();

        }
        public string Crew { get; set; }

        public override void FillInformation(out string info, out string detailed) //V
        {
            
            info = Crew;
            detailed = "";
        }
    }
}
