using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public TMPro.TextMeshProUGUI gameStartText;
    public TMPro.TextMeshProUGUI scoreText;

    public int score;

    private float promptDisplayTime;

    void Start()
    {
        gameStartText.color = new Color(1, 1, 1, 1);
        promptDisplayTime = Time.time;
        setScore(0);
    }

    void Update()
    {
        if (Time.time - promptDisplayTime > 4.0f)
            StartCoroutine(FadeImage(true));

        if (Input.GetKey(KeyCode.Escape))
        {
            //Go to main menu on Escape.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    IEnumerator FadeImage(bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                gameStartText.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                gameStartText.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }

    public int getScore()
    {
        return this.score;
    }
    public void setScore(int score)
    {
        this.score = score;
        this.scoreText.text = score.ToString();
    }
}
