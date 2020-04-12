using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int target;
    public Transform exitPoint;
    public Transform[] wayPoints;
    public float navigationUpdate;

    private Transform _enemy;
    private float _navigationTime;

    private void Start()
    {
        _enemy = GetComponent<Transform>();
    }

    private void Update()
    {
        if (wayPoints == null) return;
        _navigationTime += Time.deltaTime;
        if (!(_navigationTime > navigationUpdate)) return;
        _enemy.position = Vector2.MoveTowards(_enemy.position, target < wayPoints.Length ? 
            wayPoints[target].position 
            : exitPoint.position, _navigationTime);
        _navigationTime = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            target += 1;
        }else if (other.CompareTag("Finish"))
        {
            GameManger.Instance.RemoveEnemyFromScreen();
            Destroy(gameObject);
        }
    }
}
