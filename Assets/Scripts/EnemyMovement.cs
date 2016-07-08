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

        if (Physics.Raycast(transform.position, transform.forward, out Hit, 7f, Mask))
        {
            if (Hit.transform != transform)
            {
                dir += Hit.normal * 12f;
            }
            if (Hit.transform.tag == "Fence")
            {
                speed = 0;
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

            if (Hit.transform.tag == "Fence")
            {
                speed = 0;
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
            if (Hit.transform.tag == "Fence")
            {
                speed = 0;
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
}