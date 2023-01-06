using System;
using System.Collections.Generic;

namespace SampleCollection1.Models;

public partial class MemberWechatModel
{
    public string WechatId { get; set; } = null!;

    public string Sexual { get; set; } = null!;

    public string Nickname { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string Area { get; set; } = null!;

    public string MemberId { get; set; } = null!;

    public virtual MemberModel Member { get; set; } = null!;
}
