using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    [SerializeField]
    private PlayerManager _pm;

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.collider.gameObject.name == "Player")
        {
            _pm.HandleDeath();
        }
    }    
}
