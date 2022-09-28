using System;
using UnityEngine;

namespace Base.Ravel.Games.Movement
{
    /// <summary>
    /// Move settings for planes.
    /// </summary>
    public class PlaneMovementBehaviour : MovementBehaviour
    {
        [SerializeField] private Settings _settings;
        
        /// <summary>
        /// Serialized settings, so creators can set them in the editor. Can be custom for each of the movement types.
        /// </summary>
        [Serializable]
        private struct Settings
        {
            public float speed;
            public float roll;
            public float rollStop;
            // the speed at which the plane returns to flat rotation
            public float returnRate;
        
            public float pitch;
            public float yaw;
        
            public Settings(float speed, float roll, float rStop, float pitch, float yaw, float returnRate)
            {
                this.speed = speed;
                this.roll = roll;
                rollStop = rStop;
                this.returnRate = returnRate;
            
                this.pitch = pitch;
                this.yaw = yaw;
            }
        }
    }
}