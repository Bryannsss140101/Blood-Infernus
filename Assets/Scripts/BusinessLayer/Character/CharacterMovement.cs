using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterMovement
{
    protected float speed;
    protected Vector3 direction;

    public float Speed { get => speed; }
    public Vector3 Direction { get => direction; }

    public abstract Vector3 Velocity();
}