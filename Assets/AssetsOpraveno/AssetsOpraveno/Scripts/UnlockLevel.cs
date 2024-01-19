using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnlockLevel : MonoBehaviour
{
    private static List<Level> levels = new List<Level>();

    [SerializeField] private List<string> sceneName = new List<string>();

    private void Awake()
    {
        FillSceneList();
        //DontDestroyOnLoad(this.gameObject); 
    }

    void FillSceneList()
    {
        foreach (var sceneInList in sceneName)
        {   
            Level newLevel = new Level(sceneInList);
            levels.Add(newLevel);
            Debug.Log("level prirazen " + newLevel.sceneName);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        UnlockFirstLevelAndMenu();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadLevel(int i)
    {
        Level levelToLoad = levels[i];
        Debug.Log("level " + i);

        if (levelToLoad.isUnlocked == true)
        {
           SceneManager.LoadScene(levelToLoad.sceneName);
           Debug.Log("level " + levelToLoad.sceneName);
        }
        else
        {
           Debug.Log("Locked");
        }
    }



    void UnlockFirstLevelAndMenu()
    {
        Level menuLevel = levels[0];
        Level firstLevel = levels[1];
        menuLevel.Unlock();
        firstLevel.Unlock();
        Debug.Log("Levels Unlocked");
    }

    static public void Victory()
    {
        //Level nextLevel = levels[nextLevelNumber];
        for (int i = 0; i < levels.Count; i++)
        {
            if (levels[i].isUnlocked == false)
            {
                levels[i].Unlock();
                break;
            }
        }
        //nextLevel.Unlock();
    }

    static public void Defeat()
    {
        //Hodí to hráče do menu
        SceneManager.LoadScene(0);
    }

    class Level
    {
        public bool isUnlocked;
        public string sceneName;

        public Level(string sceneName)
        {
            isUnlocked = false;
            this.sceneName = sceneName;
        }

        public void Unlock()
        {
            isUnlocked = true;
        }
    }
}
