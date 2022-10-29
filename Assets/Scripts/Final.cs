using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Final : MonoBehaviour
{
    public GameObject Finalobj;
    public string CurrentScene;
    public int CurrStage = 0;

    private void OnTriggerEnter(Collider other)
    {
        //GameManager.singleton.NextLvl();
        int SnakeLength = GameManager.singleton.SnakeLength;

        PlayerPrefs.SetString("level", CurrentScene);
        PlayerPrefs.SetInt("SnakeLength", GameManager.singleton.SnakeLength);
        //PlayerPrefs.SetInt("SnakeLength", SnakeLength);
        SceneManager.LoadScene("lvl_pass");
    }
}
