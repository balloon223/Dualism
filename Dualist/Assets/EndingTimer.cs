using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingTimer : MonoBehaviour
{
    public Slider timerSlider;
    public Text timerText;
    public float gameTime;

    PlayerStats playerStats;

    private bool stopTimer;

    public Animator transitionAnim;
    public string sceneName;

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

                StartCoroutine(LoadScene());
                IEnumerator LoadScene()
                {
                    transitionAnim.SetTrigger("end");
                    yield return new WaitForSeconds(1.5f);
                    SceneManager.LoadScene(sceneName);
                }
            
        }

        if (stopTimer == false)
        {
            timerText.text = textTime;
            timerSlider.value = time;
        }
    }
}
