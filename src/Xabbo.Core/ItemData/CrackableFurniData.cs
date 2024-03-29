﻿using System;
using Xabbo.Messages;

namespace Xabbo.Core;

public class CrackableFurniData : ItemData, ICrackableFurniData
{
    public int Hits { get; set; }
    public int Target { get; set; }

    public CrackableFurniData()
        : base(ItemDataType.CrackableFurni)
    { }

    public CrackableFurniData(ICrackableFurniData data)
        : base(data)
    {
        Hits = data.Hits;
        Target = data.Target;
    }

    protected override void Initialize(IReadOnlyPacket packet)
    {
        Value = packet.ReadString();
        Hits = packet.ReadInt();
        Target = packet.ReadInt();

        base.Initialize(packet);
    }

    protected override void WriteData(IPacket packet)
    {
        packet.WriteString(Value);
        packet.WriteInt(Hits);
        packet.WriteInt(Target);

        WriteBase(packet);
    }
}
