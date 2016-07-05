using UnityEngine;
using System.Collections;

/// <summary>
/// Simple script to take a game object and place a number of them around the terrain randomly
/// </summary>
public class PlaceObjects : MonoBehaviour
{

    // This is the object that will be placed in the world and how many times
    public int objectCount;
    public GameObject theObject;

    public GameObject[] spawnObjects = new GameObject[4];

    // This is the height that the object will be placed at (Y coord)
    public float height;

	// Use this for initialization
	void Start()
    {
	    for(int i = 0; i < objectCount; i++)
        {
            //GameObject block = (GameObject)Instantiate(theObject, getSpawnPoint(), transform.rotation);
            Instantiate(spawnObjects[Random.RandomRange(0,4)], getSpawnPoint(), Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update()
    {
	
	}

    Vector3 getSpawnPoint()
    {
        Vector3 spawnPoint;

        spawnPoint.x = Random.Range(0, 500);
        spawnPoint.y = height;
        spawnPoint.z = Random.Range(0, 500);

        return spawnPoint;
    }
}
