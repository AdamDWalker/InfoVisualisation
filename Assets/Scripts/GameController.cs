using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public float MaxSpawn = 10;
    public float CSV = 0;
    public GameObject[] SP;
    public GameObject Enemy;
    public GameObject flag;
    public GameObject pole1;
    public GameObject pole2;
    public float TotalEnemy = 0f;
    public float WaveDelay = 7f;
    private int x = 0;
    private bool WaveStart = false;
    public GameObject canves;
    bool flagsup = true;
    public Text WaveNumber;

    public int objectCount;
    public float xRange = 100;
    public float zRange = 100;

    public int cleanXStart = 0;
    public int cleanXEnd = 25;
    public int cleanZStart = 0;
    public int cleanZEnd = 25;

    public GameObject cloud;
    public float cloudheight;
    // Use this for initialization
    void Start ()
    {
        
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log("enemy count: " + CSV);
        if (TotalEnemy == 0f && WaveStart == false && CSV == 0)
        {
            WaveStart = true;
            StartCoroutine(StartWave());
        }
         else if (CSV < MaxSpawn)
        {
            Spawner();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (flagsup == true)
            {
                flagsup = false;
                Flagsup();

            }
            else if(flagsup == false)
            {
                flagsup = true;
                Flagsup();
            }
        }

	}

    void Spawner(int Wave)
    {
        TotalEnemy = (Wave * 8);
        Debug.Log("the enemy count for wave 1 is: " + TotalEnemy);
        if (TotalEnemy != 0)
        {
            int spchoice = Random.Range(0, 5);
            GameObject enemyobj = Instantiate(Enemy) as GameObject;
            Debug.Log("enemy being spawned");
            enemyobj.transform.position = SP[spchoice].transform.position;
            CSV++;
            TotalEnemy--;   
        }
        WaveStart = false;

    }
    void Spawner()
    {
        if (TotalEnemy != 0)
        {
            int spchoice = Random.Range(0, 5);
            GameObject enemyobj = Instantiate(Enemy) as GameObject;
            Debug.Log("enemy being spawned");
            enemyobj.transform.position = SP[spchoice].transform.position;
            CSV++;
            TotalEnemy--;
        }
    }
    IEnumerator StartWave()
    {
        
        //play some hore noise if the game is in vr mode
        //instantiate a new cloud randomaly over the map here
        x++;
        yield return new WaitForSeconds(WaveDelay);
        Debug.Log("hype hype the coroutine has come! Wave: " + x);
        WaveNumber.text = x.ToString();
        Instantiate(cloud, getSpawnPoint(), Quaternion.identity);
        Spawner(x);
        StopAllCoroutines();

    }
    void Flagsup()
    {
        if (flagsup == true)
        {
            flag.GetComponent<MeshRenderer>().enabled = true;
            pole1.GetComponent<MeshRenderer>().enabled = true;
            pole2.GetComponent<MeshRenderer>().enabled = true;
            canves.SetActive(false);
        }
        else if (flagsup == false)
        {
            flag.GetComponent<MeshRenderer>().enabled = false;
            pole1.GetComponent<MeshRenderer>().enabled = false;
            pole2.GetComponent<MeshRenderer>().enabled = false;
            canves.SetActive(true);
        }


    }

    Vector3 getSpawnPoint()
    {
        Vector3 spawnPoint;
        bool validPoints = false;
        do
        {
            spawnPoint.x = Random.Range(0, xRange);
            spawnPoint.y = cloudheight;
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
