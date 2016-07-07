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
    public float FRange = 100f;
    public float LRange = 200f;
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
        if (Input.GetButtonDown("Fire1") && Lmana > 50f)
        {
            Shoot();
            Lmana -= 50f;
        }
        else if (Input.GetButtonDown("Fire1") && Lmana < 50f)
        {
            Debug.Log("mana too low");
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
}
