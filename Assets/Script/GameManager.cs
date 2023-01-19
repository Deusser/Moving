using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public Transform point1;
    public Transform point2;
    public Transform point3;
    public Transform point4;
    public Transform point5;
    public float Speed;
    public bool go;
    private Vector3 target;
    [SerializeField] private Vector3[] Points = new Vector3[3];
    public GameObject Cube;



    void Start()
    {
        Vector3[] Targets = new[] { point1.position, point2.position, point3.position, point4.position, point5.position }; 
        target = Targets[0];
        
    }


    void Update()
    {
        transform.Rotate(0, 0, 1);
        if (go)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * Speed);
        }
        if (transform.position == target)
        {
            if(target == point1.position)
            {
                target = point2.position;
            }
            else if (target == point2.position)
            {
                target = point1.position;
                transform.LookAt(target);
            }
        }
    }
}
