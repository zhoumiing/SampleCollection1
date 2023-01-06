using System;
using System.Collections.Generic;

namespace SampleCollection1.Models;

public partial class MemberModel
{
    public string MemberId { get; set; } = null!;

    public string MemberJoinDate { get; set; } = null!;

    public string MemberNickName { get; set; } = null!;

    public string Sexual { get; set; } = null!;

    public string MemberBirthday { get; set; } = null!;

    public string Comments { get; set; } = null!;

    public virtual ICollection<ContactModel> ContactModels { get; } = new List<ContactModel>();

    public virtual ICollection<MemberWechatModel> MemberWechatModels { get; } = new List<MemberWechatModel>();

    public virtual ICollection<MemberWithMemberTagModel> MemberWithMemberTagModels { get; } = new List<MemberWithMemberTagModel>();
}
