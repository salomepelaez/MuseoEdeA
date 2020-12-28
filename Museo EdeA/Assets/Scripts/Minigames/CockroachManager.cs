using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CockroachManager : MonoBehaviour
{
    public static CockroachManager Instance;

    public TextMeshProUGUI counterText;
    public TextMeshProUGUI timerText;

    public int pointsCounter;

    public GameObject foodPrefab;

    private int seconds;
    private int minutes;

    private float timer;

    private string timerString;

    public void Awake()
    {
        Instance = this;
        timer = 0f;
    }

    void Start()
    {
        pointsCounter = 0;
        InvokeRepeating("TimerCounter", 0f, 1f);
        InvokeRepeating("InstantiateFood", 1f, Random.Range(3, 10));

        Debug.Log(timer);
    }

    void Update()
    {
        counterText.text = "Puntuación: " + pointsCounter;
    }

    void TimerCounter()
    {
        timer = timer + Time.deltaTime;  
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
}
