using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeppControls : MonoBehaviour
{
    [Header("ShipControls")]
    public float MovementSpeed;
    public float RotationSpeed;
    public int SpeedIncrease;
    public SpriteRenderer Rend;
    [Header("Timer")]
    public float TimerCount;
    public int TimerIncrease = 1;
    [Header("ShipColor")]
    public int ShipColorNumber;
    public Color ShipColor;
    public SpriteRenderer RandomColor;
    [Header("Ship")]
    public Sprite[] SkeppSprite;
    public int SkeppDecider;
    [Header("Pulsating")]
    public float FadeDuration = 1f;
    public Color PulseColor1;
    public Color PulseColor2;
    public Material Material;
    private Color StartColor;
    private Color EndColor;
    private float LastColorChangeTime;

    // Use this for initialization
    void Start()
    {
        SpeedIncrease = TimerIncrease + 1;

        PulseColor1 = new Color(Random.value, Random.value, Random.value);
        PulseColor2 = new Color(Random.value, Random.value, Random.value);

        //väljer färgerna för pulseringen
        Material = GetComponent<Renderer>().material;
        StartColor = PulseColor1;
        EndColor = PulseColor2;

        //Ger en slumpässigt movement speed
        MovementSpeed = Random.Range(1, 11);

        //Gör så att det spawnar på ett slumpmässigt ställe
        transform.Translate(Random.Range(-9, 10), Random.Range(-4, 5), 0);

        //gör så att skeppets sprite blir slumpmässigt
        SkeppDecider = Random.Range(1, 5);

        if (SkeppDecider == 1)
        {
            GetComponent<SpriteRenderer>().sprite = SkeppSprite[0];
        }
        if (SkeppDecider == 2)
        {
            GetComponent<SpriteRenderer>().sprite = SkeppSprite[1];
        }
        if (SkeppDecider == 3)
        {
            GetComponent<SpriteRenderer>().sprite = SkeppSprite[2];
        }
        if (SkeppDecider == 4)
        {
            GetComponent<SpriteRenderer>().sprite = SkeppSprite[3];
        }




    }

    // Update is called once per frame
    void Update()
    {
        if(SpeedIncrease == TimerIncrease)
        {
            MovementSpeed += 1;
            RotationSpeed += 10;
            SpeedIncrease += 1;
        }
        if (MovementSpeed == 25)
        {
            MovementSpeed -= 1;
            SpeedIncrease -= 1;
            RotationSpeed -= 10;
        }
        

        //gör så att den konstant åker framåt
        transform.Translate(MovementSpeed * Time.deltaTime, 0, 0, Space.Self);

        //timern tickar uppåt
        TimerCount += 1 * Time.deltaTime;

        if (TimerCount > TimerIncrease)
        {
            Debug.Log(string.Format("Timer: {0}", TimerIncrease));
            TimerIncrease += 1;
        }

        //kan svänga höger och bli blå
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, -RotationSpeed * Time.deltaTime);

        }
        //kan svänga vänster och bli grön
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, RotationSpeed * 0.6f * Time.deltaTime);

        }
        //när man håller inne S så går man hälften så fort
        if (Input.GetKeyDown(KeyCode.S))
        {
            MovementSpeed /= 2;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            MovementSpeed *= 2;
        }
        //när man trycker på space så får skeppet en slumpmässig färg
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShipColor = new Color(Random.value, Random.value, Random.value, 1.0f);
            Rend.color = ShipColor;
        }

        //gör så att skeppet "warpar" runt skärmen
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
        //pulsating colors
        var ratio = (Time.time - LastColorChangeTime / FadeDuration);
        ratio = Mathf.Clamp01(ratio);
        Material.color = Color.Lerp(StartColor, EndColor, ratio);
        if (ratio == 1f)
        {
            LastColorChangeTime = Time.time;

            var temp = StartColor;
            StartColor = EndColor;
            EndColor = temp;
        }
    }
}
