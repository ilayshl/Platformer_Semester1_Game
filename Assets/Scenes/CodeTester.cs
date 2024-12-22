using UnityEngine;

public class CodeTester : MonoBehaviour
{
    private Vector3[] directions=
    {Vector3.left,
    Vector3.right,
    Vector3.up,
    Vector3.down
    };

    [SerializeField] private GameObject[] objects;

    private void Start() {
        //RandomMovement(100);
        foreach(var selectedObject in objects){
            Destroy(selectedObject);
        }
    }
    void RandomMovement(int steps){
        for(int i=0; i<steps; i++){
            transform.position+=directions[Random.Range(0, directions.Length)];
        }
    }
}
