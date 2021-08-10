﻿using System;
using System.Collections.Generic;

using Xabbo.Messages;

namespace Xabbo.Core
{
    public class CatalogOffer : ICatalogOffer
    {
        public int Id { get; set; }
        public CatalogPage? Page { get; set; }
        ICatalogPage? ICatalogOffer.Page => Page;
        public string FurniLine { get; set; }
        public bool IsRentable { get; set; }
        public int PriceInCredits { get; set; }
        public int PriceInActivityPoints { get; set; }
        public ActivityPointType ActivityPointType { get; set; }
        public bool CanPurchaseAsGift { get; set; }
        public List<CatalogProduct> Products { get; set; } = new List<CatalogProduct>();
        IReadOnlyList<ICatalogProduct> ICatalogOffer.Products => Products;
        public int ClubLevel { get; set; }
        public bool CanPurchaseMultiple { get; set; }
        public bool IsPet { get; set; }
        public string PreviewImage { get; set; }

        public CatalogOffer()
        {
            FurniLine = string.Empty;
            Products = new List<CatalogProduct>();
            PreviewImage = string.Empty;
        }

        protected CatalogOffer(IReadOnlyPacket packet)
        {
            Id = packet.ReadInt();
            FurniLine = packet.ReadString();
            IsRentable = packet.ReadBool();
            PriceInCredits = packet.ReadInt();
            PriceInActivityPoints = packet.ReadInt();
            ActivityPointType = (ActivityPointType)packet.ReadInt();
            CanPurchaseAsGift = packet.ReadBool();

            short n = packet.ReadLegacyShort();
            for (int i = 0; i < n; i++)
                Products.Add(CatalogProduct.Parse(packet));

            ClubLevel = packet.ReadInt();
            CanPurchaseMultiple = packet.ReadBool();
            IsPet = packet.ReadBool();
            PreviewImage = packet.ReadString();
        }

        public void Compose(IPacket packet)
        {
            packet
                .WriteInt(Id)
                .WriteString(FurniLine)
                .WriteBool(IsRentable)
                .WriteInt(PriceInCredits)
                .WriteInt(PriceInActivityPoints)
                .WriteInt((int)ActivityPointType)
                .WriteBool(CanPurchaseAsGift)
                .WriteValues(Products)
                .WriteInt(ClubLevel)
                .WriteBool(CanPurchaseMultiple)
                .WriteBool(IsPet)
                .WriteString(PreviewImage);
        }

        public static CatalogOffer Parse(IReadOnlyPacket packet) => new CatalogOffer(packet);
    }
}
