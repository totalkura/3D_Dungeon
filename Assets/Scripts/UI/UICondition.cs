using System.Runtime.CompilerServices;
using UnityEngine;

public class UICondition : MonoBehaviour
{
    public Condition health;
    public Condition stamina;

    //inspector���� ������ �ʰ� ��
    [SerializeField, HideInInspector]
    public Condition eats;

    void Start()
    {
        CharacterManager.Instance.Player.condition.uiCondition = this;
    }

}
