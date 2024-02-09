using System;

public class StartScreen : Window
{
    public event Action PlayButtonClick;

    protected override void OnButtonClick()
    {
        PlayButtonClick?.Invoke();
    }
}
