using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;                                 

public class gameover : MonoBehaviour
{
    public TextMeshProUGUI point;
    public void Setup(int score)
    { 
    gameObject.SetActive(true);
        point.text = score.ToString() + "POINTS";
    }

}