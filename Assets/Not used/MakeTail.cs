using System.Collections.Generic;
using UnityEngine;

public class MakeTail : MonoBehaviour
{
    public Transform SnakeHead;
    public Transform SnakeTail;
    public float TailDiameter;

    private List<Transform> snakeTails = new List<Transform>();
    private List<Vector2> position = new List<Vector2>();

    private void Awake()
    {
        position.Add(SnakeHead.position);
    }

    private void Update()
    {
        float distance = ((Vector2) SnakeHead.position - position[0]).magnitude;

        if (distance > TailDiameter)
        {
            Vector2 direction = ((Vector2) SnakeHead.position - position[0]).normalized;

            position.Insert(0, position[0] + direction * TailDiameter);
            position.RemoveAt(position.Count - 1);

            distance -= TailDiameter;
        }

        for (int i = 0; i < snakeTails.Count; i++)
        {
            snakeTails[i].position = Vector2.Lerp(position[i + 1], position[i], distance / TailDiameter);
        }
    }

    public void AddTail()
    {
        Transform Tail = Instantiate(SnakeTail, position[position.Count - 1], Quaternion.identity, transform);
        snakeTails.Add(Tail);
        position.Add(Tail.position);
    }

    public void RemoveTail()
    {
        Destroy(snakeTails[0].gameObject);
        snakeTails.RemoveAt(0);
        position.RemoveAt(1);
    }
}
