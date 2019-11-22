using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkingLightCycle : MonoBehaviour
{
    public GameObject lights;
    //private SpriteRenderer m_SpriteRenderer;
    public int state = 0;
    public GameObject[] states = new GameObject[4];

    //Turning, Green, Yellow Red,
    //Direction State
    public double[] TimeUntillNextLight = new double[4] { 3.0, 3.0, 1.0, 1.0 };
    float timer = 0;
    bool NSEW = false;
    // Start is called before the first frame update
    void Awake()
    {
        //lights.SetActive(true);
        //m_SpriteRenderer = GetComponent<SpriteRenderer>();
        TimeUntillNextLight = new double[4] { 3.0, 3.0, 1.0, 1.0 };
        this.state = 0;
        states[0].gameObject.SetActive(true);
        states[1].gameObject.SetActive(false);
        states[2].gameObject.SetActive(false);
        states[3].gameObject.SetActive(false);
        //m_SpriteRenderer.sprite = states[this.state];

    }


    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer > TimeUntillNextLight[this.state])
        {
            this.timer = 0;
            //this.state++;

            if (this.state == 0 )
            {
                states[0].gameObject.SetActive(true);
                states[1].gameObject.SetActive(false);
                states[2].gameObject.SetActive(false);
                states[3].gameObject.SetActive(false);
            }
            if (this.state == 1)
            {
                states[0].gameObject.SetActive(false);
                states[1].gameObject.SetActive(true);
                states[2].gameObject.SetActive(false);
                states[3].gameObject.SetActive(false);
            }
            if (this.state == 2)
            {
                states[0].gameObject.SetActive(false);
                states[1].gameObject.SetActive(false);
                states[2].gameObject.SetActive(true);
                states[3].gameObject.SetActive(false);
            }
            if (this.state == 3)
            {
                states[0].gameObject.SetActive(false);
                states[1].gameObject.SetActive(false);
                states[2].gameObject.SetActive(false);
                states[3].gameObject.SetActive(true);
                state = 0;
            }
            //m_SpriteRenderer.sprite = states[this.state];
        }
    }
}


