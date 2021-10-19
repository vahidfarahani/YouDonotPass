using System.Collections;
using UnityEngine;

/// <summary>
/// To determine the starting and ending point of the enemy movement, we make two points with random X on the top of the screen and the death zone line
/// </summary>
public class EnemyManager : MonoBehaviour
{
    public Enemy Enemy;
    public Transform DeadZone;
    Vector2 offset;
    Coroutine EnemySpawner;
    RectTransform myCanvas;
    void Start()
    {
        myCanvas = transform.GetComponent<RectTransform>();
        offset = myCanvas.sizeDelta * myCanvas.lossyScale.x / 2;
        EnemySpawner = StartCoroutine(SpawnEnemy());
    }
    public void StopSpawn()
    {
        StopCoroutine(EnemySpawner);
    }
    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(1);
        while (true)
        {
            Vector3 startPoint = new Vector3(Random.Range(-offset.x, offset.x), offset.y, 0);
            Vector3 endPoint = new Vector3(Random.Range(-offset.x, offset.x), DeadZone.transform.position.y, 0);
            Vector3 newVector = endPoint - startPoint;
            Debug.DrawRay(startPoint, newVector, Color.blue);

            Enemy enemy = Instantiate(Enemy, startPoint, Quaternion.identity, transform);
            enemy.EnemyBirthtInfo(newVector, Random.Range(10f, 20f));
            yield return new WaitForSeconds(4);
        }
    }
}
