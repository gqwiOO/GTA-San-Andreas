using Game.Scripts.Services.ScreenService;
using Zenject;

namespace Game.Scripts.Mechanics.Menu
{
    public class MenuManager: IInitializable
    {
        private IScreenService _screenService;

        [Inject]
        private void Construct(IScreenService screenService)
        {
            _screenService = screenService;
        }
        
        public void Initialize() => _screenService.Show<MenuScreen>();
    }
}