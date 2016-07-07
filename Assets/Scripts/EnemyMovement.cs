using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    public GameObject player;
    public float speed = 4f;
    public float health = 100f;
    public Vector3 playerPos;
    private bool OnFire = false;
    public ParticleEmitter fireEffect;
    // Use this for initialization
    void Start () {
	

            
	}
	
	// Update is called once per frame
	void Update () {

        playerPos = player.transform.position;

        transform.position = Vector3.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);
            
	}

    void ApplyDamage(float damage)
    {
        health -= damage;

        if (health < 0)
            Destroy(this.gameObject);
    }
    IEnumerator fireDamage(float DamPerSec, float damageDuration, float damageCount)
    {
        float count = 0f;
        if (OnFire != true)
        {
            fireEffect.emit = true;
            OnFire = true;
            while (count < damageCount)
            {
                health -= DamPerSec;
                count++;
                yield return new WaitForSeconds(damageDuration);
            }
            fireEffect.emit = false;
            OnFire = false;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            PlayerController HP = other.GetComponent<PlayerController>();

            
        }
    }
}
