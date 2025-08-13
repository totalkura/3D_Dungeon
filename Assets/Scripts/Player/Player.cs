using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController controller;
    public PlayerCondition condition;
    public Equipment equip;

    public ItemData itemData;
    public Action addItem;

    public Rigidbody _rigidbody;
    public Vector3 resetPosition;

    public bool isJump;
    private void Awake()
    {
        CharacterManager.Instance.Player = this;
        controller = GetComponent<PlayerController>();
        condition = GetComponent<PlayerCondition>();
        _rigidbody = GetComponent<Rigidbody>();

        resetPosition = transform.position;
        isJump = false;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Jump"))
        {
            Debug.Log("Jumped on Jump Object!");
            isJump = true;
            Vector3 jumpForce = new Vector3(0, 200f, 0);
            Debug.Log("Applying jump force: " + jumpForce);
            _rigidbody.AddForce(jumpForce, ForceMode.Impulse);

        }
    }

}
