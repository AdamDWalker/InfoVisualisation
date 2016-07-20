using System.Collections;
using UnityEngine;

public class EnemyMovement : GameController
{

    [SerializeField]
    private LayerMask Mask;

    public GameObject player;
    public GameObject FireBall;


    //public GameObject Test;

    public float speed;

    public float health = 100f;
    private bool OnFire = false;
    public ParticleEmitter fireEffect;
    //Transform target;

  //  private NavMeshAgent enemy;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");
     //   enemy = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        //playerPos = player.transform.position;

        //transform.position = Vector3.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);

        /*var q = Quaternion.LookRotation(player.transform.position - transform.position);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 20 * Time.deltaTime);*/

      //  enemy.SetDestination(player.transform.position);


        
        var dir = (player.transform.position - transform.position).normalized;

        RaycastHit Hit;

        if (Physics.Raycast(transform.position, transform.forward, out Hit, 7f, Mask))
        {
            if (Hit.transform != transform)
            {
                dir += Hit.normal * 12f;
            }
            if (Hit.transform.tag == "Player")
            {
                speed = 0;
                LobFireBall();

            }
            if (Hit.transform.tag == "BackTerrain")
            {
                transform.rotation = Quaternion.LookRotation(dir);
            }
        }

        var leftR = transform.position;
        var rightR = transform.position;

        leftR.x -= 2;
        rightR.x += 2;

        if (Physics.Raycast(leftR, transform.forward, out Hit, 7f, Mask))
        {
            if (Hit.transform != transform)
            {
                dir += Hit.normal * 12f;
            }

            if (Hit.transform.tag == "Player")
            {
                speed = 0;
                LobFireBall();

            }

            if (Hit.transform.tag == "BackTerrain")
            {
                transform.rotation = Quaternion.LookRotation(dir);
            }
        }

        if (Physics.Raycast(rightR, transform.forward, out Hit, 7f, Mask))
        {
            if (Hit.transform != transform)
            {
                dir += Hit.normal * 12f;
            }
            if (Hit.transform.tag == "Player")
            {
                speed = 0;
                LobFireBall();
            }

            if (Hit.transform.tag == "BackTerrain")
            {
                transform.rotation = Quaternion.LookRotation(dir);
            }
        }

        var rot = Quaternion.LookRotation(dir);

        transform.rotation = Quaternion.Slerp(transform.rotation, rot, 3 * Time.deltaTime);
        transform.position += transform.forward * speed * Time.deltaTime;

    }

    void LobFireBall()
    {
        GameObject Ball = Instantiate(FireBall) as GameObject;
        Ball.transform.position = transform.position + transform.forward;
        Rigidbody rb = Ball.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * 40f;
    }

    public void ApplyDamage(float damage)
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

            HP.health--;
        }
    }
}