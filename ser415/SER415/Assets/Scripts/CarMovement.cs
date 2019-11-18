using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarMovement : MonoBehaviour
{


    float[] myCoords;
    Vector2 newPos;
    int positionCounter = 0;
    public int LanePosition;
    public string direction;


    // 0 = Left, 1 = Center, 2 = Right
    // Value is points car goes to
    public Dictionary<int, List<float[]>> south_directions = new Dictionary<int, List<float[]>>() {
        {0, new List<float[]>{ new float[] {3.39f, -5.2f}, new float[] {3.39f, -2.08f}, new float[] {2.44f, 0.77f}, new float[] {-0.91f, 1.54f}, new float[] {-4.62f, 1.54f}}},
        {1, new List<float[]>{ new float[] {4.25f, -5.2f}, new float[] {4.25f, -2.08f}, new float[] {4.25f, 7.42f}}},
        {2, new List<float[]>{ new float[] {5.16f, -5.2f}, new float[] {5.16f, -2.08f}, new float[] {5.16f, -0.72f}, new float[] {10.6f, -0.72f}}}
    };





    // Start is called before the first frame update
    void Start()
    {
        // Move to starting position
        myCoords = grabCoords();
        transform.position = new Vector2(myCoords[0], myCoords[1]);
    }

    void FixedUpdate()
    {
        // Update car speed based on slider value
        float speed = (Inputs._instance.avg_car_speed.value / 15f);

        // Update Coords
        if (transform.position.x == myCoords[0] && transform.position.y == myCoords[1])
        {
            myCoords = grabCoords();
            newPos = new Vector2(myCoords[0], myCoords[1]);
        }
        // Move Car
        else {

            float step = speed * Time.deltaTime;
            //float step = 1f * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, newPos, step);
        }

    }

    public float[] grabCoords()
    {
        // This is Left Lane ONLY WILL NEED TO BE CHANGED BASED On car Spawn Lane
        List<float[]> inputsArray = south_directions[LanePosition];


        float [] x = new float[] { float.Parse(inputsArray[positionCounter][0].ToString()), float.Parse(inputsArray[positionCounter][1].ToString()) };

        // Increase Position Index
        if (positionCounter == inputsArray.Count - 1) {
            positionCounter = 0;
        } else
        {
            positionCounter += 1;
        }
        
        // Return array of x, y coords
        return x;
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Destroy Car Object To Prevent Overload
        Destroy(this.gameObject);
    }
   
}
