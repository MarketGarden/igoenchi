﻿using System;
using IGOEnchi.GoGameLogic;

namespace IGOPhoenix.Analysis.SpeechOfStones.Ranks.Models
{


    public class LinkModel
    {
        public readonly Stone Stone;

        /// <summary>
        /// Hortogonal Distance( follow edges of the grid)
        /// </summary>
        public readonly byte Distance;

        public LinkModel(Stone stone, byte distance)
        {
            Stone = stone;
            Distance = distance;
        }

        public static LinkModel LinkFactory(ICoords stone, ICoords coords, bool isBlack)
        {
            return new LinkModel(
                stone : new Stone(coords.X, coords.Y, isBlack),
                distance : (byte)(Math.Abs(stone.X - coords.X) + Math.Abs(stone.Y - coords.Y))
                );
        }
    }
}
