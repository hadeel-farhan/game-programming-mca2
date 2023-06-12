using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyBlock : MonoBehaviour
{
    public float speed;
    public Color startColor;
    public Color endColor;
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        startColor = Color.magenta;
        endColor = Color.yellow;
        speed = 1;
    }

    // Update is called once per frame
    void Update()
    {        

        // change the color of the platform
        GetComponent<Renderer>().material.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time, speed));

    }

    // Apply a force to the enemy or player after colliding with a bouncy block
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            GameObject Player = GameObject.FindWithTag("Player");
            Rigidbody player = Player.GetComponent<Rigidbody>();
            player.AddExplosionForce (300f, transform.position, 0f, 0f);
        }
        if (collision.gameObject.tag == "Enemy") {
            GameObject Enemy = GameObject.FindWithTag("Enemy");
            Rigidbody enemy = Enemy.GetComponent<Rigidbody>();
            enemy.AddExplosionForce (300f, transform.position, 0f, 0f);
        }
    }
}
