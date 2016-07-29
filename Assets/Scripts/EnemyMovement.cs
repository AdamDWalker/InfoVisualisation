using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField]
    private LayerMask Mask;

    private GameObject player;
    public GameObject FireBall;
    private GameObject ControllerObj;

    //public GameObject Test;

    public float speed;

    private int counter = 0;
    public int counterLimit = 10;

    public float health = 100f;
    private bool OnFire = false;
    public ParticleEmitter fireEffect;
    public GameObject StopZone;
 
    //Transform target;

    private NavMeshAgent enemy;

    // Use this for initialization
    void Start()
    {
        ControllerObj = GameObject.FindGameObjectWithTag("Controller");
        

        switch (Random.Range(0, 3))
        {
            case 0:
                player = GameObject.FindWithTag("Target1");
                
                break;
            case 1:
                player = GameObject.FindWithTag("Target2");
                break;
            case 2:
                player = GameObject.FindWithTag("Target3");
                break;
            default:
                player = GameObject.FindWithTag("`1");
                break;
        }
        enemy = GetComponent<NavMeshAgent>();
        RenderSettings.skybox.SetColor("_Tint", Color.grey);
    }

    // Update is called once per frame
    void Update()
    {
        
        //playerPos = player.transform.position;

        //transform.position = Vector3.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);

        /*var q = Quaternion.LookRotation(player.transform.position - transform.position);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 20 * Time.deltaTime);*/

        enemy.SetDestination(player.transform.position);



        Vector3 dir = (player.transform.position - transform.position).normalized;

        Debug.DrawRay(transform.position, dir, Color.red);
        Debug.DrawLine(transform.position, player.transform.position, Color.blue);

        RaycastHit Hit;

        if (Physics.Raycast(transform.position, transform.forward, out Hit, 7f, Mask))
        {
            if (Hit.transform != transform)
            {
                dir += Hit.normal * 12f;
            }
            if (Hit.transform.tag == "Player")
            {
                enemy.Stop();
                speed = 0;
                player = GameObject.FindWithTag("Player");
                //StartCoroutine(LobFireBall());

                if (counter == 0) { LobFireBall(); counter = 10; }
                else { counter--; }
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

        /*if (Physics.Raycast(leftR, transform.forward, out Hit, 7f, Mask))
        {
            if (Hit.transform != transform)
            {
                dir += Hit.normal * 12f;
            }

            if (Hit.transform.tag == "Player")
            {
               // enemy.Stop();

                //speed = 0;
                //StartCoroutine(LobFireBall());
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
               // enemy.Stop();
                //speed = 0;
                //StartCoroutine(LobFireBall());

                
            }

            if (Hit.transform.tag == "BackTerrain")
            {
                transform.rotation = Quaternion.LookRotation(dir);
            }
        }*/

        ///////Quaternion rot = Quaternion.LookRotation(dir);

        //////transform.rotation =  Quaternion.Slerp(transform.rotation, rot, 3 * Time.deltaTime);

        transform.position += transform.forward * speed * Time.deltaTime;

        transform.LookAt(player.transform);
    }

    void LobFireBall()
    {
        Debug.Log("the enemyshould be shooting");
        //yield return new WaitForSeconds(0);
        GameObject Ball = Instantiate(FireBall) as GameObject;
        Ball.transform.position = transform.position + transform.forward;
        Rigidbody rb = Ball.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * 40f;
        Debug.DrawLine(transform.position, transform.position + transform.forward);
        ControllerObj.transform.GetComponent<GameController>().healthvalue--;
        StopAllCoroutines();
    }

    public void ApplyDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
            Destroy(this.gameObject);
        ControllerObj.transform.GetComponent<GameController>().CSV--;

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
   /* void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerController HP = other.GetComponent<PlayerController>();
            HP.health--;
        }
        if (other.gameObject.tag == "Target1" || other.gameObject.tag == "Target2" || other.gameObject.tag == "Target3")
        {
            Debug.Log("in the area");
            //StartCoroutine(LobFireBall());
            speed = 0f;
        }
    }*/
}