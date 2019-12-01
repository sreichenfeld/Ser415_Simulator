using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarMovement : MonoBehaviour
{
    float[] myCoords;
    Vector2 newPos;
    Vector2 stalePos;
    int positionCounter = 0;
    public int LanePosition;
    public string direction;
    public float speed;
    private Rigidbody2D rb;
    public bool laneCarMove = false;

    // 0 = Left, 1 = Center, 2 = Right
    // Value is points car goes to
    public Dictionary<int, List<float[]>> south_directions = new Dictionary<int, List<float[]>>() {
        {0, new List<float[]>{ new float[] {3.39f, -5.2f}, new float[] {3.39f, -1.81f}, new float[] {2.44f, 0.77f}, new float[] {1.23f, 1.42f}, new float[] {-4.62f, 1.54f}}},
        {1, new List<float[]>{ new float[] {4.25f, -5.2f}, new float[] {4.25f, -1.81f}, new float[] {4.25f, 7.42f}}},
        {2, new List<float[]>{ new float[] {5.16f, -5.2f}, new float[] {5.16f, -1.81f}, new float[] {5.16f, -0.72f}, new float[] {10.6f, -0.72f}}}
    };

    public Dictionary<int, List<float[]>> north_directions = new Dictionary<int, List<float[]>>() {
        {0, new List<float[]>{ new float[] {2.49f, 7.51f}, new float[] {2.49f, 4.11f}, new float[] {3.48f, 1.61f}, new float[] {4.06f, .79f}, new float[] {10.66f, 0.7f}}},
        {1, new List<float[]>{ new float[] {1.58f, 7.43f}, new float[] {1.56f, 4.11f}, new float[] {1.58f, -5.25f}}},
        {2, new List<float[]>{ new float[] {0.71f, 7.43f}, new float[] {.71f, 4.11f}, new float[] {.05f, 3.06f}, new float[] {-4.72f, 2.97f}}}
    };

    public Dictionary<int, List<float[]>> west_directions = new Dictionary<int, List<float[]>>() {
        {0, new List<float[]>{ new float[] {-4.71f, 0.8f}, new float[] {-0.69f, .97f}, new float[] {2.98f, 1.91f}, new float[] {3.46f, 3.08f}, new float[] {3.45f, 7.64f}}},
        {1, new List<float[]>{ new float[] {-4.88f, 0.06f}, new float[] {-0.69f, 0.1f}, new float[] {10.79f, 0.1f}}},
        {2, new List<float[]>{ new float[] {-4.87f, -0.66f}, new float[] {-0.69f, -.66f}, new float[] {.85f, -0.64f}, new float[] {.71f, -5.12f}}}
    };

    public Dictionary<int, List<float[]>> east_directions = new Dictionary<int, List<float[]>>() {
        {0, new List<float[]>{ new float[] {10.67f, 1.54f}, new float[] {6.66f, 1.54f}, new float[] {3.9f, 0.91f}, new float[] {2.55f,-0.52f}, new float[] {2.55f, -5.19f}}},
        {1, new List<float[]>{ new float[] {10.67f, 2.27f}, new float[] {6.66f, 2.27f}, new float[] {-4.66f, 2.27f}}},
        {2, new List<float[]>{ new float[] {10.67f, 2.98f}, new float[] {6.66f, 2.98f}, new float[] {5.08f, 3.98f}, new float[] {5.08f, 7.59f}}}
    };

    // Start is called before the first frame update
    void Start()
    {
        // Move to starting position
        myCoords = grabCoords(direction);
        transform.position = new Vector2(myCoords[0], myCoords[1]);
    }

    void FixedUpdate()
    {
        // Update car speed based on slider value
        speed = (Inputs._instance.avg_car_speed.value / 15f);

        // Update Coords
        if (transform.position.x == myCoords[0] && transform.position.y == myCoords[1])
        {
            myCoords = grabCoords(direction);
            newPos = new Vector2(myCoords[0], myCoords[1]);
            stalePos = new Vector2(myCoords[0], myCoords[1]);
        }
        // Move Car

        else if (LightCycle._instance.directionText.text.ToString() == "E/W" && (direction == "E" || direction == "W") && newPos != stalePos)
        {

            if ((LightCycle._instance.state == 3 || LightCycle._instance.state == 4) && LanePosition == 0)
            {

                float step = speed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, stalePos, step);

            }
            else if (LightCycle._instance.state == 0 && (LanePosition == 1 || LanePosition == 2))
            {
                float step = speed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, stalePos, step);
            }
        }
        else if (LightCycle._instance.directionText.text.ToString() == "N/S" && (direction == "N" || direction == "S") && newPos != stalePos)
        {
            if ((LightCycle._instance.state == 3 || LightCycle._instance.state == 4) && LanePosition == 0)
            {
                float step = speed * Time.deltaTime;
                //float step = 1f * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, stalePos, step);
            }
            else if (LightCycle._instance.state == 0 && (LanePosition == 1 || LanePosition == 2))
            {
                float step = speed * Time.deltaTime;
                //float step = 1f * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, stalePos, step);
            }
        }
        else
        {
            float step = speed * Time.deltaTime;
            //float step = 1f * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, newPos, step);
        }
    }

    public float[] grabCoords(string cardinalDir)
    {
        // This is Left Lane ONLY WILL NEED TO BE CHANGED BASED On car Spawn Lane
        //List<float[]> inputsArray = south_directions[LanePosition];
        List<float[]> inputsArray = new List<float[]>();

        if (cardinalDir == "W")
        {
            inputsArray = west_directions[LanePosition];
        }
        else if (cardinalDir == "E")
        {
            inputsArray = east_directions[LanePosition];
        }
        else if (cardinalDir == "N")
        {
            inputsArray = north_directions[LanePosition];
        }
        else if (cardinalDir == "S")
        {
            inputsArray = south_directions[LanePosition];
        }
        else
        {
            Debug.Log("ERROR WITH DIRECTION");
        }

        float[] x = new float[] { float.Parse(inputsArray[positionCounter][0].ToString()), float.Parse(inputsArray[positionCounter][1].ToString()) };

        // Increase Position Index
        if (positionCounter == inputsArray.Count - 1)
        {
            positionCounter = 0;
        }
        else
        {
            positionCounter += 1;
        }

        // Return array of x, y coords
        return x;
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        float speed = (Inputs._instance.avg_car_speed.value / 15f);


        if (collision.OverlapPoint(gameObject.transform.position))
        {
            Destroy(this.gameObject);
        }


        if (LightCycle._instance.directionText.text == "E/W")
        {
            if (collision.tag == "Player")
            {
                newPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
                transform.position = Vector2.MoveTowards(transform.position, newPos, 0);

            }

            // Stop Left turn for E/W
            if (LightCycle._instance.state != 3)
            {
                if (collision.tag == "E_L_Lane")
                {
                    newPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
                    transform.position = Vector2.MoveTowards(transform.position, newPos, 0);
                }
                if (collision.tag == "W_L_Lane")
                {
                    newPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
                    transform.position = Vector2.MoveTowards(transform.position, newPos, 0);
                }
            }

            // Stop Left turn for N/S
            if (LightCycle._instance.state != 3)
            {
                if (collision.tag == "N_L_Lane")
                {
                    newPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
                    transform.position = Vector2.MoveTowards(transform.position, newPos, 0);
                }
                if (collision.tag == "S_L_Lane")
                {
                    newPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
                    transform.position = Vector2.MoveTowards(transform.position, newPos, 0);
                }
            }

            // Stop N/S Center and right lane
            if (collision.tag == "N_R_Lane")
            {
                newPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
                transform.position = Vector2.MoveTowards(transform.position, newPos, 0);
            }
            if (collision.tag == "N_C_Lane")
            {
                newPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
                transform.position = Vector2.MoveTowards(transform.position, newPos, 0);

            }

            if (collision.tag == "S_C_Lane")
            {
                newPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
                transform.position = Vector2.MoveTowards(transform.position, newPos, 0);
            }
            if (collision.tag == "S_R_Lane")
            {
                newPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
                transform.position = Vector2.MoveTowards(transform.position, newPos, 0);
            }

            // Stop E/W lanes when light turns red. 
            if(collision.tag == "E_C_Lane")
            {
                newPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
                transform.position = Vector2.MoveTowards(transform.position, newPos, 0);
            }
            if (collision.tag == "E_R_Lane")
            {
                newPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
                transform.position = Vector2.MoveTowards(transform.position, newPos, 0);
            }
            if (collision.tag == "W_C_Lane")
            {
                newPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
                transform.position = Vector2.MoveTowards(transform.position, newPos, 0);
            }
            if (collision.tag == "W_R_Lane")
            {
                newPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
                transform.position = Vector2.MoveTowards(transform.position, newPos, 0);
            }

        }

        if(LightCycle._instance.directionText.text == "N/S")
        {
            if (collision.tag == "Player")
            {
                newPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
                transform.position = Vector2.MoveTowards(transform.position, newPos, 0);

            }

            // Stop Left turn for N/S
            if (LightCycle._instance.state != 3)
            {

                if (collision.tag == "N_L_Lane")
                {
                    newPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
                    transform.position = Vector2.MoveTowards(transform.position, newPos, 0);
                }
                if (collision.tag == "S_L_Lane")
                {
                    newPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
                    transform.position = Vector2.MoveTowards(transform.position, newPos, 0);
                }
            }

            // Stop Left turn for E/W
            if (LightCycle._instance.state != 3 && (collision.tag == "W_L_Lane" || collision.tag == "E_L_Lane"))
            {            

                newPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
                transform.position = Vector2.MoveTowards(transform.position, newPos, 0);
                

            }
            // Stop E/W Center and right lane
            if (collision.tag == "E_C_Lane")
            {
                newPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
                transform.position = newPos;
            }
            if (collision.tag == "E_R_Lane")
            {
                newPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
                transform.position = Vector2.MoveTowards(transform.position, newPos, 0);
            }

            if (collision.tag == "W_C_Lane")
            {
                //laneStop("N/S");
                newPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
                transform.position = Vector2.MoveTowards(transform.position, newPos, 0);
            }
            if (collision.tag == "W_R_Lane")
            {
                newPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
                transform.position = Vector2.MoveTowards(transform.position, newPos, 0);
            }

            if (LightCycle._instance.state != 0) {
                // Stop N/S Center and right lane

                if (collision.tag == "N_R_Lane")
                {
                    newPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
                    transform.position = Vector2.MoveTowards(transform.position, newPos, 0);
                }
                if (collision.tag == "N_C_Lane")
                {
                    newPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
                    transform.position = Vector2.MoveTowards(transform.position, newPos, 0);
                }

                if (collision.tag == "S_C_Lane")
                {
                    newPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
                    transform.position = Vector2.MoveTowards(transform.position, newPos, 0);
                }
                if (collision.tag == "S_R_Lane")
                {
                    newPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
                    transform.position = Vector2.MoveTowards(transform.position, newPos, 0);
                }
            }
            
        }

        // Destory car
        if (collision.tag == "Finish")
        {
            Destroy(this.gameObject);
        }
    }

}
