using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class hazardLights : MonoBehaviour
{
    // Start is called before the first frame update
    public Button leftLight;
    public Button rightLight;

    Color on;
    Color off;

    //blinking variables
    public float interval = 1f;
    public float startDelay = 0.5f;
    public bool currentState = true;
    public bool TurnedON = false;
    public bool defaultState = true;
    //  bool isBlinking = false;
    void Start()
    {
        ColorUtility.TryParseHtmlString("#054D00", out Color off1);
        ColorUtility.TryParseHtmlString("#63F80F", out Color on1);
        on = on1;
        off = off1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void toggleLight()
    {

        TurnedON = !TurnedON;
        if (TurnedON)
        {
            InvokeRepeating("ToggleState", startDelay, interval);
        }
        else
        {
            CancelInvoke();
            var colors = leftLight.colors;
            colors.selectedColor = off;
            colors.highlightedColor = off;
            colors.normalColor = off;
            leftLight.colors = colors;
            rightLight.colors = colors;
        }

    }

    public void ToggleState()
    {
        // Debug.Log("Blinking!!!!");
        if (currentState)
        {
            currentState = !currentState;
            ColorUtility.TryParseHtmlString("#63F80F", out Color temp);
            var colors = leftLight.colors;
            colors.selectedColor = temp;
            colors.highlightedColor = temp;
            colors.normalColor = temp;
            leftLight.colors = colors;
            rightLight.colors = colors;
        }
        else
        {
            currentState = !currentState;
            ColorUtility.TryParseHtmlString("#054D00", out Color tmep2);
            var colors = leftLight.colors;
            colors.selectedColor = tmep2;
            colors.highlightedColor = tmep2;
            colors.normalColor = tmep2;
            leftLight.colors = colors;
            rightLight.colors = colors;
        }

    }
}
