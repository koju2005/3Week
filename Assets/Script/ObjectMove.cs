using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    public MovingObject movingObject;
    [SerializeField] private float curSpeed;
    private bool hasStopped = false;

    private void Start()
    {
        curSpeed = movingObject.Speed;
    }

    private void FixedUpdate()
    {
        if (!hasStopped)
        {
            if (transform.position.y >= movingObject.WantY)
            {
                movingObject.Speed = 0;
                hasStopped = true;
                StartCoroutine(ResetSpeedAfterDelay(movingObject.StopTime));
            }
            else if (transform.position.y <= movingObject.MinY)
            {
                movingObject.Speed = 0;
                hasStopped = true;
                StartCoroutine(ResetSpeedAfterDelay(movingObject.StopTime));
            }
        }
        transform.position += new Vector3(0, movingObject.Speed, 0);
    }

    private IEnumerator ResetSpeedAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (transform.position.y >= movingObject.WantY)
        {
             transform.position += new Vector3(0, -curSpeed, 0);
            movingObject.Speed = -curSpeed;
        }
        else
        {
            transform.position += new Vector3(0, curSpeed, 0);
            movingObject.Speed = curSpeed;
        }
        hasStopped = false;
    }
}
