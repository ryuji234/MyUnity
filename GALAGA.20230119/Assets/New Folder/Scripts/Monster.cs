using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody bulletRigidbody;
    private Vector3 direction = default;
    // Start is called before the first frame update
    public void Shoot(Vector3 direction)
    {
        this.direction = direction;
        transform.LookAt(direction);
        bulletRigidbody.velocity = transform.forward * speed;
        Invoke("DestroyMonster", 4f);
    }
    
    private void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
    }

    public void DestroyMonster()
    {
        MonsterPool.ReturnObject(this);
        CancelInvoke();
    }
    public void Die()
    {
        Invoke("DestroyMonster", 0);
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerspaceship player = other.GetComponent<playerspaceship>();

            if (player != null)
            {
                player.Die();
                
            }
        }

    }
}
