using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Moving Object", menuName = "Moving Object Data", order = int.MaxValue)]
public class MovingObject : ScriptableObject
{
    public float Speed;
    public float StopTime;
    public float WantY;
    public float MinY;
}
