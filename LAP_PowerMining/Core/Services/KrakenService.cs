using LAP_PowerMining.Core.KrakenComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAP_PowerMining.Core.Services
{
    public class KrakenService
    {
        public KrakenService()
        {
            KrakenClient.KrakenClient kClient = new KrakenClient.KrakenClient();
            var tickerJson = kClient.GetTicker(new List<string> { "XXBTZEUR" });
            var historyJson = kClient.GetRecentTrades("XXBTZEUR", 137589964200000000);
            Ticker ticker = new Ticker(tickerJson.ToString());
        }
    }
}