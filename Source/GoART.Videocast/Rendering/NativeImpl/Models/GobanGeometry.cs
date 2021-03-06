﻿using System;
using System.Collections.Generic;
using System.Drawing;

namespace IGOEnchi.Videocast.Rendering.NativeImpl.Models
{
    /// <summary>
    ///     Compute coordinates of elements
    /// </summary>
    public class GobanGeometry
    {
        public static GobanGeometry TumblrResolution = new GobanGeometry(500, 19);
        public static GobanGeometry DebugResolution = new GobanGeometry(320, 19);
        public static GobanGeometry HighResolution = new GobanGeometry(1080, 19);
        public static GobanGeometry UltraHighResolution = new GobanGeometry(2160, 19);

        public readonly float focusStrokePx;
        private readonly int gridsize;
        private readonly float gridStepPx;
        private readonly float gridWidthPx;
        
        private readonly float marginLeftPx;

        private readonly float marginTopPx;
        public readonly float stoneSizePx;
        public readonly float strokePx;
        public readonly int widthPx;
        public readonly int heightPx;

        /// <summary>
        /// </summary>
        /// <param name="resolutionPx">goban size (width & height)</param>
        /// <param name="gridsize">grid of goban (ex 19x19)</param>
        public GobanGeometry(int resolutionPx, int gridsize)
        {
            this.gridsize = gridsize;
            this.widthPx = resolutionPx;
            this.heightPx = resolutionPx;
            
            strokePx = Math.Max(resolutionPx / 480, 1);
            gridStepPx = (float)resolutionPx/(this.gridsize+1);
            gridWidthPx = gridStepPx*(this.gridsize - 1);
            stoneSizePx = (int) (gridStepPx*0.9);
            focusStrokePx = stoneSizePx/6;
            marginTopPx = gridStepPx;
            marginLeftPx = gridStepPx;
        }

        public RectangleF GobanRect => new RectangleF(marginLeftPx - stoneSizePx / 2, marginTopPx - stoneSizePx / 2, gridsize * gridStepPx+stoneSizePx, gridsize * gridStepPx + stoneSizePx);

        public IEnumerable<RectangleF> Lines()
        {
            for (byte y = 0; y < gridsize; y++)
            {
                yield return new RectangleF(
                    marginLeftPx,
                    marginTopPx + y*gridStepPx,
                    gridWidthPx, 0
                    );
            }

            for (byte x = 0; x < gridsize; x++)
            {
                yield return new RectangleF(
                    marginLeftPx + x*gridStepPx,
                    marginTopPx,
                    0, gridWidthPx
                    );
            }
        }

        public PointF Intersection(int x, int y)
        {
            return new PointF(marginLeftPx + x*gridStepPx, marginTopPx + y*gridStepPx);
        }

        public PointF LeftTopCorner(int x, int y)
        {
            var intesection = Intersection(x, y);
            return new PointF(intesection.X - gridStepPx / 2, intesection.Y - gridStepPx / 2);
        }

        public PointF RightBottomCorner(int x, int y)
        {
            var intesection = Intersection(x, y);
            return new PointF(intesection.X - gridStepPx/ 2+ gridStepPx, intesection.Y - gridStepPx/ 2+ gridStepPx);
        }

        public PointF LeftBottomCorner(int x, int y)
        {
            var intesection = Intersection(x, y);
            return new PointF(intesection.X - gridStepPx / 2, intesection.Y - gridStepPx / 2 + gridStepPx);
        }

        public PointF RightTopCorner(int x, int y)
        {
            var intesection = Intersection(x, y);
            return new PointF(intesection.X - gridStepPx / 2 + gridStepPx, intesection.Y - gridStepPx / 2 );
        }
        public RectangleF AeraBound(int x, int y)
        {
            var intesection = Intersection(x, y);

            return new RectangleF(intesection.X - gridStepPx / 2, intesection.Y - gridStepPx / 2, gridStepPx, gridStepPx);
        }

        public RectangleF StoneBound(int x, int y)
        {
            var intesection = Intersection(x, y);

            return new RectangleF(intesection.X - stoneSizePx / 2, intesection.Y - stoneSizePx/2, stoneSizePx, stoneSizePx);
        }

        public RectangleF FocusBound(int x, int y)
        {
            var intesection = Intersection(x, y);
            return new RectangleF(intesection.X - stoneSizePx/4, intesection.Y - stoneSizePx/4, stoneSizePx/2,
                stoneSizePx/2);
        }
    }
}