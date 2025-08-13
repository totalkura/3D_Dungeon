using UnityEngine;

public class Sphere : MonoBehaviour
{

    public float forcePower;

    void Update()
    {
        if(transform.position.y < -10f)
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();

            if (playerRb != null)
            {
                Vector3 force = (collision.transform.position - transform.position) * -1f;
                force.y = 2f;

                playerRb.AddForce(force * forcePower, ForceMode.Impulse);
            }
        }
    }
}
