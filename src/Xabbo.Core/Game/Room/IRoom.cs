﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Xabbo.Core.Game;

public interface IRoom
{
    /// <summary>
    /// Gets the ID of this room.
    /// </summary>
    long Id { get; }

    /// <summary>
    /// Gets the data of this room.
    /// </summary>
    IRoomData Data { get; }

    #region - Room data -
    /// <summary>
    /// Gets the name of this room.
    /// </summary>
    string Name => Data.Name;
    /// <summary>
    /// Gets the description of this room.
    /// </summary>
    string Description => Data.Description;
    /// <summary>
    /// Gets the owner of this room's ID.
    /// </summary>
    long OwnerId => Data.OwnerId;
    /// <summary>
    /// Gets the owner of this room's name.
    /// </summary>
    string OwnerName => Data.OwnerName;

    /// <summary>
    /// Gets the door access mode of this room.
    /// </summary>
    RoomAccess Access => Data.Access;
    /// <summary>
    /// Gets if this room is open.
    /// </summary>
    bool IsOpen => Access == RoomAccess.Open;
    /// <summary>
    /// Gets if this room is in doorbell mode.
    /// </summary>
    bool IsDoorbell => Access == RoomAccess.Doorbell;
    /// <summary>
    /// Gets if this room is locked with a password.
    /// </summary>
    bool IsLocked => Access == RoomAccess.Password;
    /// <summary>
    /// Gets if this room is invisible.
    /// </summary>
    bool IsInvisible => Access == RoomAccess.Invisible;

    /// <summary>
    /// Gets the maximum users allowed in this room.
    /// </summary>
    int MaxUsers => Data.MaxUsers;
    /// <summary>
    /// Gets the trading permissions of this room.
    /// </summary>
    TradePermissions Trading => Data.Trading;
    /// <summary>
    /// Gets the score of this room.
    /// </summary>
    int Score => Data.Score;
    /// <summary>
    /// Gets the ranking of this room.
    /// </summary>
    int Ranking => Data.Ranking;
    /// <summary>
    /// Gets the category of this room.
    /// </summary>
    RoomCategory Category => Data.Category;
    IReadOnlyList<string> Tags => Data.Tags;

    /// <summary>
    /// Gets the flags of this room.
    /// </summary>
    RoomFlags Flags => Data.Flags;
    /// <summary>
    /// Gets if this room currently has an event.
    /// </summary>
    bool HasEvent => Data.HasEvent;
    /// <summary>
    /// Gets if this room is a group home room.
    /// </summary>
    bool IsGroupRoom => Data.IsGroupRoom;
    /// <summary>
    /// Gets if other's pets are allowed in this room.
    /// </summary>
    bool AllowPets => Data.AllowPets;

    /// <summary>
    /// Gets the ID of the group this room is home to.
    /// </summary>
    long GroupId => Data.GroupId;
    /// <summary>
    /// Gets the name of the group this room is home to.
    /// </summary>
    string GroupName => Data.GroupName;
    /// <summary>
    /// Gets the badge code of the group this room is home to.
    /// </summary>
    string GroupBadge => Data.GroupBadge;

    /// <summary>
    /// Gets the event name for this room.
    /// </summary>
    string EventName => Data.EventName;
    /// <summary>
    /// Gets the event description for this room.
    /// </summary>
    string EventDescription => Data.EventDescription;
    /// <summary>
    /// Gets the number of minutes remaining of the event for this room.
    /// </summary>
    int EventMinutesRemaining => Data.EventMinutesRemaining;

    /// <summary>
    /// Gets the moderation settings of this room.
    /// </summary>
    IModerationSettings Moderation => Data.Moderation;
    /// <summary>
    /// Gets the chat settings of this room.
    /// </summary>
    IChatSettings ChatSettings => Data.ChatSettings;
    #endregion

    /// <summary>
    /// Gets the model of this room.
    /// </summary>
    string Model { get; }
    /// <summary>
    /// Gets the floor code of this room.
    /// </summary>
    string? Floor { get; }
    /// <summary>
    /// Gets the wallpaper code of this room.
    /// </summary>
    string? Wallpaper { get; }
    /// <summary>
    /// Gets the landscape code of this room.
    /// </summary>
    string? Landscape { get; }

    /// <summary>
    /// Gets the location of this room's door tile.
    /// </summary>
    Tile DoorTile { get; }
    /// <summary>
    /// Gets the entry direction of this room.
    /// </summary>
    int EntryDirection { get; }

    /// <summary>
    /// Gets the floor plan of this room.
    /// </summary>
    IFloorPlan FloorPlan { get; }
    /// <summary>
    /// Gets the heightmap of this room.
    /// </summary>
    IHeightmap Heightmap { get; }

    /// <summary>
    /// Gets if the walls are hidden.
    /// </summary>
    bool HideWalls { get; }
    /// <summary>
    /// Gets the wall thickness.
    /// </summary>
    Thickness WallThickness { get; }
    /// <summary>
    /// Gets the floor thickness.
    /// </summary>
    Thickness FloorThickness { get; }

    #region - Furni -
    /// <summary>
    /// Gets the furni in this room.
    /// </summary>
    IEnumerable<IFurni> Furni => FloorItems.Concat<IFurni>(WallItems);
    /// <summary>
    /// Gets the floor items in this room.
    /// </summary>
    IEnumerable<IFloorItem> FloorItems { get; }
    /// <summary>
    /// Gets the wall items in this room.
    /// </summary>
    IEnumerable<IWallItem> WallItems { get; }

    /// <summary>
    /// Gets if a floor item with the specified ID exists in this room.
    /// </summary>
    bool HasFloorItem(long id);
    /// <summary>
    /// Gets if a wall item with the specified ID exists in this room.
    /// </summary>
    bool HasWallItem(long id);

    /// <summary>
    /// Gets the furni of the specified type with the specified ID if it exists.
    /// </summary>
    IFurni? GetFurni(ItemType type, long id);
    /// <summary>
    /// Gets the floor item with the specified ID if it exists.
    /// </summary>
    IFloorItem? GetFloorItem(long id);
    /// <summary>
    /// Gets the wall item with the specified ID if it exists.
    /// </summary>
    IWallItem? GetWallItem(long id);
    #endregion

    #region - Entities -
    /// <summary>
    /// Gets the entities in this room.
    /// </summary>
    IEnumerable<IEntity> Entities { get; }
    /// <summary>
    /// Gets the users in this room.
    /// </summary>
    IEnumerable<IRoomUser> Users => Entities.OfType<IRoomUser>();
    /// <summary>
    /// Gets the pets in this room.
    /// </summary>
    IEnumerable<IPet> Pets => Entities.OfType<IPet>();
    /// <summary>
    /// Gets the bots in this room.
    /// </summary>
    IEnumerable<IBot> Bots => Entities.OfType<IBot>();

    /// <summary>
    /// Gets the entity with the specified index if it exists.
    /// </summary>
    TEntity? GetEntity<TEntity>(int index) where TEntity : IEntity;
    /// <summary>
    /// Gets the entity with the specified name if it exists.
    /// </summary>
    TEntity? GetEntity<TEntity>(string name) where TEntity : IEntity;
    /// <summary>
    /// Gets the entity with the specified ID if it exists.
    /// </summary>
    TEntity? GetEntityById<TEntity>(long id) where TEntity : IEntity;

    bool TryGetEntityByIndex<TEntity>(int index, [NotNullWhen(true)] out TEntity? entity) where TEntity : IEntity;
    bool TryGetEntityById<TEntity>(long id, [NotNullWhen(true)] out TEntity? entity) where TEntity : IEntity;
    bool TryGetEntityByName<TEntity>(string name, [NotNullWhen(true)] out TEntity? entity) where TEntity : IEntity;

    bool TryGetUserByIndex(int index, [NotNullWhen(true)] out IRoomUser? user) => TryGetEntityByIndex(index, out user);
    bool TryGetUserById(long id, [NotNullWhen(true)] out IRoomUser? user) => TryGetEntityById(id, out user);
    bool TryGetUserByName(string name, [NotNullWhen(true)] out IRoomUser? user) => TryGetEntityByName(name, out user);

    bool TryGetPetByIndex(int index, [NotNullWhen(true)] out IPet? pet) => TryGetEntityByIndex(index, out pet);
    bool TryGetPetById(long id, [NotNullWhen(true)] out IPet? pet) => TryGetEntityById(id, out pet);
    bool TryGetPetByName(string name, [NotNullWhen(true)] out IPet? pet) => TryGetEntityByName(name, out pet);

    bool TryGetBotByIndex(int index, [NotNullWhen(true)] out IBot? bot) => TryGetEntityByIndex(index, out bot);
    bool TryGetBotById(long id, [NotNullWhen(true)] out IBot? bot) => TryGetEntityById(id, out bot);
    bool TryGetBotByName(string name, [NotNullWhen(true)] out IBot? bot) => TryGetEntityByName(name, out bot);
    #endregion
}
