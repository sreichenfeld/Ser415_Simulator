using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Inputs : MonoBehaviour
{

    // Create instance of class to access from other classes
    public static Inputs _instance;

    // Initialize all Input Fields From UI
    public InputField north_cars_per_second;
    public InputField south_cars_per_second;
    public InputField west_cars_per_second;
    public InputField east_cars_per_second;

    public InputField time_of_day;

    public InputField north_percentage_left;
    public InputField south_percentage_left;
    public InputField east_percentage_left;
    public InputField west_percentage_left;

    public InputField north_percentage_center;
    public InputField south_percentage_center;
    public InputField east_percentage_center;
    public InputField west_percentage_center;

    public InputField north_percentage_right;
    public InputField south_percentage_right;
    public InputField east_percentage_right;
    public InputField west_percentage_right;

    public Slider avg_car_speed;
    public Slider wrecklessness;
    public Slider car_start_lag;

    // Check if Time Value has changed
    public int lastTime;


    // {KEY, {Value}}
    // EXAMPLE = {Time of Day, {Traffic Flow, north_cars_per_second, south_cars_per_second, east_cars_per_second, 
    //          west_cars_per_second, avg_car_speed, wrecklessness, car_start_lag}}
    public Dictionary<int, List<float>> time_cars = new Dictionary<int, List<float>>() {
        {0, new List<float>() { 0.1f, 0.1f, 0.2f, 0.3f, 0.25f, 25f, 50f, 2f}},
        {1, new List<float>() { 0.1f, 0.2f, 0.21f, 0.1f, 0.05f, 25f, 1f, 0.1f}},
        {2, new List<float>() { 0.1f, 0.05f, 0.75f, 0.1f, 0.15f, 25f, 1f, 0.1f}},
        {3, new List<float>() { 0.1f, 0.1f, 0.03f, 0.03f, 0.04f, 25f, 1f, 0.1f}},
        {4, new List<float>() { 0.2f, 0.2f, 0.13f, 0.12f, 0.18f, 25f, 1f, 0.1f}},
        {5, new List<float>() { 0.3f, 0.45f, 0.3f, 0.25f, 0.32f, 25f, 1f, 0.1f}},
        {6, new List<float>() { 0.5f, 0.5f, 0.48f, 0.38f, 0.7f, 25f, 1f, 0.1f}},
        {7, new List<float>() { 0.6f, 0.6f, 0.62f, 0.52f, 0.54f, 25f, 1f, 0.1f}},
        {8, new List<float>() { 0.6f, 0.54f, 0.65f, 0.65f, 0.7f, 25f, 1f, 0.1f}},
        {9, new List<float>() { 0.5f, 0.45f, 0.54f, 0.6f, 0.58f, 25f, 1f, 0.1f}},
        {10, new List<float>() { 0.5f, 0.5f, 0.48f, 0.38f, 0.7f, 25f, 1f, 0.1f}},
        {11, new List<float>() { 0.7f, 0.7f, 0.72f, 0.8f, 0.78f, 25f, 1f, 0.1f}},
        {12, new List<float>() { 0.9f, 0.9f, 0.98f, 0.85f, 0.89f, 25f, 1f, 0.1f}},
        {13, new List<float>() { 0.9f, 0.83f, 0.87f, 0.95f, 0.93f, 25f, 1f, 0.1f}},
        {14, new List<float>() { 0.8f, 0.74f, 0.78f, 0.81f, 0.79f, 25f, 1f, 0.1f}},
        {15, new List<float>() { 0.9f, 0.99f, 0.92f, 0.87f, 0.95f, 25f, 1f, 0.1f}},
        {16, new List<float>() { 0.8f, 0.7f, 0.72f, 0.76f, 0.83f, 25f, 1f, 0.1f}},
        {17, new List<float>() { 0.9f, 0.83f, 0.87f, 0.95f, 0.93f, 25f, 1f, 0.1f}},
        {18, new List<float>() { 0.8f, 0.74f, 0.78f, 0.81f, 0.79f, 25f, 1f, 0.1f}},
        {19, new List<float>() { 0.6f, 0.54f, 0.65f, 0.65f, 0.7f, 25f, 1f, 0.1f}},
        {20, new List<float>() { 0.5f, 0.5f, 0.48f, 0.38f, 0.7f, 25f, 1f, 0.1f}},
        {21, new List<float>() { 0.5f, 0.5f, 0.48f, 0.38f, 0.7f, 25f, 1f, 0.1f}},
        {22, new List<float>() { 0.3f, 0.45f, 0.3f, 0.25f, 0.32f, 25f, 1f, 0.1f}},
        {23, new List<float>() { 0.1f, 0.2f, 0.21f, 0.1f, 0.05f, 25f, 1f, 0.1f}},
    };
    // {Key, {Value}}
    // {time_of_day, {north_percentage [], south_percentage [], east_percentage [], west_percentage []}}
    public Dictionary<int, List<float[]>> time_percentage = new Dictionary<int, List<float[]>>() {
        {0, new List<float[]>{ new float[] {0f, 90f, 10f}, new float[] {5f, 95f, 0f}, new float[] {5f, 85f, 10f}, new float[] {15f, 80f, 5f} }},
        {1, new List<float[]>{ new float[] {6f, 90f, 4f}, new float[] {10f, 70f, 20f}, new float[] {5f,80f, 15f}, new float[] {23f, 57f, 30f} }},
        {2, new List<float[]>{ new float[] {0f, 100f, 0f}, new float[] {21f, 52f, 27f}, new float[] {18f, 82f, 0f}, new float[] {38f, 52f, 10f} }},
        {3, new List<float[]>{ new float[] {12f, 58f, 30f}, new float[] {0f, 90f, 10f}, new float[] {10f, 90f, 0f}, new float[] {16f, 84f, 0f} }},
        {4, new List<float[]>{ new float[] {20f, 61f, 19f}, new float[] {2f, 80f, 18f}, new float[] {14f, 74f, 12f}, new float[] {7f, 53f, 40f} }},
        {5, new List<float[]>{ new float[] {25f, 70f, 5f}, new float[] {5f, 65f, 30f}, new float[] {20f, 69f, 11f}, new float[] {12f, 76f, 20f} }},
        {6, new List<float[]>{ new float[] {14f, 72f, 14f}, new float[] {10f, 55f, 35f}, new float[] {30f, 69f, 1f}, new float[] {13f, 47f, 40f} }},
        {7, new List<float[]>{ new float[] {16f, 71f, 13f}, new float[] {1f, 70f, 29f}, new float[] {20f, 75f, 5f}, new float[] {5f, 80f, 15f} }},
        {8, new List<float[]>{ new float[] {17f, 69f, 14f}, new float[] {10f, 50f, 40f}, new float[] {10f, 70f, 20f}, new float[] {22f, 56f, 22f} }},
        {9, new List<float[]>{ new float[] {22f, 58f, 20f}, new float[] {30f, 48f, 22f}, new float[] {18f, 90f, 5f}, new float[] {23f, 70f, 7f} }},
        {10, new List<float[]>{ new float[] {27f, 53f, 20f}, new float[] {7f, 80f, 13f}, new float[] {11f, 80f, 9f}, new float[] {3f, 75f, 22f} }},
        {11, new List<float[]>{ new float[] {10f, 75f, 15f}, new float[] {2f, 64f, 34f}, new float[] {7f, 60f, 33f}, new float[] {9f, 90f, 1f} }},
        {12, new List<float[]>{ new float[] {6f, 70f, 24f}, new float[] {29f, 41f, 40f}, new float[] {6f, 71f, 23f}, new float[] {6f, 88f, 6f} }},
        {13, new List<float[]>{ new float[] {19f, 80f, 1f}, new float[] {12f, 68f, 21f}, new float[] {8f, 50f, 42f}, new float[] {1f, 90f, 9f} }},
        {14, new List<float[]>{ new float[] {26f, 64f, 10f}, new float[] {10f, 88f, 2f}, new float[] {16f, 61f, 23f}, new float[] {20f, 43f, 37f} }},
        {15, new List<float[]>{ new float[] {33f, 60f, 7f}, new float[] {17f, 74f, 9f}, new float[] {23f, 70f, 7f}, new float[] {55f, 30f, 15f} }},
        {16, new List<float[]>{ new float[] {11f, 70f, 19f}, new float[] {9f, 72f, 19f}, new float[] {13f, 60f, 27}, new float[] {5f, 67f, 28f} }},
        {17, new List<float[]>{ new float[] {25f, 61f, 14f}, new float[] {30f, 69f, 1f}, new float[] {19f, 80f, 1f}, new float[] {8f, 74f, 18f} }},
        {18, new List<float[]>{ new float[] {31f, 60f, 9f}, new float[] {25f, 71f, 4f}, new float[] {3f, 87f, 10f}, new float[] {13f, 77f, 10f} }},
        {19, new List<float[]>{ new float[] {18f, 72f, 10f}, new float[] {6f, 59f, 40f}, new float[] {0f, 50f, 50f}, new float[] {20f, 80f, 0f} }},
        {20, new List<float[]>{ new float[] {11f, 70f, 19f}, new float[] {3f, 70f, 27f}, new float[] {2f, 90f, 8f}, new float[] {3f, 92f, 5f} }},
        {21, new List<float[]>{ new float[] {2f, 88f, 10f}, new float[] {18f, 66f, 16f}, new float[] {19f, 60f, 21f}, new float[] {5f, 75f, 20f} }},
        {22, new List<float[]>{ new float[] {1f, 90f, 9f}, new float[] {29f, 54f, 17f}, new float[] {30f, 50f, 20f}, new float[] {10f, 78f, 12f} }},
        {23, new List<float[]>{ new float[] {3f, 92f, 5f}, new float[] {8f, 60f, 32f}, new float[] {20f, 60f, 20f}, new float[] {9f, 61f, 30f} }},
    };

    // Start is called before the first frame update
    void Awake()
    {
        if (_instance != null && _instance != this) {
            Debug.Log("BAD INSTANCE");
        }
        else {
            _instance = this;
        }

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
            //north_percentage.text = '{' + inputsArray[0][0].ToString() + ',' + inputsArray[0][1].ToString() + ',' + inputsArray[0][2].ToString() + '}';
            //south_percentage.text = '{' + inputsArray[1][0].ToString() + ',' + inputsArray[1][1].ToString() + ',' + inputsArray[1][2].ToString() + '}';
            //east_percentage.text = '{' + inputsArray[2][0].ToString() + ',' + inputsArray[2][1].ToString() + ',' + inputsArray[2][2].ToString() + '}';
            //west_percentage.text = '{' + inputsArray[3][0].ToString() + ',' + inputsArray[3][1].ToString() + ',' + inputsArray[3][2].ToString() + '}';

            north_percentage_left.text = inputsArray[0][0].ToString();
            south_percentage_left.text = inputsArray[1][0].ToString();
            east_percentage_left.text = inputsArray[2][0].ToString();
            west_percentage_left.text = inputsArray[3][0].ToString();

            north_percentage_center.text = inputsArray[0][1].ToString();
            south_percentage_center.text = inputsArray[1][1].ToString();
            east_percentage_center.text = inputsArray[2][1].ToString();
            west_percentage_center.text = inputsArray[3][1].ToString();

            north_percentage_right.text = inputsArray[0][2].ToString();
            south_percentage_right.text = inputsArray[1][2].ToString();
            east_percentage_right.text = inputsArray[2][2].ToString();
            west_percentage_right.text = inputsArray[3][2].ToString();

}
        else {
            //north_percentage.text = "Error";
            //south_percentage.text = "Error";
            //east_percentage.text = "ERROR";
            //west_percentage.text = "ERROR";
            north_percentage_left.text = "ERROR";
            south_percentage_left.text = "ERROR";
            east_percentage_left.text = "ERROR";
            west_percentage_left.text = "ERROR";

            north_percentage_center.text = "ERROR";
            south_percentage_center.text = "ERROR";
            east_percentage_center.text = "ERROR";
            west_percentage_center.text = "ERROR";

            north_percentage_right.text = "ERROR";
            south_percentage_right.text = "ERROR";
            east_percentage_right.text = "ERROR";
            west_percentage_right.text = "ERROR";
        }
    }
}
