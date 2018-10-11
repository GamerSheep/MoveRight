using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    public int speed;
    public int rotate;

    // Use this for initialization
    void Start()
    {
        speed = Random.Range(4, 10);
        rotate = Random.Range(180, 361);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0, Space.World);
        transform.Rotate(0, 0, rotate * Time.deltaTime);

        if (transform.position.x < -18)
        {
            transform.position = new Vector3(18, transform.position.y);
        }
        if (transform.position.x > 18)
        {
            transform.position = new Vector3(-18, transform.position.y);
        }
        if (transform.position.y < -10)
        {
            transform.position = new Vector3(transform.position.x, 10);
        }
        if (transform.position.y > 10)
        {
            transform.position = new Vector3(transform.position.x, -10);
        }
    }
}
