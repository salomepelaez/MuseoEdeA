using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CockroachManager : MonoBehaviour
{
    public static CockroachManager Instance;

    public ScenesInitializer _scene;

    public GameObject gameOverPanel;

    public bool inGame;
    public bool dead;

    public TextMeshProUGUI counterText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI finalpoints;

    public int pointsCounter;
    public int life;

    public GameObject foodPrefab;

    private int seconds;
    private int minutes;

    private float timer = 0;

    private string timerString;

    public void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        _scene = ScenesInitializer._scene;
        inGame = true;
        dead = false;
        life = 3;
        pointsCounter = 0;

        gameOverPanel.SetActive(false);

        if(inGame == true)
        {
            InvokeRepeating("InstantiateFood", 1f, Random.Range(3, 10));
        }

        else
        {
            CancelInvoke("InstantiateFood");
        }
    }

    void Update()
    {
        if(inGame == true)
            TimerCounter();
        
        counterText.text = "Puntuación: " + pointsCounter;

        CheckLife();
    }

    void TimerCounter()
    {
        timer += Time.deltaTime;;  
        seconds = (int)(timer % 60);
        minutes = (int)(timer / 60) % 60;

        timerString = string.Format("{00:00}:{01:00}", minutes, seconds);
        timerText.text = timerString;    
    }

    void InstantiateFood()
    {
        Vector3 pos = new Vector3(Random.Range(-6f, 7f), 2.16f, Random.Range(-7f, 6f));

        GameObject f = Instantiate(foodPrefab, Vector3.zero, Quaternion.identity);
        f.AddComponent<Food>();
        f.transform.position = pos; 
    }

    void CheckLife()
    {
        if(dead == true)
        {
            inGame = false;
            gameOverPanel.SetActive(true);
            finalpoints.text = "" + pointsCounter;
        }
    }
}
