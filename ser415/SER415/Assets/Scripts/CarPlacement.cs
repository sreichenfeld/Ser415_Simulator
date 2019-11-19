using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class CarPlacement : MonoBehaviour
{

    public GameObject car;

    private IEnumerator StartCounter(string direction, float carTime)
    {
        while(true)
        {
            yield return new WaitForSeconds(carTime);
            spawn(direction);
            //StartCoroutine(StartCounter(direction, float.Parse(Inputs._instance.north_cars_per_second.text)));
        }

    }

    public void spawn(string mydirection)
    {
        GameObject Inst = Instantiate(car, new Vector2(0, 0), Quaternion.identity);// as Inst.GetComponent <CarMovement>().lanePosition = 1;
        Inst.GetComponent<CarMovement>().LanePosition = Random.Range(0, 3);
        Inst.GetComponent<CarMovement>().direction = mydirection;
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
