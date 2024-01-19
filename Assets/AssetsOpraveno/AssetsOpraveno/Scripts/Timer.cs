using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float cas = 120f;
    public Text Timer_txt;
    public GameObject canvas;

    void Update()
    {
        if (cas > 0)
        {
            cas -= Time.deltaTime;

            int minuty = Mathf.FloorToInt(cas / 60);
            int sekundy = Mathf.FloorToInt(cas % 60);
            Timer_txt.text = string.Format("{0:00}:{1:00}", minuty, sekundy);
        }
        else
        {
            PausniHru();
        }
              
    }
    public void PausniHru()
    {
        Timer_txt.text = " ";
        canvas.SetActive(true);
    }
}
