using UnityEngine;
using System.Collections;

/// <summary>
/// Simple script to take a game object and place a number of them around the terrain randomly
/// </summary>
public class PlaceObjects : MonoBehaviour
{

    // This is the object that will be placed in the world and how many times
    public int objectCount;
    public float xRange = 100;
    public float zRange = 100;

    // This is a clean zone that will be for the player camp, and no stuff will spawn there
    public int cleanXStart = 0;
    public int cleanXEnd = 50;
    public int cleanZStart = 0;
    public int cleanZEnd = 50;

    //public GameObject terrain;
    public GameObject[] spawnObjects = new GameObject[4];

    // This is the height that the object will be placed at (Y coord)
    public float height;

	// Use this for initialization
	void Start()
    {
	    for(int i = 0; i < objectCount; i++)
        {
            //GameObject block = (GameObject)Instantiate(theObject, getSpawnPoint(), transform.rotation);
            Instantiate(spawnObjects[Random.RandomRange(0,spawnObjects.Length)], getSpawnPoint(), Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update()
    {
	
	}

    Vector3 getSpawnPoint()
    {
        Vector3 spawnPoint;
        bool validPoints = false;
        do
        {
            spawnPoint.x = Random.Range(0, xRange);
            spawnPoint.y = height;
            spawnPoint.z = Random.Range(0, zRange);

            if ((spawnPoint.x > cleanXStart && spawnPoint.x < cleanXEnd) && (spawnPoint.z > cleanZStart && spawnPoint.z < cleanZEnd))
            {
                validPoints = false;
            }
            else
            {
                validPoints = true;
            }
        } while (!validPoints);

        return spawnPoint;
    }
}
