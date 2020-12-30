using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesInitializer : MonoBehaviour
{
    public static ScenesInitializer _scene;

    public void MainScene()
    {
        SceneManager.LoadScene("TeleportationScene");
    }

    //Minijuegos
    public void CockroachesGame()
    {
        SceneManager.LoadScene("Survival");
    }

    public void CricketGame()
    {
        SceneManager.LoadScene("Grillos");
    }
}
