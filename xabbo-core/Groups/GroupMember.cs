﻿using System;

using Xabbo.Core.Protocol;

namespace Xabbo.Core
{
    public class GroupMember
    {
        public static GroupMember Parse(Packet packet) => new GroupMember(packet);

        public GroupMemberType Type { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Figure { get; set; }
        public DateTime Joined { get; set; }

        public GroupMember() { }

        protected GroupMember(Packet packet)
        {
            Type = (GroupMemberType)packet.ReadInteger();
            Id = packet.ReadInteger();
            Name = packet.ReadString();
            Figure = packet.ReadString();
            Joined = DateTime.Parse(packet.ReadString());
        }
    }
}