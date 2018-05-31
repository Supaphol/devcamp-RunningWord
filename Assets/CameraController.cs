using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player; 
	float targetaspect = 4.0f / 3.0f;
	private Vector3 offset;  
	// Use this for initialization
	void Start () {
		offset = (transform.position - player.transform.position);
		
	}
	
	// Update is called once per frame
	void Update () {
		if(player == null)
		return;
		transform.position = (new Vector3(player.transform.position.x,0,0)) + offset ;
	}
}

