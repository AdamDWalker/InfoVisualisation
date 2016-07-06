using UnityEngine;
using System.Collections;

public class FireballAOE : MonoBehaviour {

    public float radius = 5.0f;

    public float power = 10.0f;
    //public GameObject GranageObject;

    public Transform particalEffect;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        

    }
    void OnTriggerEnter()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
            EnemyMovement enemy = hit.GetComponent<EnemyMovement>();
            if (enemy != null)
            {
                float proximity = (explosionPos - enemy.transform.position).magnitude;
                float effect = 1 - (proximity / radius);

               // enemy.ApplyDamage(power * effect);  //apply damage needs to be added to enemys 
            }
            Instantiate(particalEffect, explosionPos, transform.rotation);

        }
    }
}
