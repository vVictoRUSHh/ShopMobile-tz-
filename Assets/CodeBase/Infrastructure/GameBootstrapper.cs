using System;
using CodeBase.Services.SceneLoader;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        [SerializeField] private SceneLoadService _sceneLoadService;
        private Game _game;

        private void Awake()
        {
            StartCoroutine(_sceneLoadService.LoadGame(Init, "Game", 1f));
            DontDestroyOnLoad(this);
        }

        private void Init()
        {
            _game = new Game();
        }
    }
}