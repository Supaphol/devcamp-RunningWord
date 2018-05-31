using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    public float baseTime ;
    public Text timer;
	public Text lifeRemaining;
    public Text scoreText;

    public static int score =0 ;

    public GameObject lifeItemCanvas;
    public GameObject timeItemCanvas;
    public GameObject immortalItemCanvas;

    public static float remainingTime;

    public static float startTime;
    public PlayerController player;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        startTime = Time.time;
    }

    public static void increaseScore(int value){
        score += value;
    }

    void Update()
    {
		if(player == null) return;

        remainingTime = (int)(baseTime - Time.time + startTime);

        scoreText.text = "score : " + score;

		lifeRemaining.text = "X " + PlayerController.life ;

        if (remainingTime >= 1 )
        {
            timer.text = "" + remainingTime;
        }
        else
        {
            remainingTime = 0;
            timer.text = "" + remainingTime;
            player.Die();
        }
    }
    public void setRemainingTime(int time)
    {
        startTime = startTime + time;
    }

    public void showItemIcon(int itemNum){
        if(itemNum ==1){
            GameObject item = (GameObject)Instantiate(lifeItemCanvas);
            Destroy(item,1);
        }
        if(itemNum ==2){
            GameObject item = (GameObject)Instantiate(immortalItemCanvas);
            Destroy(item,9f);
        }
        if(itemNum ==3){
            GameObject item = (GameObject)Instantiate(timeItemCanvas);
            Destroy(item,1);
        }
    }

    public static void decreaseTime(){
       startTime -=10;
    } 

    public static float getRemainingTime(){
        return remainingTime;
    }

}
