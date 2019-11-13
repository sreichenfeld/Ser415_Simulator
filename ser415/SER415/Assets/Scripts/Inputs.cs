using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Inputs : MonoBehaviour
{
    // Initialize all Input Fields From UI
    public InputField north_cars_per_second;
    public InputField south_cars_per_second;
    public InputField west_cars_per_second;
    public InputField east_cars_per_second;

    public InputField time_of_day;

    public InputField north_percentage;
    public InputField south_percentage;
    public InputField east_percentage;
    public InputField west_percentage;

    public Slider avg_car_speed;
    public Slider wrecklessness;
    public Slider car_start_lag;

    // Check if Time Value has changed
    public int lastTime;


    // {KEY, {Value}}
    // EXAMPLE = {Time of Day, {Traffic Flow, north_cars_per_second, south_cars_per_second, east_cars_per_second, 
    //          west_cars_per_second, avg_car_speed, wrecklessness, car_start_lag}}
    public Dictionary<int, List<float>> time_cars = new Dictionary<int, List<float>>() {
        {0, new List<float>() { 0.1f, 10f, 20f, 30f, 40f, 0f, 50f, 2f}},
        {1, new List<float>() { 0.1f, 100f, 200f, 300f, 400f, 25f, 1f, 0.1f}},
        {2, new List<float>() { 0.1f, 100f, 200f, 300f, 400f, 25f, 1f, 0.1f}},
        {3, new List<float>() { 0.1f, 100f, 200f, 300f, 400f, 25f, 1f, 0.1f}},
        {4, new List<float>() { 0.2f, 100f, 200f, 300f, 400f, 25f, 1f, 0.1f}},
        {5, new List<float>() { 0.3f, 100f, 200f, 300f, 400f, 25f, 1f, 0.1f}},
        {6, new List<float>() { 0.5f, 100f, 200f, 300f, 400f, 25f, 1f, 0.1f}},
        {7, new List<float>() { 0.6f, 100f, 200f, 300f, 400f, 25f, 1f, 0.1f}},
        {8, new List<float>() { 0.6f, 100f, 200f, 300f, 400f, 25f, 1f, 0.1f}},
        {9, new List<float>() { 0.5f, 100f, 200f, 300f, 400f, 25f, 1f, 0.1f}},
        {10, new List<float>() { 0.5f, 100f, 200f, 300f, 400f, 25f, 1f, 0.1f}},
        {11, new List<float>() { 0.7f, 100f, 200f, 300f, 400f, 25f, 1f, 0.1f}},
        {12, new List<float>() { 0.9f, 100f, 200f, 300f, 400f, 25f, 1f, 0.1f}},
        {13, new List<float>() { 0.9f, 100f, 200f, 300f, 400f, 25f, 1f, 0.1f}},
        {14, new List<float>() { 0.8f, 100f, 200f, 300f, 400f, 25f, 1f, 0.1f}},
        {15, new List<float>() { 0.9f, 100f, 200f, 300f, 400f, 25f, 1f, 0.1f}},
        {16, new List<float>() { 0.8f, 100f, 200f, 300f, 400f, 25f, 1f, 0.1f}},
        {17, new List<float>() { 0.9f, 100f, 200f, 300f, 400f, 25f, 1f, 0.1f}},
        {18, new List<float>() { 0.8f, 100f, 200f, 300f, 400f, 25f, 1f, 0.1f}},
        {19, new List<float>() { 0.6f, 100f, 200f, 300f, 400f, 25f, 1f, 0.1f}},
        {20, new List<float>() { 0.5f, 100f, 200f, 300f, 400f, 25f, 1f, 0.1f}},
        {21, new List<float>() { 0.5f, 100f, 200f, 300f, 400f, 25f, 1f, 0.1f}},
        {22, new List<float>() { 0.3f, 100f, 200f, 300f, 400f, 25f, 1f, 0.1f}},
        {23, new List<float>() { 0.1f, 100f, 200f, 300f, 400f, 25f, 1f, 0.1f}},
    };
    // {Key, {Value}}
    // {time_of_day, {north_percentage [], south_percentage [], east_percentage [], west_percentage []}}
    public Dictionary<int, List<float[]>> time_percentage = new Dictionary<int, List<float[]>>() {
        {0, new List<float[]>{ new float[] {0f, 90f, 10f}, new float[] {5f, 95f, 0f}, new float[] {5f, 85f, 10f}, new float[] {15f, 80f, 5f} }},
        {1, new List<float[]>{ new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f} }},
        {2, new List<float[]>{ new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f} }},
        {3, new List<float[]>{ new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f} }},
        {4, new List<float[]>{ new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f} }},
        {5, new List<float[]>{ new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f} }},
        {6, new List<float[]>{ new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f} }},
        {7, new List<float[]>{ new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f} }},
        {8, new List<float[]>{ new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f} }},
        {9, new List<float[]>{ new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f} }},
        {10, new List<float[]>{ new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f} }},
        {11, new List<float[]>{ new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f} }},
        {12, new List<float[]>{ new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f} }},
        {13, new List<float[]>{ new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f} }},
        {14, new List<float[]>{ new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f} }},
        {15, new List<float[]>{ new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f} }},
        {16, new List<float[]>{ new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f} }},
        {17, new List<float[]>{ new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f} }},
        {18, new List<float[]>{ new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f} }},
        {19, new List<float[]>{ new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f} }},
        {20, new List<float[]>{ new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f} }},
        {21, new List<float[]>{ new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f} }},
        {22, new List<float[]>{ new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f} }},
        {23, new List<float[]>{ new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f}, new float[] {5f, 90f, 5f} }},
    };

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(time_cars);
        Debug.Log(time_percentage);


        // Initilize lastTime
        lastTime = Convert.ToInt32(time_of_day.text);
        // Initilize Input Fields
        get_time_cars_info(Convert.ToInt32(time_of_day.text), time_cars);
        get_time_percetage_info(Convert.ToInt32(time_of_day.text), time_percentage);
    }

    // Update is called once per frame
    void Update()
    {
        if (lastTime != Convert.ToInt32(time_of_day.text)) {
            // Update Input Fields
            get_time_cars_info(Convert.ToInt32(time_of_day.text), time_cars);
            get_time_percetage_info(Convert.ToInt32(time_of_day.text), time_percentage);
            // Update LastTime
            lastTime = Convert.ToInt32(time_of_day.text);
        }   
    }
    

    // Takes time and dictionary to undate input fields
    public void get_time_cars_info(int time, Dictionary<int, List<float>> myDictionary) {
        List<float> inputsArray;
        if (myDictionary.ContainsKey(time))
        {
            inputsArray = myDictionary[time];
            north_cars_per_second.text = inputsArray[1].ToString();
            south_cars_per_second.text = inputsArray[2].ToString();
            east_cars_per_second.text = inputsArray[3].ToString();
            west_cars_per_second.text = inputsArray[4].ToString();
            avg_car_speed.value = inputsArray[5];
            wrecklessness.value = inputsArray[6];
            car_start_lag.value = inputsArray[7];
        }
        else {
            north_cars_per_second.text = "Error";
            south_cars_per_second.text = "Error";
            east_cars_per_second.text = "Error";
            west_cars_per_second.text = "Error";
            avg_car_speed.value = 0;
            wrecklessness.value = 0;
            car_start_lag.value = 0.1f;
        }
    }
    // Takes time and dictionary to undate input fields
    public void get_time_percetage_info(int time, Dictionary<int, List<float[]>> myDictionary) {
        List<float[]> inputsArray;
        if (myDictionary.ContainsKey(time))
        {
            inputsArray = myDictionary[time];
            // Set Percentage Input field based on Int time Given
            north_percentage.text = '{' + inputsArray[0][0].ToString() + ',' + inputsArray[0][1].ToString() + ',' + inputsArray[0][2].ToString() + '}';
            south_percentage.text = '{' + inputsArray[1][0].ToString() + ',' + inputsArray[1][1].ToString() + ',' + inputsArray[1][2].ToString() + '}';
            east_percentage.text = '{' + inputsArray[2][0].ToString() + ',' + inputsArray[2][1].ToString() + ',' + inputsArray[2][2].ToString() + '}';
            west_percentage.text = '{' + inputsArray[3][0].ToString() + ',' + inputsArray[3][1].ToString() + ',' + inputsArray[3][2].ToString() + '}';
        }
        else {
            north_percentage.text = "Error";
            south_percentage.text = "Error";
            east_percentage.text = "ERROR";
            west_percentage.text = "ERROR";
        }
    }
}
