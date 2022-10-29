using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class button : MonoBehaviour
{
    public string NextScene;
    public int CurrStage;

    public Button Next;
    void Awake()
    {
        Button btn = Next.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    public void TaskOnClick()
    {
        if (PlayerPrefs.GetString("prev_level") == "lvl1")
        {
            //PlayerPrefs.SetInt("SnakeLength", GameManager.singleton.SnakeLength);
            //FindObjectOfType<GameManager>().NextLvl();
            //PlayerPrefs.GetInt("SnakeLength");
            SceneManager.LoadScene("lvl2");
        }

        else if (PlayerPrefs.GetString("prev_level") == "lvl2")
        {
            //PlayerPrefs.SetInt("SnakeLength", GameManager.singleton.SnakeLength);
            //FindObjectOfType<GameManager>().NextLvl();
            //PlayerPrefs.GetInt("SnakeLength");
            SceneManager.LoadScene("lvl3");
        }

        else if (PlayerPrefs.GetString("prev_level") == "lvl3")
        {
            //PlayerPrefs.SetInt("SnakeLength", GameManager.singleton.SnakeLength);
            //FindObjectOfType<GameManager>().NextLvl();
            //PlayerPrefs.GetInt("SnakeLength");
            SceneManager.LoadScene("lvl1");
        }
    }
    
}
