﻿/*
 * Copyright © 2016 EDDiscovery development team
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
    //When written: when passing through the jet code from a white dwarf or neutron star has caused damage to a ship module
    //Parameters:
    //•	Module: the name of the module that has taken some damage
    [JournalEntryType(JournalTypeEnum.JetConeDamage)]
    public class JournalJetConeDamage : JournalEntry
    {
        public JournalJetConeDamage(JObject evt ) : base(evt, JournalTypeEnum.JetConeDamage)
        {
            ModuleFD = JournalFieldNaming.NormaliseFDItemName(evt["Module"].Str());
            Module = JournalFieldNaming.GetBetterItemName(ModuleFD);
            ModuleLocalised = evt["Module_Localised"].Str();       
            if ( ModuleLocalised.Length == 0 )
                ModuleLocalised = evt["_Localised"].Str();       //Frontier bug - jet cone boost entries are bugged in journal at the moment up to 2.2.
            ModuleLocalised = ModuleLocalised.Alt(Module);
        }

        public string Module { get; set; }
        public string ModuleFD { get; set; }
        public string ModuleLocalised { get; set; }

        public override void FillInformation(out string info, out string detailed) //V
        {
            
            info = ModuleLocalised;
            detailed = "";
        }
    }
}
