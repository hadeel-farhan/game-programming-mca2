using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float jumpAmount = 2;

    Rigidbody rb;
    public AudioClip jumpSFX;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 5);
    }

    void Update()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        // Destroy the object and end the game if the player falls off the board
        if (transform.position.y < -2) {
            LevelManager.isGameOver = true;
            LevelManager.countDown = 0;
            FindObjectOfType<LevelManager>().LevelLost();
            Destroy(gameObject);
        }

        if(!LevelManager.isGameOver) {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 forceVector = new Vector3(moveHorizontal, 0.0f, moveVertical);

            rb.AddForce(forceVector * speed);

            // Jump and sound effect
            if (Input.GetKeyDown(KeyCode.Space)) {
                if (transform.position.y < 3) {
                    rb.AddForce(0, jumpAmount, 0, ForceMode.Impulse);
                    AudioSource.PlayClipAtPoint(jumpSFX, Camera.main.transform.position);
                }
            }
            // Double speed if shift pressed
            if (Input.GetKey(KeyCode.LeftShift))
            {
                rb.AddForce(forceVector * speed * 2);
            }
        }
        // if gameover keep the player stationary
        else {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

    }
}
