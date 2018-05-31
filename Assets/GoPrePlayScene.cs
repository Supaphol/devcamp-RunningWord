using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoPrePlayScene : MonoBehaviour {

private int stage =1;
private int level =1;

public static int lastScene =1;
private string text ;
private float currentTime;
	// Use this for initialization
	void Start () {
			level = lastScene % 5 + 1;
			stage = lastScene / 5 + 1;

		text = "PrePlayScene"+stage+"-"+level;
		
		if(lastScene < 5){
			SceneManager.LoadScene(text);
		}
		else if (lastScene == 5){
			SceneManager.LoadScene("conPage");
		}

		lastScene ++;
		
	}
}
