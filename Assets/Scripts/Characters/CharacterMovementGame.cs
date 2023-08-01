using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CharacterMovement;
using UnityEngine;
using UnityEngine.AI;
using VFSCloud;

    public class CharacterMovementGame : CharacterMovement3D, INotifyPropertyChanged
    {
        public PlayerData Stats;
        
        public void Awake()
        {
            base.Awake();

            UpdateFromStats();
        }

        public void OnPropertyChanged()
        {
            UpdateFromStats();
        }

        private void UpdateFromStats()
        {
            _speed = Stats.Speed;
            _turnSpeed = Stats.TurnSpeed;
            _jumpHeight = Stats.JumpHeight;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value,
            [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }