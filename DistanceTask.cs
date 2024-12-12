using System;

namespace DistanceTask
{
    public static class DistanceTask
    {
        public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
        {
            double DistanceSquared(double x1, double y1, double x2, double y2) =>
                (x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2);

            double CrossProductLength(double ax, double ay, double bx, double by, double cx, double cy) =>
                Math.Abs((bx - ax) * (cy - ay) - (by - ay) * (cx - ax));

            if (ax == bx && ay == by)
                return Math.Sqrt(DistanceSquared(ax, ay, x, y));

            double vectorABx = bx - ax, vectorABy = by - ay;
            double vectorAPx = x - ax, vectorAPy = y - ay;
            double vectorBPx = x - bx, vectorBPy = y - by;

            double dotABAP = vectorABx * vectorAPx + vectorABy * vectorAPy;
            double dotABBP = vectorABx * vectorBPx + vectorABy * vectorBPy;

            if (dotABAP < 0)
                return Math.Sqrt(DistanceSquared(ax, ay, x, y));
            if (dotABBP > 0)
                return Math.Sqrt(DistanceSquared(bx, by, x, y));

            return CrossProductLength(ax, ay, bx, by, x, y) / Math.Sqrt(DistanceSquared(ax, ay, bx, by));
        }
    }
}
