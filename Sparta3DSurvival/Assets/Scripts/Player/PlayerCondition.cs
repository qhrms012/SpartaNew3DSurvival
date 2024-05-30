using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public interface IDamagalbe
{
    void TakePhysicalDamage(int damage);
}
public class PlayerCondition : MonoBehaviour, IDamagalbe
{
    PlayerController controller;
    public UICondition uicondition;

    Condition health { get { return uicondition.health; } }
    Condition hunger { get { return uicondition.hunger; } }
    Condition stamina { get { return uicondition.stamina; } }

    public float noHungerHealthDecay;

    public event Action onTakeDamage;

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
    }

    void Update()
    {
        if (controller.IsMoving == true)
        {
            stamina.Subtract(stamina.passiveValue * Time.deltaTime);
        }
        else
        {
            stamina.Add(stamina.passiveValue * Time.deltaTime);
        }


        hunger.Subtract(hunger.passiveValue * Time.deltaTime);
        

        if(hunger.curValue == 0f)
        {
            health.Subtract(noHungerHealthDecay * Time.deltaTime);
        }

        if(health.curValue == 0f)
        {
            Die();
        }

    }

    public void Heal(float amout)
    {
        health.Add(amout);
    }

    public void Eat(float amout)
    {
        hunger.Add(amout);
        stamina.Add(amout);
    }
    

    public void Die()
    {
        Debug.Log("DIE");
    }

    public void TakePhysicalDamage(int damage)
    {
        health.Subtract(damage);
        onTakeDamage?.Invoke();
    }
}
