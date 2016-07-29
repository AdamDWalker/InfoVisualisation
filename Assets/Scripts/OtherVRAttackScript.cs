using UnityEngine;
using System.Collections;

namespace NewtonVR.Example
{
    public class OtherVRAttackScript : MonoBehaviour
    {

        public GameObject FireBall;
        public GameObject HPS; 

        private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
        private bool triggerButtonDown = false;
        private bool triggerButtonUp = false;
        private bool triggerButtonPressed = false;

        private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
        private SteamVR_TrackedObject trackedObj;
        public GameObject Fire;
        private GameObject particals;
        private GameObject healthSlider;

        // Use this for initialization
        void Start()
        {
            trackedObj = GetComponent<SteamVR_TrackedObject>();
            particals = Instantiate(Fire) as GameObject;
        }
        // Update is called once per frame
        void Update()
        {
            if (controller == null)
            {
                Debug.Log("Controller not initialized");
                return;
            }
            triggerButtonDown = controller.GetPressDown(triggerButton);
            if (triggerButtonDown)
            {
                //Debug.Log("Trigger Button Down");
                LobFireBall();
            }
            particals.transform.position = this.transform.position;

            //if (SteamVR_Controller.Input(1).GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
            //{
            //    Debug.Log("fireball left");
            //    LobFireBall();
            //}

        }

        void LobFireBall()
        {
            GameObject Ball = Instantiate(FireBall) as GameObject;
            Ball.transform.position = this.transform.position + transform.forward;
            Rigidbody rb = Ball.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * 40f;


        }

    }
}