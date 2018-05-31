using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    int dropRate;
	 float immortalTime = 0f;
    public UIController timer;


    public Canvas itemCanvas;

	void Start(){
		timer = FindObjectOfType<UIController>();
	}
    public void getItem(PlayerController player)
    {
        dropRate = Random.Range(0, 100);
        Debug.Log("Item No:" + dropRate);
        if (dropRate >= 0 && dropRate < 30)
        {
            PlayerController.life += 1; //add 1 life
            timer.showItemIcon(1);
            
        }
        else if (dropRate >= 30 && dropRate < 65)
        {
			immortalTime = 10 ; //10 sec that can go thought obstacle  
			player.setNextImmortalTime(immortalTime);
             timer.showItemIcon(2);
        }
        else
        {
            timer.setRemainingTime(30);//add time 30 sec
             timer.showItemIcon(3);
        }
    }
}
