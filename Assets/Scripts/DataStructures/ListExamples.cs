using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListExamples : MonoBehaviour
{
    public GameObject prefab;
    public List<GameObject> list = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        GameObject tempObj;

        tempObj = Instantiate(prefab, transform);
        tempObj.transform.position = new Vector2(0, 0);
        list.Add(tempObj);

        tempObj = Instantiate(prefab, transform);
        tempObj.transform.position = new Vector2(1, 0);
        list.Add(tempObj);

        tempObj = Instantiate(prefab, transform);
        tempObj.transform.position = new Vector2(2, 0);
        list.Add(tempObj);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            int index = Random.Range(0, list.Count);
            if (list[index] != null)
            {
                list[index].GetComponent<SpriteRenderer>().color = Random.ColorHSV();
            }
        }

        if (Input.GetKeyDown(KeyCode.X) && list.Count > 0)
        {
            int index = Random.Range(0, list.Count);
            Destroy(list[index]);
            list.RemoveAt(index);
        }
    }
}
