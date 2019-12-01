using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System.Linq;

public class CarPlacement : MonoBehaviour
{
    GameObject Inst;
    public static CarPlacement _instance;

    public GameObject car;

    private IEnumerator StartCounter(string direction, float carTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(1/carTime);
            spawn(direction);
        }
    }

    public void spawn(string mydirection)
    {
        Inst = Instantiate(car, new Vector2(0, 0), Quaternion.identity);// as Inst.GetComponent <CarMovement>().lanePosition = 1;
        Inst.GetComponent<CarMovement>().LanePosition = Random.Range(0, 3);
        Inst.GetComponent<CarMovement>().direction = mydirection;



        if (mydirection == "W")
        {
            Inst.transform.Rotate(0, 0, 90);
        }

        else if(mydirection == "E")
        {
            Inst.transform.Rotate(0, 0, 90);
        }

        float left = 0;
        float center = 0;
        float right = 0;
   
        int ranNum = Random.Range(1, 101);

        if (mydirection == "W")
        {
            left = float.Parse(Inputs._instance.west_percentage_left.text);
            center = float.Parse(Inputs._instance.west_percentage_center.text);
            right = float.Parse(Inputs._instance.west_percentage_right.text);
        }
        else if (mydirection == "E")
        {
            left = float.Parse(Inputs._instance.east_percentage_left.text);
            center = float.Parse(Inputs._instance.east_percentage_center.text);
            right = float.Parse(Inputs._instance.east_percentage_right.text);
        }
        else if (mydirection == "N")
        {
            left = float.Parse(Inputs._instance.north_percentage_left.text);
            center = float.Parse(Inputs._instance.north_percentage_center.text);
            right = float.Parse(Inputs._instance.north_percentage_right.text);
        }
        else if (mydirection == "S")
        {
            left = float.Parse(Inputs._instance.south_percentage_left.text);
            center = float.Parse(Inputs._instance.south_percentage_center.text);
            right = float.Parse(Inputs._instance.south_percentage_right.text);
        }
        else
        {
            Debug.Log("ERROR WITH DIRECTION");
        }
        
        if (ranNum <= left)
        {
            Inst.GetComponent<CarMovement>().LanePosition = 0;
        }
        else if (ranNum >= (left + center))
        {
            Inst.GetComponent<CarMovement>().LanePosition = 2;
        }
        else {
            Inst.GetComponent<CarMovement>().LanePosition = 1;
        }
        
    }

    private void FixedUpdate()
    {

        // GameObject Inst = Instantiate(car, new Vector2(0, 0), Quaternion.identity);// as Inst.GetComponent <CarMovement>().lanePosition = 1;
        //Inst.GetComponent<CarMovement>().LanePosition = Random.Range(0, 3);


        Debug.Log(Inputs._instance.north_cars_per_second.text);
    }
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(StartCounter("N", float.Parse(Inputs._instance.north_cars_per_second.text)));
        StartCoroutine(StartCounter("S", float.Parse(Inputs._instance.south_cars_per_second.text)));
        StartCoroutine(StartCounter("E", float.Parse(Inputs._instance.east_cars_per_second.text)));
        StartCoroutine(StartCounter("W", float.Parse(Inputs._instance.west_cars_per_second.text)));

    }

    // Update is called once per frame
    void Update()
    {

    }
}



