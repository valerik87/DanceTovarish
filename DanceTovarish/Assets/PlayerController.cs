using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float fVelocityVertical;
    public float fVelocityHorizontal;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float MovementVertical = 0;
        float MovementHorizontal = 0;
        if (Input.GetKey(KeyCode.W))
        {
            MovementVertical = Time.deltaTime * fVelocityVertical;
        }
        if (Input.GetKey(KeyCode.S))
        {
            MovementVertical = -Time.deltaTime * fVelocityVertical;
        }
        if (Input.GetKey(KeyCode.D))
        {
            MovementHorizontal = Time.deltaTime * fVelocityHorizontal;
        }
        if (Input.GetKey(KeyCode.A))
        {
            MovementHorizontal = -Time.deltaTime * fVelocityHorizontal;
        }

        transform.Translate(MovementHorizontal, MovementVertical, 0f);
    }

    
}
