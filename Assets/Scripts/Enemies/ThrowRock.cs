using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowRock : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float timeLife;
    [SerializeField] private int damage;

    void Start()
    {
        Destroy(gameObject, timeLife);
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {

        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.ReciveDamage(damage);
            Destroy(this.gameObject);

        }

    }

}
