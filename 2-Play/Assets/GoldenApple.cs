using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenApple : MonoBehaviour
{
    public BoxCollider2D gameArea;
    public int WaitTime;

    private void Start()
    {
        StartCoroutine(Activate());
    }

    private void RandomPosition() 
    {
        Bounds bounds = this.gameArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }

    private IEnumerator Activate()
    {
        yield return new WaitForSeconds(WaitTime);
        RandomPosition();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
