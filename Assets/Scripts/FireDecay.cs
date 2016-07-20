using UnityEngine;
using System.Collections;

public class FireDecay : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(Decay());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    IEnumerator Decay()
    {
        yield return new WaitForSeconds(6f);

        Destroy(this.gameObject);
    }
}
