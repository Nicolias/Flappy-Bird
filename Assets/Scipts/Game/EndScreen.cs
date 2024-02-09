using System;

public class EndScreen : Window
{
    public event Action RestartButtonClick;

    protected override void OnButtonClick()
    {
        RestartButtonClick?.Invoke();
    }
}