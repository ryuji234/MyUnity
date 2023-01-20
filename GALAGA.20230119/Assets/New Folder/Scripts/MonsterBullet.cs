using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBullet : MonoBehaviour
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
        //transform.rotation = Quaternion.Euler(direction);
        gameObject.transform.localEulerAngles = new Vector3(0, 0, 0);
        Invoke("DestroyMonster", 3f);
    }

    private void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
    }

    public void DestroyMonster()
    {
        MonsterBulletPool.ReturnObject(this);
        CancelInvoke();
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerspaceship player = other.GetComponent<playerspaceship>();

            if (player != null)
            {
                player.Die();
                Invoke("DestroyMonster", 0);
            }
        }

    }
}
