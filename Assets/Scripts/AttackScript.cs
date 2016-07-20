using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AttackScript : MonoBehaviour {

    [SerializeField]
    private Camera Cam;

    [SerializeField]
    private LayerMask Mask;

    public float MaxLmana = 1000f;
    public float MaxFmana = 1000f;
    public float Lmana = 1000f;
    public float Fmana = 1000f;
    public float ThrowThrust = 1000f;

    public GameObject FireBall;
    public GameObject firefist;
    public GameObject LightFist;
    public GameObject largeL;
    public GameObject midL;
    public GameObject smallL;
    public GameObject largeR;
    public GameObject midR;
    public GameObject smallR;
    public Slider RightHandMana;
    public Slider LeftHandMana;

    private int particalscaler;
    private bool RLoff = false;
    private bool RMoff = false;
    private bool RSoff = false;
    private bool LLoff = false;
    private bool LMoff = false;
    private bool LSoff = false;
    private bool CanOn = true;


    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (Lmana < MaxLmana)
        {
            Lmana++;
        }
        if (Fmana < MaxFmana)
        {
            Fmana++;
        }
        if (Input.GetButtonDown("Fire1") && Lmana > 50f)
        {
            RightLobfireball();
            Lmana -= 50f;
        }

        if (Input.GetButtonDown("Fire2") && Fmana > 50f)
        {
            LobFireBall();
            Fmana -= 50f; 
        }

        if (Input.GetKeyDown(KeyCode.X));
        {
            CanOn = false;
        }

        if (CanOn == true)
        {
            smallR.transform.FindChild("SmallFiresParticleSystem").GetComponent<ParticleSystem>().Stop();
            midR.transform.FindChild("SmallFiresParticleSystem").GetComponent<ParticleSystem>().Stop();
            largeR.transform.FindChild("SmallFiresParticleSystem").GetComponent<ParticleSystem>().Stop();
            largeL.transform.FindChild("SmallFiresParticleSystem").GetComponent<ParticleSystem>().Stop();
            midL.transform.FindChild("SmallFiresParticleSystem").GetComponent<ParticleSystem>().Stop();
            smallL.transform.FindChild("SmallFiresParticleSystem").GetComponent<ParticleSystem>().Stop();

        }
        else if (CanOn == false)
        {
            if (Fmana < 500 && RLoff == false)
            {
                RLoff = true;
                largeR.transform.FindChild("SmallFiresParticleSystem").GetComponent<ParticleSystem>().Stop();
            }
            if (Fmana < 250 && RMoff == false)
            {
                RMoff = true;
                midR.transform.FindChild("SmallFiresParticleSystem").GetComponent<ParticleSystem>().Stop();
            }
            if (Fmana < 50 && RSoff == false)
            {
                RSoff = true;
                smallR.transform.FindChild("SmallFiresParticleSystem").GetComponent<ParticleSystem>().Stop();
            }
      

            if (Fmana > 500 && RLoff == true)
            {
                RLoff = false;
                largeR.transform.FindChild("SmallFiresParticleSystem").GetComponent<ParticleSystem>().Play();
            }

            if (Fmana > 250 && RMoff == true)
            {
                RMoff = false;
                midR.transform.FindChild("SmallFiresParticleSystem").GetComponent<ParticleSystem>().Play();
            }
            if (Fmana > 50 && RSoff == true)
            {
                RSoff = false;
                smallR.transform.FindChild("SmallFiresParticleSystem").GetComponent<ParticleSystem>().Play();
            }


            //var em = LightFist.GetComponent<ParticleSystem>().emission;
            //var rate = new ParticleSystem.MinMaxCurve();
            //rate.constantMax = Lmana;
            //em.rate = rate;

            if (Lmana < 500 && LLoff == false)
            {
                LLoff = true;
                largeL.transform.FindChild("SmallFiresParticleSystem").GetComponent<ParticleSystem>().Stop();
            }
            if (Lmana < 250 && LMoff == false)
            {
                LMoff = true;
                midL.transform.FindChild("SmallFiresParticleSystem").GetComponent<ParticleSystem>().Stop();
            }
            if (Lmana < 50 && LSoff == false)
            {
                LSoff = true;
                smallL.transform.FindChild("SmallFiresParticleSystem").GetComponent<ParticleSystem>().Stop();
            }


            if (Lmana > 500 && LLoff == true)
            {
                LLoff = false;
                largeL.transform.FindChild("SmallFiresParticleSystem").GetComponent<ParticleSystem>().Play();
            }

            if (Lmana > 250 && LMoff == true)
            {
                LMoff = false;
                midL.transform.FindChild("SmallFiresParticleSystem").GetComponent<ParticleSystem>().Play();
            }
            if (Lmana > 50 && LSoff == true)
            {
                LSoff = false;
                smallL.transform.FindChild("SmallFiresParticleSystem").GetComponent<ParticleSystem>().Play();
            }
        }
            RightHandMana.value = Fmana;
            LeftHandMana.value = Lmana;
        

    }
    void LobFireBall()
    {
        GameObject Ball = Instantiate(FireBall) as GameObject;
        Ball.transform.position = firefist.transform.position + Cam.transform.forward;
        Rigidbody rb = Ball.GetComponent<Rigidbody>();
        rb.velocity = Cam.transform.forward * 40f;
        

    }
    void RightLobfireball()
    {
        GameObject Ball = Instantiate(FireBall) as GameObject;
        Ball.transform.position = LightFist.transform.position + Cam.transform.forward;
        Rigidbody rb = Ball.GetComponent<Rigidbody>();
        rb.velocity = Cam.transform.forward * 40f;
    }
}
