using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject player; // Reference to the player's transform
    public Vector3 offset = new Vector3(0f, 10f, -20f); // Offset to control the camera position
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            // Set the camera's position to follow the player with an offset
            transform.position = player.transform.position + offset;
        }
    }
}
