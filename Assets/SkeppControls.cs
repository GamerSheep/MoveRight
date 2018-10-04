using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeppControls : MonoBehaviour
{
    [Header("ShipControls")]
    public float MovementSpeed;
    public float RotationSpeed;
    public SpriteRenderer rend;
    [Header("Timer")]
    public float TimerCount;
    [Header("ShipColor")]
    public int ShipColorNumber;
    public Color ShipColor;
    public SpriteRenderer RandomColor;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //gör så att den konstant åker framåt
        transform.Translate(MovementSpeed * Time.deltaTime, 0, 0, Space.Self);

        //timern tickar uppåt
        TimerCount += 1 * Time.deltaTime;
        
        print(TimerCount);

        //kan svänga höger och bli blå
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, -RotationSpeed * Time.deltaTime);
            rend.color = Color.blue;
        }
        //kan svänga vänster och bli grön
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, RotationSpeed *0.6f * Time.deltaTime);
            rend.color = Color.green;
        }
        //när man håller inne S så sänks farten med 2
        if (Input.GetKeyDown(KeyCode.S))
        {
            MovementSpeed /= 2;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            MovementSpeed *= 2;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShipColor = new Color(Random.value, Random.value, Random.value, 1.0f);
            rend.color = ShipColor;
        }
            
    }
}
