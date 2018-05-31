using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetName : MonoBehaviour {
	public static string name;
	public static void ChangeName(string s){
		name = s;
	}
	public static string getName(){
		return name ;
	}
}
