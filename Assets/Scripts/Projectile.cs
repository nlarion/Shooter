using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D other)
    {
        //destroy the projectile
        Destroy(this.gameObject);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if(other.tag == "MainCamera")
        {        
            //destroy the projectile
            Destroy(this.gameObject);
        }
    }
}
