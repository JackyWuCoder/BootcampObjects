using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayExample : MonoBehaviour
{
    public int num = 5;
    public int[] integerNumbers;
    public int[] newIntNumbers = new int[2];
    public GameObject[] gameObjectArray = new GameObject[2];
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        newIntNumbers[0] = 50;
        newIntNumbers[1] = -23;
        // newIntNumbers[2] = 65;

        // Assign prefab as child of the transform's game object
        gameObjectArray[0] = Instantiate(prefab, transform);
        // Set position of the prefab after it has been instantiated
        gameObjectArray[0].transform.position = new Vector2(0, 0);
        gameObjectArray[1] = Instantiate(prefab, transform);
        gameObjectArray[1].transform.position = new Vector2(1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            int index = Random.Range(0, gameObjectArray.Length);
            if (gameObjectArray[index] != null)
            {
                gameObjectArray[index].GetComponent<SpriteRenderer>().color = Random.ColorHSV();
            }
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            int index = Random.Range(0, gameObjectArray.Length);
            while (gameObjectArray[index] == null)
            {
                index = Random.Range(0, gameObjectArray.Length);
            }
            Destroy(gameObjectArray[index]);
        }
    }
}
