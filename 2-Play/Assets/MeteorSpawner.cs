using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteorPrefab;
    public float interval;
    public float minSpeed;
    public float maxSpeed;
    public float minHeight;
    public float maxHeight;
    public float originX;

    void Start()
    {
        StartCoroutine(Timer());
    }

    void ShootMeteor()
    {
        GameObject m = Instantiate(meteorPrefab) as GameObject;

        m.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(minSpeed, maxSpeed), 0);

        Vector3 pos = new Vector3(originX, Random.Range(minHeight, maxHeight), 0);

        m.transform.position = pos;
    }

    private IEnumerator Timer()
    {
        while(true)
        {
            ShootMeteor();
            yield return new WaitForSeconds(this.interval);
        }
    }
}
