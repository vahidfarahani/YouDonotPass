using Menu;
using Shoot;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private Vector3 Direction;
    private float Speed;
    private int life;
    public Text EnemyLife;
    public Animator Explode;
    void Start()
    {
        life = Random.Range(1, 6);
        EnemyLife.text = life.ToString();
    }
    /// <summary>
    /// The direction and speed of the enemy at the moment of birth
    /// </summary>
    public void EnemyBirthtInfo(Vector3 direction, float speed)
    {
        Direction = direction;
        Speed = speed;
    }
    // Update is called once per frame
    void Update()
    {
        transform.localPosition += Speed * Direction * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            life -= collision.GetComponent<Bullet>().Damage;
            EnemyLife.text = life.ToString();
            Destroy(collision.gameObject);
            if (life <= 0)
            {
                GameManager.Instance.IncrementScore();
                Animator explode = Instantiate(Explode, this.transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
        if (collision.tag == "DeadZone")
        {
            GameManager.Instance.DecrementLife();
            Destroy(gameObject);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "EndOfWorld")
        {
            Destroy(gameObject);
        }
    }
}
