using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class camara : MonoBehaviour
{
    Transform Camara;
    public Transform megaman;
    // Start is called before the first frame update
    void Start()
    {
        Camara = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Camara.position = new Vector3(megaman.position.x, Camara.position.y, Camara.position.z);
    }
}
