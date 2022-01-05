using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField]
    private Sprite enemySprite;

    [SerializeField]
    private Sprite playerSprite;

    [SerializeField]
    private Vector3 startPos;

    [SerializeField]
    private float maxForce;
    [SerializeField]
    private float maxSpeed;

    [SerializeField]
    private float maxVelocity;

    private Vector3 target;

    private Vector3 vel;

    private SeekerBehaviour sb;

    private float restartTime = 1f;
    

    void Start()
    {
        sb = new SeekerBehaviour();
        this.gameObject.GetComponent<Transform>().position = startPos;

        if (this.gameObject.CompareTag("Player")){
            this.vel = new Vector3(0, 0, 0);
            this.GetComponent<SpriteRenderer>().sprite = playerSprite;
        }else if (this.gameObject.CompareTag("Enemy")){
            this.vel = new Vector3(0, 0, 0);
            this.GetComponent<SpriteRenderer>().sprite = enemySprite;
        }
        
    }

    void Update()
    {
        if (this.gameObject.CompareTag("Player")){
            this.target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.target.z = 0;
        }else if (this.gameObject.CompareTag("Enemy")){
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

    void OnTriggerEnter2D (Collider2D other){
        if (other.gameObject.CompareTag("Enemy") && this.gameObject.CompareTag("Player")){
            this.GameOver();
        }
    }

    void OnBecameInvisible()
    {
        if (this.gameObject.CompareTag("Player")){
            this.GameOver();
        }
    }

    void GameOver(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void edgeCheck()
    {
        //todo
    }
}
