using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gerenciador : MonoBehaviour
{
    public Transform cube;
    // Start is called before the first frame update
    void Start()
    {
        cube = GameObject.Find("Cube").transform;
    }

    // Update is called once per frame
    void Update()
    {
        cube.rotation *= Quaternion.Euler(30 * Time.deltaTime, 0, 0);
    }
}
