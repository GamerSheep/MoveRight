using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeppControls : MonoBehaviour {

    public float MovementSpeed;
    public float RotationSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(MovementSpeed * Time.deltaTime, 0, 0, Space.Self);

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, -RotationSpeed * Time.deltaTime);
        }

	}
}
