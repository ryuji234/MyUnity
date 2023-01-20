using UnityEngine;

public class Monsterspowner : MonoBehaviour
{
    public GameObject bulletspawner;
    public GameObject bulletPrefab;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;

    private Transform target;
    private float spawnRate;
    private float timeAfterSpawn;
    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        target = FindObjectOfType<playerspaceship>().transform;

    }

    // Update is called once per frame
    void Update()
    {

        timeAfterSpawn += Time.deltaTime;
        Vector3 pos = this.transform.position;
        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;

            var direction = target.position;

            var bullet = MonsterPool.GetObject(); // ¼öÁ¤
            bullet.transform.position = pos;
            bullet.transform.LookAt(target);
            bullet.Shoot(direction);




            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }

    }
}
