using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapObject;

namespace SceneProgress.Scenes
{
    public class ConvinenceSceneEvent : SceneEvent
    {
        [SerializeField]
        private SceneProgressLogger sceneLogger;

        #region EventObject

        public GameObject ragPrefab;
        public GameObject rag;
        public GameObject checkpoint;

        public GameObject doorToStoreroom;
        public GameObject doorSprite;

        #endregion

        public void StartMopping()//maybe some time limit 
        {
            if (sceneLogger.currentStage != 1)
            {
                return;
            }
            sceneLogger.currentStage += 0.1f;
            rag = Instantiate(ragPrefab, gameObject.transform);
            checkpoint.SetActive(true);
        }

        public void FailMopping() { }//optional

        public void FinishMopping()
        {
            if (sceneLogger.currentStage != 1.1f)
            {
                return;
            }
            checkpoint.SetActive(false);
            Destroy(rag);
            doorToStoreroom.GetComponent<SceneTransitioner>().canPass = true;
            sceneLogger.currentStage = 2;
        }
    }
}