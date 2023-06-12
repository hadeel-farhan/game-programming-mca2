using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Transform player;
    public int moveSpeed = 1;
    public AudioClip enemySFX;
    Collider m_Collider;


    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(Vector3.forward, 50 * Time.deltaTime);

        if(player == null) {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        m_Collider = GetComponent<Collider>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if(!LevelManager.isGameOver){
            transform.Rotate(Vector3.forward, 360 * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);  
        }
  
    }

    // If enemies collide, destroy each other and play the animation
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            gameObject.GetComponent<Animator>().SetTrigger("enemyDestroyed");
            AudioSource.PlayClipAtPoint(enemySFX, Camera.main.transform.position);
            m_Collider.enabled = false;
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            Destroy(gameObject, 2);
        }
    }
}
