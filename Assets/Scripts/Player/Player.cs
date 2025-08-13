using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController controller;
    public PlayerCondition condition;

    public ItemData itemData;
    public Action addItem;

    public Rigidbody _rigidbody;
    public Vector3 resetPosition;

    private Transform currentMove;

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
            isJump = true;
            Vector3 jumpForce = new Vector3(0, 200f, 0);
            _rigidbody.AddForce(jumpForce, ForceMode.Impulse);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            currentMove = collision.transform;
            transform.SetParent(currentMove);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform == currentMove)
        {
            transform.SetParent(null);
            currentMove = null;
        }
    }
}
