using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CountDownController : MonoBehaviour
{
    public int countdownTime;
    public Text countdownDisplay;
    public Text timeIsUpDisplay;
    public Button restartButton;
    private void Start()
    {
        StartCoroutine(CountdownToFinish());
        timeIsUpDisplay.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        
    }

    IEnumerator CountdownToFinish()
    {
        while(countdownTime >= 0)
        {
            countdownDisplay.text = "Время: " + countdownTime.ToString();

            yield return new WaitForSeconds(1f);

            countdownTime--;
        }

        GameObject cookie = GameObject.FindGameObjectWithTag("cookie");
        cookie.SetActive(false);
        countdownDisplay.gameObject.SetActive(false);
        var sceneController = GetComponent<SceneController>();
        sceneController.CounterText.gameObject.SetActive(false);
        timeIsUpDisplay.gameObject.SetActive(true);
        timeIsUpDisplay.text = $"Время вышло!\nВаш счет: {sceneController.Counter}";
        Time.timeScale = 0;
        restartButton.gameObject.SetActive(true);
    }

   
}
