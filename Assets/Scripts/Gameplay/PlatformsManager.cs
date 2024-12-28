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

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Vector3 offset = new Vector3(10, 2, 0);
            var newPlatform = Instantiate(platforms[Random.Range(0, platforms.Length)], gridParent);
            //newPlatform.transform.position += offset;
        }
    }

    void CreateStartingPlatform()
    {
        var newPlatform = Instantiate(platforms[Random.Range(0, platforms.Length)], gridParent);
        newPlatform.transform.position = new Vector3(-3, 0, 0);

        foreach(Transform enemy in newPlatform.transform){
            Debug.Log("check");
     //       Instantiate enemy and delete placeholder
        }
    }

    void CreatePlatform(GameObject platform, Vector2 position, GameObject parentObject)
    {

    }
}
