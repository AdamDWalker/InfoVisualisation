using UnityEngine;
using System.Collections;

public class CJScript : MonoBehaviour {

    public float curSpeed = 2;
    public GameObject gremlin;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        CharacterController controller = GetComponent<CharacterController>();
        
        controller.SimpleMove(transform.forward * curSpeed);
        transform.LookAt(gremlin.transform.position);

        
    }
}
 