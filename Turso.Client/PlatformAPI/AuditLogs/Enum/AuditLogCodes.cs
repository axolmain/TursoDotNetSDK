using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Turso.Client.PlatformAPI.AuditLogs.Enum;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AuditLogCodes
{
    [EnumMember(Value = "user-signup")]
    UserSignup,

    [EnumMember(Value = "db-create")]
    DbCreate,

    [EnumMember(Value = "db-delete")]
    DbDelete,

    [EnumMember(Value = "instance-create")]
    InstanceCreate,

    [EnumMember(Value = "instance-delete")]
    InstanceDelete,

    [EnumMember(Value = "org-create")]
    OrgCreate,

    [EnumMember(Value = "org-delete")]
    OrgDelete,

    [EnumMember(Value = "org-member-add")]
    OrgMemberAdd,

    [EnumMember(Value = "org-member-rm")]
    OrgMemberRm,

    [EnumMember(Value = "org-member-leave")]
    OrgMemberLeave,

    [EnumMember(Value = "org-plan-update")]
    OrgPlanUpdate,

    [EnumMember(Value = "org-set-overages")]
    OrgSetOverages,

    [EnumMember(Value = "group-create")]
    GroupCreate,

    [EnumMember(Value = "group-delete")]
    GroupDelete
}