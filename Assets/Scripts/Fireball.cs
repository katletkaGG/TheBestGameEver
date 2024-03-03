using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyFireball", lifetime);
    }

    // Update is called once per frame

    public float Speed;
    public float lifetime;

    void FixedUpdate()
    {
        MoveFixedUpdate();
    }

    private void MoveFixedUpdate()
    {
        transform.position += transform.forward * Speed * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        DestroyFireball();
    }

    private void DestroyFireball()
    {
        Destroy(gameObject);
    }



}

