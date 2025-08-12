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
    Condition eats { get { return uiCondition.eats; } }
    Condition stamina { get { return uiCondition.stamina; } }

    public float noHungerHealthDecay;

    public event Action onTakeDamage;


    void Update()
    {
        stamina.Add(stamina.passiveValue * Time.deltaTime);
        Debug.Log(CharacterManager.Instance.Player.transform.position.y);
        Debug.Log(CharacterManager.Instance.Player.resetPosition);
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
        eats.Add(amount);
    }

    public void Die()
    {
        CharacterManager.Instance.Player.transform.position = CharacterManager.Instance.Player.resetPosition;
    }

    public void TakePhysicalDamage(int damage)
    {
        health.Subtract(damage);
        onTakeDamage?.Invoke();
    }

    public bool UseStamina(float amount)
    {
        Debug.Log($"{stamina.curValue - amount < 0f}");
        if (stamina.curValue - amount < 0f)
        {
            return false;
        }

        stamina.Subtract(amount);

        return true;
    }
}
