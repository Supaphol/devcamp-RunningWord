using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerBox : MonoBehaviour
{
    AnswerBoxController abc;
    public bool isFill = false;
    void Start(){
        abc = FindObjectOfType<AnswerBoxController>();
    }
    public int ans;
    public void sentValue(int value){
        abc.checkLetter(value);
    }
}
