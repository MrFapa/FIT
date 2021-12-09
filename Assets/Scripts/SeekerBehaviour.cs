using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekerBehaviour 
{
    public Vector3 calcSeekingVector(Vector3 target, Vector3 currentPos, Vector3 vel, float maxSpeed, float maxForce, float maxVelocity)
    {
        Vector3 desired = target - currentPos;
        desired = desired.normalized * maxSpeed;

        Vector3 steering = desired - vel;
        steering = Vector3.ClampMagnitude(steering, maxForce);

        Vector3 newVel = Vector3.ClampMagnitude(vel + steering, maxSpeed);
        return newVel;
    }
}
