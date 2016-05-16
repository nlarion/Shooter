using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class CameraMods : MonoBehaviour
{

    // Handle gameobjects collider with a deathzone object
    void OnCollisionEnter2D (Collision2D other) {
        if (other.gameObject.tag == "MainCamera")
        {
            // if player then tell the player to do its FallDeath
            other.gameObject.GetComponent<Camera2DFollow>().CameraManip ();
        }
    }
}
