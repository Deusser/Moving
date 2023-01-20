using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement2 : MonoBehaviour
{
    private Vector3[] arrayPoint;
    private Vector3 nextPosition;
    [SerializeField] GameObject points;
    [SerializeField] private float speed;
    [SerializeField] private bool forward = true;
    [SerializeField] private int volumePoint;
    private int countStep = 0;

    private void Start()
    {
        Vector3[] arrayPoint2 = new Vector3[volumePoint];
        for (int i = 0; i < volumePoint; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
            Instantiate(points, spawnPosition, Quaternion.Euler(90, 0, 0));
            arrayPoint2[i] = spawnPosition;
        }
        nextPosition = arrayPoint2[countStep];
        arrayPoint = arrayPoint2;
        transform.position = nextPosition;
    }

    private void Update()
    {
        transform.Rotate(0, 0, 3);
        nextPosition.y = 1f;
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed * Time.deltaTime);
        if (transform.position == nextPosition)
        {
            if (forward)
            {
                if (countStep < (volumePoint - 1))
                {
                    countStep++;
                    forward = true;
                }
                else forward = false;
            }
            else if (countStep > 0)
            {
                countStep--;
                forward = false;
            }
            else forward = true;
            nextPosition = arrayPoint[countStep];
            transform.LookAt(nextPosition);
        }
    }
}