using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] public Text textSnakeLength;
    [SerializeField] public Text textBest;
    
    
    void Update()
    {
        textBest.text = "Best Score: " + GameManager.singleton.BestScore;
        textSnakeLength.text = "" + GameManager.singleton.SnakeLength;
    }

}
