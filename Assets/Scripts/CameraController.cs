using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;

    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position;
    }

    // Update is called once per frame
    void LateUpdate()//poziva se na kraju iscrtavanja kadra
    {
        transform.position = offset + target.transform.position;//offset je pocetni polozaj kamere
    }
}
