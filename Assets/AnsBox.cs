using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnsBox : MonoBehaviour {
	public int ans;
	bool isFill = false;
	public bool isAnswer(int num){
		if(num == ans && !isFill){
			isFill = true;
			// change secen
			return true;
		}
		return false;
	}
	void cleared(){
		//change scene
	}

}
