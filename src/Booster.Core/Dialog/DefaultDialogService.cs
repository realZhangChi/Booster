﻿namespace Booster.Core.Dialog;

public class DefaultDialogService : IDialogService
{
    public Task<bool> DisplayAlertAsync(string title, string message, string accept = "Yes", string cancel = "No")
    {
        return Shell.Current.CurrentPage.DisplayAlert(title, message, accept, cancel);
    }

    public Task<string> DisplayPromptAsync(string title, string message, string accept = "OK", string cancel = "Cancel",
        string? placeholder = null, int maxLength = -1, Keyboard? keyboard = default, string initialValue = "")
    {
        return Shell.Current.CurrentPage.DisplayPromptAsync(
            title,
            message,
            accept,
            cancel,
            placeholder,
            maxLength,
            keyboard,
            initialValue);
    }

    public Task<string> DisplayActionSheet(string title, string cancel, string destruction, params string[] buttons)
    {
        return Shell.Current.DisplayActionSheet(title, cancel, destruction, buttons);
    }
}