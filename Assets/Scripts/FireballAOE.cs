using UnityEngine;
using System.Collections;

public class FireballAOE : MonoBehaviour {

    public float radius = 5.0f;

    public float power = 10.0f;
    //public GameObject GranageObject;

    public Transform particalEffect;
    public Transform FireEffect;

    public delegate void FireProjectileCollisionDelegate(FireballAOE script, Vector3 pos);

    public ParticleSystem[] ProjectileDestroyParticleSystemsOnCollision;

    public AudioSource ProjectileCollisionSound;
    public ParticleSystem ProjectileExplosionParticleSystem;

    public float ProjectileExplosionRadius = 50.0f;

    [Tooltip("The force of the explosion upon collision.")]
    public float ProjectileExplosionForce = 50.0f;

    [HideInInspector]
    public FireProjectileCollisionDelegate CollisionDelegate;


    void OnTriggerEnter()
    {
      //  Debug.Log("hit something well done!");
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
          //      Debug.Log("enemy hit for some damage");
                float proximity = (explosionPos - enemy.transform.position).magnitude;
                float effect = 1 - (proximity / radius);

                
               enemy.ApplyDamage(100);  //apply damage needs to be added to enemys 
            }
            Instantiate(particalEffect, explosionPos, transform.rotation);
            Instantiate(FireEffect, explosionPos, transform.rotation);
            Destroy(this.gameObject);

        }
    }
    private bool collided;

    public void HandleCollision(GameObject obj, Collision c)
    {
        if (collided)
        {
            // already collided, don't do anything
            return;
        }

        // stop the projectile
        collided = true;
        //Stop();

        // destroy particle systems after a slight delay
        if (ProjectileDestroyParticleSystemsOnCollision != null)
        {
            foreach (ParticleSystem p in ProjectileDestroyParticleSystemsOnCollision)
            {
                GameObject.Destroy(p, 0.1f);
            }
        }

        // play collision sound
        if (ProjectileCollisionSound != null)
        {
            ProjectileCollisionSound.Play();
        }

        // if we have contacts, play the collision particle system and call the delegate
        if (c.contacts.Length != 0)
        {
            ProjectileExplosionParticleSystem.transform.position = c.contacts[0].point;
            ProjectileExplosionParticleSystem.Play();
            CreateExplosion(c.contacts[0].point, ProjectileExplosionRadius, ProjectileExplosionForce);
            if (CollisionDelegate != null)
            {
                CollisionDelegate(this, c.contacts[0].point);
            }
        }
    }
    public static void CreateExplosion(Vector3 pos, float radius, float force)
    {
        if (force <= 0.0f || radius <= 0.0f)
        {
            return;
        }

        // find all colliders and add explosive force
        Collider[] objects = UnityEngine.Physics.OverlapSphere(pos, radius);
        foreach (Collider h in objects)
        {
            Rigidbody r = h.GetComponent<Rigidbody>();
            if (r != null)
            {
                r.AddExplosionForce(force, pos, radius);
            }
        }
    }
}
