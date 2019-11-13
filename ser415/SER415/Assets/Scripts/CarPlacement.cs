using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPlacement : MonoBehaviour
{
    public GameObject car;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(car, new Vector2(0, 0), Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
