using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private Vector3 temp;

    void Start()
    {
        temp = this.transform.localScale;
        StartCoroutine(Decrease());
    }

    private IEnumerator Decrease()
    {
        while(temp.x > 0.0f)
        {
            yield return new WaitForSeconds(1);
            temp.x -= 0.5f;
            this.transform.localScale = temp;
        }

        Time.timeScale = 0;
    }
}
