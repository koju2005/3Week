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
        curSpeed = movingObject.Speed; //���� �� �� �������� ���� �ֱټӵ� ������
    }

    private void FixedUpdate()
    {
        if (!hasStopped)
        {
            if (movingObject.HowMoving == "1") //�����
            { 
                 if (transform.position.y >= movingObject.WantY) //���ϴ� Y��ǥ ���� �� ���� �ð� ���� �� �� ������
                {
                     movingObject.Speed = 0;
                     hasStopped = true;
                     StartCoroutine(ResetSpeedAfterDelay(movingObject.StopTime));
                }
                else if (transform.position.y <= movingObject.MinY) //���ϴ� Y��ǥ ���� �� ���� �ð� ���� �� �� ������
                {
                     movingObject.Speed = 0;
                     hasStopped = true;
                     StartCoroutine(ResetSpeedAfterDelay(movingObject.StopTime));
                }
            }

            if (movingObject.HowMoving == "2") //����
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
