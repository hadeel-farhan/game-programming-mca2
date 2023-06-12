using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static float levelDuration = 40.0f;
    public static float countDown;

    public Text timerText;
    public Text gameText;
    public Text scoreText;

    public AudioClip gameOverSFX;
    public AudioClip gameWonSFX;

    public static bool isGameOver = false;
    public string nextLevel;

    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        countDown = levelDuration;
        SetTimerText();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver) {
            if (countDown > 0) {
                countDown -= Time.deltaTime;
            }
            else {
                countDown = 0;
                
                LevelLost();
            }
            SetTimerText();
            SetScoreText();
        }
    }

    void SetTimerText() {
        timerText.text = countDown.ToString("f2");
    }

    void SetScoreText() {
        scoreText.text = "Score: " + PickupBehavior.score.ToString();
    }

    public void LevelLost() {
        isGameOver = true;
        timerText.gameObject.SetActive(false);
        gameText.gameObject.SetActive(true);
        gameText.text = "GAME OVER!";

        Camera.main.GetComponent<AudioSource>().pitch = 1;
        AudioSource.PlayClipAtPoint(gameOverSFX, Camera.main.transform.position);

        Invoke("LoadCurrentLevel", 2);

    }
    public void LevelBeat() {
        isGameOver = true;
        timerText.gameObject.SetActive(false);
        gameText.gameObject.SetActive(true);
        SetScoreText();
        gameText.text = "YOU WIN!";

        Camera.main.GetComponent<AudioSource>().pitch = 2;
        AudioSource.PlayClipAtPoint(gameWonSFX, Camera.main.transform.position);

        // If there is a next level, invoke it. Otherwise stay on same screen
        if(!string.IsNullOrEmpty(nextLevel)) {
            Invoke("LoadNextLevel", 2);
        }
    }

    void LoadNextLevel() {
        SceneManager.LoadScene(nextLevel);
    }

    void LoadCurrentLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
