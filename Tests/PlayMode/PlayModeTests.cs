using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using DesignPatterns.Runtime.Creational.Singleton;

namespace DesignPatterns.Tests.PlayMode
{
    public sealed class PlayModeTests
    {
        #region CreationalTests
        [UnityTest]
        public IEnumerator MonoSingleton_Instance_ReturnsSameInstance()
        {
            GameObject go = new GameObject("MonoSingleton");
            
            go.AddComponent<TestMonoSingleton>();

            yield return null;

            TestMonoSingleton instanceA = TestMonoSingleton.Instance;
            
            TestMonoSingleton instanceB = TestMonoSingleton.Instance;

            Assert.IsNotNull(instanceA);
            
            Assert.AreSame(instanceA, instanceB);
        }
        [UnityTest]
        public IEnumerator MonoSingleton_DuplicateInstance_IsDestroyed()
        {
            GameObject goA = new GameObject("Singleton_A");
            
            goA.AddComponent<TestMonoSingleton>();

            yield return null;

            GameObject goB = new GameObject("Singleton_B");
            
            goB.AddComponent<TestMonoSingleton>();

            yield return null;

            TestMonoSingleton[] instances = Object.FindObjectsByType<TestMonoSingleton>(FindObjectsSortMode.None);

            Assert.AreEqual(1, instances.Length);
        }
        [UnityTest]
        public IEnumerator PersistentMonoSingleton_PersistsBetweenScenes()
        {
            GameObject go = new GameObject("PersistentSingleton");
            
            go.AddComponent<TestPersistentMonoSingleton>();

            yield return null;

            TestPersistentMonoSingleton instanceBefore = TestPersistentMonoSingleton.Instance;

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            yield return null;

            TestPersistentMonoSingleton instanceAfter = TestPersistentMonoSingleton.Instance;

            Assert.IsNotNull(instanceAfter);
            
            Assert.AreSame(instanceBefore, instanceAfter);
        }
        [UnityTest]
        public IEnumerator PersistentMonoSingleton_DuplicateInstance_IsDestroyed()
        {
            GameObject goA = new GameObject("Persistent_A");
            
            goA.AddComponent<TestPersistentMonoSingleton>();

            yield return null;

            GameObject goB = new GameObject("Persistent_B");
            
            goB.AddComponent<TestPersistentMonoSingleton>();

            yield return null;

            TestPersistentMonoSingleton[] instances =
                Object.FindObjectsByType<TestPersistentMonoSingleton>(FindObjectsSortMode.None);

            Assert.AreEqual(1, instances.Length);
        }
        #endregion

        #region TestElements
        private sealed class TestMonoSingleton : MonoSingleton<TestMonoSingleton> { }
        private sealed class TestPersistentMonoSingleton : PersistentMonoSingleton<TestPersistentMonoSingleton> { }
        #endregion
    }
}
