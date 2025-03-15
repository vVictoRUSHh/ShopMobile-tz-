using CodeBase.Services;
using CodeBase.Services.Factories;
using CodeBase.Services.Input;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class Game
    {
        public static IInputService _inputService;
        private PlayerFactory _playerFactory;
        private HudFactory _hudFactory;
        public Game()
        {
            _inputService = new InputService();
            _playerFactory = new PlayerFactory(ResourcesPaths.PLAYER_PATH);
            _hudFactory = new HudFactory(ResourcesPaths.HUD_PATH);
        }

        public void ShowPlayerInput() => Debug.Log(_inputService._inputAxis.ToString());
    }
}