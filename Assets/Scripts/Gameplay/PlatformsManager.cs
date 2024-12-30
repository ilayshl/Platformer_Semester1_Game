using Unity.VisualScripting;
using UnityEngine;

public class PlatformsManager : MonoBehaviour
{
    [SerializeField] Transform gridParent;
    [SerializeField] GameObject[] platforms;
    [SerializeField] GameObject[] enemies;

    void Start()
    {
        Invoke("CreateStartingPlatform", 1.5f);
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            CreatePlatform(platforms, transform.position, gridParent);
            other.gameObject.tag = "Used Ground";
        }
    }

    void CreateStartingPlatform()
    {
        var newPlatform = Instantiate(platforms[Random.Range(0, platforms.Length)], gridParent);
        newPlatform.transform.position = new Vector3(-3, 0, 0);
        CheckForEnemies(newPlatform.transform);

    }

    int GetRandomIndex(GameObject[] array)
    {
        int i = Random.Range(0, array.Length);
        return i;
    }
    void CheckForEnemies(Transform platform)
    {
        foreach (Transform enemy in platform.transform)
        {
            if (enemy.gameObject.CompareTag("Enemy"))
            {
                CreateEnemy(enemies, enemy.position);
                Destroy(enemy.gameObject);
            }
        }
    }
    void CreateEnemy(GameObject[] source, Vector3 position)
    {
        Instantiate(source[GetRandomIndex(source)], position, Quaternion.identity);
    }

    void CreatePlatform(GameObject[] source, Vector3 position, Transform parentTransform)
    {
        var newPlatform = Instantiate(source[GetRandomIndex(source)], parentTransform);
        newPlatform.transform.position = position;
        CheckForEnemies(newPlatform.transform);
    }
}
