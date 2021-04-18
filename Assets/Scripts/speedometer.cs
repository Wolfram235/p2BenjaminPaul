using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class speedometer : MonoBehaviour
{
    private Transform odo;
    private Transform taco;
    public Text speedText;
    public Text gearText;
    public Text TripText;
    private const float zeroSpeed = 113.16f;
    private const float MaxSpeed = -118.94f;

    private const float zeroTaco = 116.51f;
    private const float MaxTaco = -121.25f;
    private float speedMax;
    private float speed;

    private float tacoMax;
    private float tacoValue;
    private float timeElapsed;
    private float distanceCovered;
    private bool upPressed = false;
    private bool tripped1 = false;
    private bool tripped2 = false;
    private bool tripped3 = false;

    public GameObject cruiseControlSign;
    private int gears = 1;
    // private float gearChange = 58.69f;
    private bool cruiseControl = false;

    // find distance 

    private void Awake()
    {
        odo = transform.Find("speedometerKnob");
        //Debug.Log(odo);
        speed = 0f;
        speedMax = 210f;
        timeElapsed = Time.time;

        //tacometer
        taco = transform.Find("tachoometerKnob");
        tacoValue = 0f;
        tacoMax = 8000f;
    }
    private void Update()
    {
        // speed += 30f * Time.deltaTime;
        //if (speed > speedMax) speed = speedMax;
        //Debug.Log(tacoValue);
        handlePlayerInput();
        cruiseControlSign.SetActive(cruiseControl);
        if (!cruiseControl)
        {
            odo.eulerAngles = new Vector3(0, 0, getSpeedRotation());
            //tacometer update
            taco.eulerAngles = new Vector3(0, 0, gettacoRotation());
            // player input

            int speedInt = (int)speed;
            speedText.text = speedInt.ToString() + " MPH";
            if (gears == 1 && speed <= 0.0)
            {
                //Debug.Log("Parked");
                gearText.text = "Gear : N";
            }
            else
                gearText.text = "Gear : " + gears.ToString();
        }
        //int distance = speed * (int)(timeElapsed-Time.time);
    }

    private void handlePlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cruiseControl = !cruiseControl;
            // Debug.Log(cruiseControl);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {

            float acceleration = 50f;
            speed += acceleration * Time.deltaTime;

            float tacoAccel = 5000f;
            tacoValue += tacoAccel * Time.deltaTime;

            upPressed = true;
        }
        else
        {
            if (!cruiseControl)
            {
                upPressed = false;
                float deceleration = 20f;
                speed -= deceleration * Time.deltaTime;

                float tacoDeccel = 1400f;
                if (tacoValue >= 1000f)
                    tacoValue -= tacoDeccel * Time.deltaTime;



                // Debug.Log(speed);
                if (tacoValue <= 4000 && gears > 1)
                {
                    tacoValue = 7000;
                    gears--;
                }


            }
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            float brakeSpeed = 100f;
            speed -= brakeSpeed * Time.deltaTime;
        }

        speed = Mathf.Clamp(speed, 0f, speedMax);
        tacoValue = Mathf.Clamp(tacoValue, 0f, tacoMax);

        if (gears < 3 && tacoValue >= 6500 && upPressed)
        {
            tacoValue = 2000f;
            gears++;
        }
        //Debug.Log(tacoValue);
        // Debug.Log("Gears: " + gears);

    }

    private float getSpeedRotation()
    {
        float totalAngleSize = zeroSpeed - MaxSpeed;

        float speedNormalized = speed / speedMax;

        return zeroSpeed - speedNormalized * totalAngleSize;
    }


    private float gettacoRotation()
    {
        float totalAngleSize = zeroTaco - MaxTaco;

        float tacoNormalized = tacoValue / tacoMax;

        return zeroTaco - tacoNormalized * totalAngleSize;
    }
}
