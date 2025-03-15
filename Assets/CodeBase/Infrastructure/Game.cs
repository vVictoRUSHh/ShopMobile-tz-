using CodeBase.Services;
using CodeBase.Services.Input;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class Game
    {
        public static IInputService _inputService;
        public Game()
        {
            _inputService = new InputService();
        }
    }
}