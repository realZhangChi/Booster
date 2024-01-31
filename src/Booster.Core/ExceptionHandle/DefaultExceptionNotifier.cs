﻿using Booster.Dialog;

namespace Booster.ExceptionHandle;

public class DefaultExceptionNotifier(IDialogService dialogService) : IExceptionNotifier
{
    protected virtual IDialogService DialogService { get; } = dialogService;

    public Task NotifyAsync(Exception exception)
    {
        return DialogService.DisplayAlertAsync("Error", exception.Message, cancel: "Close");
    }
}