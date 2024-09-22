using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Game.Scripts.Services.SceneLoader
{
    public class SceneLoader : ISceneLoader
    {
        public async UniTask Load(string name) => await SceneManager.LoadSceneAsync(name);
    }
}