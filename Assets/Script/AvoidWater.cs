using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidWater : MonoBehaviour
{
    /// <summary>
    /// AvoidWater Script Credit: Marc-André Larouche
    /// </summary>

    private Vector3 prevPos = new Vector3(); // Last valid character position
    
    // Start is called before the first frame update
    void Start()
    {
        prevPos = transform.position;// Save the current position when we spawn
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag("Water"))
            {
                transform.position =new Vector3(prevPos.x, transform.position.y, prevPos.z);// Go back to the previous position
            }
            else
            {
                prevPos = transform.position;
            }
        }
    }
}
