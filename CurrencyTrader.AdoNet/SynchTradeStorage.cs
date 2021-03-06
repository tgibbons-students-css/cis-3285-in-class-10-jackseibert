﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyTrader.Contracts;

namespace CurrencyTrader.AdoNet
{
    public class AsynchTradeStorage : ITradeStorage
    {
        private readonly ILogger logger;
        private ITradeStorage SynchTradeStorage;

        public AsynchTradeStorage(ILogger logger)
        {
            this.logger = logger;
            SynchTradeStorage = new AdoNetTradeStorage(logger);
        }

        public void Persist(IEnumerable<TradeRecord> trades)
        {
            logger.LogInfo("Synch trade storage.");
            Task.Run(() => SynchTradeStorage.Persist(trades));
        }
    }
}