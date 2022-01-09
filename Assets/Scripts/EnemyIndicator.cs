using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIndicator : MonoBehaviour
{
    [SerializeField]
    private GameObject indicator;

    private SpriteRenderer indicatorRenderer;

    private bool visible;

    private Vector3 screenCords;


    void Start()
    {
        this.indicator = Instantiate(indicator);
        this.indicatorRenderer = indicator.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        this.screenCords = Camera.main.WorldToScreenPoint(this.transform.position);

        visible = !(this.screenCords.x < 0 || this.screenCords.x > Screen.width || this.screenCords.y < 0 || this.screenCords.y > Screen.height);

        if (!visible)
        {
            float xPos = Mathf.Clamp(screenCords.x, 0, Screen.width) * 0.9f + Screen.width * 0.05f;
            float yPos = Mathf.Clamp(screenCords.y, 0, Screen.height) * 0.9f + Screen.height * 0.05f;

            Debug.Log(xPos + " : " + yPos);
            Vector3 newPos = Camera.main.ScreenToWorldPoint(new Vector3(xPos, yPos, 0));

            indicator.transform.position = newPos;

        }
        //indicatorRenderer.enabled = !visible;
    }
}
