using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Food : MonoBehaviour
{
    public GameObject FoodObj;
    public bool isEaten = false;
    public int FoodCount;
    public TextMeshPro TextFood;
    public Vector3 Rotation;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TextFood.SetText(FoodCount.ToString());

        Quaternion quaternion = Quaternion.Euler(Rotation * Time.deltaTime);
        FoodObj.transform.rotation = quaternion * FoodObj.transform.rotation;

    }

    private void OnCollisionEnter(Collision collision)
    {
        FindObjectOfType<PlrCntr>().AddTail(FoodCount);
        isEaten = true;
        Destroy(FoodObj.gameObject);
    }

}
