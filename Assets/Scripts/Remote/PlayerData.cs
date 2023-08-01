using System;
using UnityEngine;

namespace VFSCloud
{
    //[System.Serializable]
    [CreateAssetMenu(fileName = "PlayerData", menuName = "CloudDemo/Player Data", order = 1)]
    public class PlayerData : ScriptableObject, IRemoteData
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

        public void UpdateConfig(PlayerData newData)
        {
            Speed = newData.Speed;
            TurnSpeed = newData.TurnSpeed;
            JumpHeight = newData.JumpHeight;
        }
    }
}