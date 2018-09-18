using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFP : MonoBehaviour {

    Vector2 mouseLook;
    Vector2 smoothV;
    public float sensetivity = 5f;
    public float smoothing = 2f;

    GameObject character;

	void Start ()
    {
        character = this.transform.parent.gameObject;
	}
	

	void Update ()
    {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(sensetivity * smoothing, sensetivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);

        mouseLook += smoothV;
        mouseLook.y = Mathf.Clamp(mouseLook.y, -20f, 50f);


        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
    }
}
