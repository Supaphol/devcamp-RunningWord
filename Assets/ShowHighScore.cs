using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHighScore : MonoBehaviour {

	public Text sc ;

	private string s;

	HighScore h;

	// Use this for initialization
	void Start () {
		h = HighScore.LoadHighScore();
		for(int i = 0 ; i< 10 ; i++)
			s +=  h.names[i]+" : "+(h.scores[i]) +"\n";
			sc.text = s;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
