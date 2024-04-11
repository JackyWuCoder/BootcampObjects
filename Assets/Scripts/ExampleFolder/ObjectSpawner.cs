using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] GameObject objToSpawn;
    [SerializeField] string objName;

    public void CustomSpawn(GameObject objectToSpawn)
    {
        Instantiate(objectToSpawn, transform.position, Quaternion.identity);
    }

    public void CustomSpawn(string objectName)
    {
        GameObject newObject = Resources.Load<GameObject>(objectName);
        Instantiate(newObject, transform.position, Quaternion.identity);
    }

    // Start is called before the first frame update
    private void Start()
    {
        CustomSpawn(objName);
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
