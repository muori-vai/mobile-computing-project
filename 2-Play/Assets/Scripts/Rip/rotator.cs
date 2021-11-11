using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotator : MonoBehaviour
{
    public int rotationSpeed;

    void Update()
    {
        this.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
