using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseGoal : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float direction;
    [SerializeField]
    private float max;
    [SerializeField]
    private Vector3 initialPos;

    void Start()
    {
        Restart();
    }

    void FixedUpdate()
    {
        Vector2 pos = this.transform.position;
        if(Mathf.Abs(pos.x) < max)
        {
            transform.Translate(new Vector2(direction, 0) * speed * Time.deltaTime);
        }
    }

    public void Restart()
    {
        this.transform.position = initialPos;
    }
}
