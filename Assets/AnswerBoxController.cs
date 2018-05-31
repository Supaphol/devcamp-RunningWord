using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerBoxController : MonoBehaviour {

    public AnswerBox[] ab;

	public Sprite[] letter ;


	void put(int index){Debug.Log(index);
		ab[index].GetComponent<Image>().sprite = letter[ab[index].ans];
	}
	
	int count = 0;
    public void checkLetter(int value)
    {
		int c=0;
        for (int i = 0; i < ab.Length; i++)
        {
            if (ab[i].ans == value)
            {
				if(ab[i].isFill == false){	
				put(i);				
				count++;
				ab[i].isFill = true;
				}
				c = 1;
				UIController.increaseScore(100);
				if(count == ab.Length){
					UIController.increaseScore((int)UIController.getRemainingTime()*10);
					new GameObject().AddComponent<GoPrePlayScene>();
				}
					if(count == ab.Length && GoPlayScene.last == 5){
					UIController.increaseScore((int)UIController.getRemainingTime()*10);
					HighScore h = HighScore.LoadHighScore();
        			h.Add(UIController.score,GetName.getName(),h);
        			HighScore.SaveHighScore(h);
					new GameObject().AddComponent<GoPrePlayScene>();
				}
            }

        }
		if(c==0){
			UIController.decreaseTime();
		}
    }
}
