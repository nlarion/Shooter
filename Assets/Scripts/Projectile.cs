using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D other)
    {
        //destroy the projectile
        Destroy(this.gameObject);
    }
}
