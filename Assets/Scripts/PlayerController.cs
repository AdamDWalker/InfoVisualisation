using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float Speed = 7.0f;
    public float health = 3f;
	// Use this for initialization
	void Start ()
    {
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update ()
    {
        float Tran = Input.GetAxis("Vertical") * Speed;
        float Strafe = Input.GetAxis("Horizontal") * Speed;

        Tran *= Time.deltaTime;
        Strafe *= Time.deltaTime;

        transform.Translate(Strafe, 0, Tran);

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
	}
    void Hit(float damage)
    {

    }
}
