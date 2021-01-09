﻿using System;
using Xabbo.Core.Protocol;

namespace Xabbo.Core
{
    /// <summary>
    /// Contains information about the user's friend.
    /// </summary>
    public interface IFriend : IPacketData
    {
        /// <summary>
        /// Gets the ID of the friend.
        /// </summary>
        int Id { get; }
        /// <summary>
        /// Gets the name of the friend.
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Gets the gender of the friend.
        /// </summary>
        Gender Gender { get; }
        /// <summary>
        /// Gets whether the friend is online or not.
        /// </summary>
        bool IsOnline { get; }
        /// <summary>
        /// Gets whether the friend can be followed or not.
        /// </summary>
        bool CanFollow { get; }
        /// <summary>
        /// Gets the figure string of the friend.
        /// </summary>
        string FigureString { get; }
        /// <summary>
        /// Gets the category in the friend list that the friend belongs to.
        /// </summary>
        int Category { get; }
        /// <summary>
        /// Gets the motto of the friend.
        /// </summary>
        string Motto { get; }
        /// <summary>
        /// Gets whether the friend is accepting offline messages or not.
        /// </summary>
        bool IsAcceptingOfflineMessages { get; }
        bool IsPocketHabboUser { get; }
        /// <summary>
        /// Gets the relation of the friend.
        /// </summary>
        Relation Relation { get; }
    }
}