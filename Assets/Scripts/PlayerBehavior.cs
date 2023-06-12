using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            //If you collide with the enemy the game is over and level is lost
            FindObjectOfType<LevelManager>().LevelLost();
            Destroy(gameObject);
        }
    }


    


}
