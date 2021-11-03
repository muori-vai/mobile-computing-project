using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Snake2 : MonoBehaviour
{
    private Vector2 _direction = Vector2.down;
    
    private List<Transform> _segments;

    public Transform segmentPrefab;

    public Text gameOverText;

    private void Start()
    {
        _segments = new List<Transform>();
        _segments.Add(this.transform);
    }

    void FixedUpdate()
    {
        for(int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }

        this.transform.position = new Vector3(Mathf.Round(this.transform.position.x) + _direction.x, Mathf.Round(this.transform.position.y) + _direction.y, .0f);
    }

    public void MobileControls(int dir)
    {
        if(dir == 0 && _direction != Vector2.up)
            _direction = Vector2.down;
        else if(dir == 1 && _direction != Vector2.down)
            _direction = Vector2.up;
        else if(dir == 2 && _direction != Vector2.left)
            _direction = Vector2.right;
        else if(dir == 3 && _direction != Vector2.right)
            _direction = Vector2.left;
    }

    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;

        _segments.Add(segment);
    }

    private void GameOver()
    {
        for(int i = 0; i < _segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }

        _segments.Clear();

        this.gameOverText.text = "YOU LOSE!";

        Time.timeScale = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Apple")
        {
            Grow();
            Time.timeScale += 0.1f;
        }
        else if(other.tag == "Obstacle" || other.tag == "Player")
        {
            GameOver();
        }
    }

}