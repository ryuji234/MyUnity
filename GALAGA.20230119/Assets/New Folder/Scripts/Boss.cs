using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class Boss : MonoBehaviour
{
    public Text BossHP;
    public GameObject BossHPText;
    private int hp = 60;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;
    private float spawnRate;
    private float timeAfterSpawn;
    private int one = 1;
    void Update()
    {
        BossHP.text = "Boss HP: " + (int)hp;
        timeAfterSpawn += Time.deltaTime;
        Vector3 pos = this.transform.position;
        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;
            one *= -1;
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
        gameObject.transform.Translate(new Vector3(one, 0, 0) * Time.deltaTime);
        BossHP.transform.Translate(new Vector3(-1 * one, 0, 0) * Time.deltaTime);

    }
    public void Hit()
    {
        --hp;
        GameManager manager = FindObjectOfType<GameManager>();
        manager.ScoreAdd();
        if (hp <= 0)
        {
            BossHP.text = "Boss HP: 0";
            BossHPText.SetActive(false);
            Die();
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);

    }
}
