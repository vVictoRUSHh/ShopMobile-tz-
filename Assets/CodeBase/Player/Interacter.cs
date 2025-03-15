using CodeBase.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class Interacter : MonoBehaviour
{
    [SerializeField] private Transform _handPosition;
    [SerializeField] private float _hitDistance;
    [SerializeField] private GameObject _currentItem;
    private bool _canTakeItem = true;
    private DropButtonLogic _dropButton;
    public Button _button;

    [Inject]
    public void Construct(DropButtonLogic dropButtonLogic)
    {
        Debug.Log("Construct вызван! " + dropButtonLogic);
        _dropButton = dropButtonLogic;
        _button = dropButtonLogic._dropButton;
    }
      private void Update()
      {
          ShowDropButton();
          if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            InteractCheck(ray);
        }
      }

    private void ShowDropButton()
    {
        _button.gameObject.SetActive(!_canTakeItem);
    }

    private void OnDropButtonPressed()
    {
        var rigidbody = _currentItem.GetComponent<Rigidbody>();
        _currentItem.transform.SetParent(_currentItem.transform);
        rigidbody.isKinematic = false;
        rigidbody.velocity = transform.forward * 10f;
        _currentItem.transform.SetParent(null);
        _currentItem = null;
        _canTakeItem = true;
        print("Im working wtf!");
    }

    private void SetCurrentItem() => _currentItem = _handPosition.GetChild(0).gameObject;
    private void  InteractCheck(Ray ray)
    {
        if (Physics.Raycast(ray, out RaycastHit hit,_hitDistance))
        {
            if (hit.collider.TryGetComponent(out IInteractable interactable))
            {
                interactable.Interact(); 
            }
            if (hit.collider.TryGetComponent(out IItem item) && _canTakeItem)
            {
                item.TakeItem(_handPosition);
                SetCurrentItem();
                _canTakeItem = false;
                _button.onClick.AddListener(OnDropButtonPressed);
                _button.gameObject.SetActive(true);
            }
        }

    }
}
