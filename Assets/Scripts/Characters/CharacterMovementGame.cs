using System;
using System.Collections;
using System.Collections.Generic;
using CharacterMovement;
using UnityEngine;
using UnityEngine.AI;
using VFSCloud;

    public class CharacterMovementGame : CharacterMovement3D, IRemotePlayer
    {
        public void Awake()
        {
            base.Awake();
        }

        // From IRemoteData:
        public void LoadConfigs(PlayerData theData)
        {
            _speed = theData.Speed;
            _turnSpeed = theData.TurnSpeed;
            _jumpHeight = theData.JumpHeight;
        }
    }