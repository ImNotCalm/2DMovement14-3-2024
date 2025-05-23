using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    public float health { get; set; }
    public float damage { get; set; }
    public float speed { get; set; }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}
