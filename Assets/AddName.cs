using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddName : MonoBehaviour {

public void changeName(Text t){
	    GetName.ChangeName(t.text);
	}
}
