using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Rigidbody player;
    //public Player player;
    public Transform WinSector;
    //public Scrollbar slider;
    public Slider slider;
    private float startX;
    private float minX;

    private void Start()
    {
        startX = player.transform.position.x;
    }

    private void Update()
    {
        //minY = Mathf.Min(minY, player.transform.positions.y);
        float currX = player.transform.position.x;
        float winX = WinSector.position.x;
        float t = Mathf.InverseLerp(startX, winX, currX);
        slider.value = t;
    }
}
