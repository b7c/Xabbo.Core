﻿using System;

using Xabbo.Core.Messages;

namespace Xabbo.Core
{
    public class ItemData4 : StuffData
    {
        public ItemData4()
            : base(StuffDataType.ItemData4)
        { }

        protected override void WriteData(IPacket packet) { }
    }
}
