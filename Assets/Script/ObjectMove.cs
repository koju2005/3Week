using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    public MovingObject movingObject;
    private float curSpeed;
    private bool hasStopped = false;

    private void Awake()
    {
        movingObject.Speed = 5f;
    }
    private void Start()
    {
        curSpeed = movingObject.Speed; //정지 후 재 움직임을 위해 최근속도 가져옴
    }

    private void FixedUpdate()
    {
        if (!hasStopped)
        {
            if (movingObject.HowMoving == "1") //수직운동
            { 
                 if (transform.position.y >= movingObject.WantY) //원하는 Y좌표 도착 시 일정 시간 정지 후 재 움직임
                {
                     movingObject.Speed = 0;
                     hasStopped = true;
                     StartCoroutine(ResetSpeedAfterDelay(movingObject.StopTime));
                }
                else if (transform.position.y <= movingObject.MinY) //원하는 Y좌표 도착 시 일정 시간 정지 후 재 움직임
                {
                     movingObject.Speed = 0;
                     hasStopped = true;
                     StartCoroutine(ResetSpeedAfterDelay(movingObject.StopTime));
                }
            }

            if (movingObject.HowMoving == "2") //수평운동
            {
            
            }
        }
        transform.position += new Vector3(0, movingObject.Speed*Time.deltaTime, 0);
    }

    private IEnumerator ResetSpeedAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (transform.position.y >= movingObject.WantY)
        {
             transform.position += new Vector3(0, -0.1f, 0);
            movingObject.Speed = -curSpeed;
        }
        else
        {
            transform.position += new Vector3(0, 0.1f, 0);
            movingObject.Speed = curSpeed;
        }
        hasStopped = false;
    }
}
