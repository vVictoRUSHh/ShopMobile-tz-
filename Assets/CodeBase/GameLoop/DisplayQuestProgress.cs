using CodeBase.Services;
using TMPro;
using UnityEngine;

public class DisplayQuestProgress : MonoBehaviour
{
    [SerializeField] private ItemsCounter _itemsCounter;
    public TMP_Text _text;

    private void ShowPlayerProgress()
    {
        _text.text = _itemsCounter._currentItemsCount + " / " + _itemsCounter._itemsCount;
    }

    private void Start()
    {
        _text.text = "Отнеси 6 фруктов в зону!";
    }

    private void OnEnable()
    {
        EventBus.Instance.onItemDelivered += ShowPlayerProgress;
        EventBus.Instance.onPlayerWin += ShowWinMessage;
    }

    private void OnDisable()
    {
        EventBus.Instance.onItemDelivered -= ShowPlayerProgress;
        EventBus.Instance.onPlayerWin -= ShowWinMessage;
    }

    private void ShowWinMessage()
    {
        _text.text = "You win my bro!)";
    }
}