using UnityEngine;
using System.Collections;

public class PickupRotator : MonoBehaviour {

    public float spinSpeed = 50f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0f, spinSpeed * Time.deltaTime, 0f);
	}
}
