using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WalkingNpc : MonoBehaviour
{
    /// <summary>
    /// Idea: the npc will walk until it get in the WalkingDestination
    /// and after he got in 1 walking destination he will move to the next one
    /// Since the walker will follow the box destination.
    /// I decided to do like this because if it was the npc changing positions it would just disappear and reappear again
    /// </summary>

    // User Story 3

    public int WalkingDestination;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TiredBoy"))
        {
            // In this one it will go to the fist again in the next walking destination
            if (WalkingDestination == 9)
            {
                this.gameObject.transform.position = new Vector3(264.74f, 115.50f, 407.62f);
                WalkingDestination = 0;
            }
            if (WalkingDestination == 8)
            {
                this.gameObject.transform.position = new Vector3(315f, 120.193f, 329.1f);
                WalkingDestination = 9;
            }
            if (WalkingDestination == 7)
            {
                this.gameObject.transform.position = new Vector3(369.5f, 116.952f, 293.5f);
                WalkingDestination = 8;
            }
            if (WalkingDestination == 6)
            {
                this.gameObject.transform.position = new Vector3(443.05f, 115.181f, 286.51f);
                WalkingDestination = 7;
            }
            if (WalkingDestination == 5)
            {
                this.gameObject.transform.position = new Vector3(474.5f, 116.468f, 322.5f);
                WalkingDestination = 6;
            }
            if (WalkingDestination == 4)
            {
                this.gameObject.transform.position = new Vector3(474.5f, 115.21f, 455.3f);
                WalkingDestination = 5;
            }
            if (WalkingDestination == 3)
            {
                this.gameObject.transform.position = new Vector3(438.8f, 113.2f, 512.2f);
                WalkingDestination = 4;
            }
            if (WalkingDestination == 2)
            {
                this.gameObject.transform.position = new Vector3(397.2f,114.944f,512.2f);
                WalkingDestination = 3;
            }
            if (WalkingDestination == 1)
            {
                this.gameObject.transform.position = new Vector3(336.11f, 114.944f, 517.1f);
                WalkingDestination = 2;
            }
            if (WalkingDestination == 0)
            {
                this.gameObject.transform.position = new Vector3(264.74f, 115.52f, 407.62f);
                WalkingDestination = 1;
            }
        }
    }
}
