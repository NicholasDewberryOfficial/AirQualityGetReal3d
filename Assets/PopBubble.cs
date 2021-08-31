using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopBubble : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        if (other.gameObject.CompareTag("Bubble"))
        {
            GameObject.Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter");
        if (collision.collider.gameObject.CompareTag("Bubble"))
        {
            GameObject.Destroy(collision.collider.gameObject);
        }
    }
}
