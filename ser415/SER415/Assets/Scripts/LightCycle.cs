using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightCycle : MonoBehaviour
{
    public static LightCycle _instance;

    public GameObject lights;
    private SpriteRenderer m_SpriteRenderer;
    public int state = 0;
    public Sprite[] states = new Sprite[6];
    public Text directionText;
    bool dir = true;
    double g, y, r, lg, ly, lr;

    //Turning, Green, Yellow, Red,
    //Direction State
    public double[] TimeUntillNextLight = new double[6] { 3.0, 3.0, 3.0, 3.0, 3.0, 3.0 };
    public float timer = 0;
    bool NSEW = false;
    // Start is called before the first frame update
    void Start()
    {
        _instance = this;

        lights.SetActive(true);
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        // TimeUntillNextLight = new double[6] { 7.0, 7.0, 7.0, 10.0, 3.0, 3.0 };
        
        this.state = 0;
        directionText.text = "N/S";
        m_SpriteRenderer.sprite = states[this.state];
        Screen.fullScreen = false;
    }
    void update_light_times()
    {
        if (!double.TryParse(Inputs._instance.green_time.text, out g))
        {
            
        }

        g = double.Parse(Inputs._instance.green_time.text);
        y = double.Parse(Inputs._instance.yellow_time.text);
        r = double.Parse(Inputs._instance.red_time.text);
        lg = double.Parse(Inputs._instance.left_green_time.text);
        ly = double.Parse(Inputs._instance.left_yellow_time.text);
        lr = double.Parse(Inputs._instance.left_red_time.text);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        update_light_times();
        TimeUntillNextLight = new double[6] { g, y, r, lg, ly, lr };

        timer += Time.deltaTime;


        if (timer > TimeUntillNextLight[this.state])
        {
            this.timer = 0;
            this.state++;
            Debug.Log(state);

            if (this.state > 5)
            {
                this.state = 0;

                if (dir == true)
                {
                    directionText.text = "E/W";
                    dir = false;
                }
                else
                {
                    directionText.text = "N/S";
                    dir = true;
                }
            }

            m_SpriteRenderer.sprite = states[this.state];
        }
    }
}

