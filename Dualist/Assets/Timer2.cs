using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer2 : MonoBehaviour
{
    public Slider timerSlider;
    public Text timerText;
    public float gameTime;

    PlayerStats playerStats;

    private bool stopTimer;

    public Animator transitionAnim;
    public string sceneName;
    public string sceneName_overEating;
    public string sceneName_emotionalDamage;
    public string sceneName_success;
    public string sceneName_fail;

    // Start is called before the first frame update
    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        stopTimer = false;
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;
    }

    // Update is called once per frame
    void Update()
    {
        float time = gameTime - Time.time;

        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time - minutes * 60f);

        string textTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        if (time <= 0)
        {
            stopTimer = true;

            if (playerStats.currentHealth >= 50 && playerStats.currentSpirit >= 50)
            {
                StartCoroutine(LoadScene());
                IEnumerator LoadScene()
                {
                    transitionAnim.SetTrigger("end");
                    yield return new WaitForSeconds(0.8f);
                    SceneManager.LoadScene(sceneName);
                }
            }
            else
            {
                StartCoroutine(LoadScene());
                IEnumerator LoadScene()
                {
                    transitionAnim.SetTrigger("end");
                    yield return new WaitForSeconds(0.8f);
                    SceneManager.LoadScene(sceneName_fail);
                }
            }

            if (playerStats.currentHealth <= 0)
            {
                StartCoroutine(LoadScene());
                IEnumerator LoadScene()
                {
                    transitionAnim.SetTrigger("end");
                    yield return new WaitForSeconds(0.8f);
                    SceneManager.LoadScene(sceneName_overEating);
                }
            }

            if (playerStats.currentSpirit <= 0)
            {
                StartCoroutine(LoadScene());
                IEnumerator LoadScene()
                {
                    transitionAnim.SetTrigger("end");
                    yield return new WaitForSeconds(0.8f);
                    SceneManager.LoadScene(sceneName_emotionalDamage);
                }
            }
        }

        if (playerStats.currentHealth <= 0)
        {
            StartCoroutine(LoadScene());
            IEnumerator LoadScene()
            {
                transitionAnim.SetTrigger("end");
                yield return new WaitForSeconds(0.8f);
                SceneManager.LoadScene(sceneName_overEating);
            }
        }

        if (playerStats.currentSpirit <= 0)
        {
            StartCoroutine(LoadScene());
            IEnumerator LoadScene()
            {
                transitionAnim.SetTrigger("end");
                yield return new WaitForSeconds(0.8f);
                SceneManager.LoadScene(sceneName_emotionalDamage);
            }
        }

        if (stopTimer == false)
        {
            timerText.text = textTime;
            timerSlider.value = time;
        }
    }
}
