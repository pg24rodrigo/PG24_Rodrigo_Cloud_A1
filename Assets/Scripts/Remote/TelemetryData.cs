using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace VFSCloud
{
    public class TelemetryData
    {
        public string Level;
        public Vector3 Position;
        public float DeltaTime;

        public TelemetryData()
        {
            Level = "level-one";
            Position = new Vector3(0, 0, 0);
            DeltaTime = 0.0f;
        }
        
        public Dictionary<string, object> AsDict()
        {
            var theDict = new Dictionary<string, object>()
            {
                { "levelName", Level },
                { "Position", JsonUtility.ToJson(Position) },
                { "DeltaTime", DeltaTime }
            };
            
            return theDict;
        }
    }
}