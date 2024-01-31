namespace Booster.Core.Dialog;

public interface IDialogService
{
    Task<bool> DisplayAlertAsync(string title, string message, string? accept = null, string cancel = "Cancel");

    Task<string> DisplayPromptAsync(string title, string message, string accept = "OK", string cancel = "Cancel",
        string? placeholder = null, int maxLength = -1, Keyboard? keyboard = default, string initialValue = "");

    Task<string> DisplayActionSheet(string title, string cancel, string destruction, params string[] buttons);
}