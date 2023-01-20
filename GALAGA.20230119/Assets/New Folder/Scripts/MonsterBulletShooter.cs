using UnityEngine;

public class MonsterBulletShooter : MonoBehaviour
{
    public GameObject bulletspawner;
    public GameObject bulletPrefab;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 1f;

    private Transform target;
    private float spawnRate;
    private float timeAfterSpawn;
    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        if(FindObjectOfType<playerspaceship>() !=null)
        {
            target = FindObjectOfType<playerspaceship>().transform;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
        timeAfterSpawn += Time.deltaTime;
        Vector3 pos = this.transform.position;
        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;
            if (target != null)
            {

                var direction = target.position;

                var bullet = MonsterBulletPool.GetObject(); // ¼öÁ¤
                if (pos.z > -8f)
                {

                    bullet.transform.position = pos;
                    bullet.Shoot(direction);
                }
                else
                {
                    MonsterBulletPool.ReturnObject(bullet);
                }

                spawnRate = Random.Range(spawnRateMin, spawnRateMax);
            }
            else
            {
                
            }

        }

    }
}
