﻿/*
 * QUANTCONNECT.COM - Democratizing Finance, Empowering Individuals.
 * Lean Algorithmic Trading Engine v2.0. Copyright 2014 QuantConnect Corporation.
 * 
 * Licensed under the Apache License, Version 2.0 (the "License"); 
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using QuantConnect.Interfaces;
using QuantConnect.Packets;

namespace QuantConnect.Brokerages.Backtesting
{
    class BacktestingBrokerageFactory : IBrokerageFactory
    {
        /// <summary>
        /// Gets the type of brokerage produced by this factory
        /// </summary>
        public Type BrokerageType
        {
            get { return typeof(BacktestingBrokerage); }
        }

        /// <summary>
        /// Gets the brokerage data required to run the IB brokerage from configuration
        /// </summary>
        /// <remarks>
        /// The implementation of this property will create the brokerage data dictionary required for running
        /// live jobs locally with the ConsoleSetupHandler. The implementation must specify the following
        /// attributes:
        ///    [Export(typeof(Dictionary&lt;string, string&gt;))]
        ///    [ExportMetadata("BrokerageData", "{BrokerageTypeNameHere}")]
        /// </remarks>
        [Export(typeof(Dictionary<string, string>))]
        [ExportMetadata("BrokerageData", "BacktestingBrokerage")]
        public Dictionary<string, string> BrokerageData
        {
            get { return new Dictionary<string, string>(); }
        }

        /// <summary>
        /// Creates a new IBrokerage instance
        /// </summary>
        /// <param name="job">The job packet to create the brokerage for</param>
        /// <param name="algorithm">The algorithm instance</param>
        /// <returns>A new brokerage instance</returns>
        public IBrokerage CreateBrokerage(LiveNodePacket job, IAlgorithm algorithm)
        {
            return new BacktestingBrokerage(algorithm);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            // NOP
        }
    }
}