using System;
using System.Drawing;


namespace test_automation_2023
{
	public class ImageToCompare
	{
		public string PathToImage;
		int Height;
		int Width;
		List<int> colors;


		public List<int> GetImageDimensions(Bitmap img)
		{
			Bitmap newImg = img;
			List<int> dimensions = new List<int>();

			var bounds = img.GetBounds;
			Console.WriteLine(bounds);

			return dimensions;
		}

		public void GetImageColors(Bitmap img)
		{
			Bitmap newImg = img;
			
			
		}




	}
}

