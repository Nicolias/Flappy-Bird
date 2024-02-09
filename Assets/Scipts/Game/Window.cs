using UnityEngine;
using UnityEngine.UI;

public abstract class Window : MonoBehaviour
{
    [SerializeField] private Button _actionButton;
    [SerializeField] private CanvasGroup _canvasGroup;

    private void OnEnable()
    {
        _actionButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _actionButton.onClick.RemoveListener(OnButtonClick);
    }

    public void Open()
    {
        gameObject.SetActive(true);
        _canvasGroup.alpha = 1;
        _actionButton.interactable = true;
    }

    public void Close()
    {
        gameObject.SetActive(false);
        _canvasGroup.alpha = 0;
        _actionButton.interactable = false;
    }

    protected abstract void OnButtonClick();
}
