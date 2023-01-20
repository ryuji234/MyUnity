using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class playerspaceship : MonoBehaviour
{
    public Text PlayerHP;
    private Rigidbody playerRigidbody;
    private GameObject bulletPrefab;
    public float speed = 8f;
    private int HP;
    private bool unDie = false;
    // Start is called before the first frame update
    void Start()
    {
        HP = 3;
        playerRigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        PlayerHP.text = "HP: " + (int)HP;
        float xInput = Input.GetAxis("Horizontal");
        float xSpeed = xInput * speed;
        Vector3 newVelocity = new Vector3();
        Vector3 pos = this.transform.position;
        newVelocity = new Vector3(xSpeed, 0f, 0f);
        playerRigidbody.velocity = newVelocity;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bullet = ObjectPool.GetObject(); // ¼öÁ¤
            if (bullet != null)
            {

                var direction = new Vector3(0, 0, 0.03f);
                bullet.transform.position = pos;
                bullet.Shoot(direction);
                
            }
            else { }

        }
    }
    public void Die()
    {
        --HP;
        if (HP>0)
        {
            gameObject.transform.position = new Vector3(0, 0, -100);
            if(!unDie)
            {
                unDie = true;
                StartCoroutine(Undie());
            }

        }
        else
        {
            PlayerHP.text = "HP: 0";
            gameObject.SetActive(false);
            GameManager gameManager = FindObjectOfType<GameManager>();
            gameManager.EndGame();
            
        }
      
    }
    IEnumerator Undie()
    {
        
        yield return new WaitForSeconds(1.0f);
        gameObject.transform.position = new Vector3(0, 0, -10);
        gameObject.tag = "Untagged";
        yield return new WaitForSeconds(1.0f);
        gameObject.tag = "Player";
        
        unDie = false;
    }
    

}
