﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xabbo.Core.Protocol;

/*
	Achievement {
		int achievementId
		int level // level 0 must start at 1
		string string1
		int baseProgress
		int maxProgress = max(1, readInt())
			get() => maxProgress - baseProgress;
		int int3
		int int4
		int currentProgress
			get() => currentProgress - baseProgress;
		bool bool1 // Maxed?
		string category
		string string2
		int maxLevel
		int int7
		
		local bool ? => level > 1 || bool1;
	}
*/

namespace Xabbo.Core
{
    public class Achievement : IWritable
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public string BadgeName { get; set; }
        public int BaseProgress { get; set; }
        public int MaxProgress { get; set; }
        public int UnknownIntA { get; set; }
        public int UnknownIntB { get; set; }
        public int CurrentProgress { get; set; }
        public bool IsCompleted { get; set; }
        public string Category { get; set; }
        public string UnknownStringA { get; set; }
        public int MaxLevel { get; set; }
        public int UnknownIntC { get; set; }

        public Achievement() { }

        internal Achievement(Packet packet)
        {
            Id = packet.ReadInteger();
            Level = packet.ReadInteger();
            BadgeName = packet.ReadString();
            BaseProgress = packet.ReadInteger();
            MaxProgress = packet.ReadInteger();
            UnknownIntA = packet.ReadInteger();
            UnknownIntB = packet.ReadInteger();
            CurrentProgress = packet.ReadInteger();
            IsCompleted = packet.ReadBoolean();
            Category = packet.ReadString();
            UnknownStringA = packet.ReadString();
            MaxLevel = packet.ReadInteger();
            UnknownIntC = packet.ReadInteger();
        }

        public void Write(Packet packet)
        {
            packet.WriteValues(
                Id,
                Level,
                BadgeName,
                BaseProgress,
                MaxProgress,
                UnknownIntA,
                UnknownIntB,
                CurrentProgress,
                IsCompleted,
                Category,
                UnknownStringA,
                MaxLevel,
                UnknownIntC
            );
        }

        public static Achievement Parse(Packet packet) => new Achievement(packet);
    }
}
