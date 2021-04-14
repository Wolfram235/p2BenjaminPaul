using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class blinkers : MonoBehaviour
{
    public Button leftLight;
    public bool TurnedON = false;

    Color on;
    Color off;

    //blinking variables
    public float interval = 1f;
    public float startDelay = 0.5f;
    public bool currentState = true;
    public bool defaultState = true;
    // bool isBlinking = false;
    // Start is called before the first frame update
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
        /*   if (TurnedON)
          {


          }
          else
          {
              /*  ColorBlock colo = leftLight.colors;
               colo.normalColor = off;
               leftLight.colors = colo; */
        /*  var colors = GetComponent<Button>().colors;
         colors.selectedColor = off;
         colors.highlightedColor = off;
         colors.normalColor = off;
         GetComponent<Button>().colors = colors; */

    }

    public void toggleLight()
    {
        Debug.Log("This is a click test");
        TurnedON = !TurnedON;
        if (TurnedON)
        {
            InvokeRepeating("ToggleState", startDelay, interval);
        }
        else
        {
            CancelInvoke();
            var colors = GetComponent<Button>().colors;
            colors.selectedColor = off;
            colors.highlightedColor = off;
            colors.normalColor = off;
            GetComponent<Button>().colors = colors;
        }

    }



    public void ToggleState()
    {
        Debug.Log("Blinking!!!!");
        if (currentState)
        {
            currentState = !currentState;
            ColorUtility.TryParseHtmlString("#63F80F", out Color temp);
            var colors = GetComponent<Button>().colors;
            colors.selectedColor = temp;
            colors.highlightedColor = temp;
            colors.normalColor = temp;
            GetComponent<Button>().colors = colors;
        }
        else
        {
            currentState = !currentState;
            ColorUtility.TryParseHtmlString("#054D00", out Color tmep2);
            var colors = GetComponent<Button>().colors;
            colors.selectedColor = tmep2;
            colors.highlightedColor = tmep2;
            colors.normalColor = tmep2;
            GetComponent<Button>().colors = colors;
        }

    }

}
