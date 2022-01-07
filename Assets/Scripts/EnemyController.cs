using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField]
    private float maxForce;
    [SerializeField]
    private float maxSpeed;

    [SerializeField]
    private float maxVelocity;

    [SerializeField]
    private float lifeTime;

    private GameObject player;
    private Vector3 target;
    private Vector3 vel;

    private SeekerBehaviour sb;

    private Vector2 screenPos;

    private float birthday;

    // Start is called before the first frame update
    void Start()
    {
        sb = new SeekerBehaviour();
        player = GameObject.Find("Player");
        birthday = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        this.target = player.transform.position;
        this.target.z = 0;

        this.screenPos = Camera.main.WorldToScreenPoint(this.transform.position);

        rotate();

        if (Time.time - birthday > lifeTime)
        {
            GameObject.Destroy(this.gameObject);
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

    void rotate()
    {
        Vector3 dir = (this.vel).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;

        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
