using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBehavior : MonoBehaviour
{
    public static int pickupCount = 0;
    public int scoreValue = 1;

    public AudioClip pickupSFX;
    public static int score = 0;

    Collider m_Collider;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        pickupCount++;
        Debug.Log("Pickup count: " + pickupCount);
        m_Collider = GetComponent<Collider>();

    }

    // Update is called once per frame
    void Update()
    {
        if(LevelManager.isGameOver) {
            pickupCount = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            AudioSource.PlayClipAtPoint(pickupSFX, Camera.main.transform.position);
            gameObject.GetComponent<Animator>().SetTrigger("pickupDestroyed");
            m_Collider.enabled = false;
            Destroy(gameObject, 1);
        }

    }
    private void OnDestroy() {
        if (!LevelManager.isGameOver) {
            pickupCount--;
            Debug.Log("Pickup remaining: " + pickupCount);
            // Regular points if in second half of game
            if (LevelManager.countDown < (LevelManager.levelDuration / 2)) {
                score = score + scoreValue;
            }
            // Double points if in first half of game
            else {
                score = score + (scoreValue * 2);
            }

            // Level is won if there are no more gem pickups
            if(pickupCount <= 0)
            {
                FindObjectOfType<LevelManager>().LevelBeat();
            }
        }
    }
}
