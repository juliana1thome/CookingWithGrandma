using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class WalkingNpc : MonoBehaviour
{
    
    /// <summary>
    /// Idea: the npc will walk until it get in the WalkingDestination
    /// and after he got in 1 walking destination he will move to the next one
    /// Since the walker will follow the box destination.
    /// I decided to do like this because if it was the npc changing positions it would just disappear and reappear again
    /// </summary>

    // User Story 3
    public List<Vector3> wayPoints = new List<Vector3>();// Create a list of WayPoints
    public int WalkingDestination = 0;// It is public for Debug

    private void OnTriggerEnter(Collider other)
    {
        do
        {
            switch (WalkingDestination)
            {
                // In this one it will go to the fist again in the next walking destination
                case 9:
                    wayPoints.Add(new Vector3(264.74f, 115.52f, 407.62f));
                    WalkingDestination = 0;
                    break;
                
                case 8:
                    wayPoints.Add(new Vector3(397.2f, 114.944f, 512.2f));
                    WalkingDestination = 9;
                    break;
                
                case 7:
                    wayPoints.Add(new Vector3(438.8f, 113.2f, 512.2f));
                    WalkingDestination = 8;
                    break;
                
                case 6:
                    wayPoints.Add(new Vector3(474.5f, 115.21f, 455.3f));
                    WalkingDestination = 7;
                    break;
                
                case 5:
                    wayPoints.Add(new Vector3(474.5f, 116.468f, 322.5f));
                    WalkingDestination = 6;
                    break;
                
                case 4:
                    wayPoints.Add(new Vector3(443.05f, 115.181f, 286.51f));
                    WalkingDestination = 5;
                    break;
                
                case 3:
                    wayPoints.Add(new Vector3(443.05f, 115.181f, 286.51f));
                    this.gameObject.transform.position = wayPoints[0];
                    WalkingDestination = 4;
                    break;
                
                case 2:
                    wayPoints.Add(new Vector3(369.5f, 116.952f, 293.5f));
                    WalkingDestination = 3;
                    break;
                
                case 1:
                    wayPoints.Add(new Vector3(315f, 120.193f, 329.1f));
                    this.gameObject.transform.position = wayPoints[1];
                    WalkingDestination = 2;
                    break;
                
                case 0:
                    wayPoints.Add(new Vector3(264.74f, 115.50f, 407.62f));
                    this.gameObject.transform.position = wayPoints[0];
                    WalkingDestination = 1;
                    break;
            }
        } while (other.CompareTag("TiredBoy"));
    }
}
