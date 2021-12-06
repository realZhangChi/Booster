using System;

using Foundation;

using ObjCRuntime;

namespace Booster.WeChat.Binding.iOS
{
	// typedef void (^WXLogBolock)(int *);
	unsafe delegate void WXLogBolock(int* arg0);

	// @interface WXCheckULStepResult
	interface WXCheckULStepResult
	{
		// @property (assign, nonatomic) int success;
		[Export("success")]
		int Success { get; set; }

		// @property (nonatomic, strong) int * errorInfo;
		[Export("errorInfo", ArgumentSemantic.Strong)]
		unsafe int* ErrorInfo { get; set; }

		// @property (nonatomic, strong) int * suggestion;
		[Export("suggestion", ArgumentSemantic.Strong)]
		unsafe int* Suggestion { get; set; }

		// -(instancetype)initWithCheckResult:(id)success errorInfo:(id)errorInfo suggestion:(id)suggestion;
		[Export("initWithCheckResult:errorInfo:suggestion:")]
		IntPtr Constructor(NSObject success, NSObject errorInfo, NSObject suggestion);
	}

	// typedef void (^WXCheckULCompletion)(int, WXCheckULStepResult *);
	delegate void WXCheckULCompletion(int arg0, WXCheckULStepResult arg1);

	// @interface BaseReq
	interface BaseReq
	{
		// @property (assign, nonatomic) int type;
		[Export("type")]
		int Type { get; set; }

		// @property (copy, nonatomic) int * openID;
		[Export("openID", ArgumentSemantic.Copy)]
		unsafe int* OpenID { get; set; }
	}

	// @interface BaseResp
	interface BaseResp
	{
		// @property (assign, nonatomic) int errCode;
		[Export("errCode")]
		int ErrCode { get; set; }

		// @property (copy, nonatomic) int * errStr;
		[Export("errStr", ArgumentSemantic.Copy)]
		unsafe int* ErrStr { get; set; }

		// @property (assign, nonatomic) int type;
		[Export("type")]
		int Type { get; set; }
	}

	// @interface PayReq : BaseReq
	[BaseType(typeof(BaseReq))]
	interface PayReq
	{
		// @property (copy, nonatomic) int * partnerId;
		[Export("partnerId", ArgumentSemantic.Copy)]
		unsafe int* PartnerId { get; set; }

		// @property (copy, nonatomic) int * prepayId;
		[Export("prepayId", ArgumentSemantic.Copy)]
		unsafe int* PrepayId { get; set; }

		// @property (copy, nonatomic) int * nonceStr;
		[Export("nonceStr", ArgumentSemantic.Copy)]
		unsafe int* NonceStr { get; set; }

		// @property (assign, nonatomic) int timeStamp;
		[Export("timeStamp")]
		int TimeStamp { get; set; }

		// @property (copy, nonatomic) int * package;
		[Export("package", ArgumentSemantic.Copy)]
		unsafe int* Package { get; set; }

		// @property (copy, nonatomic) int * sign;
		[Export("sign", ArgumentSemantic.Copy)]
		unsafe int* Sign { get; set; }
	}

	// @interface PayResp : BaseResp
	[BaseType(typeof(BaseResp))]
	interface PayResp
	{
		// @property (copy, nonatomic) int * returnKey;
		[Export("returnKey", ArgumentSemantic.Copy)]
		unsafe int* ReturnKey { get; set; }
	}

	// @interface WXOfflinePayReq : BaseReq
	[BaseType(typeof(BaseReq))]
	interface WXOfflinePayReq
	{
	}

	// @interface WXOfflinePayResp : BaseResp
	[BaseType(typeof(BaseResp))]
	interface WXOfflinePayResp
	{
	}

	// @interface WXNontaxPayReq : BaseReq
	[BaseType(typeof(BaseReq))]
	interface WXNontaxPayReq
	{
		// @property (copy, nonatomic) int * urlString;
		[Export("urlString", ArgumentSemantic.Copy)]
		unsafe int* UrlString { get; set; }
	}

	// @interface WXNontaxPayResp : BaseResp
	[BaseType(typeof(BaseResp))]
	interface WXNontaxPayResp
	{
		// @property (copy, nonatomic) int * wxOrderId;
		[Export("wxOrderId", ArgumentSemantic.Copy)]
		unsafe int* WxOrderId { get; set; }
	}

	// @interface WXPayInsuranceReq : BaseReq
	[BaseType(typeof(BaseReq))]
	interface WXPayInsuranceReq
	{
		// @property (copy, nonatomic) int * urlString;
		[Export("urlString", ArgumentSemantic.Copy)]
		unsafe int* UrlString { get; set; }
	}

	// @interface WXPayInsuranceResp : BaseResp
	[BaseType(typeof(BaseResp))]
	interface WXPayInsuranceResp
	{
		// @property (copy, nonatomic) int * wxOrderId;
		[Export("wxOrderId", ArgumentSemantic.Copy)]
		unsafe int* WxOrderId { get; set; }
	}

	// @interface SendAuthReq : BaseReq
	[BaseType(typeof(BaseReq))]
	interface SendAuthReq
	{
		// @property (copy, nonatomic) int * scope;
		[Export("scope", ArgumentSemantic.Copy)]
		unsafe int* Scope { get; set; }

		// @property (copy, nonatomic) int * state;
		[Export("state", ArgumentSemantic.Copy)]
		unsafe int* State { get; set; }
	}

	// @interface SendAuthResp : BaseResp
	[BaseType(typeof(BaseResp))]
	interface SendAuthResp
	{
		// @property (copy, nonatomic) int * _Nullable code;
		[NullAllowed, Export("code", ArgumentSemantic.Copy)]
		unsafe int* Code { get; set; }

		// @property (copy, nonatomic) int * _Nullable state;
		[NullAllowed, Export("state", ArgumentSemantic.Copy)]
		unsafe int* State { get; set; }

		// @property (copy, nonatomic) int * _Nullable lang;
		[NullAllowed, Export("lang", ArgumentSemantic.Copy)]
		unsafe int* Lang { get; set; }

		// @property (copy, nonatomic) int * _Nullable country;
		[NullAllowed, Export("country", ArgumentSemantic.Copy)]
		unsafe int* Country { get; set; }
	}

	// @interface WXStateJumpInfo
	interface WXStateJumpInfo
	{
	}

	// @interface WXStateJumpUrlInfo : WXStateJumpInfo
	[BaseType(typeof(WXStateJumpInfo))]
	interface WXStateJumpUrlInfo
	{
		// @property (copy, nonatomic) int * url;
		[Export("url", ArgumentSemantic.Copy)]
		unsafe int* Url { get; set; }
	}

	// @interface WXSceneDataObject
	interface WXSceneDataObject
	{
	}

	// @interface WXStateSceneDataObject : WXSceneDataObject
	[BaseType(typeof(WXSceneDataObject))]
	interface WXStateSceneDataObject
	{
		// @property (copy, nonatomic) int * stateId;
		[Export("stateId", ArgumentSemantic.Copy)]
		unsafe int* StateId { get; set; }

		// @property (copy, nonatomic) int * stateTitle;
		[Export("stateTitle", ArgumentSemantic.Copy)]
		unsafe int* StateTitle { get; set; }

		// @property (copy, nonatomic) int * token;
		[Export("token", ArgumentSemantic.Copy)]
		unsafe int* Token { get; set; }

		// @property (nonatomic, strong) WXStateJumpInfo * stateJumpDataInfo;
		[Export("stateJumpDataInfo", ArgumentSemantic.Strong)]
		WXStateJumpInfo StateJumpDataInfo { get; set; }
	}

	// @interface SendMessageToWXReq : BaseReq
	[BaseType(typeof(BaseReq))]
	interface SendMessageToWXReq
	{
		// @property (copy, nonatomic) int * text;
		[Export("text", ArgumentSemantic.Copy)]
		unsafe int* Text { get; set; }

		// @property (nonatomic, strong) WXMediaMessage * message;
		[Export("message", ArgumentSemantic.Strong)]
		WXMediaMessage Message { get; set; }

		// @property (assign, nonatomic) int bText;
		[Export("bText")]
		int BText { get; set; }

		// @property (assign, nonatomic) int scene;
		[Export("scene")]
		int Scene { get; set; }

		// @property (copy, nonatomic) int * _Nullable toUserOpenId;
		[NullAllowed, Export("toUserOpenId", ArgumentSemantic.Copy)]
		unsafe int* ToUserOpenId { get; set; }

		// @property (nonatomic, strong) WXSceneDataObject * sceneDataObject;
		[Export("sceneDataObject", ArgumentSemantic.Strong)]
		WXSceneDataObject SceneDataObject { get; set; }
	}

	// @interface SendMessageToWXResp : BaseResp
	[BaseType(typeof(BaseResp))]
	interface SendMessageToWXResp
	{
		// @property (copy, nonatomic) int * lang;
		[Export("lang", ArgumentSemantic.Copy)]
		unsafe int* Lang { get; set; }

		// @property (copy, nonatomic) int * country;
		[Export("country", ArgumentSemantic.Copy)]
		unsafe int* Country { get; set; }
	}

	// @interface GetMessageFromWXReq : BaseReq
	[BaseType(typeof(BaseReq))]
	interface GetMessageFromWXReq
	{
		// @property (nonatomic, strong) int * lang;
		[Export("lang", ArgumentSemantic.Strong)]
		unsafe int* Lang { get; set; }

		// @property (nonatomic, strong) int * country;
		[Export("country", ArgumentSemantic.Strong)]
		unsafe int* Country { get; set; }
	}

	// @interface GetMessageFromWXResp : BaseResp
	[BaseType(typeof(BaseResp))]
	interface GetMessageFromWXResp
	{
		// @property (nonatomic, strong) int * text;
		[Export("text", ArgumentSemantic.Strong)]
		unsafe int* Text { get; set; }

		// @property (nonatomic, strong) WXMediaMessage * message;
		[Export("message", ArgumentSemantic.Strong)]
		WXMediaMessage Message { get; set; }

		// @property (assign, nonatomic) int bText;
		[Export("bText")]
		int BText { get; set; }
	}

	// @interface ShowMessageFromWXReq : BaseReq
	[BaseType(typeof(BaseReq))]
	interface ShowMessageFromWXReq
	{
		// @property (nonatomic, strong) WXMediaMessage * message;
		[Export("message", ArgumentSemantic.Strong)]
		WXMediaMessage Message { get; set; }

		// @property (copy, nonatomic) int * lang;
		[Export("lang", ArgumentSemantic.Copy)]
		unsafe int* Lang { get; set; }

		// @property (copy, nonatomic) int * country;
		[Export("country", ArgumentSemantic.Copy)]
		unsafe int* Country { get; set; }
	}

	// @interface ShowMessageFromWXResp : BaseResp
	[BaseType(typeof(BaseResp))]
	interface ShowMessageFromWXResp
	{
	}

	// @interface LaunchFromWXReq : BaseReq
	[BaseType(typeof(BaseReq))]
	interface LaunchFromWXReq
	{
		// @property (nonatomic, strong) WXMediaMessage * message;
		[Export("message", ArgumentSemantic.Strong)]
		WXMediaMessage Message { get; set; }

		// @property (copy, nonatomic) int * lang;
		[Export("lang", ArgumentSemantic.Copy)]
		unsafe int* Lang { get; set; }

		// @property (copy, nonatomic) int * country;
		[Export("country", ArgumentSemantic.Copy)]
		unsafe int* Country { get; set; }
	}

	// @interface OpenWebviewReq : BaseReq
	[BaseType(typeof(BaseReq))]
	interface OpenWebviewReq
	{
		// @property (copy, nonatomic) int * url;
		[Export("url", ArgumentSemantic.Copy)]
		unsafe int* Url { get; set; }
	}

	// @interface OpenWebviewResp : BaseResp
	[BaseType(typeof(BaseResp))]
	interface OpenWebviewResp
	{
	}

	// @interface WXOpenBusinessWebViewReq : BaseReq
	[BaseType(typeof(BaseReq))]
	interface WXOpenBusinessWebViewReq
	{
		// @property (assign, nonatomic) int businessType;
		[Export("businessType")]
		int BusinessType { get; set; }

		// @property (nonatomic, strong) int * _Nullable queryInfoDic;
		[NullAllowed, Export("queryInfoDic", ArgumentSemantic.Strong)]
		unsafe int* QueryInfoDic { get; set; }
	}

	// @interface WXOpenBusinessWebViewResp : BaseResp
	[BaseType(typeof(BaseResp))]
	interface WXOpenBusinessWebViewResp
	{
		// @property (copy, nonatomic) int * result;
		[Export("result", ArgumentSemantic.Copy)]
		unsafe int* Result { get; set; }

		// @property (assign, nonatomic) int businessType;
		[Export("businessType")]
		int BusinessType { get; set; }
	}

	// @interface OpenRankListReq : BaseReq
	[BaseType(typeof(BaseReq))]
	interface OpenRankListReq
	{
	}

	// @interface OpenRankListResp : BaseResp
	[BaseType(typeof(BaseResp))]
	interface OpenRankListResp
	{
	}

	// @interface WXCardItem
	interface WXCardItem
	{
		// @property (copy, nonatomic) int * cardId;
		[Export("cardId", ArgumentSemantic.Copy)]
		unsafe int* CardId { get; set; }

		// @property (copy, nonatomic) int * _Nullable extMsg;
		[NullAllowed, Export("extMsg", ArgumentSemantic.Copy)]
		unsafe int* ExtMsg { get; set; }

		// @property (assign, nonatomic) int cardState;
		[Export("cardState")]
		int CardState { get; set; }

		// @property (copy, nonatomic) int * encryptCode;
		[Export("encryptCode", ArgumentSemantic.Copy)]
		unsafe int* EncryptCode { get; set; }

		// @property (copy, nonatomic) int * appID;
		[Export("appID", ArgumentSemantic.Copy)]
		unsafe int* AppID { get; set; }
	}

	// @interface WXInvoiceItem
	interface WXInvoiceItem
	{
		// @property (copy, nonatomic) int * cardId;
		[Export("cardId", ArgumentSemantic.Copy)]
		unsafe int* CardId { get; set; }

		// @property (copy, nonatomic) int * _Nullable extMsg;
		[NullAllowed, Export("extMsg", ArgumentSemantic.Copy)]
		unsafe int* ExtMsg { get; set; }

		// @property (assign, nonatomic) int cardState;
		[Export("cardState")]
		int CardState { get; set; }

		// @property (copy, nonatomic) int * encryptCode;
		[Export("encryptCode", ArgumentSemantic.Copy)]
		unsafe int* EncryptCode { get; set; }

		// @property (copy, nonatomic) int * appID;
		[Export("appID", ArgumentSemantic.Copy)]
		unsafe int* AppID { get; set; }
	}

	// @interface AddCardToWXCardPackageReq : BaseReq
	[BaseType(typeof(BaseReq))]
	interface AddCardToWXCardPackageReq
	{
		// @property (nonatomic, strong) int * cardAry;
		[Export("cardAry", ArgumentSemantic.Strong)]
		unsafe int* CardAry { get; set; }
	}

	// @interface AddCardToWXCardPackageResp : BaseResp
	[BaseType(typeof(BaseResp))]
	interface AddCardToWXCardPackageResp
	{
		// @property (nonatomic, strong) int * cardAry;
		[Export("cardAry", ArgumentSemantic.Strong)]
		unsafe int* CardAry { get; set; }
	}

	// @interface WXChooseCardReq : BaseReq
	[BaseType(typeof(BaseReq))]
	interface WXChooseCardReq
	{
		// @property (copy, nonatomic) int * appID;
		[Export("appID", ArgumentSemantic.Copy)]
		unsafe int* AppID { get; set; }

		// @property (assign, nonatomic) int shopID;
		[Export("shopID")]
		int ShopID { get; set; }

		// @property (assign, nonatomic) int canMultiSelect;
		[Export("canMultiSelect")]
		int CanMultiSelect { get; set; }

		// @property (copy, nonatomic) int * cardType;
		[Export("cardType", ArgumentSemantic.Copy)]
		unsafe int* CardType { get; set; }

		// @property (copy, nonatomic) int * cardTpID;
		[Export("cardTpID", ArgumentSemantic.Copy)]
		unsafe int* CardTpID { get; set; }

		// @property (copy, nonatomic) int * signType;
		[Export("signType", ArgumentSemantic.Copy)]
		unsafe int* SignType { get; set; }

		// @property (copy, nonatomic) int * cardSign;
		[Export("cardSign", ArgumentSemantic.Copy)]
		unsafe int* CardSign { get; set; }

		// @property (assign, nonatomic) int timeStamp;
		[Export("timeStamp")]
		int TimeStamp { get; set; }

		// @property (copy, nonatomic) int * nonceStr;
		[Export("nonceStr", ArgumentSemantic.Copy)]
		unsafe int* NonceStr { get; set; }
	}

	// @interface WXChooseCardResp : BaseResp
	[BaseType(typeof(BaseResp))]
	interface WXChooseCardResp
	{
		// @property (nonatomic, strong) int * cardAry;
		[Export("cardAry", ArgumentSemantic.Strong)]
		unsafe int* CardAry { get; set; }
	}

	// @interface WXChooseInvoiceReq : BaseReq
	[BaseType(typeof(BaseReq))]
	interface WXChooseInvoiceReq
	{
		// @property (copy, nonatomic) int * appID;
		[Export("appID", ArgumentSemantic.Copy)]
		unsafe int* AppID { get; set; }

		// @property (assign, nonatomic) int shopID;
		[Export("shopID")]
		int ShopID { get; set; }

		// @property (copy, nonatomic) int * signType;
		[Export("signType", ArgumentSemantic.Copy)]
		unsafe int* SignType { get; set; }

		// @property (copy, nonatomic) int * cardSign;
		[Export("cardSign", ArgumentSemantic.Copy)]
		unsafe int* CardSign { get; set; }

		// @property (assign, nonatomic) int timeStamp;
		[Export("timeStamp")]
		int TimeStamp { get; set; }

		// @property (copy, nonatomic) int * nonceStr;
		[Export("nonceStr", ArgumentSemantic.Copy)]
		unsafe int* NonceStr { get; set; }
	}

	// @interface WXChooseInvoiceResp : BaseResp
	[BaseType(typeof(BaseResp))]
	interface WXChooseInvoiceResp
	{
		// @property (nonatomic, strong) int * cardAry;
		[Export("cardAry", ArgumentSemantic.Strong)]
		unsafe int* CardAry { get; set; }
	}

	// @interface WXSubscribeMsgReq : BaseReq
	[BaseType(typeof(BaseReq))]
	interface WXSubscribeMsgReq
	{
		// @property (assign, nonatomic) int scene;
		[Export("scene")]
		int Scene { get; set; }

		// @property (copy, nonatomic) int * templateId;
		[Export("templateId", ArgumentSemantic.Copy)]
		unsafe int* TemplateId { get; set; }

		// @property (copy, nonatomic) int * _Nullable reserved;
		[NullAllowed, Export("reserved", ArgumentSemantic.Copy)]
		unsafe int* Reserved { get; set; }
	}

	// @interface WXSubscribeMsgResp : BaseResp
	[BaseType(typeof(BaseResp))]
	interface WXSubscribeMsgResp
	{
		// @property (copy, nonatomic) int * templateId;
		[Export("templateId", ArgumentSemantic.Copy)]
		unsafe int* TemplateId { get; set; }

		// @property (assign, nonatomic) int scene;
		[Export("scene")]
		int Scene { get; set; }

		// @property (copy, nonatomic) int * action;
		[Export("action", ArgumentSemantic.Copy)]
		unsafe int* Action { get; set; }

		// @property (copy, nonatomic) int * reserved;
		[Export("reserved", ArgumentSemantic.Copy)]
		unsafe int* Reserved { get; set; }

		// @property (copy, nonatomic) int * _Nullable openId;
		[NullAllowed, Export("openId", ArgumentSemantic.Copy)]
		unsafe int* OpenId { get; set; }
	}

	// @interface WXSubscribeMiniProgramMsgReq : BaseReq
	[BaseType(typeof(BaseReq))]
	interface WXSubscribeMiniProgramMsgReq
	{
		// @property (copy, nonatomic) int * miniProgramAppid;
		[Export("miniProgramAppid", ArgumentSemantic.Copy)]
		unsafe int* MiniProgramAppid { get; set; }
	}

	// @interface WXSubscribeMiniProgramMsgResp : BaseResp
	[BaseType(typeof(BaseResp))]
	interface WXSubscribeMiniProgramMsgResp
	{
		// @property (copy, nonatomic) int * openId;
		[Export("openId", ArgumentSemantic.Copy)]
		unsafe int* OpenId { get; set; }

		// @property (copy, nonatomic) int * unionId;
		[Export("unionId", ArgumentSemantic.Copy)]
		unsafe int* UnionId { get; set; }

		// @property (copy, nonatomic) int * nickName;
		[Export("nickName", ArgumentSemantic.Copy)]
		unsafe int* NickName { get; set; }
	}

	// @interface WXInvoiceAuthInsertReq : BaseReq
	[BaseType(typeof(BaseReq))]
	interface WXInvoiceAuthInsertReq
	{
		// @property (copy, nonatomic) int * urlString;
		[Export("urlString", ArgumentSemantic.Copy)]
		unsafe int* UrlString { get; set; }
	}

	// @interface WXInvoiceAuthInsertResp : BaseResp
	[BaseType(typeof(BaseResp))]
	interface WXInvoiceAuthInsertResp
	{
		// @property (copy, nonatomic) int * wxOrderId;
		[Export("wxOrderId", ArgumentSemantic.Copy)]
		unsafe int* WxOrderId { get; set; }
	}

	// @interface WXMediaMessage
	interface WXMediaMessage
	{
		// +(WXMediaMessage *)message;
		[Static]
		[Export("message")]
		[Verify(MethodToProperty)]
		WXMediaMessage Message { get; }

		// @property (copy, nonatomic) int * title;
		[Export("title", ArgumentSemantic.Copy)]
		unsafe int* Title { get; set; }

		// @property (copy, nonatomic) int * description;
		[Export("description", ArgumentSemantic.Copy)]
		unsafe int* Description { get; set; }

		// @property (nonatomic, strong) int * _Nullable thumbData;
		[NullAllowed, Export("thumbData", ArgumentSemantic.Strong)]
		unsafe int* ThumbData { get; set; }

		// @property (copy, nonatomic) int * _Nullable mediaTagName;
		[NullAllowed, Export("mediaTagName", ArgumentSemantic.Copy)]
		unsafe int* MediaTagName { get; set; }

		// @property (copy, nonatomic) int * _Nullable messageExt;
		[NullAllowed, Export("messageExt", ArgumentSemantic.Copy)]
		unsafe int* MessageExt { get; set; }

		// @property (copy, nonatomic) int * _Nullable messageAction;
		[NullAllowed, Export("messageAction", ArgumentSemantic.Copy)]
		unsafe int* MessageAction { get; set; }

		// @property (nonatomic, strong) id mediaObject;
		[Export("mediaObject", ArgumentSemantic.Strong)]
		NSObject MediaObject { get; set; }

		// -(void)setThumbImage:(id)image;
		[Export("setThumbImage:")]
		void SetThumbImage(NSObject image);
	}

	// @interface WXImageObject
	interface WXImageObject
	{
		// +(WXImageObject *)object;
		[Static]
		[Export("object")]
		[Verify(MethodToProperty)]
		WXImageObject Object { get; }

		// @property (nonatomic, strong) int * imageData;
		[Export("imageData", ArgumentSemantic.Strong)]
		unsafe int* ImageData { get; set; }
	}

	// @interface WXMusicObject
	interface WXMusicObject
	{
		// +(WXMusicObject *)object;
		[Static]
		[Export("object")]
		[Verify(MethodToProperty)]
		WXMusicObject Object { get; }

		// @property (copy, nonatomic) int * musicUrl;
		[Export("musicUrl", ArgumentSemantic.Copy)]
		unsafe int* MusicUrl { get; set; }

		// @property (copy, nonatomic) int * musicLowBandUrl;
		[Export("musicLowBandUrl", ArgumentSemantic.Copy)]
		unsafe int* MusicLowBandUrl { get; set; }

		// @property (copy, nonatomic) int * musicDataUrl;
		[Export("musicDataUrl", ArgumentSemantic.Copy)]
		unsafe int* MusicDataUrl { get; set; }

		// @property (copy, nonatomic) int * musicLowBandDataUrl;
		[Export("musicLowBandDataUrl", ArgumentSemantic.Copy)]
		unsafe int* MusicLowBandDataUrl { get; set; }

		// @property (copy, nonatomic) int * songAlbumUrl;
		[Export("songAlbumUrl", ArgumentSemantic.Copy)]
		unsafe int* SongAlbumUrl { get; set; }

		// @property (copy, nonatomic) int * _Nullable songLyric;
		[NullAllowed, Export("songLyric", ArgumentSemantic.Copy)]
		unsafe int* SongLyric { get; set; }
	}

	// @interface WXMusicVideoObject
	interface WXMusicVideoObject
	{
		// +(WXMusicVideoObject *)object;
		[Static]
		[Export("object")]
		[Verify(MethodToProperty)]
		WXMusicVideoObject Object { get; }

		// @property (copy, nonatomic) int * musicUrl;
		[Export("musicUrl", ArgumentSemantic.Copy)]
		unsafe int* MusicUrl { get; set; }

		// @property (copy, nonatomic) int * musicDataUrl;
		[Export("musicDataUrl", ArgumentSemantic.Copy)]
		unsafe int* MusicDataUrl { get; set; }

		// @property (copy, nonatomic) int * singerName;
		[Export("singerName", ArgumentSemantic.Copy)]
		unsafe int* SingerName { get; set; }

		// @property (assign, nonatomic) int duration;
		[Export("duration")]
		int Duration { get; set; }

		// @property (copy, nonatomic) int * songLyric;
		[Export("songLyric", ArgumentSemantic.Copy)]
		unsafe int* SongLyric { get; set; }

		// @property (nonatomic, strong) int * hdAlbumThumbData;
		[Export("hdAlbumThumbData", ArgumentSemantic.Strong)]
		unsafe int* HdAlbumThumbData { get; set; }

		// @property (copy, nonatomic) int * _Nullable albumName;
		[NullAllowed, Export("albumName", ArgumentSemantic.Copy)]
		unsafe int* AlbumName { get; set; }

		// @property (copy, nonatomic) int * _Nullable musicGenre;
		[NullAllowed, Export("musicGenre", ArgumentSemantic.Copy)]
		unsafe int* MusicGenre { get; set; }

		// @property (assign, nonatomic) int issueDate;
		[Export("issueDate")]
		int IssueDate { get; set; }

		// @property (copy, nonatomic) int * _Nullable identification;
		[NullAllowed, Export("identification", ArgumentSemantic.Copy)]
		unsafe int* Identification { get; set; }

		// @property (copy, nonatomic) int * _Nullable musicOperationUrl;
		[NullAllowed, Export("musicOperationUrl", ArgumentSemantic.Copy)]
		unsafe int* MusicOperationUrl { get; set; }
	}

	// @interface WXVideoObject
	interface WXVideoObject
	{
		// +(WXVideoObject *)object;
		[Static]
		[Export("object")]
		[Verify(MethodToProperty)]
		WXVideoObject Object { get; }

		// @property (copy, nonatomic) int * videoUrl;
		[Export("videoUrl", ArgumentSemantic.Copy)]
		unsafe int* VideoUrl { get; set; }

		// @property (copy, nonatomic) int * videoLowBandUrl;
		[Export("videoLowBandUrl", ArgumentSemantic.Copy)]
		unsafe int* VideoLowBandUrl { get; set; }
	}

	// @interface WXWebpageObject
	interface WXWebpageObject
	{
		// +(WXWebpageObject *)object;
		[Static]
		[Export("object")]
		[Verify(MethodToProperty)]
		WXWebpageObject Object { get; }

		// @property (copy, nonatomic) int * webpageUrl;
		[Export("webpageUrl", ArgumentSemantic.Copy)]
		unsafe int* WebpageUrl { get; set; }
	}

	// @interface WXAppExtendObject
	interface WXAppExtendObject
	{
		// +(WXAppExtendObject *)object;
		[Static]
		[Export("object")]
		[Verify(MethodToProperty)]
		WXAppExtendObject Object { get; }

		// @property (copy, nonatomic) int * url;
		[Export("url", ArgumentSemantic.Copy)]
		unsafe int* Url { get; set; }

		// @property (copy, nonatomic) int * _Nullable extInfo;
		[NullAllowed, Export("extInfo", ArgumentSemantic.Copy)]
		unsafe int* ExtInfo { get; set; }

		// @property (nonatomic, strong) int * _Nullable fileData;
		[NullAllowed, Export("fileData", ArgumentSemantic.Strong)]
		unsafe int* FileData { get; set; }
	}

	// @interface WXEmoticonObject
	interface WXEmoticonObject
	{
		// +(WXEmoticonObject *)object;
		[Static]
		[Export("object")]
		[Verify(MethodToProperty)]
		WXEmoticonObject Object { get; }

		// @property (nonatomic, strong) int * emoticonData;
		[Export("emoticonData", ArgumentSemantic.Strong)]
		unsafe int* EmoticonData { get; set; }
	}

	// @interface WXFileObject
	interface WXFileObject
	{
		// +(WXFileObject *)object;
		[Static]
		[Export("object")]
		[Verify(MethodToProperty)]
		WXFileObject Object { get; }

		// @property (copy, nonatomic) int * fileExtension;
		[Export("fileExtension", ArgumentSemantic.Copy)]
		unsafe int* FileExtension { get; set; }

		// @property (nonatomic, strong) int * fileData;
		[Export("fileData", ArgumentSemantic.Strong)]
		unsafe int* FileData { get; set; }
	}

	// @interface WXLocationObject
	interface WXLocationObject
	{
		// +(WXLocationObject *)object;
		[Static]
		[Export("object")]
		[Verify(MethodToProperty)]
		WXLocationObject Object { get; }

		// @property (assign, nonatomic) double lng;
		[Export("lng")]
		double Lng { get; set; }

		// @property (assign, nonatomic) double lat;
		[Export("lat")]
		double Lat { get; set; }
	}

	// @interface WXTextObject
	interface WXTextObject
	{
		// +(WXTextObject *)object;
		[Static]
		[Export("object")]
		[Verify(MethodToProperty)]
		WXTextObject Object { get; }

		// @property (copy, nonatomic) int * contentText;
		[Export("contentText", ArgumentSemantic.Copy)]
		unsafe int* ContentText { get; set; }
	}

	// @interface WXMiniProgramObject
	interface WXMiniProgramObject
	{
		// +(WXMiniProgramObject *)object;
		[Static]
		[Export("object")]
		[Verify(MethodToProperty)]
		WXMiniProgramObject Object { get; }

		// @property (copy, nonatomic) int * webpageUrl;
		[Export("webpageUrl", ArgumentSemantic.Copy)]
		unsafe int* WebpageUrl { get; set; }

		// @property (copy, nonatomic) int * userName;
		[Export("userName", ArgumentSemantic.Copy)]
		unsafe int* UserName { get; set; }

		// @property (copy, nonatomic) int * _Nullable path;
		[NullAllowed, Export("path", ArgumentSemantic.Copy)]
		unsafe int* Path { get; set; }

		// @property (nonatomic, strong) int * _Nullable hdImageData;
		[NullAllowed, Export("hdImageData", ArgumentSemantic.Strong)]
		unsafe int* HdImageData { get; set; }

		// @property (assign, nonatomic) int withShareTicket;
		[Export("withShareTicket")]
		int WithShareTicket { get; set; }

		// @property (assign, nonatomic) int miniProgramType;
		[Export("miniProgramType")]
		int MiniProgramType { get; set; }

		// @property (assign, nonatomic) int disableForward;
		[Export("disableForward")]
		int DisableForward { get; set; }

		// @property (assign, nonatomic) int isUpdatableMessage;
		[Export("isUpdatableMessage")]
		int IsUpdatableMessage { get; set; }

		// @property (assign, nonatomic) int isSecretMessage;
		[Export("isSecretMessage")]
		int IsSecretMessage { get; set; }

		// @property (nonatomic, strong) int * _Nullable extraInfoDic;
		[NullAllowed, Export("extraInfoDic", ArgumentSemantic.Strong)]
		unsafe int* ExtraInfoDic { get; set; }
	}

	// @interface WXGameLiveObject
	interface WXGameLiveObject
	{
		// +(WXGameLiveObject *)object;
		[Static]
		[Export("object")]
		[Verify(MethodToProperty)]
		WXGameLiveObject Object { get; }

		// @property (nonatomic, strong) int * _Nullable extraInfoDic;
		[NullAllowed, Export("extraInfoDic", ArgumentSemantic.Strong)]
		unsafe int* ExtraInfoDic { get; set; }
	}

	// @interface WXLaunchMiniProgramReq : BaseReq
	[BaseType(typeof(BaseReq))]
	interface WXLaunchMiniProgramReq
	{
		// +(WXLaunchMiniProgramReq *)object;
		[Static]
		[Export("object")]
		[Verify(MethodToProperty)]
		WXLaunchMiniProgramReq Object { get; }

		// @property (copy, nonatomic) int * userName;
		[Export("userName", ArgumentSemantic.Copy)]
		unsafe int* UserName { get; set; }

		// @property (copy, nonatomic) int * _Nullable path;
		[NullAllowed, Export("path", ArgumentSemantic.Copy)]
		unsafe int* Path { get; set; }

		// @property (assign, nonatomic) int miniProgramType;
		[Export("miniProgramType")]
		int MiniProgramType { get; set; }

		// @property (copy, nonatomic) int * _Nullable extMsg;
		[NullAllowed, Export("extMsg", ArgumentSemantic.Copy)]
		unsafe int* ExtMsg { get; set; }

		// @property (copy, nonatomic) int * _Nullable extDic;
		[NullAllowed, Export("extDic", ArgumentSemantic.Copy)]
		unsafe int* ExtDic { get; set; }
	}

	// @interface WXLaunchMiniProgramResp : BaseResp
	[BaseType(typeof(BaseResp))]
	interface WXLaunchMiniProgramResp
	{
		// @property (copy, nonatomic) int * _Nullable extMsg;
		[NullAllowed, Export("extMsg", ArgumentSemantic.Copy)]
		unsafe int* ExtMsg { get; set; }
	}

	// @interface WXOpenBusinessViewReq : BaseReq
	[BaseType(typeof(BaseReq))]
	interface WXOpenBusinessViewReq
	{
		// +(WXOpenBusinessViewReq *)object;
		[Static]
		[Export("object")]
		[Verify(MethodToProperty)]
		WXOpenBusinessViewReq Object { get; }

		// @property (copy, nonatomic) int * businessType;
		[Export("businessType", ArgumentSemantic.Copy)]
		unsafe int* BusinessType { get; set; }

		// @property (copy, nonatomic) int * _Nullable query;
		[NullAllowed, Export("query", ArgumentSemantic.Copy)]
		unsafe int* Query { get; set; }

		// @property (copy, nonatomic) int * _Nullable extInfo;
		[NullAllowed, Export("extInfo", ArgumentSemantic.Copy)]
		unsafe int* ExtInfo { get; set; }

		// @property (nonatomic, strong) int * _Nullable extData;
		[NullAllowed, Export("extData", ArgumentSemantic.Strong)]
		unsafe int* ExtData { get; set; }
	}

	// @interface WXOpenBusinessViewResp : BaseResp
	[BaseType(typeof(BaseResp))]
	interface WXOpenBusinessViewResp
	{
		// @property (copy, nonatomic) int * businessType;
		[Export("businessType", ArgumentSemantic.Copy)]
		unsafe int* BusinessType { get; set; }

		// @property (copy, nonatomic) int * _Nullable extMsg;
		[NullAllowed, Export("extMsg", ArgumentSemantic.Copy)]
		unsafe int* ExtMsg { get; set; }
	}

	// @interface WXOpenCustomerServiceReq : BaseReq
	[BaseType(typeof(BaseReq))]
	interface WXOpenCustomerServiceReq
	{
		// +(WXOpenCustomerServiceReq *)object;
		[Static]
		[Export("object")]
		[Verify(MethodToProperty)]
		WXOpenCustomerServiceReq Object { get; }

		// @property (copy, nonatomic) int * _Nullable url;
		[NullAllowed, Export("url", ArgumentSemantic.Copy)]
		unsafe int* Url { get; set; }

		// @property (copy, nonatomic) int * _Nullable corpid;
		[NullAllowed, Export("corpid", ArgumentSemantic.Copy)]
		unsafe int* Corpid { get; set; }
	}

	// @interface WXOpenCustomerServiceResp : BaseResp
	[BaseType(typeof(BaseResp))]
	interface WXOpenCustomerServiceResp
	{
		// @property (copy, nonatomic) int * _Nullable extMsg;
		[NullAllowed, Export("extMsg", ArgumentSemantic.Copy)]
		unsafe int* ExtMsg { get; set; }
	}

	[Static]
	[Verify(ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern int NS_ASSUME_NONNULL_BEGIN;
		[Field("NS_ASSUME_NONNULL_BEGIN")]
		int NS_ASSUME_NONNULL_BEGIN { get; }
	}

	// @interface WXApi
	interface WXApi
	{
		// +(id)registerApp:(id)appid universalLink:(id)universalLink;
		[Static]
		[Export("registerApp:universalLink:")]
		NSObject RegisterApp(NSObject appid, NSObject universalLink);

		// +(id)handleOpenURL:(id)url delegate:(id _Nullable)delegate;
		[Static]
		[Export("handleOpenURL:delegate:")]
		NSObject HandleOpenURL(NSObject url, [NullAllowed] NSObject @delegate);

		// +(id)handleOpenUniversalLink:(id)userActivity delegate:(id _Nullable)delegate;
		[Static]
		[Export("handleOpenUniversalLink:delegate:")]
		NSObject HandleOpenUniversalLink(NSObject userActivity, [NullAllowed] NSObject @delegate);

		// +(id)isWXAppInstalled;
		[Static]
		[Export("isWXAppInstalled")]
		[Verify(MethodToProperty)]
		NSObject IsWXAppInstalled { get; }

		// +(id)isWXAppSupportApi;
		[Static]
		[Export("isWXAppSupportApi")]
		[Verify(MethodToProperty)]
		NSObject IsWXAppSupportApi { get; }

		// +(id)isWXAppSupportStateAPI;
		[Static]
		[Export("isWXAppSupportStateAPI")]
		[Verify(MethodToProperty)]
		NSObject IsWXAppSupportStateAPI { get; }

		// +(id)getWXAppInstallUrl;
		[Static]
		[Export("getWXAppInstallUrl")]
		[Verify(MethodToProperty)]
		NSObject WXAppInstallUrl { get; }

		// +(id)getApiVersion;
		[Static]
		[Export("getApiVersion")]
		[Verify(MethodToProperty)]
		NSObject ApiVersion { get; }

		// +(id)openWXApp;
		[Static]
		[Export("openWXApp")]
		[Verify(MethodToProperty)]
		NSObject OpenWXApp { get; }

		// +(void)sendReq:(BaseReq *)req completion:(void (^ _Nullable)(int))completion;
		[Static]
		[Export("sendReq:completion:")]
		void SendReq(BaseReq req, [NullAllowed] Action<int> completion);

		// +(void)sendResp:(BaseResp *)resp completion:(void (^ _Nullable)(int))completion;
		[Static]
		[Export("sendResp:completion:")]
		void SendResp(BaseResp resp, [NullAllowed] Action<int> completion);

		// +(void)sendAuthReq:(SendAuthReq *)req viewController:(id)viewController delegate:(id _Nullable)delegate completion:(void (^ _Nullable)(int))completion;
		[Static]
		[Export("sendAuthReq:viewController:delegate:completion:")]
		void SendAuthReq(SendAuthReq req, NSObject viewController, [NullAllowed] NSObject @delegate, [NullAllowed] Action<int> completion);

		// +(void)checkUniversalLinkReady:(WXCheckULCompletion _Nonnull)completion;
		[Static]
		[Export("checkUniversalLinkReady:")]
		void CheckUniversalLinkReady(WXCheckULCompletion completion);

		// +(void)startLogByLevel:(id)level logBlock:(WXLogBolock)logBlock;
		[Static]
		[Export("startLogByLevel:logBlock:")]
		void StartLogByLevel(NSObject level, WXLogBolock logBlock);

		// +(void)startLogByLevel:(id)level logDelegate:(id)logDelegate;
		[Static]
		[Export("startLogByLevel:logDelegate:")]
		void StartLogByLevel(NSObject level, NSObject logDelegate);

		// +(void)stopLog;
		[Static]
		[Export("stopLog")]
		void StopLog();
	}

	[Static]
	[Verify(ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern int NS_ASSUME_NONNULL_BEGIN;
		[Field("NS_ASSUME_NONNULL_BEGIN")]
		int NS_ASSUME_NONNULL_BEGIN { get; }
	}

	// @protocol WechatAuthAPIDelegate
	[Protocol, Model(AutoGeneratedName = true)]
	interface WechatAuthAPIDelegate
	{
		// @optional -(void)onAuthGotQrcode:(id)image;
		[Export("onAuthGotQrcode:")]
		void OnAuthGotQrcode(NSObject image);

		// @optional -(void)onQrcodeScanned;
		[Export("onQrcodeScanned")]
		void OnQrcodeScanned();

		// @optional -(void)onAuthFinish:(int)errCode AuthCode:(id)authCode;
		[Export("onAuthFinish:AuthCode:")]
		void OnAuthFinish(int errCode, NSObject authCode);
	}

	// @interface WechatAuthSDK
	interface WechatAuthSDK
	{
		[Wrap("WeakDelegate")]
		[NullAllowed]
		WechatAuthAPIDelegate Delegate { }

		// @property (nonatomic, weak) id<WechatAuthAPIDelegate> _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { }

		// @property (readonly, nonatomic) int * sdkVersion;
		[Export("sdkVersion")]
		unsafe int* SdkVersion { }

		// -(id)Auth:(id)appId nonceStr:(id)nonceStr timeStamp:(id)timeStamp scope:(id)scope signature:(id)signature schemeData:(id)schemeData;
		[Export("Auth:nonceStr:timeStamp:scope:signature:schemeData:")]
		NSObject Auth(NSObject appId, NSObject nonceStr, NSObject timeStamp, NSObject scope, NSObject signature, NSObject schemeData);

		// -(id)StopAuth;
		[Export("StopAuth")]
		[Verify(MethodToProperty)]
		NSObject StopAuth { get; }
	}
}
