using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;


public class AirQualityObjectInteraction : MonoBehaviour
{

    //public IrisDataHolder IrisDataHolder;

    private GameObject collidingObject;
    public AirQualityHolder ObjectDeets; // = collidingObject.GetComponent<IrisDataHolder>();
    
public void OnTriggerEnter(Collider other)
    {
        collidingObject = null;
        collidingObject = other.gameObject;
        ObjectDeets = collidingObject.GetComponent<AirQualityHolder>();
        ClearLog();
        Debug.Log("The details of your selection are:");
        Debug.Log("Ozone is " + ObjectDeets.Ozone);
        Debug.Log("Solar.R " + ObjectDeets.SolarR);
        Debug.Log("Wind is " + ObjectDeets.Wind);
        Debug.Log("Temp is " + ObjectDeets.Temp);
        Debug.Log("Month is " + ObjectDeets.Month);
        Debug.Log("Day is " + ObjectDeets.Day);
        // Debug.Log("rand1 is " + ObjectDeets.rand1);
        // Debug.Log("rand2 is " + ObjectDeets.rand2);
        // Debug.Log("rand3 is " + ObjectDeets.rand3);
        // Debug.Log("rand4 is " + ObjectDeets.rand4);
        // Debug.Log("rand5 is " + ObjectDeets.rand5);
    }

     void Update()
    {
    //     if (getReal3D.Input.GetButtonDown("Reset"))
    //     {

    //     //collidingObject = null;
    //    // SetCollidingObject(other);
    //     ObjectDeets = collidingObject.GetComponent<AirQualityHolder>();
    //     ClearLog();
    //     Debug.Log("The details of your selection are:");
    //     Debug.Log("Ozone is " + ObjectDeets.Ozone);
    //     Debug.Log("Solar.R " + ObjectDeets.SolarR);
    //     Debug.Log("Wind is " + ObjectDeets.Wind);
    //     Debug.Log("Temp is " + ObjectDeets.Temp);
    //     Debug.Log("Month is " + ObjectDeets.Month);
    //     Debug.Log("Day is " + ObjectDeets.Day);
    //     Debug.Log("rand1 is " + ObjectDeets.rand1);
    //     Debug.Log("rand2 is " + ObjectDeets.rand2);
    //     Debug.Log("rand3 is " + ObjectDeets.rand3);
    //     Debug.Log("rand4 is " + ObjectDeets.rand4);
    //     Debug.Log("rand5 is " + ObjectDeets.rand5);
    //         // if (collidingObject)
    //         // {
    //         //     GrabObject();
    //         // }
    //     }      
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void ClearLog()
{
        Debug.Log(" ");
        Debug.Log(" ");
        Debug.Log(" ");
        Debug.Log(" ");
        Debug.Log(" ");
        Debug.Log(" ");
        Debug.Log(" ");
        // Debug.Log(" ");
        // Debug.Log(" ");
        // Debug.Log(" ");
        // Debug.Log(" ");
        // Debug.Log(" ");

    // var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
    // var type = assembly.GetType("UnityEditor.LogEntries");
    // var method = type.GetMethod("Clear");
    // method.Invoke(new object(), null);
}
    // Update is called once per frame
    // void Update()
    // {
        
    // }
}
