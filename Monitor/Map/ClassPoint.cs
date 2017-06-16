using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AxMapWinGIS;
using MapWinGIS;

namespace Monitor.Map
{
	public class ClassPoint
	{
		public double x;
		public double y;
		public string str;
	}

	public class ClassLine
	{
		public double startX;
		public double startY;
		public double endX;
		public double endY;
		public string str;

	}

	public struct PointSet
	{
		public string categroyName;
		public tkDefaultPointSymbol shape;
		public  tkMapColor color;
		public  float size;

		public PointSet(string categroyName, tkDefaultPointSymbol shape, tkMapColor color, float size)
		{
			this.categroyName = categroyName;
			this.shape = shape;
			this.color = color;
			this.size = size;

		}

	}

	public struct LineSet
	{
		public tkMapColor color;
		public float Width;
		public tkDashStyle style;
		
		public LineSet(tkMapColor color, float Width, tkDashStyle style)
		{
			this.color = color;
			this.Width = Width;
			this.style = style;
		}    
	}
}
