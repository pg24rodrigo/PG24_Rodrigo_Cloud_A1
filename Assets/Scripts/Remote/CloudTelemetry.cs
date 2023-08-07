using System.Collections.Generic;
using Unity.Services.Analytics;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

namespace VFSCloud
{
    public class CloudTelemetry
    {
        public TelemetryEvent Telemetry = TelemetryEvent.Service;

        public void RecordEvent(string eventName)
        {
            Telemetry.Data.Level = SceneManager.GetActiveScene().name;
            Telemetry.Data.Position = GameObject.FindGameObjectWithTag("Player").transform.position;
            Telemetry.Data.DeltaTime = Time.timeSinceLevelLoad;
            Telemetry.Record(eventName);

#if UNITY_EDITOR
            Debug.Log($"CloudTelemetry recorded: {eventName}");
#endif
        }
    }
}