using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planets : MonoBehaviour {
    public int rotate;
	// Use this for initialization
	void Start () {
        rotate = 10;
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 0, rotate * Time.deltaTime);
    }
}
