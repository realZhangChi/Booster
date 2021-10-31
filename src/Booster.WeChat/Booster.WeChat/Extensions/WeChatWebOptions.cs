using System.ComponentModel.DataAnnotations;

namespace Booster.WeChat.Extensions;

public class WeChatWebOptions
{
    [Required]
    public string AppId { get; set; } = null!;

    [Required]
    public string AppSecret { get; set; } = null!;

    [Required]
    public string RedirectUrl { get; set; } = null!;
}
