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
    }
}
