using System;
using System.Collections.Generic;

namespace SampleCollection1.Models;

public partial class MemberWithMemberTagModel
{
    public string MemberId { get; set; } = null!;

    public string MemberTagId { get; set; } = null!;

    public string SimilarScore { get; set; } = null!;

    public string SupportScore { get; set; } = null!;

    public string TagScore { get; set; } = null!;

    public virtual MemberModel Member { get; set; } = null!;

    public virtual MemberTagModel MemberTag { get; set; } = null!;
}
