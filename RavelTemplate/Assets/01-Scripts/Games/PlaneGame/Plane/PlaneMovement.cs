using System;
using UnityEngine;

namespace Base.Ravel.Games.Planes
{
    public class PlaneMovement : MonoBehaviour
    {
        [Tooltip("The roll object translates local rotation, so that it can return to normal")]
        public Transform rollTransform;
        
        //roll yaw pitch rates
        [Serializable]
        public struct PlaneSettings
        {
            public float speed;
            public float roll;

            public float rollStop;

            // the speed at which the plane returns to flat rotation
            public float returnRate;

            public float pitch;
            public float yaw;
        }
    }
}