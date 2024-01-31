namespace Booster.Dialog;

public class DefaultDialogService : IDialogService
{
    public async Task<bool> DisplayAlertAsync(string title, string message, string? accept = null, string cancel = "No")
    {
        if (string.IsNullOrEmpty(accept))
        {
            await Shell.Current.CurrentPage.DisplayAlert(title, message, cancel);
            return false;
        }

        else
        {
            return await Shell.Current.CurrentPage.DisplayAlert(title, message, accept, cancel);
        }
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