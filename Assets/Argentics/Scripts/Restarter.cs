using UnityEngine.SceneManagement;

namespace Argentics._2D
{
    public class Restarter : Singleton<Restarter>
    {
        public void RestartLvel()
        {
            SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
        }
    }
}
