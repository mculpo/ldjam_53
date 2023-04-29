using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    None = 0,
    Up = 1 << 0,
    Down = 1 << 1,
    Left = 1 << 2,
    Right = 1 << 3
}