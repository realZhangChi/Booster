using System.Runtime.InteropServices;

namespace Booster.WeChat.Binding.iOS
{
	public enum WXErrCode
	{
		Success = 0,
		ErrCodeCommon = -1,
		ErrCodeUserCancel = -2,
		ErrCodeSentFail = -3,
		ErrCodeAuthDeny = -4,
		ErrCodeUnsupport = -5
	}

	public enum WXScene : uint
	{
		Session = 0,
		Timeline = 1,
		Favorite = 2,
		SpecifiedSession = 3,
		State = 4
	}

	public enum WXAPISupport : uint
	{
		WXAPISupportSession = 0
	}

	public enum WXBizProfileType : uint
	{
		Normal = 0,
		Device = 1
	}

	//static class CFunctions
	//{
	//	// extern int NS_ENUM (int NSUInteger, int WXMiniProgramType);
	//	[DllImport("__Internal")]
	//	static extern int NS_ENUM(int NSUInteger, int WXMiniProgramType);

	//	// extern int NS_ENUM (int NSInteger, int WXLogLevel);
	//	[DllImport("__Internal")]
	//	static extern int NS_ENUM(int NSInteger, int WXLogLevel);

	//	// extern int NS_ENUM (int NSInteger, int WXULCheckStep);
	//	//[DllImport("__Internal")]
	//	//static extern int NS_ENUM(int NSInteger, int WXULCheckStep);
	//}

	public enum WXMPWebviewType : uint
	{
		WXMPWebviewType_Ad = 0
	}

	public enum AuthErrCode
	{
		Ok = 0,
		NormalErr = -1,
		NetworkErr = -2,
		GetQrcodeFailed = -3,
		Cancel = -4,
		Timeout = -5
	}
}
