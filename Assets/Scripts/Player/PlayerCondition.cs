using System;
using UnityEngine;

public interface IDamageable
{
    void TakePhysicalDamage(int damage);
}

public class PlayerCondition : MonoBehaviour, IDamageable
{
    public UICondition uiCondition;

    Condition health { get { return uiCondition.health; } }
    Condition stamina { get { return uiCondition.stamina; } }

    public float noHungerHealthDecay;

    public event Action onTakeDamage;

    public GameObject effectDie;

    public float timeSet;
    public float staminaTimeSet;

    void Update()
    {
        if (timeSet >= 0f)
        {
            timeSet -= Time.deltaTime;
            stamina.Add((stamina.passiveValue + staminaTimeSet) * Time.deltaTime);
            Debug.Log(timeSet);
        }
        else
        {
            stamina.Add(stamina.passiveValue * Time.deltaTime);
        }

        if (health.curValue == 0f || CharacterManager.Instance.Player.transform.position.y < -10f)
        {
            Die();
        }

    }

    public void Heal(float amount)
    {
        health.Add(amount);
    }

    public void Eat(float amount)
    {
        stamina.Add(amount);
    }

    public void TimeAdd(float time,float value)
    {
        timeSet = time;
        staminaTimeSet = value;
    }


    public void Die()
    {
        effectDie.SetActive(true);
        stamina.Add(stamina.maxValue);
        health.Add(health.maxValue);
        CharacterManager.Instance.Player.transform.position = CharacterManager.Instance.Player.resetPosition;
        Invoke("EffactDieFalse", 2f);
    }

    public void TakePhysicalDamage(int damage)
    {
        health.Subtract(damage);
        onTakeDamage?.Invoke();
    }

    public bool UseStamina(float amount)
    {
        if (stamina.curValue - amount < 0f)
        {
            return false;
        }

        stamina.Subtract(amount);

        return true;
    }



    public void EffactDieFalse()
    {
        effectDie.SetActive(false);
    }
}
