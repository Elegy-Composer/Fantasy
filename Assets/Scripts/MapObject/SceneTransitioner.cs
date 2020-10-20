using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MapObject
{
    public class SceneTransitioner : MonoBehaviour
    {
        //maybe can add some transition effect
        [SerializeField]
        private string sceneName;
        public bool canPass = true;


        public void SwitchScene()
        {
            SceneManager.LoadScene(sceneName);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player" && canPass)
            {
                SwitchScene();
            }
        }
    }
}