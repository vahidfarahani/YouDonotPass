using System.Collections.Generic;
using UnityEngine;

namespace Utility
{
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        private static T _instance;
        private static object _lock = new object();

        public static T Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {

                        List<T> allInst = FindObjectsOfTypeIncludingDisabled<T>();

                        if (allInst.Count > 1)
                        {
                            Debug.LogError("[Singleton] Something went really wrong " +
                                " - there should never be more than 1 singleton!" +
                                " Reopening the scene might fix it.");
                            return _instance;
                        }
                        else if (allInst.Count == 1)
                        {
                            _instance = allInst[0];
                        }
                        /*if (_instance == null)
                        {
                            Debug.unityLogger.Log("[Singleton] An instance of " + typeof(T) +
                                " is needed in the scene, none was provided. Single Ton create a game object");
                            _instance = new GameObject(typeof(T).Name).AddComponent<T>();
                        }
                        else
                        {
                            Debug.unityLogger.Log("[Singleton] Using instance already created: " +
                                _instance.gameObject.name);
                        }*/
                    }

                    return _instance;
                }
            }
        }
        static List<E> FindObjectsOfTypeIncludingDisabled<E>()
        {
            var ActiveScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
            var RootObjects = ActiveScene.GetRootGameObjects();
            var MatchObjects = new List<E>();

            foreach (var ro in RootObjects)
            {
                var Matches = ro.GetComponentsInChildren<E>(true);
                MatchObjects.AddRange(Matches);
            }

            return MatchObjects;
        }
    }
}