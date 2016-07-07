using UnityEngine;
using System.Collections;

public class AttackScript : MonoBehaviour {

    [SerializeField]
    private Camera Cam;

    [SerializeField]
    private LayerMask Mask;

    public float MaxLmana = 200f;
    public float MaxFmana = 300f;
    public float Lmana = 200f;
    public float Fmana = 300f;
    public float FRange = 100f;
    public float LRange = 200f;
    public float ThrowThrust = 1000f;

    public GameObject FireBall;
    public GameObject firefist;
	// Use this for initialization
	void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Lmana < MaxLmana)
        {
            Lmana++;
        }
        if (Fmana < MaxFmana)
        {
            Fmana++;
        }
        if (Input.GetButtonDown("Fire1") && Lmana > 50f)
        {
            Shoot();
            Lmana -= 50f;
        }
        else if (Input.GetButtonDown("Fire1") && Lmana < 50f)
        {
            Debug.Log("lightning mana too low");
        }

        if (Input.GetButtonDown("Fire2") && Fmana > 75f)
        {
            LobFireBall();
            Fmana -= 75f; 
        }
	}
    void Shoot()
    {
        RaycastHit Hit;

        if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out Hit, LRange, Mask))
        {
            Debug.Log("we hit: " + Hit.collider.name);
        } 
    }
    void LobFireBall()
    {
        GameObject Ball = Instantiate(FireBall) as GameObject;
        Ball.transform.position = transform.position + Cam.transform.forward * 2;
        Rigidbody rb = Ball.GetComponent<Rigidbody>();
        rb.velocity = Cam.transform.forward * 40f;
        

    }
}
