using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : Collaeble
{
    public string[] sceneNames;

    protected override void onCollide(Collider2D coll)
    {
        if(coll.name == "Player")
        {
            GameManager.instance.SaveState();
            string sceneName = sceneNames[Random.Range(0, sceneNames.Length)];
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }
}
