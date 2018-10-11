using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    public int speed;
    public int rotate;
    public float direction;
    public float directionY;

    // Use this for initialization
    void Start()
    {
        speed = Random.Range(-4 ,4);
        rotate = Random.Range(180, 361);
        direction = 0.4f;
        directionY = 0.4f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, direction, 0, Space.World);
        transform.Rotate(0, 0, rotate * Time.deltaTime);

        if (transform.position.x < -18)
        {
            transform.position = new Vector3(18, Random.Range(-10, 11));
            direction = Random.Range(-0.5f, 0.5f);
            directionY = Random.Range(-0.5f, 0.5f);
            speed = Random.Range(-4, 5);
        }
        if (transform.position.x > 18)
        {
            transform.position = new Vector3(-18, Random.Range(-10, 11));
            direction = Random.Range(-0.5f, 0.5f);
            directionY = Random.Range(-0.5f, 0.5f);
            speed = Random.Range(-4, 5);
        }
        if (transform.position.y < -10)
        {
            transform.position = new Vector3(Random.Range(-18, 19), 10);
            direction = Random.Range(-0.5f, 0.5f);
            directionY = Random.Range(-0.5f, 0.5f);
            speed = Random.Range(-4, 5);
        }
        if (transform.position.y > 10)
        {
            transform.position = new Vector3(Random.Range(-18, 19), -10);
            direction = Random.Range(-0.5f, 0.5f);
            directionY = Random.Range(-0.5f, 0.5f);
            speed = Random.Range(-4, 5);
        }
    }
}
