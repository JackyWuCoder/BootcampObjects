using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueExample : MonoBehaviour
{
    public Queue<GameObject> queue = new Queue<GameObject>();
    public GameObject prefab;

    GameObject tempObj;

    Vector2 lastEnqueuePosition = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            tempObj = Instantiate(prefab, transform);
            tempObj.transform.position = new Vector2(lastEnqueuePosition.x + 1, 0);

            tempObj.name = $"Queue-{queue.Count}";
            tempObj.GetComponent<SpriteRenderer>().color = Random.ColorHSV();

            queue.Enqueue(tempObj);
            lastEnqueuePosition = tempObj.transform.position;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            var remObj = queue.Dequeue();
            Destroy(remObj);
            Debug.Log("Dequeued from the queue " + remObj);
        }

        // Peek the next queue obj
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log($"Object at the front is {queue.Peek().name}");
        }
    }
}
