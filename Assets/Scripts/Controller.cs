using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum Typ
{
    Player,
    Enemy
}
public class Controller : MonoBehaviour
{
    [SerializeField]
    private Typ typ;

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
        sb = new SeekerBehaviour();

        if (this.typ == Typ.Player){
            this.vel = new Vector3(0, 0, 0);
        }else if (this.typ == Typ.Enemy){
            this.vel = new Vector3(0, 0, 0);
        }
        
    }

    void Update()
    {
        if (this.typ == Typ.Player){
            this.target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.target.z = 0;
        }else if (this.typ == Typ.Enemy){
            this.target = GameObject.Find("Player").GetComponent<Transform>().position;
        }
    }

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
