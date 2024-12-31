using UnityEngine;

public class PlayerInfo: MonoBehaviour {
    public int currentHealth;
    [SerializeField] private float winHeight = 50;
    private int startingHealth = 6;
    private int enemiesSlain;
    private PlayerMovement pMovement;

    private void Awake() {
        pMovement=GetComponent<PlayerMovement>();
    }

    void Start() {
        Invoke("CheckForWinning", 5f);
        currentHealth=startingHealth;
    }

    private void CheckForWinning() {
        if(transform.position.y>=winHeight) {
            pMovement.PlayerWon(enemiesSlain, (int)transform.position.y);
        } else {
            Invoke("CheckForWinning", 2f);
        }
    }

    public void UpdateEnemiesSlainValue(int amout) {
        enemiesSlain+=amout;
        Debug.Log($"Enemies slain: {enemiesSlain}");
    }

}
