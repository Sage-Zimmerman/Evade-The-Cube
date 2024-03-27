using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Text health;
    public void UpdateHealthText(float healthText)
    {
        health.text = "Health: " + healthText;
    }
}
