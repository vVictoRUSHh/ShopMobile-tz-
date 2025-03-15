using UnityEngine;

namespace CodeBase.Services.Input
{
    public class InputService : IInputService
    {
        public Vector2 _inputAxis =>  new Vector2(SimpleInput.GetAxis("Horizontal"), SimpleInput.GetAxis("Vertical"));
    }
}