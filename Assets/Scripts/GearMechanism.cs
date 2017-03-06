using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearMechanism : MonoBehaviour {
    public bool hasGear = false;
    public bool readyToRecieve = false;
    public bool readyToFire = false;
    public GameObject Gear;
    public Rigidbody rb;
	// Use this for initialization
	void Start () {
        Gear.SetActive(false);
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if ((Input.GetButton("FireGear") || Input.GetKeyUp(KeyCode.Space)) && hasGear) {
            launchGear();
        }
	}

    private void pickUpGear() {
        Gear.SetActive(true);
    }
    private void launchGear()
    {
        Gear.SetActive(false);
        hasGear = false;
        //TODO create new gear and actually move it
       GameObject newGear = Instantiate(Gear,Gear.transform);
        newGear.transform.parent = null;
        newGear.SetActive(true);
        newGear.AddComponent<Rigidbody>();
        Rigidbody gearRB = newGear.GetComponent<Rigidbody>();
        gearRB.AddRelativeForce(Vector3.back * 3000);
        newGear.GetComponent<BoxCollider>().enabled = true;
    }
    private void setUpNewGear() {
        //TODO set up colliders and instantiate gear;
    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "GearChute" && !hasGear)
        {
            resetColliderPos();
            pickUpGear();
            hasGear = true;
        }

    }
    private void resetColliderPos() {
        rb.velocity = new Vector3(0, 0, 0);
    }
}
