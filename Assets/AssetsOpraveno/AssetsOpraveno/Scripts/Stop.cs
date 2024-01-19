using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop : MonoBehaviour
{
    public GameObject canvas;

    public void PausniHru()
    {
        canvas.SetActive(true);
        Time.timeScale = 0f;
    }
}
