using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Web.Helpers;
using LAP_PowerMining.Core.Enums;

namespace LAP_PowerMining.Core.KrakenComponents
{
    public class Ticker
    {
        // ticker information
        //=======================================================================================================================
        // "error": [],
        // "result": {
        //     "XXBTZEUR": {
        //         "a": ["7992.80000", "6", "6.000"],        a = ask array(<price>, <whole lot volume>, <lot volume>),
        //         "b": ["7978.60000", "1", "1.000"],        b = bid array(<price>, <whole lot volume>, <lot volume>),
        //         "c": ["7978.10000", "0.02895576"],        c = last trade closed array(<price>, <lot volume>),
        //         "v": ["14387.00922111", "19575.33345430"],v = volume array(<today>, <last 24 hours>),
        //         "p": ["8023.72390", "8060.67366"],        p = volume weighted average price array(<today>, <last 24 hours>),
        //         "t": [77387, 102991],                     t = number of trades array(<today>, <last 24 hours>),
        //         "l": ["7737.00000", "7737.00000"],        l = low array(<today>, <last 24 hours>),
        //         "h": ["8305.60000", "8366.60000"],        h = high array(<today>, <last 24 hours>),
        //         "o": "8073.00000"                         o = today's opening price
        //     }

        public string GetBtcEurData(string enumDataType)
        {
            switch (enumDataType)
            {
                case "a":
                    break;
                case "b":
                    break;
                case "c":
                    break;
                case "v":
                    break;
                case "p":
                    break;
                case "t":
                    break;
                case "l":
                    break;
                case "h":
                    break;
                case "o":
                    break;
            }
            return "";
        }

        public bool HasError { get; set; }

        public dynamic BTCEuroData { get; set; }
        public dynamic ErrorData { get; set; }

        public DateTime Timestamp { get; set; }

        public Ticker(string jsonString)
        {
            Timestamp = DateTime.Now;
            dynamic decodedJson = Json.Decode(jsonString);

            BTCEuroData = decodedJson["result"]["XXBTZEUR"];
            ErrorData = decodedJson["error"];
        }


    }
}