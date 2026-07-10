using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    public int maxHP = 100;

    public int CurrentHP { get; private set; }

    public bool IsDead => CurrentHP <= 0;

    public Action OnDeath;

    void Awake()
    {
        CurrentHP = maxHP;
    }

    public void Damage(int damage)
    {
        if (IsDead)
            return;

        CurrentHP -= damage;

        if (CurrentHP < 0)
            CurrentHP = 0;

        Debug.Log($"{gameObject.name} HP : {CurrentHP}");

        if (CurrentHP <= 0)
        {
            Animator animator = GetComponent<Animator>();

            if (animator != null)
            {
                animator.SetTrigger("Death");
            }

            OnDeath?.Invoke();
        }
    }
}
