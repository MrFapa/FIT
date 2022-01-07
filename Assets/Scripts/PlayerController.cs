using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
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

    private Vector2 screenPos;

    // Start is called before the first frame update
    void Start()
    {
        sb = new SeekerBehaviour();
    }

    // Update is called once per frame
    void Update()
    {
        this.target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.target.z = 0;

        this.screenPos = Camera.main.WorldToScreenPoint(this.transform.position);

        rotate();
    }

    void FixedUpdate()
    {
        this.vel = sb.calcSeekingVector(target, this.transform.position, vel, maxSpeed, maxForce, maxVelocity);
        edgeCheck();
        move();

    }

    void move()
    {
        this.transform.position += this.vel;
    }

    void edgeCheck()
    {
        if (this.screenPos.x < 0 || this.screenPos.x > Screen.width)
        {
            Vector3 updatePos = this.transform.position;
            updatePos.x = (this.screenPos.x <= 0) ? 0 : Screen.width;
            this.vel.x *= -1;
        }
        if (this.screenPos.y <= 0 || this.screenPos.y > Screen.height)
        {
            Vector3 updatePos = this.transform.position;
            updatePos.y = (this.screenPos.y <= 0) ? 0 : Screen.height;
            this.vel.y *= -1;
        }
    }

    void die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void rotate()
    {
        Vector3 dir = (this.vel).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;

        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Enemy")) return;

        die();
    }
}
