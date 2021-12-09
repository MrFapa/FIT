using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float maxForce;
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float maxVelocity;

    private Vector3 target;

    private Vector3 vel;

    private SeekerBehaviour sb;
    

    void Start()
    {
        this.vel = new Vector3(0, 0, 0);
        sb = new SeekerBehaviour();
    }

    void Update()
    {
        this.target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.target.z = 0;


        Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.vel = sb.calcSeekingVector(target, this.transform.position, vel, maxSpeed, maxForce, maxVelocity);
        move();
    }

    void move()
    {
        this.transform.position += this.vel;
    }

    void edgeCheck()
    {
        

    }
}
