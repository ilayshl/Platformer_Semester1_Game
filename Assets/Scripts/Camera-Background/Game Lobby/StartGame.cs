using UnityEngine;

public class StartGame : MonoBehaviour
{

    private CameraMovement sceneCamera;
    [SerializeField] GameObject playerObject;

    private void Awake() {
        sceneCamera=Camera.main.GetComponent<CameraMovement>(); 
    }

    void Start()
    {
        sceneCamera.SetTarget(gameObject, new Vector3(0, 0, 0));
        Invoke("SpawnPlayer", 2);
    }

    void SpawnPlayer() {
        var newPlayer = Instantiate(playerObject, gameObject.transform.position+new Vector3(0, 10, 0), Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        sceneCamera.SetTarget(collision.gameObject, Vector3.zero);
        Destroy(gameObject, 4);
    }

}
