using System;
using UnityEngine;

namespace VFSCloud
{
    [System.Serializable]
    public class PlayerData
    {
        [SerializeField] public float Speed;
        [SerializeField] public float TurnSpeed;
        [SerializeField] public float JumpHeight;

        public PlayerData()
        {
            Speed = 1.0f;
            TurnSpeed = 1.0f;
            JumpHeight = 1.0f;
        }
    }
}