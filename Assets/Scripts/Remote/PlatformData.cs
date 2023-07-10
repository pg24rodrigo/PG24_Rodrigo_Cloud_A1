using System;
using System.Collections.Generic;
using UnityEngine;

namespace VFSCloud
{
    [System.Serializable]
    public class PlatformData
    {
        [SerializeField] public float Speed;
        [SerializeField] public float EasingDistance;
        [SerializeField] public List<Vector3> Points;

        public PlatformData()
        {
            Speed = 1.0f;
            EasingDistance = 0.5f;
            Points = new List<Vector3>();
        }
    }
    
    [System.Serializable]
    public class PlatformInfo
    {
        
    }
}