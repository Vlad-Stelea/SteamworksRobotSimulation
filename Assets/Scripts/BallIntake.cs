using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallIntake : MonoBehaviour {
    public GameObject fuelModel;
    public GameObject output;
    ArrayList balls;
	// Use this for initialization
	void Start () {
        balls = new ArrayList();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Fuel") {
            Instantiate(collision.gameObject,gameObject.transform);
            Destroy(collision.gameObject);
        }     
    }
}
