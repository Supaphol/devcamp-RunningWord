using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoPlayScene : MonoBehaviour {

private int stage =1;
private int level =1;

public static int last =0;
private string text ;
private float currentTime;

	// Use this for initialization
	void Start () {
			level = last % 5 + 1;
			stage = last / 5 + 1;

		currentTime = Time.time+3.0f;
		text = stage+"-"+level;
		last ++;
	}

	// Update is called once per frame
	void Update () {
		
		if(Time.time > currentTime){
			SceneManager.LoadScene(text);
		}
	}
}
