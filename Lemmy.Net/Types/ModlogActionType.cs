using System.Runtime.Serialization;

namespace Lemmy.Net.Types;

public enum ModlogActionType
{
    [EnumMember(Value = "All")]
    All,

    [EnumMember(Value = "ModRemovePost")]
    ModRemovePost,

    [EnumMember(Value = "ModLockPost")]
    ModLockPost,

    [EnumMember(Value = "ModFeaturePost")]
    ModFeaturePost,

    [EnumMember(Value = "ModRemoveComment")]
    ModRemoveComment,

    [EnumMember(Value = "ModRemoveCommunity")]
    ModRemoveCommunity,

    [EnumMember(Value = "ModBanFromCommunity")]
    ModBanFromCommunity,

    [EnumMember(Value = "ModAddCommunity")]
    ModAddCommunity,

    [EnumMember(Value = "ModTransferCommunity")]
    ModTransferCommunity,

    [EnumMember(Value = "ModAdd")]
    ModAdd,

    [EnumMember(Value = "ModBan")]
    ModBan,

    [EnumMember(Value = "ModHideCommunity")]
    ModHideCommunity,

    [EnumMember(Value = "AdminPurgePerson")]
    AdminPurgePerson,

    [EnumMember(Value = "AdminPurgeCommunity")]
    AdminPurgeCommunity,

    [EnumMember(Value = "AdminPurgePost")]
    AdminPurgePost,

    [EnumMember(Value = "AdminPurgeComment")]
    AdminPurgeComment
}