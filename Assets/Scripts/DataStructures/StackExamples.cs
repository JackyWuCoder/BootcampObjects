using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackExamples : MonoBehaviour
{
    public Stack<GameObject> stack = new Stack<GameObject>();
    public GameObject prefab;
    GameObject tempObj;

    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        // Push elemnt to the stack
        if (Input.GetKeyDown(KeyCode.A))
        {
            tempObj = Instantiate(prefab, transform);
            tempObj.transform.position = new Vector2(0, stack.Count);

            tempObj.name = $"Stacked-{stack.Count}";
            tempObj.GetComponent<SpriteRenderer>().color = Random.ColorHSV();

            stack.Push(tempObj);
            Debug.Log($"Pushed {tempObj.name}");
        }

        // Remove element but don't destroy
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log($"Popped from the stack : {stack.Pop().name}");
        }

        // Remove and destroy the element
        if (Input.GetKeyDown(KeyCode.X))
        {
            var remObj = stack.Pop();
            Destroy(remObj);
            Debug.Log($"Popped from stack : {remObj}");
        }

        // Peek the top element of the stack
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log($"Object at the top is : {stack.Peek()}");
        }
    }
}
