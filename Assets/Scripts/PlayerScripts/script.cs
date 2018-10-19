using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour {
    public List<AxleInfo> axleInfos; // the information about each individual axle
    public float maxMotorTorque; // maximum torque the motor can apply to wheel
    public float maxSteeringAngle; // maximum steer angle the wheel can have

    public static readonly float MAX_EULER = 360;
    public static readonly float MOTOR_TORQUE_MULTIPLIER = 30;

    int i = 0;

    public void Start()
    {
        foreach (AxleInfo axleInfo in axleInfos)
        {
            axleInfo.leftWheel.ConfigureVehicleSubsteps(1, 12, 15);
            axleInfo.rightWheel.ConfigureVehicleSubsteps(1, 12, 15);
        }
    }


    public void FixedUpdate()
    {

        //transform.
        float motor = maxMotorTorque * Input.GetAxis("Vertical"); 
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        //float zRot = transform.rotation.z;
        float zRot = transform.eulerAngles.z;
        zRot = ClampEuler(zRot, -15, 15);

        if (steering == 0.0)
        {
            //zRot = Mathf.MoveTowards(zRot, 0, 10 * Time.fixedDeltaTime);
            zRot = StabilizeEuler(zRot, 20 * Time.fixedDeltaTime);
        }
        Debug.Log(zRot + " " + i++);
        transform.eulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, zRot);

        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
        }
    }

    //0 < zRot < 360
    public static float StabilizeEuler(float val, float howFast)
    {
        if (val > 180.0)
        {
            return Mathf.MoveTowards(val, MAX_EULER, howFast);
        }
        else
        {
            return Mathf.MoveTowards(val, 0, howFast);
        }
    }

    //0 < zRot < 360
    public static float ClampEuler(float val, float min, float max)
    {
        if(val > 180)
        {
            return Mathf.Clamp(val, MAX_EULER - Mathf.Abs(min), MAX_EULER);
        }
        else
        {
            return Mathf.Clamp(val, 0, max);
        }
    }
}

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor; // is this wheel attached to motor?
    public bool steering; // does this wheel apply steer angle?
}