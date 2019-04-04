using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCountdown : MonoBehaviour
{
    public static int lifes;

    Text text;
	void Awake () {
        text = GetComponent<Text>();
        lifes = 20;
	}
	

	void Update ()
    {
        text.text = "lifes" + lifes;
	}
}
