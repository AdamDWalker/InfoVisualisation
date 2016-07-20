using UnityEngine;
using System.Collections;

public class CamaraController : MonoBehaviour {

    Vector2 Mouselook;
    Vector2 Smoother;
    public float sensativity = 5.0f;
    public float smooth = 2.0f;

    GameObject Character;

    // Use this for initialization
    void Start () {
        Character = this.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        var md = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(smooth * sensativity, smooth * sensativity));
        Smoother.x = Mathf.Lerp(Smoother.x, md.x, 1f / smooth);
        Smoother.y = Mathf.Lerp(Smoother.y, md.y, 1f / smooth);
        Mouselook += Smoother;

        transform.localRotation = Quaternion.AngleAxis(-Mouselook.y, Vector3.right);
        Character.transform.localRotation = Quaternion.AngleAxis(Mouselook.x, Character.transform.up);
    }
}
