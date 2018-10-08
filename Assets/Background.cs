using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {
    public Color BakgrundColor;
    public SpriteRenderer Rend;

	// Use this for initialization
	void Start ()
    {
		BakgrundColor = new Color (Random.value, Random.value, Random.value);
        Rend.color = BakgrundColor;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
