namespace ExtractBytes
{
	using System;
	using System.IO;
	using System.Linq;
	

	public class ExtractBytes
	{
		static void Main(string[] args)
		{
			const string binaryFilePath = @"..\..\..\Files\example.png";
			const string bytesFilePath = @"..\..\..\Files\bytes.txt";
			const string outputPath = @"..\..\..\Files\output.bin";

			ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
		}

		public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
		{
			byte[] bytes = File.ReadAllText(bytesFilePath).Split("\n", StringSplitOptions.RemoveEmptyEntries).Select(byte.Parse).ToArray();

			{
				byte[] text = File.ReadAllBytes(binaryFilePath);

				using (FileStream writer = new FileStream(outputPath, FileMode.OpenOrCreate))
				{
					foreach (byte item in text)
					{
						if (bytes.Contains(item))
						{
							writer.WriteByte(item);
						}
					}
				}
			}
		}
	}
}
