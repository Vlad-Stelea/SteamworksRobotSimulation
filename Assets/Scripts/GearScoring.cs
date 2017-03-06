using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearScoring : MonoBehaviour {
    public GameObject gear;
    public float highestGear;
    public GameObject scoreKeeper;
    Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}

    private void addGear()
    {
        gear.SetActive(true);
    }
    private void bringUpGear() {
        anim.SetTrigger("Ready");
    }
   public void animationEnded() {
        gear.SetActive(false);
    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Gear")
        {
            Destroy(collision.gameObject);
            addGear();
            bringUpGear();
            scoreKeeper.SendMessage("gearScore");
        }

    }
}
