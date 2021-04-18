using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class carScripts : MonoBehaviour
{
    public GameObject turnKnob;


    public GameObject SteeringWheel;
    public bool movingScreen = false;
    public bool steer = false;
    public Animator wind;
    public Animator wind2;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ToggleWindScreen()
    {
        movingScreen = !movingScreen;
        wind.gameObject.GetComponent<Animator>().enabled = movingScreen;
        wind2.gameObject.GetComponent<Animator>().enabled = movingScreen;

        wind.Play("windsheild");
        wind2.Play("windsheild");
    }

    public void ToggleSteering()
    {
        steer = !steer;

        SteeringWheel.GetComponent<Renderer>().enabled = steer;

    }

    public void changeScene()
    {
        SceneManager.LoadScene("Dashboard");
    }


}
