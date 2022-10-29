using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlrCntr : MonoBehaviour
{

    public Transform SnakeHead;
    public Transform SnakeTail;
    public float TailDiameter;
    public TextMeshPro LenghtText;

    private List<Transform> snakeTails = new List<Transform>();
    private List<Vector3> positions = new List<Vector3>();
    [SerializeField] private float distance;

    public int NormalSpeed;
    private int Speed;
    public float rotationSpeed = 50;
    public float LerpTimeX;
    public float LerpTimeZ;
    
    private Vector3 startPos;
    private int TailCount;

    //private float distance;
    private Vector3 refVelocity;

    private Transform currTail;
    private Transform prevTail;

    //public AudioSource Boom;
    //public AudioSource Eat;
    //public AudioSource Rotten;

    public bool StarBoxPassed = false;

    private void Awake()
    {
        //snakeTails.Add(SnakeHead);
        //positions.Add(SnakeHead.position);
    }

    private void Start()
    {
        startPos = transform.position;
        
        for (int i = 0; i < 100; i++)
        {
            float AddT = TailDiameter * (i);
            //Vector3 pos = new Vector3(transform.localPosition.x + AddT, transform.localPosition.y, transform.localPosition.z);

            Vector3 pos = new Vector3(AddT, 0, 0);
            positions.Add(pos);
        }

            //int StartTail = GetComponent<GameManager>().SnakeLength;

            int StartTail = PlayerPrefs.GetInt("SnakeLength");
       
        if (SceneManager.GetActiveScene().name != "lvl1") 
        { 
            AddTail(StartTail);
            GetComponent<GameManager>().SnakeLength = GetComponent<GameManager>().SnakeLength / 2;
        }
        
        //StopAllCoroutines;
    }

    private void Update()
    {
        MoveHead();
        MoveTail();

        LenghtText.SetText(GetComponent<GameManager>().SnakeLength.ToString());
    }

    public void AddTail(int TailCount)
    {
        try
        {

            for (int i = 0; i < TailCount; i++)
            {
                //float AddT = TailDiameter * (i);
                ////Vector3 pos = new Vector3(transform.localPosition.x + AddT, transform.localPosition.y, transform.localPosition.z);

                //Vector3 pos = new Vector3(AddT, 0, 0);
                //positions.Add(pos);

                Transform Tail = Instantiate(SnakeTail, positions[(snakeTails.Count) + i], Quaternion.identity, transform);
                snakeTails.Add(Tail);

                //positions.Add(Tail.position);

                //snakeTails[i+1].position = positions[i+1];

                GetComponent<GameManager>().SnakeLength++;

                Debug.Log(positions.Count);
                Debug.Log(snakeTails.Count);
                Debug.Log(positions[i]);
            }
        }

        catch { Debug.Log("Error"); }

        //Debug.Log(GetComponent<GameManager>().SnakeLength);
    }

    public void RemoveTail(int TailCount)
    {
        try
        {
            for (int i = 0; i < TailCount; i++)
            {
                Destroy(snakeTails[snakeTails.Count - 1].gameObject);
                snakeTails.RemoveAt(snakeTails.Count - 1);
                //positions.RemoveAt(i);

                GetComponent<GameManager>().SnakeLength--;

                Debug.Log(positions.Count);
                Debug.Log(snakeTails.Count);
                Debug.Log(positions[i]);
            }
            
        }

        catch { DeathBox(); }

        Debug.Log(positions.Count);
        Debug.Log(snakeTails.Count);
    }

    public void MoveHead()
    {
        if (StarBoxPassed)
        {
            int Speed = NormalSpeed * 2;
            //StartCoroutine(AfterStarBox());
        }

        else
        {
            int Speed = NormalSpeed;
            SnakeHead.position += Vector3.left * Speed * Time.deltaTime;

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                SnakeHead.position += Vector3.back * Speed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                SnakeHead.position += Vector3.forward * Speed * Time.deltaTime;
            }
        }
        // big hit part than speed
        float MinZ = 31.2f;
        float MaxZ = 35.8f;

        if (SnakeHead.position.z <= MinZ) SnakeHead.position = new Vector3(SnakeHead.position.x, SnakeHead.position.y, MinZ);
        if (SnakeHead.position.z >= MaxZ) SnakeHead.position = new Vector3(SnakeHead.position.x, SnakeHead.position.y, MaxZ);
    }

    // public void AfterStarBox()
    //{
    //    yield return new WaitForSeconds(5);
    //    int Speed = NormalSpeed;
    //}

    public void MoveTail()
    {
        foreach (var tail in snakeTails)

        {
            for (int i = 0; i < snakeTails.Count; i++)

            {
                int Speed = NormalSpeed;
                snakeTails[i].position = SnakeHead.position + positions[i];

                

                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    snakeTails[i].position += Vector3.forward * Speed * Time.deltaTime * i * 3;
                }

                if (Input.GetKey(KeyCode.RightArrow))
                {
                    snakeTails[i].position += Vector3.back * Speed * Time.deltaTime * i * 3;
                }

                float MinZt = 31.2f;
                float MaxZt = 35.8f;
                if (SnakeHead.position.z <= MinZt) snakeTails[i].position = new Vector3(snakeTails[i].position.x, snakeTails[i].position.y, MinZt);
                if (SnakeHead.position.z >= MaxZt) snakeTails[i].position = new Vector3(snakeTails[i].position.x, snakeTails[i].position.y, MaxZt);
            }

            //    for (int i = 1; i < snakeTails.Count; i++)

            //    {
            //        if (Input.GetKey(KeyCode.LeftArrow))
            //        {
            //            snakeTails[i].position += (Vector3.forward * Speed * Time.deltaTime * i * 2);

            //            //snakeTails[i].position = Vector3.Lerp(snakeTails[i].position, (Vector3.forward * Speed * Time.deltaTime * i * 2), Time.time*i);
            //        }

            //        if (Input.GetKey(KeyCode.RightArrow))
            //        {
            //            snakeTails[i].position += Vector3.back * Speed * Time.deltaTime * i * 2;
            //        }


            //    }
            //}

            //float MinZ = 31.2f;
            //float MaxZ = 35.8f;

            //if (SnakeHead.position.z <= MinZ) SnakeHead.position = new Vector3(SnakeHead.position.x, SnakeHead.position.y, MinZ);
            //if (SnakeHead.position.z >= MaxZ) SnakeHead.position = new Vector3(SnakeHead.position.x, SnakeHead.position.y, MaxZ);

        }
    }

    void FixedUpdate() 
    {
     
    }

    void OnCollisionEnter(Collision collision)
    {
        ////Box interaction behavior

        //if (StarBoxPassed)
        //{
        //    if (!collision.transform.GetComponent<Final>()) ;
        //    {
        //        Destroy(collision.gameObject);
        //        //Boom.Play();
        //        //Instantiate(HitSmoke, collision.transform.positions, Quaternion.identity);
        //    }
        //}

    }

    public void DeathBox()
    {
        //Rotten.Play();
        SceneManager.LoadScene("tryagain");

        //GameManager.singleton.RestartLvl();
    }

    public void ResetPlayer()
    {
        //int Speed = NormalSpeed;
        transform.position = startPos;

    }

}
