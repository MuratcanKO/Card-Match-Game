using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preloader : MonoBehaviour
{
    [SerializeField]
    private SceneLoader sceneLoader;
    // Start is called before the first frame update
    void Start()
    {
        sceneLoader.AsyncSceneLoader(GlobalConstants.MENU_SCENE_NAME);
    }

}
