using System.Data.Common;
using Unity.Services.Analytics;
using UnityEngine;
using UnityEngine.Analytics;

using Unity.Services.Core;
using Unity.Services.Analytics;

namespace VFSCloud
{
    public class TelemetryEvent
    {
        private static TelemetryEvent _instance = null;
        private static TelemetryData _data;
        
        public TelemetryData Data => _data;

        public static TelemetryEvent Service
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TelemetryEvent();
                }
                
                return _instance;
            }
        }

        private TelemetryEvent()
        {
            if (_data == null)
            {
                _data = new TelemetryData();
            }
        }

        public void Record(string eventName)
        {
            if (eventName == null || _data == null)
            {
                return;
            }

            var dataDict = _data.AsDict();
            AnalyticsService.Instance.CustomData(eventName, dataDict);
        }
    }
}