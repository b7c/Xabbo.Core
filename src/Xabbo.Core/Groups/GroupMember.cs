﻿using System;
using Xabbo.Messages;

namespace Xabbo.Core;

public class GroupMember : IGroupMember
{
    public static GroupMember Parse(IReadOnlyPacket packet) => new GroupMember(packet);

    public GroupMemberType Type { get; set; }
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Figure { get; set; } = string.Empty;
    public DateTime Joined { get; set; }

    public GroupMember() { }

    protected GroupMember(IReadOnlyPacket packet)
    {
        Type = (GroupMemberType)packet.ReadInt();
        Id = packet.ReadLegacyLong();
        Name = packet.ReadString();
        Figure = packet.ReadString();
        Joined = DateTime.Parse(packet.ReadString());
    }
}