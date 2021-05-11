﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

using Xabbo.Messages;
using Xabbo.Interceptor;

using Xabbo.Core.Events;
using System.Diagnostics.CodeAnalysis;

namespace Xabbo.Core.Game
{
    /// <summary>
    /// Manages and tracks entities in the room.
    /// </summary>
    public class EntityManager : GameStateManager
    {
        private readonly RoomManager _roomManager;
        private readonly ConcurrentDictionary<int, Entity> _entities = new();

        /// <summary>
        /// Gets the entities in the room.
        /// </summary>
        public IEnumerable<IEntity> Entities => _entities.Select(x => x.Value);
        /// <summary>
        /// Gets the users in the room.
        /// </summary>
        public IEnumerable<IRoomUser> Users => Entities.OfType<RoomUser>();
        /// <summary>
        /// Gets the pets in the room.
        /// </summary>
        public IEnumerable<IPet> Pets => Entities.OfType<Pet>();
        /// <summary>
        /// Gets the bots in the room.
        /// </summary>
        public IEnumerable<IBot> Bots => Entities.OfType<Bot>();

        /// <summary>
        /// Gets the entity of the specified type with the specified index, or <c>null</c> if it does not exist.
        /// </summary>
        public T? GetEntityByIndex<T>(int index) where T : class, IEntity => GetEntityByIndex(index) as T;
        /// <summary>
        /// Gets the entity of the specified type with the specified ID, or <c>null</c> if it does not exist.
        /// </summary>
        public T? GetEntity<T>(long id) where T : IEntity
            => Entities.OfType<T>().FirstOrDefault(e => e.Id == id);
        /// <summary>
        /// Gets the entity of the specified type with the specified name, or <c>null</c> if it does not exist.
        /// </summary>
        public T? GetEntity<T>(string name) where T : IEntity
            => Entities.OfType<T>().FirstOrDefault(e => e.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));

        /// <summary>
        /// Gets the entity with the specified index, or <c>null</c> if it does not exist.
        /// </summary>
        public IEntity? GetEntityByIndex(int index) => _entities.TryGetValue(index, out Entity? e) ? e : null;
        /// <summary>
        /// Gets the entity with the specified ID, or <c>null</c> if it does not exist.
        /// </summary>
        public IEntity? GetEntity(long id) => Entities.FirstOrDefault(e => e.Id == id);
        /// <summary>
        /// Gets the entity with the specified name, or <c>null</c> if it does not exist.
        /// </summary>
        public IEntity? GetEntity(string name) => Entities.FirstOrDefault(e => e.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));

        /// <summary>
        /// Attempts to get the entity with the specified index.
        /// </summary>
        public bool TryGetEntityByIndex(int index, out IEntity? entity)
        {
            if (_entities.TryGetValue(index, out Entity? result))
            {
                entity = result;
                return true;
            }
            else
            {
                entity = default;
                return false;
            }
        }

        /// <summary>
        /// Attempts to get the entity of the specified type with the specified index.
        /// </summary>
        public bool TryGetEntityByIndex<T>(int index, [NotNullWhen(true)] out T? entity) where T : IEntity
        {
            if (_entities.TryGetValue(index, out Entity? e))
            {
                entity = (T)(IEntity)e;
                return true;
            }
            else
            {
                entity = default;
                return false;
            }
        }

        /// <summary>
        /// Attempts to get the entity of the specified type with the specified ID.
        /// </summary>
        public bool TryGetEntity<T>(long id, [NotNullWhen(true)] out T? entity) where T : IEntity
            => (entity = GetEntity<T>(id)) != null;

        /// <summary>
        /// Attempts to get the entity of the specified type with the specified name.
        /// </summary>
        public bool TryGetEntity<T>(string name, out T? entity) where T : IEntity
            => (entity = GetEntity<T>(name)) != null;

        

        public EntityManager(IInterceptor interceptor, RoomManager roomManager)
            : base(interceptor)
        {
            _roomManager = roomManager;
            _roomManager.Left += Room_Left;
        }

        private void Room_Left(object? sender, EventArgs e)
        {
            DebugUtil.Log("clearing entities");

            _entities.Clear();
        }

        /// <summary>
        /// Hides the entity client-side.
        /// </summary>
        public void Hide(IEntity entity)
        {
            if (entity is not Entity e)
                return;

            if (!e.IsHidden)
            {
                e.IsHidden = true;
                SendClientAsync(In.UserLoggedOut, e.Index);
            }
        }

        /// <summary>
        /// Hides the entities client-side.
        /// </summary>
        /// <param name="entities"></param>
        public void Hide(IEnumerable<IEntity> entities)
        {
            foreach (Entity e in entities.OfType<Entity>())
            {
                
            }
        }

        /// <summary>
        /// Shows the entity after hiding it client-side.
        /// </summary>
        /// <param name="entity"></param>
        public void Show(IEntity entity)
        {
            if (entity is not Entity e)
                return;

            if (e.IsHidden)
            {
                e.IsHidden = false;
                SendClientAsync(In.UsersInRoom, 1, e);
            }
        }

        /// <summary>
        /// Shows the entities after hiding them client-side.
        /// </summary>
        public void Show(IEnumerable<IEntity> entities)
        {
            List<IEntity> shown = new();
            foreach (Entity entity in entities.OfType<Entity>())
            {
                if (entity.IsHidden)
                {
                    entity.IsHidden = false;
                    shown.Add(entity);
                }
            }

            SendClientAsync(In.UsersInRoom, shown);
        }

        [InterceptIn(nameof(Incoming.Ping))]
        private void DeleteThis(InterceptArgs e) { }

        /*[InterceptIn(nameof(Incoming.UsersInRoom))]
        private void HandleUsersInRoom(InterceptArgs e)
        {
            if (!_roomManager.IsLoadingRoom && !_roomManager.IsInRoom)
                return;

            List<Entity> newEntities = new List<Entity>();

            foreach (Entity entity in Entity.ParseAll(e.Packet))
            {
                if (_entities.TryAdd(entity.Index, entity))
                {
                    newEntities.Add(entity);
                    OnEntityAdded(entity);
                }
                else
                {
                    DebugUtil.Log($"failed to add entity {entity.Index} {entity.Name} (id:{entity.Id})");
                }
            }

            if (newEntities.Count > 0)
            {
                OnEntitiesAdded(newEntities);
            }
        }

        [InterceptIn(nameof(Incoming.UserLoggedOut))]
        private void HandleUserLoggedOut(InterceptArgs e)
        {
            if (!_roomManager.IsInRoom)
            {
                DebugUtil.Log("not in room");
                return;
            }

            int index = e.Client switch
            {
                ClientType.Flash => int.Parse(e.Packet.ReadString()),
                _ => e.Packet.ReadInt()
            };

            if (_entities.TryRemove(index, out Entity? entity))
            {
                OnEntityRemoved(entity);
            }
            else
            {
                DebugUtil.Log($"failed to remove entity {index}");
            }
        }

        [InterceptIn(nameof(Incoming.Status))]
        private void HandleStatus(InterceptArgs e)
        {
            if (!_roomManager.IsInRoom) return;

            var updatedEntities = new List<IEntity>();

            short n = e.Packet.ReadLegacyShort();
            for (int i = 0; i < n; i++)
            {
                EntityStatusUpdate update = EntityStatusUpdate.Parse(e.Packet);
                if (!_entities.TryGetValue(update.Index, out Entity? entity))
                {
                    DebugUtil.Log($"failed to find entity {update.Index} to update");
                    continue;
                }

                entity.Update(update);
                updatedEntities.Add(entity);

                OnEntityUpdated(entity);
            }

            OnEntitiesUpdated(updatedEntities);
        }

        [InterceptIn(nameof(Incoming.QueueMoveUpdate))]
        private void HandleQueueMoveUpdate(InterceptArgs e)
        {
            if (!_roomManager.IsInRoom) return;

            var rollerUpdate = RollerUpdate.Parse(e.Packet);

            if (rollerUpdate.Type == RollerUpdateType.MovingEntity ||
                rollerUpdate.Type == RollerUpdateType.StationaryEntity)
            {
                if (_entities.TryGetValue(rollerUpdate.EntityIndex, out Entity? entity))
                {
                    var previousTile = entity.Location;
                    entity.Location = new Tile(rollerUpdate.TargetX, rollerUpdate.TargetY, rollerUpdate.EntityTargetZ);

                    OnEntitySlide(entity, previousTile);
                }
                else
                {
                    DebugUtil.Log($"failed to find entity {rollerUpdate.EntityIndex} to update");
                }
            }
        }

        [InterceptIn(nameof(Incoming.UpdateAvatar))]
        private void HandleUpdateAvatar(InterceptArgs e)
        {
            if (!_roomManager.IsInRoom) return;

            int index = e.Packet.ReadInt();
            if (TryGetEntityByIndex(index, out RoomUser? user))
            {
                string previousFigure = user.Figure;
                Gender previousGender = user.Gender;
                string previousMotto = user.Motto;
                int previousAchievementScore = user.AchievementScore;

                user.Figure = e.Packet.ReadString();
                user.Gender = H.ToGender(e.Packet.ReadString());
                user.Motto = e.Packet.ReadString();
                user.AchievementScore = e.Packet.ReadInt();

                OnUserDataUpdated(user,
                    previousFigure, previousGender,
                    previousMotto, previousAchievementScore
                );
            }
            else
            {
                DebugUtil.Log($"failed to find entity {index} to update");
            }
        }

        [InterceptIn(nameof(Incoming.UserNameChanged))] // @Check
        private void HandleUserNameChanged(InterceptArgs e)
        {
            if (!_roomManager.IsInRoom) return;

            long id = e.Packet.ReadLegacyLong();
            int index = e.Packet.ReadInt();
            string newName = e.Packet.ReadString();

            if (TryGetEntityByIndex(index, out Entity? entity))
            {
                string previousName = entity.Name;
                entity.Name = newName;
                OnEntityNameChanged(entity, previousName);
            }
            else
            {
                DebugUtil.Log($"failed to find entity {index} to update");
            }
        }

        [InterceptIn(nameof(Incoming.RoomAvatarSleeping))]
        private void HandleRoomAvatarSleeping(InterceptArgs e)
        {
            if (!_roomManager.IsInRoom) return;

            int index = e.Packet.ReadInt();
            if (TryGetEntityByIndex(index, out Entity? entity))
            {
                bool wasIdle = entity.IsIdle;
                entity.IsIdle = e.Packet.ReadBool();
                OnEntityIdle(entity, wasIdle);
            }
            else
            {
                DebugUtil.Log($"failed to find entity {index} to update");
            }
        }

        [InterceptIn(nameof(Incoming.RoomDance))]
        private void HandleRoomDance(InterceptArgs e)
        {
            if (!_roomManager.IsInRoom) return;

            int index = e.Packet.ReadInt();
            if (!TryGetEntityByIndex(index, out Entity? entity))
            {
                DebugUtil.Log($"failed to find entity {index} to update");
                return;
            }

            int previousDance = entity.Dance;
            entity.Dance = e.Packet.ReadInt();

            OnEntityDance(entity, previousDance);
        }

        [InterceptIn(nameof(Incoming.RoomExpression))]
        private void HandleRoomExpression(InterceptArgs e)
        {
            if (!_roomManager.IsInRoom) return;

            int index = e.Packet.ReadInt();
            if (!TryGetEntityByIndex(index, out Entity? entity))
            {
                DebugUtil.Log($"failed to find entity {index} to update");
                return;
            }

            OnEntityExpression(entity, (Expressions)e.Packet.ReadInt());
        }

        [InterceptIn(nameof(Incoming.RoomCarryObject))]
        private void HandleRoomCarryObject(InterceptArgs e)
        {
            if (!_roomManager.IsInRoom) return;

            int index = e.Packet.ReadInt();
            if (!TryGetEntityByIndex(index, out Entity? entity))
            {
                DebugUtil.Log($"failed to find entity {index} to update");
                return;
            }

            int previousItem = entity.HandItem;
            entity.HandItem = e.Packet.ReadInt();
            OnEntityHandItem(entity, previousItem);
        }

        [InterceptIn(nameof(Incoming.RoomAvatarEffect))]
        private void HandleRoomAvatarEffect(InterceptArgs e)
        {
            if (!_roomManager.IsInRoom) return;

            int index = e.Packet.ReadInt();
            if (!TryGetEntityByIndex(index, out Entity? entity))
            {
                DebugUtil.Log($"failed to find entity {index} to update");
                return;
            }

            int previousEffect = entity.Effect;
            entity.Effect = e.Packet.ReadInt();
            OnEntityEffect(entity, previousEffect);

            // + int delay
        }

        [InterceptIn(nameof(Incoming.UserTypingStatusChange))]
        private void HandleUserTypingStatusChange(InterceptArgs e)
        {
            if (!_roomManager.IsInRoom) return;

            int index = e.Packet.ReadInt();

            if (!TryGetEntityByIndex(index, out Entity? entity))
            {
                DebugUtil.Log($"failed to find entity {index} to update");
                return;
            }

            bool wasTyping = entity.IsTyping;
            entity.IsTyping = e.Packet.ReadInt() != 0;
            OnEntityTyping(entity, wasTyping);
        }*/
    }
}
