﻿using System;
using System.Collections.Generic;

using Xabbo.Core.Protocol;

namespace Xabbo.Core
{
    public class RoomSettings : IWritable
    {
        public static RoomSettings Parse(Packet packet) => new RoomSettings(packet);

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public RoomAccess Access { get; set; }
        public string Password { get; set; }
        public int MaxVisitors { get; set; }
        public RoomCategory Category { get; set; }
        public List<string> Tags { get; set; }
        public TradePermissions Trading { get; set; }

        public bool AllowPets { get; set; }
        public bool AllowOthersPetsToEat { get; set; }
        public bool DisableRoomBlocking { get; set; }
        public bool HideWalls { get; set; }
        public Thickness WallThickness { get; set; }
        public Thickness FloorThickness { get; set; }

        public ModerationSettings Moderation { get; set; }
        public ChatSettings Chat { get; set; }

        public bool EnlistByFurniContent { get; set; }

        public RoomSettings()
        {
            Tags = new List<string>();
        }

        internal RoomSettings(Packet packet)
            : this()
        {
            /*
            << RoomSettings
            int roomId
            string name
            string desc
            int access
            int category
            int maxUsers
            int 50 ???
            int tags[] { string }
            int trading
            int allowPets
            int allowOtherPetsToEat
            int disableRoomBlocking
            int hideWalls
            int wallThickness
            int floorThickness
            chatSettings
            bool enlistByFurniContent
            moderationSettings
            */

            Id = packet.ReadInteger();
            Name = packet.ReadString();
            Description = packet.ReadString();
            Access = (RoomAccess)packet.ReadInteger();
            Category = (RoomCategory)packet.ReadInteger();
            MaxVisitors = packet.ReadInteger();
            packet.ReadInteger();
            int n = packet.ReadInteger();
            for (int i = 0; i < n; i++)
                Tags.Add(packet.ReadString());
            Trading = (TradePermissions)packet.ReadInteger();
            AllowPets = packet.ReadInteger() > 0;
            AllowOthersPetsToEat = packet.ReadInteger() > 0;
            DisableRoomBlocking = packet.ReadInteger() > 0;
            HideWalls = packet.ReadInteger() > 0;
            WallThickness = (Thickness)packet.ReadInteger();
            FloorThickness = (Thickness)packet.ReadInteger();
            Chat = ChatSettings.Parse(packet);
            EnlistByFurniContent = packet.ReadBoolean();
            Moderation = ModerationSettings.Parse(packet);
        }

        /*
        >> RoomSettingsSave
        int id
        string name
        string description
        int access
        string password
        int maxUsers
        int category
        int tags { string }
        int tradePermissions
        bool allowPets
        bool allowOthersPetsToEat
        bool disableRoomBlocking
        bool hideWalls
        int wallThickness
        int floorThickness
        moderationSettings
          int 
          int 
          int 
        chatSettings
          int 
          int 
          int 
          int chatHearingDistance
          int 
        bool enlistByTopFurniContent
        */

        /// <summary>
        /// Writes the values of this <see cref="RoomSettings"/> to the specified packet
        /// to be sent to the server with <c>RoomSettingsSave</c>.
        /// </summary>
        public void Write(Packet packet)
        {
            packet.WriteValues(
                Id,
                Name,
                Description,
                (int)Access,
                Password,
                MaxVisitors,
                (int)Category,
                Tags,
                (int)Trading,
                AllowPets,
                AllowOthersPetsToEat,
                DisableRoomBlocking,
                HideWalls,
                (int)WallThickness,
                (int)FloorThickness,
                Moderation,
                Chat,
                EnlistByFurniContent
            );
        }
    }
}
