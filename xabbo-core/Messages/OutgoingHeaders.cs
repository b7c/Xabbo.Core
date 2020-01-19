﻿using System;
using System.Collections.Generic;

namespace Xabbo.Core.Messages
{
    public sealed class OutgoingHeaders : HeaderDictionary
    {
        public OutgoingHeaders() { }

        public OutgoingHeaders(IDictionary<string, short> values)
            : base(values)
        { }

        public short AcceptFriendRequest { get; private set; }
        public short ActivateEffect { get; private set; }
        public short AdventCalendarForceOpen { get; private set; }
        public short AdventCalendarOpenDay { get; private set; }
        public short AdvertisingSave { get; private set; }
        public short AmbassadorAlertCommand { get; private set; }
        public short AmbassadorVisitCommand { get; private set; }
        public short AnswerPoll { get; private set; }
        public short BotPickup { get; private set; }
        public short BotPlace { get; private set; }
        public short BotSaveSettings { get; private set; }
        public short BotSettings { get; private set; }
        public short BreedPets { get; private set; }
        public short BuyItem { get; private set; }
        public short BuyRoomPromotion { get; private set; }
        public short CameraPublishToWeb { get; private set; }
        public short CameraPurchase { get; private set; }
        public short CameraRoomPicture { get; private set; }
        public short CameraRoomThumbnail { get; private set; }
        public short CancelPoll { get; private set; }
        public short CatalogBuyItemAsGift { get; private set; }
        public short CatalogBuyItem { get; private set; }
        public short CatalogSearchedItem { get; private set; }
        public short ChangeNameCheckUsername { get; private set; }
        public short ChangeRelation { get; private set; }
        public short CheckPetName { get; private set; }
        public short ClientVariables { get; private set; }
        public short CloseDice { get; private set; }
        public short CompostMonsterplant { get; private set; }
        public short ConfirmChangeName { get; private set; }
        public short CraftingAddRecipe { get; private set; }
        public short CraftingCraftItem { get; private set; }
        public short CraftingCraftSecret { get; private set; }
        public short DeclineFriendRequest { get; private set; }
        public short EditRoomPromotionMessage { get; private set; }
        public short EnableEffect { get; private set; }
        public short FindNewFriends { get; private set; }
        public short FloorPlanEditorRequestBlockedTiles { get; private set; }
        public short FloorPlanEditorRequestDoorSettings { get; private set; }
        public short FloorPlanEditorSave { get; private set; }
        public short FootballGateSaveLook { get; private set; }
        public short FriendPrivateMessage { get; private set; }
        public short FriendRequest { get; private set; }
        public short GameCenter { get; private set; }
        public short GameCenterJoinGame { get; private set; }
        public short GameCenterLoadGame { get; private set; }
        public short GameCenterRequestAccountStatus { get; private set; }
        public short GameCenterRequestGameStatus { get; private set; }
        public short GenerateSecretKey { get; private set; }
        public short GetClubData { get; private set; }
        public short GetHabboGuildBadgesMessage { get; private set; }
        public short GetMarketplaceConfig { get; private set; }
        public short GetPollData { get; private set; }
        public short GuardianAcceptRequest { get; private set; }
        public short GuardianNoUpdatesWanted { get; private set; }
        public short GuardianVote { get; private set; }
        public short GuideCancelHelpRequest { get; private set; }
        public short GuideCloseHelpRequest { get; private set; }
        public short GuideHandleHelpRequest { get; private set; }
        public short GuideInviteUser { get; private set; }
        public short GuideRecommendHelper { get; private set; }
        public short GuideReportHelper { get; private set; }
        public short GuideUserMessage { get; private set; }
        public short GuideUserTyping { get; private set; }
        public short GuideVisitUser { get; private set; }
        public short GuildAcceptMembership { get; private set; }
        public short GuildChangeBadge { get; private set; }
        public short GuildChangeColors { get; private set; }
        public short GuildChangeNameDesc { get; private set; }
        public short GuildChangeSettings { get; private set; }
        public short GuildConfirmRemoveMember { get; private set; }
        public short GuildDeclineMembership { get; private set; }
        public short GuildDelete { get; private set; }
        public short GuildRemoveAdmin { get; private set; }
        public short GuildRemoveFavorite { get; private set; }
        public short GuildRemoveMember { get; private set; }
        public short GuildSetAdmin { get; private set; }
        public short GuildSetFavorite { get; private set; }
        public short HandleDoorbell { get; private set; }
        public short HorseRide { get; private set; }
        public short HorseRideSettings { get; private set; }
        public short HorseUseItem { get; private set; }
        public short HotelViewClaimBadge { get; private set; }
        public short HotelViewClaimBadgeReward { get; private set; }
        public short HotelViewConcurrentUsersButton { get; private set; }
        public short HotelViewData { get; private set; }
        public short HotelView { get; private set; }
        public short HotelViewRequestBadgeReward { get; private set; }
        public short HotelViewRequestBonusRare { get; private set; }
        public short HotelViewRequestCommunityGoal { get; private set; }
        public short HotelViewRequestConcurrentUsers { get; private set; }
        public short IgnoreRoomUser { get; private set; }
        public short InitCrypto { get; private set; }
        public short InviteFriends { get; private set; }
        public short JukeBoxAddSoundTrack { get; private set; }
        public short JukeBoxEventOne { get; private set; }
        public short JukeBoxEventThree { get; private set; }
        public short JukeBoxEventTwo { get; private set; }
        public short JukeBoxRequestPlayList { get; private set; }
        public short JukeBoxRequestTrackCode { get; private set; }
        public short JukeBoxRequestTrackData { get; private set; }
        public short LatencyTest { get; private set; }
        public short MachineID { get; private set; }
        public short MannequinSaveLook { get; private set; }
        public short MannequinSaveName { get; private set; }
        public short ModToolAlert { get; private set; }
        public short ModToolBan { get; private set; }
        public short ModToolChangeRoomSettings { get; private set; }
        public short ModToolCloseTicket { get; private set; }
        public short ModToolKick { get; private set; }
        public short ModToolPickTicket { get; private set; }
        public short ModToolReleaseTicket { get; private set; }
        public short ModToolRequestIssueChatlog { get; private set; }
        public short ModToolRequestRoomChatlog { get; private set; }
        public short ModToolRequestRoomInfo { get; private set; }
        public short ModToolRequestRoomUserChatlog { get; private set; }
        public short ModToolRequestRoomVisits { get; private set; }
        public short ModToolRequestUserChatlog { get; private set; }
        public short ModToolRequestUserInfo { get; private set; }
        public short ModToolRoomAlert { get; private set; }
        public short ModToolSanctionAlert { get; private set; }
        public short ModToolSanctionBan { get; private set; }
        public short ModToolSanctionMute { get; private set; }
        public short ModToolSanctionTradeLock { get; private set; }
        public short ModToolWarn { get; private set; }
        public short MoodLightSaveSettings { get; private set; }
        public short MoodLightSettings { get; private set; }
        public short MoodLightTurnOn { get; private set; }
        public short MovePet { get; private set; }
        public short MoveWallItem { get; private set; }
        public short NavigatorCategoryListMode { get; private set; }
        public short NavigatorCollapseCategory { get; private set; }
        public short NavigatorUncollapseCategory { get; private set; }
        public short NewNavigatorAction { get; private set; }
        public short OpenRecycleBox { get; private set; }
        public short PetPackageName { get; private set; }
        public short PetPickup { get; private set; }
        public short PetPlace { get; private set; }
        public short PickNewUserGift { get; private set; }
        public short Pong { get; private set; }
        public short PostItDelete { get; private set; }
        public short PostItPlace { get; private set; }
        public short PostItRequestData { get; private set; }
        public short PostItSaveData { get; private set; }
        public short Recycle { get; private set; }
        public short RedeemClothing { get; private set; }
        public short RedeemItem { get; private set; }
        public short RedeemVoucher { get; private set; }
        public short ReleaseVersion { get; private set; }
        public short ReloadRecycler { get; private set; }
        public short RemoveFriend { get; private set; }
        public short RentSpaceCancel { get; private set; }
        public short RentSpace { get; private set; }
        public short ReportBully { get; private set; }
        public short Report { get; private set; }
        public short RequestAchievementConfiguration { get; private set; }
        public short RequestAchievements { get; private set; }
        public short RequestCameraConfiguration { get; private set; }
        public short RequestCanCreateRoom { get; private set; }
        public short RequestCatalogIndex { get; private set; }
        public short RequestCatalogMode { get; private set; }
        public short RequestCatalogPage { get; private set; }
        public short RequestClubGifts { get; private set; }
        public short RequestCraftingRecipesAvailable { get; private set; }
        public short RequestCraftingRecipes { get; private set; }
        public short RequestCreateRoom { get; private set; }
        public short RequestCredits { get; private set; }
        public short RequestDeleteRoom { get; private set; }
        public short RequestDiscount { get; private set; }
        public short RequestFriendRequest { get; private set; }
        public short RequestFriends { get; private set; }
        public short RequestGameConfigurations { get; private set; }
        public short RequestGiftConfiguration { get; private set; }
        public short RequestGuideAssistance { get; private set; }
        public short RequestGuideTool { get; private set; }
        public short RequestGuildBuy { get; private set; }
        public short RequestGuildBuyRooms { get; private set; }
        public short RequestGuildFurniWidget { get; private set; }
        public short RequestGuildInfo { get; private set; }
        public short RequestGuildJoin { get; private set; }
        public short RequestGuildManage { get; private set; }
        public short RequestGuildMembers { get; private set; }
        public short RequestGuildParts { get; private set; }
        public short RequestHeightmap { get; private set; }
        public short RequestHighestScoreRooms { get; private set; }
        public short RequestInitFriends { get; private set; }
        public short RequestInventoryBadges { get; private set; }
        public short RequestInventoryBots { get; private set; }
        public short RequestInventoryItems { get; private set; }
        public short RequestInventoryPets { get; private set; }
        public short RequestItemInfo { get; private set; }
        public short RequestMeMenuSettings { get; private set; }
        public short RequestMyRooms { get; private set; }
        public short RequestNavigatorSettings { get; private set; }
        public short RequestNewNavigatorData { get; private set; }
        public short RequestNewNavigatorRooms { get; private set; }
        public short RequestNewsList { get; private set; }
        public short RequestOffers { get; private set; }
        public short RequestOwnGuilds { get; private set; }
        public short RequestOwnItems { get; private set; }
        public short RequestPetBreeds { get; private set; }
        public short RequestPetInformation { get; private set; }
        public short RequestPetTrainingPanel { get; private set; }
        public short RequestPopularRooms { get; private set; }
        public short RequestProfileFriends { get; private set; }
        public short RequestPromotedRooms { get; private set; }
        public short RequestPromotionRooms { get; private set; }
        public short RequestPublicRooms { get; private set; }
        public short RequestRecylerLogic { get; private set; }
        public short RequestReportRoom { get; private set; }
        public short RequestReportUserBullying { get; private set; }
        public short RequestResolution { get; private set; }
        public short RequestRoomCategories { get; private set; }
        public short RequestRoomData { get; private set; }
        public short RequestRoomHeightmap { get; private set; }
        public short RequestRoomLoad { get; private set; }
        public short RequestRoomRights { get; private set; }
        public short RequestRoomSettings { get; private set; }
        public short RequestRoomWordFilter { get; private set; }
        public short RequestSellItem { get; private set; }
        public short RequestTags { get; private set; }
        public short RequestTalenTrack { get; private set; }
        public short RequestTargetOffer { get; private set; }
        public short RequestUserCitizenShip { get; private set; }
        public short RequestUserClub { get; private set; }
        public short RequestUserCredits { get; private set; }
        public short RequestUserData { get; private set; }
        public short RequestUserProfile { get; private set; }
        public short RequestUserTags { get; private set; }
        public short RequestUserWardrobe { get; private set; }
        public short RequestWearingBadges { get; private set; }
        public short RoomBackground { get; private set; }
        public short RoomFavorite { get; private set; }
        public short RoomMute { get; private set; }
        public short RoomPickupItem { get; private set; }
        public short RoomPlaceBuildersClubItem { get; private set; }
        public short RoomPlaceItem { get; private set; }
        public short RoomPlacePaint { get; private set; }
        public short RoomRemoveAllRights { get; private set; }
        public short RoomRemoveRights { get; private set; }
        public short RoomRequestBannedUsers { get; private set; }
        public short RoomSettingsSave { get; private set; }
        public short RoomStaffPick { get; private set; }
        public short RoomUserAction { get; private set; }
        public short RoomUserBan { get; private set; }
        public short RoomUserDance { get; private set; }
        public short RoomUserDropHandItem { get; private set; }
        public short RoomUserGiveHandItem { get; private set; }
        public short RoomUserGiveRespect { get; private set; }
        public short RoomUserGiveRights { get; private set; }
        public short RoomUserKick { get; private set; }
        public short RoomUserLookAtPoint { get; private set; }
        public short RoomUserMute { get; private set; }
        public short RoomUserRemoveRights { get; private set; }
        public short RoomUserShout { get; private set; }
        public short RoomUserSign { get; private set; }
        public short RoomUserSit { get; private set; }
        public short RoomUserStartTyping { get; private set; }
        public short RoomUserStopTyping { get; private set; }
        public short RoomUserTalk { get; private set; }
        public short RoomUserWalk { get; private set; }
        public short RoomUserWhisper { get; private set; }
        public short RoomVote { get; private set; }
        public short RoomWordFilterModify { get; private set; }
        public short RotateMoveItem { get; private set; }
        public short SaveBlockCameraFollow { get; private set; }
        public short SaveIgnoreRoomInvites { get; private set; }
        public short SaveMotto { get; private set; }
        public short SavePostItStickyPole { get; private set; }
        public short SavePreferOldChat { get; private set; }
        public short SaveUserVolumes { get; private set; }
        public short SaveWardrobe { get; private set; }
        public short SaveWindowSettings { get; private set; }
        public short ScratchPet { get; private set; }
        public short SearchRoomsByTag { get; private set; }
        public short SearchRooms { get; private set; }
        public short SearchRoomsFriendsNow { get; private set; }
        public short SearchRoomsFriendsOwn { get; private set; }
        public short SearchRoomsInGroup { get; private set; }
        public short SearchRoomsMyFavorite { get; private set; }
        public short SearchRoomsVisited { get; private set; }
        public short SearchRoomsWithRights { get; private set; }
        public short SearchUser { get; private set; }
        public short SSOTicket { get; private set; }
        public short SellItem { get; private set; }
        public short SetHomeRoom { get; private set; }
        public short SetStackHelperHeight { get; private set; }
        public short StalkFriend { get; private set; }
        public short TakeBackItem { get; private set; }
        public short TestInventory { get; private set; }
        public short ToggleFloorItem { get; private set; }
        public short ToggleMonsterplantBreedable { get; private set; }
        public short ToggleWallItem { get; private set; }
        public short TradeAccept { get; private set; }
        public short TradeCancelOfferItem { get; private set; }
        public short TradeClose { get; private set; }
        public short TradeConfirm { get; private set; }
        public short TradeOfferItem { get; private set; }
        public short TradeOfferMultipleItems { get; private set; }
        public short TradeStart { get; private set; }
        public short TradeUnAccept { get; private set; }
        public short TriggerColorWheel { get; private set; }
        public short TriggerDice { get; private set; }
        public short TriggerOneWayGate { get; private set; }
        public short UnIgnoreRoomUser { get; private set; }
        public short UnbanRoomUser { get; private set; }
        public short UserActivity { get; private set; }
        public short UserNux { get; private set; }
        public short UserSaveLook { get; private set; }
        public short UserWearBadge { get; private set; }
        public short Username { get; private set; }
        public short WiredConditionSaveData { get; private set; }
        public short WiredEffectSaveData { get; private set; }
        public short WiredTriggerSaveData { get; private set; }
        public short YoutubeRequestNextVideo { get; private set; }
        public short YoutubeRequestPlayList { get; private set; }
        public short YoutubeRequestVideoData { get; private set; }
    }
}
