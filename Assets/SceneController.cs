using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{

    public int Counter = 0;
    public GameObject CookiePreFab;
    public Text CounterText;
    public bool reload;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.transform != null && hit.collider.CompareTag("cookie"))
            {
                hit.transform.gameObject.GetComponent<CookieController>().Pickup();
                Counter++;
                CounterText.text = "Счет: " + Counter;
                Debug.Log(Counter);
                Debug.Log("Есть совпадение");
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void CreateCookie()
    {
        float x = Random.Range(-8, 8);
        float y = Random.Range(-5, 4);
        var position = new Vector3(x, y, 5);
        Instantiate(CookiePreFab, position, Quaternion.identity); 
    }

    public void Restart()
    {
        reload = true;
        Time.timeScale = 1;
        SceneManager.LoadScene(0);

    }
}
