using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayMove : MonoBehaviour {

    public GameObject Player;

    Rigidbody rigid;
    public float m_Speed = 5.0f;
    public float m_Input;
    //rigidbody = GetComponent<Rigidbody>();
    // Use this for initialization
    
    void Awake ()
    {
        rigid = GetComponent<Rigidbody>();

        //rigidbody.velocity = transform.forward;
        // int x = Player.transform.position();
        //  Player.transform.position();
    }
	private void OnEnable()
    {
        rigid.isKinematic = false;

        m_Input = 0f;
        
    }
    private void OnDisable()
    {
        rigid.isKinematic = true;
    }
	// Update is called once per frame
	void Update ()
    {
        m_Input = Input.GetAxis("Vertical");
        //if(KeyCode)
		//Player.transform.position += Vector3.forward * 5 * Time.deltaTime;
	}
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        Vector3 movement = Player.transform.forward * m_Input * m_Speed * Time.deltaTime;
        rigid.MovePosition(rigid.position + movement);
    }
}
