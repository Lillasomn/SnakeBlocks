using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PassCube : MonoBehaviour
{
    public int LoseWeight;
    public bool isStarBox;

    public TextMeshPro TextWeight;
    public Material EasyMat;
    public Material MidMat;
    public Material HardMat;
    private object Player;

    public Color Color;
    public Gradient Gradient;
    public int Min = 1;
    public int Max = 10;

    private void Start()
    {
        //cube color
        //if (LoseWeight < 4) GetComponent<Renderer>().sharedMaterial = EasyMat;
        //if (LoseWeight >= 4 && LoseWeight <= 6) GetComponent<Renderer>().sharedMaterial = MidMat;
        //if (LoseWeight > 6) GetComponent<Renderer>().sharedMaterial = HardMat;

        Color = Gradient.Evaluate ((float) LoseWeight / Max);
        GetComponent<Renderer>().material.color = Color;

        TextWeight.SetText(LoseWeight.ToString());
    }

    public void StarBox()
    {
        if (isStarBox) FindObjectOfType<PlrCntr>().StarBoxPassed=true;
    }

    private void OnTriggerEnter(Collider other)
    {
            FindObjectOfType<PlrCntr>().RemoveTail(LoseWeight); 
    }

    //coroutine remove tail

    private void OnCollisionEnter(Collision collision)
    {
        //if (LoseWeight> FindObjectOfType<GameManager>().SnakeLength)

        //{
        //    //FindObjectOfType<PlrCntr>().RemoveTail(LoseWeight);
        //    FindObjectOfType<PlrCntr>().FullStop();
        //    GameManager.singleton.RestartLvl();
        //}

        //else
        //{
        //    //GameManager.singleton.AddLength(-LoseWeight);
        //    FindObjectOfType<PlrCntr>().RemoveTail(LoseWeight);
        //    //FindObjectOfType<GameManager>().SnakeLength =- LoseWeight;
        //}

        //if (LoseWeight > GetComponent<GameManager>().SnakeLength)
        //{
        //    int NoSnake = GetComponent<GameManager>().SnakeLength;
        //    FindObjectOfType<PlrCntr>().RemoveTail(NoSnake);
        //    DeathBox();
        //}

        //else
        //{
        //    FindObjectOfType<PlrCntr>().RemoveTail(LoseWeight);
        //}
    }

}
