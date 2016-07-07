using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField]
    private LayerMask Mask;

    public GameObject player;

    //public GameObject Test;

    public float speed;

   // Vector3 playerPos;

    //public float LRange = 20f;

    //Transform target;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //playerPos = player.transform.position;

        //transform.position = Vector3.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);

        /*var q = Quaternion.LookRotation(player.transform.position - transform.position);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 20 * Time.deltaTime);*/




        var dir = (player.transform.position - transform.position).normalized;

        RaycastHit Hit;

        if (Physics.Raycast(transform.position, transform.forward, out Hit, 5f, Mask))
        {
            if (Hit.transform != transform)
            {
                dir += Hit.normal * 10f;
            }
        }

        var leftR = transform.position;
        var rightR = transform.position;

        leftR.x -= 2;
        rightR.x += 2;

        if (Physics.Raycast(leftR, transform.forward, out Hit, 5f, Mask))
        {
            if (Hit.transform != transform)
            {
                dir += Hit.normal * 10f;
            }
        }

        if (Physics.Raycast(rightR, transform.forward, out Hit, 5f, Mask))
        {
            if (Hit.transform != transform)
            {
                dir += Hit.normal * 10f;
            }
        }

        var rot = Quaternion.LookRotation(dir);

        transform.rotation = Quaternion.Slerp(transform.rotation, rot, 2 * Time.deltaTime);
        transform.position += transform.forward * 10 * Time.deltaTime;


    }
}