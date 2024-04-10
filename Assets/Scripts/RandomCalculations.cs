using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCalculations : MonoBehaviour
{
    public float height;
    public float length;
    public float area;

    public static int randNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        CalcRandNum();
        CalculateArea();
    }

    public static void CalcRandNum()
    {
        randNum++;
        Debug.Log($"Rand number = {randNum}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CalculateArea()
    {
        area = height * length;
        Debug.Log($"Area = {area}");
    }

    public void RandMethod()
    {
        area = height * length;
    }
}
