using UnityEngine;
using System;

[Serializable]
public class FlagData
{
    [field:SerializeField] public Transform Flag { get; private set; }
    [field: SerializeField] public Vector3 EndRotation { get; private set; }
}
