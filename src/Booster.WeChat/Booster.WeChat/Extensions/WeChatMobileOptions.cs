using System.ComponentModel.DataAnnotations;

namespace Booster.WeChat.Extensions;

public class WeChatMobileOptions
{
    [Required]
    public string AppId { get; set; } = null!;

    [Required]
    public string AppSecret { get; set; } = null!;
}
