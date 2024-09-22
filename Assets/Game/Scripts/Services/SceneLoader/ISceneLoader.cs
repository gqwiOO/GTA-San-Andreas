using Cysharp.Threading.Tasks;

namespace Game.Scripts.Services.SceneLoader
{
    public interface ISceneLoader
    {
        UniTask Load(string name);
    }
}