using System;
using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
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
        
        public PlaneSettings(float speed, float roll, float rStop, float pitch, float yaw, float returnRate)
        {
            this.speed = speed;
            this.roll = roll;
            rollStop = rStop;
            this.returnRate = returnRate;
            
            this.pitch = pitch;
            this.yaw = yaw;
        }

        public PlaneSettings PaperPlane {
            get { return new PlaneSettings(1, 45, 70, 20, 30, 0.99f); }
        }
    }
}
