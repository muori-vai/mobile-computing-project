using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteorPrefab;
    public float rotationZ;
    public float interval;
    public float minSpeed;
    public float maxSpeed;
    public float minSpeedY;
    public float maxSpeedY;
    public float minHeight;
    public float maxHeight;
    public float minWidth;
    public float maxWidth;

    void Start()
    {
        StartCoroutine(Timer());
    }

    void ShootMeteor()
    {
        GameObject m = Instantiate(meteorPrefab) as GameObject;

        m.transform.Rotate(0, 0, rotationZ);

        m.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(minSpeed, maxSpeed), Random.Range(minSpeedY, maxSpeedY));

        Vector3 pos = new Vector3(Random.Range(minWidth, maxWidth), Random.Range(minHeight, maxHeight), 0);

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
