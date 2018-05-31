using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoxControl : MonoBehaviour {
	public GameObject[] boxs;
	public int[] randomLetter ;
	public char[] ansW ;

	public Sprite[] letter ;
	const int ADDEDRANDOMLETTER = 6;

	// Use this for initialization
	void Start () {
		randomLetter = new int[ansW.Length + ADDEDRANDOMLETTER];
		randomizeLetter();

		int size = boxs.Length;

		int a = randomLetter.Length;
		randomLetter = Shuffle(randomLetter);
		int i = 0;
		while(i != size){
			for(int j = 0 ; j < a && i < size; j++){
				put(i,randomLetter[j]);
				boxs[i].GetComponent<AnswerBox>().ans = randomLetter[j];
				i++;
			}
		}
	}
	
	public T[] Shuffle<T>(T[] array)
	{
		for (int i = array.Length; i > 1; i--)
		{
			// Pick random element to swap.
			int j = Random.Range(0,array.Length-1); // 0 <= j <= i-1

			// Swap.
			T tmp = array[j];
			array[j] = array[i - 1];
			array[i - 1] = tmp;
		}
		return array;
	}

	void put(int index,int value){
		boxs[index].GetComponent<SpriteRenderer>().sprite = letter[value];
	}

	void randomizeLetter(){
		int generatedNumber  = 0;
        for (int i = 0; i < randomLetter.Length ;i++)
        {
            if (i < ansW.Length){
               randomLetter[i] = ansW[i] - 'a';
            }
            else{
				generatedNumber = Random.Range(0,25);
                for (int j = 0; j < i; j++){
                    if (generatedNumber == randomLetter[j])
                    {
						generatedNumber = Random.Range(0,25);
						j = 0;
                    }
				}
				randomLetter[i] = generatedNumber;
            }

        }
    }
}
