using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int BestScore;
    public int SnakeLength;
    public string ThisScene;

    public int CurrStage = 0;
    public static GameManager singleton;
    void Awake()
    {
        
        if (singleton == null) singleton = this;
        else if (singleton != this) Destroy(gameObject);

        //PlayerPrefs.SetInt("SnakeLength", 0);

        //{ SnakeLength = singleton.SnakeLength; }

        if (SceneManager.GetActiveScene().name != "lvl1")

        { SnakeLength = PlayerPrefs.GetInt("SnakeLength"); }

        else SnakeLength = 0;

        //if (SceneManager.GetActiveScene().name == "lvl1") PlayerPrefs.SetInt("SnakeLength", 0);

        ThisScene = SceneManager.GetActiveScene().name;

        if (ThisScene == "lvl1")
            PlayerPrefs.SetString("prev_level", "lvl1");
        else if (ThisScene == "lvl2")
            PlayerPrefs.SetString("prev_level", "lvl2");
        else if (ThisScene == "lvl3")
            PlayerPrefs.SetString("prev_level", "lvl3");

        BestScore = PlayerPrefs.GetInt("BestScore");
    }

    private void Update()
    {
        if (SnakeLength > BestScore) { BestScore = SnakeLength; PlayerPrefs.SetInt("BestScore", BestScore); }
    }

    public void NextLvl()
    {
        //if (PlayerPrefs.GetString("prev_level") == "lvl1")
        //{
        //    //PlayerPrefs.GetInt("SnakeLength");
        //    //PlayerPrefs.SetInt("SnakeLength", singleton.SnakeLength);
        //    SceneManager.LoadScene("lvl2");
        //}

        //else if (PlayerPrefs.GetString("prev_level") == "lvl2")
        //{
        //    //PlayerPrefs.GetInt("SnakeLength");
        //    PlayerPrefs.SetInt("SnakeLength", singleton.SnakeLength);
        //    SceneManager.LoadScene("lvl3");
        //}

        //else if (PlayerPrefs.GetString("prev_level") == "lvl3")
        //{
        //    //PlayerPrefs.GetInt("SnakeLength");
        //    PlayerPrefs.SetInt("SnakeLength", 0);
        //    SceneManager.LoadScene("lvl1");
        //}


        //CurrStage++;
        //FindObjectOfType<PlrCntr>().ResetPlayer();

        //PlayerPrefs.SetInt("SnakeLength", singleton.SnakeLength);

        //if (NextScene !="")
        //{ SceneManager.LoadScene(NextScene); }

    }

    public void RestartLvl()
    {
        if (SceneManager.GetActiveScene().name != "lvl1")

        { SnakeLength = PlayerPrefs.GetInt("SnakeLength"); }

        else PlayerPrefs.SetInt("SnakeLength", 0);

        //PlayerPrefs.SetInt("SnakeLength", 0);
        FindObjectOfType<PlrCntr>().ResetPlayer();
        SceneManager.LoadScene(ThisScene);
    }

}
