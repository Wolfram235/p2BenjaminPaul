using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dateAndTime : MonoBehaviour
{
    // Start is called before the first frame update
    public Text date;
    public Text time;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        date.text = System.DateTime.Now.ToString("MM/dd/yyyy");
        time.text = System.DateTime.Now.ToString("hh:mm:ss");
    }
}
