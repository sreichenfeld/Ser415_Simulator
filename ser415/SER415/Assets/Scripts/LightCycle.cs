using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightCycle : MonoBehaviour
{
    public GameObject lights;
    private SpriteRenderer m_SpriteRenderer;
    public int state = 0;
    public Sprite[] states = new Sprite[4];
    public Text directionText;
    bool dir = true;

    //Turning, Green, Yellow Red,
    //Direction State
    public double[] TimeUntillNextLight = new double[4] { 3.0, 3.0, 1.0, 1.0 };
    float timer = 0;
    bool NSEW = false;
    // Start is called before the first frame update
    void Start()
    {

        lights.SetActive(true);
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        TimeUntillNextLight = new double[4] { 3.0, 3.0, 1.0, 1.0 };
        this.state = 0;
        directionText.text = "N/S";
        m_SpriteRenderer.sprite = states[this.state];

    }


    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer > TimeUntillNextLight[this.state])
        {
            this.timer = 0;
            this.state++;

            if (this.state > 3)
            {
                this.state = 0;
                //this.NSEW = !this.NSEW;
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

