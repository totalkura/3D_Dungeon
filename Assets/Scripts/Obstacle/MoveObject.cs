using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float speed;
    public bool check = true;
    void Update()
    {
        if (transform.position.z < 9.0f) check = true;
        else if (transform.position.z > 24.0f) check = false;

        if (check) transform.position += new Vector3(0, 0, speed)*Time.deltaTime;
        else if(!check) transform.position += new Vector3(0, 0, -speed) * Time.deltaTime;


    }

}
