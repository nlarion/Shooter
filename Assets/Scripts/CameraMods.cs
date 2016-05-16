using UnityEngine;
using System.Collections;

public class CameraMods : MonoBehaviour
{

    // Handle gameobjects collider with a deathzone object
    void OnCollision(Collision2D other)
    {
        if (other.gameObject.tag == "MainCamera")
        {
            // if player then tell the player to do its FallDeath
            other.gameObject.GetComponent<Camera>().CameraManip();
        }
    }
}
