using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightCycle : MonoBehaviour
{
    public GameObject lights;
    public LightCycle instance;
    SpriteRenderer m_SpriteRenderer;
    public int state = 0;
    static Color[] cycles = new Color[] { Color.green, Color.yellow, Color.red };
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_SpriteRenderer.color = Color.green;
        if (this.instance == null)
            {
                this.instance = new LightCycle();
                this.state = 0;
            }
        
    }

    
    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer > 5)
        {
            this.timer = 0;
            this.state++;
            if (this.state > 2)
            {
                this.state = 0;
            }
            if (this.state == 0)
            {
                m_SpriteRenderer.color = cycles[this.state];
            } else if(this.state == 1)
            {
                m_SpriteRenderer.color = cycles[this.state];
            } else if( this.state == 2)
            {
                m_SpriteRenderer.color = cycles[this.state];
            }
        }
    }
}
