using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Drawing;

public class pointmama : MonoBehaviour
{
    public SwipeMove hero;

    void Update()
    {
        string txt = hero.points.ToString();
        gameObject.GetComponent<TextMeshProUGUI>().text = txt;
    }
}
