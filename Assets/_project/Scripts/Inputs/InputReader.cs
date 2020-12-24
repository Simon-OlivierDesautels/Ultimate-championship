using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace _project.Scripts
{
    [CreateAssetMenu(fileName = "InputReader", menuName = "Game/Input Reader")]
    public class InputReader : ScriptableObject
    {
        private PlayerInputs _gameInput;
        
        public event UnityAction<float> MoveEvent;
        public event UnityAction FireEventHeld;
        public event UnityAction <SmashDirection> FireNorthEventCanceled;
        public event UnityAction <SmashDirection> FireSouthEventCanceled;

        public void OnMove(InputAction.CallbackContext context)
        {
            if (MoveEvent != null)
                MoveEvent.Invoke(context.ReadValue<float>());
        }

        public void OnFireNorth(InputAction.CallbackContext context)
        {
            if (FireEventHeld != null && context.phase == InputActionPhase.Performed)
                FireEventHeld.Invoke();
            if (FireNorthEventCanceled != null && context.phase == InputActionPhase.Canceled)
                FireNorthEventCanceled.Invoke(SmashDirection.North);
        }

        public void OnFireSouth(InputAction.CallbackContext context)
        {
            if (FireEventHeld != null && context.phase == InputActionPhase.Performed)
                FireEventHeld.Invoke();
            if (FireSouthEventCanceled != null && context.phase == InputActionPhase.Canceled)
                FireSouthEventCanceled.Invoke(SmashDirection.South);
        }
        

        #region -Enable/disable-

        private void OnEnable()
        {
            _gameInput = new PlayerInputs();
            _gameInput.Enable();
        }

        private void OnDisable()
        {
            _gameInput.Disable();
        }

        #endregion
    }
}