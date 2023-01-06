using System;
using System.Collections.Generic;

namespace SampleCollection1.Models;

public partial class MemberTagModel
{
    public string MemberTagId { get; set; } = null!;

    public string TagName { get; set; } = null!;

    public string TagComments { get; set; } = null!;

    public virtual ICollection<MemberWithMemberTagModel> MemberWithMemberTagModels { get; } = new List<MemberWithMemberTagModel>();
}
