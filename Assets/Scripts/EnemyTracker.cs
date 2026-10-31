using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class EnemyTracker : MonoBehaviour
{
    // Generic list declaration
    private List<string> enemies = new List<string>();
    public TextMeshProUGUI enemyText;
    void Start()
    {

    }
    public void SpawnEnemy(string enemyName)
    {
        // spawn enemy
        enemies.Add(enemyName);
        UpdateUI();
    }
    public void DefeatEnemy(string enemyName)
    {
        // kill enemy
        if (enemies.Remove(enemyName))
        {
            Debug.Log("EnemyDefeated");
        }
        else
        {
            Debug.LogWarning("Could not find enemy");
        }
        UpdateUI();
    }
    // Only kills zombie
    public void KillZombie()
    {
        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            if (enemies[i].Contains("Zombie"))
            {
                enemies.RemoveAt(i);
            }
        }
        UpdateUI();
    }
    public void DefeatAllEnemies(string enemyName)
    {
        enemies.Clear();
        Debug.Log("All enemies killed");
        UpdateUI();
    }
    // Update is called once per frame
    private void UpdateUI()
    {
        //Updates UI
        enemyText.text = "Enemy Tracker \n";
        for (int i = 0; i < enemies.Count; i++)
        {
            enemyText.text += $"- {enemies[i]}\n";
        }
    }
}