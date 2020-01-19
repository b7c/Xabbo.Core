﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xabbo.Core.Protocol;

namespace Xabbo.Core
{
    public class CatalogPage
    {
        public static CatalogPage Parse(Packet packet) => new CatalogPage(packet);

        public int Id { get; set; }
        public string Mode { get; set; }
        public string LayoutCode { get; set; }
        public List<string> Images { get; set; } = new List<string>();
        public List<string> Texts { get; set; } = new List<string>();
        public List<CatalogOffer> Offers { get; set; } = new List<CatalogOffer>();
        public int UnknownIntA { get; set; }
        public bool AcceptSeasonCurrencyAsCredits { get; set; }
        public List<CatalogPageData> Data { get; set; } = new List<CatalogPageData>();

        public CatalogPage() { }

        internal CatalogPage(Packet packet)
        {
            Id = packet.ReadInteger();
            Mode = packet.ReadString();
            LayoutCode = packet.ReadString();
            int n = packet.ReadInteger();
            for (int i = 0; i < n; i++)
                Images.Add(packet.ReadString());
            n = packet.ReadInteger();
            for (int i = 0; i < n; i++)
                Texts.Add(packet.ReadString());
            n = packet.ReadInteger();
            for (int i = 0; i < n; i++)
                Offers.Add(CatalogOffer.Parse(packet));
            UnknownIntA = packet.ReadInteger();
            AcceptSeasonCurrencyAsCredits = packet.ReadBoolean();
            if (packet.Available > 0)
            {
                n = packet.ReadInteger();
                for (int i = 0; i < n; i++)
                    Data.Add(CatalogPageData.Parse(packet));
            }
        }

        public CatalogOffer FindOffer(
            int priceInCredits = -1,
            int priceInActivityPoints = -1,
            ActivityPointType? activityPointType = null,
            bool? canPurchaseMultiple = null,
            int clubLevel = -1,
            int productCount = -1,
            int[] furniIds = null)
        {
            return FindOffers(
                priceInCredits: priceInCredits,
                priceInActivityPoints: priceInActivityPoints,
                activityPointType: activityPointType,
                canPurchaseMultiple: canPurchaseMultiple,
                clubLevel: clubLevel,
                productCount: productCount,
                furniIds: furniIds
            ).FirstOrDefault();
        }

        public IEnumerable<CatalogOffer> FindOffers(
            int priceInCredits = -1,
            int priceInActivityPoints = -1,
            ActivityPointType? activityPointType = null,
            bool? canPurchaseMultiple = null,
            int clubLevel = -1,
            int productCount = -1,
            int[] furniIds = null)
        {
            foreach (var offer in Offers)
            {
                bool match = true;
                if (priceInCredits != -1 && offer.PriceInCredits != priceInCredits) continue;
                if (priceInActivityPoints != -1 && offer.PriceInActivityPoints != priceInActivityPoints) continue;
                if (activityPointType.HasValue && offer.ActivityPointType != activityPointType) continue;
                if (canPurchaseMultiple.HasValue && offer.CanPurchaseMultiple != canPurchaseMultiple) continue;
                if (clubLevel != -1 && offer.ClubLevel != clubLevel) continue;

                if (productCount != -1 && offer.Products.Count != productCount) continue;
                foreach (var product in offer.Products)
                {
                    if (furniIds != null && !furniIds.Contains(product.FurniId))
                    {
                        match = false;
                        break;
                    }
                }

                if (match)
                    yield return offer;
            }
        }
    }
}