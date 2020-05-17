using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    public const int maxHealth = 100;
    public bool destroyOnDeath;

    public int currentHealth = maxHealth;
    public bool isEnemy = false;
    public RectTransform healthBar;

    private bool isLocalPlayer;

    // Start is called before the first frame update
    void Start() {
        PlayerController pc = GetComponent<PlayerController>();
        isLocalPlayer = pc.isLocalPlayer;
    }

    public void TakeDamage(GameObject playerFrom, int amount) {
        currentHealth -= amount;
        //TODO network
    }

    public void onChangeHealth() {
        healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);

        if (currentHealth <= 0) {
            if (destroyOnDeath) {
                Destroy(gameObject);
            } else {
                currentHealth = maxHealth;
                healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
                Respown();
            }
        }
    }

    void Respown() {
        if (isLocalPlayer) {
            Vector3 spawnPoint = Vector3.zero;
            Quaternion spawnRotation = Quaternion.Euler(0, 180, 0);
            transform.position = spawnPoint;
            transform.rotation = spawnRotation;
        }
    }

    // Update is called once per frame
    void Update() {

    }
}