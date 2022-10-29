using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buttonrsa : MonoBehaviour
{
    public Button Restart;
    public string ThisScene { get; private set; }

    void Awake()
    {
        Button btn = Restart.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    public void TaskOnClick()
    {
        ThisScene = PlayerPrefs.GetString("prev_level");
        SceneManager.LoadScene(ThisScene);
        Debug.Log("click");
    }
}
