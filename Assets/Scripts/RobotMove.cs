using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RobotMove : MonoBehaviour {
    public float moveSpeed,rotateSpeed,strafeSpeed,climbRotateSpeed,climbSpeed;
    public GameObject Gui;
    Rigidbody rb;
    bool done;
    int framesPassed;
	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
        Time.timeScale = 1;
    }
	
	// Update is called once per frame
	void Update () {
        joystickDrive();
        keyBoarDrive();
        if (done) {
            if(framesPassed>=4)
                Gui.SendMessage("gameOver");
            framesPassed++;
        }
        
	}
    IEnumerator wait() {
        yield return new WaitForSeconds(2);
    }
    void keyBoarDrive() {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKey(KeyCode.W)) {
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.back * Time.deltaTime * strafeSpeed);
        }
            if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * strafeSpeed);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.down * Time.deltaTime * rotateSpeed);
        }
        if (gameObject.transform.position.y> 4.41336)
        {
            gameObject.transform.position.Set(gameObject.transform.position.x,4.41336f, gameObject.transform.position.z);
        }

    }
    void joystickDrive()
    {

        if (Input.GetButton("AutoLineUp"))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * strafeSpeed);
        }
        else
        {
            float speedMult;
            if (Input.GetButton("HalfSpeed"))
            {
                speedMult = .5f;
            }
            else
            {
                speedMult = getSpeedMult();
            }
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * Input.GetAxis("Y") * speedMult);
            transform.Translate(Vector3.back * Time.deltaTime * strafeSpeed * Input.GetAxis("X") * speedMult);
            transform.Rotate(Vector3.down * Time.deltaTime * rotateSpeed * Input.GetAxis("R") * speedMult);
        }

    }
    float getSpeedMult() {
        return (Input.GetAxis("speed")*-.4f)+.6f;
    }
    bool isClimbing = false;
    void climb() {
        if (!isClimbing) {
            transform.Translate(Vector3.down * 10);
            rb.useGravity = false;
            //transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, 90);
            transform.Rotate(Vector3.back *90);
            transform.Translate(Vector3.up * 3.5f);
            strafeSpeed = 0;
            moveSpeed = 0;
            rotateSpeed = 0;
            isClimbing = true;
        }
        //gameObject.transform.rotation.Set(transform.rotation.x,transform.rotation.y,-90,transform.rotation.w);
        //transform.Rotate(Vector3.up * Time.deltaTime * climbRotateSpeed);
        transform.Translate(Vector3.right  * Time.deltaTime * climbSpeed);
    }
    void stopClimbing() {
        climbSpeed = 0;
        done = true;
    }
}
