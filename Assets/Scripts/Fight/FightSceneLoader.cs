using System.Collections;
using System.Collections.Generic;
using Fight.Model;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Fight
{
    public class FightSceneLoader
    {
        public static void LoadScene(string BossName)
        {
            SceneLoadingModel.BossName = BossName;
            //Load scene
            SceneManager.LoadScene("FightScene");
        }
    }
}
