using UnityEngine;
using System.Collections;

namespace NewtonVR.Example
{
    public class VRAttackScript : MonoBehaviour
    {

        public GameObject FireBall;

        private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
        private bool triggerButtonDown = false;
        private bool triggerButtonUp = false;
        private bool triggerButtonPressed = false;

        private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
        private SteamVR_TrackedObject trackedObj;
        public GameObject Fire;
        private GameObject particals;

        public float MaxLmana = 1000f;
        public float Lmana = 1000f;

        public GameObject largeL;
        public GameObject midL;
        public GameObject smallL;


        private int particalscaler;
        private bool LLoff = false;
        private bool LMoff = false;
        private bool LSoff = false;
        public GameObject minimap;
        // Use this for initialization
        void Start()
        {
            trackedObj = GetComponent<SteamVR_TrackedObject>();
           particals =  Instantiate(Fire) as GameObject;

            minimap = Instantiate(minimap) as GameObject;

        }

        // Update is called once per frame
        void Update()
        {
            if (Lmana < MaxLmana)
            {
                Lmana++;
            }
            if (Input.GetButtonDown("Fire1") && Lmana > 50f)
            {
                Lmana -= 50f;
            }
            if (controller == null)
            {
                Debug.Log("Controller not initialized");
                return;
            }
            triggerButtonDown = controller.GetPressDown(triggerButton);
            if (triggerButtonDown && Lmana > 50f)
            {
                Debug.Log("Trigger Button Down");
                LobFireBall();
            }
            Vector3 mappos = new Vector3(this.transform.position.x, this.transform.position.y - 0.25f, this.transform.position.z);
            particals.transform.position = this.transform.position;
            minimap.transform.position = mappos;// new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 0.5f);       
            //if (SteamVR_Controller.Input(1).GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
            //{
            //    Debug.Log("fireball left");
            //    LobFireBall();
            //}
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
        void LobFireBall()
        {
            GameObject Ball = Instantiate(FireBall) as GameObject;
            Ball.transform.position = this.transform.position + transform.up;
            Rigidbody rb = Ball.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * 40f;
        }
    }
}