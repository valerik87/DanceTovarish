using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SetColorNetBased : NetworkBehaviour
{

    public SpriteRenderer HatRenderer;

    // Use this for initialization
    public override void OnStartLocalPlayer()
    {
        HatRenderer.material.color = Color.blue;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
