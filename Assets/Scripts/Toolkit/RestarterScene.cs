using UnityEngine;
using UnityEngine.SceneManagement;

namespace Toolkit
{
    public class RestarterScene : MonoBehaviour
    {
        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}