using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climb : MonoBehaviour {
    public GameObject robot;
    public GameObject Gui;
    bool isClimbing;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isClimbing && Input.GetButton("Climb"))
        {
            robot.SendMessage("climb");
        }
	}
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Rope" && Input.GetButton("Climb")) {
            robot.SendMessage("climb");
            isClimbing = true;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "RopeTop")
        {
            // isClimbing = false;
            Gui.SendMessage("scale");
            robot.SendMessage("stopClimbing");
          
        }
    }

}
