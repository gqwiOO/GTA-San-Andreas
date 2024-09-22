using System;
using System.Collections.Generic;
using Game.Scripts.Mechanics.Screen;
using UnityEngine;

namespace Game.Scripts.Services.ScreenService
{
    public class ScreenService : IScreenService
    {
        private readonly Dictionary<Type, UIScreen> _screens = new();
        
        public UIScreen Current { private set; get; }

        private UIScreen Get<TScreen>() where TScreen : UIScreen
        {
            return _screens[typeof(TScreen)];   
        }
        
        public void Show<TScreen>(bool hidePrevious = true) where TScreen : UIScreen
        {
            var screen = Get<TScreen>();
            
            if(hidePrevious && Current != null)
                Current.Hide();
            
            Current = screen;
            Current.Show();
        }

        public void Hide()
        {
             Current.Hide();
             Current = null;
        }

        public void AddScreen(UIScreen screen)
        {
            if (_screens.ContainsValue(screen))
            {
                Debug.LogError($"Screen {screen.GetType()} already in dictionary");
                return;
            }
            _screens.Add(screen.GetType(),screen);
        }

    }

    public interface IScreenService
    {
        void Show<TScreen>(bool hidePrevious = true) where TScreen : UIScreen;
        
        void Hide();
        

        void AddScreen(UIScreen screen);
        
        UIScreen Current { get; }
    }
}