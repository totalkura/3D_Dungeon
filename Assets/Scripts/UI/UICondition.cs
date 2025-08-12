using System.Runtime.CompilerServices;
using UnityEngine;

public class UICondition : MonoBehaviour
{
    public Condition health;
    public Condition stamina;

    //inspector에서 보이지 않게 함
    [SerializeField, HideInInspector]
    public Condition eats;

    void Start()
    {
        CharacterManager.Instance.Player.condition.uiCondition = this;
    }

}
