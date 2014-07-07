﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ixts.Ausbildung.Geometry
{
    public class Point
    {
        protected double x;
        protected double y;
        public Point(double x,double y)
        {
            this.x = x;
            this.y = y;
        }

        public double X()
        {
            return x;
        }

        public double Y()
        {
            return y;
        }

        public double Distance(Point NPoint)
        {
            double disX = (NPoint.x - this.x)*(NPoint.x - this.x);
            double disY = (NPoint.y - this.y)*(NPoint.y - this.y);
            double distance = Math.Sqrt(disX + disY);
            return distance;
        }

    }
}
