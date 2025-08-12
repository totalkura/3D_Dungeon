using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController controller;
    public PlayerCondition condition;

    //public ItemData itemData;
    public Action addItem;

    public Vector3 resetPosition;
    private void Awake()
    {
        CharacterManager.Instance.Player = this;
        controller = GetComponent<PlayerController>();
        condition = GetComponent<PlayerCondition>();

        resetPosition = transform.position;
    }

    
}
