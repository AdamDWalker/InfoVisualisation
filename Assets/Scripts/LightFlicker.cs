using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour {

    private Light thisLight;
    Color originalColour;
    float timePassed;
    float changeValue;


	// Use this for initialization
	void Start ()
    {
        thisLight = this.GetComponent<Light>();

        if(thisLight != null)
        {
            originalColour = thisLight.color;
        }
        else
        {
            enabled = false;
            return;
        }

        changeValue = 0;
        timePassed = 0;

    }

    // Update is called once per frame
    void Update ()
    {

        timePassed = Time.time;
        timePassed = timePassed - Mathf.Floor(timePassed);

        thisLight.color = originalColour * CalculateChange();
	}

    private float CalculateChange()
    {
        changeValue = -Mathf.Sin(timePassed * 12 * Mathf.PI) * 0.05f + 0.95f;
        return changeValue;
    }

}
