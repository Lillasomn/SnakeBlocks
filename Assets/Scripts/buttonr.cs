using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonr : MonoBehaviour
{
    public Button Restart;

    void Awake()
    {
        Button btn = Restart.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    public void TaskOnClick()
    {
        FindObjectOfType<GameManager>().RestartLvl();
        Debug.Log("click");
    }
}
