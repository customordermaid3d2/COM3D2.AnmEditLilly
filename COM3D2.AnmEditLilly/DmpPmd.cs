using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using AnmCommon;

namespace COM3D2.AnmEditLilly
{
	public static class DmpPmd
	{
		/// <summary>
		/// 불러오기
		/// </summary>
		/// <param name="fname"></param>
		/// <param name="tw"></param>
		/// <returns></returns>

		public static int Dmp(string fname, TextWriter tw)
		{
			AnmFile anmFile = AnmFile.fromFile(fname);
			if (anmFile == null)
			{
				DmpPmd.error = "ファイルの読見込みに失敗しました";
				return -1;
			}
			SortedSet<int> timeSet = anmFile.getTimeSet();
			tw.Write("Filename:");
			tw.WriteLine(fname);
			tw.Write("Format:");
			tw.Write(anmFile.format);
			if (anmFile.format == 1001)
			{
				tw.Write("  MuneL有効:");
				tw.Write((anmFile.muneLR[0] == 0) ? "x" : "o");
				tw.Write("  MuneR有効:");
				tw.Write((anmFile.muneLR[1] == 0) ? "x" : "o");
			}
			tw.WriteLine("");
			foreach (AnmBoneEntry anmBoneEntry in anmFile)
			{
				tw.Write("[");
				tw.Write(anmBoneEntry.boneName);
				tw.WriteLine("]");
				foreach (int num in timeSet)
				{
					bool flag = false;
					foreach (AnmFrameList anmFrameList in anmBoneEntry)
					{
						foreach (AnmFrame anmFrame in anmFrameList)
						{
							if ((int)(anmFrame.time * 1000f) == num)
							{
								if (!flag)
								{
									tw.Write(num.ToString("00000000"));
									flag = true;
								}
								else
								{
									tw.Write("        ");
								}
								tw.Write("    ");
								tw.Write(DmpPmd.types[(int)(anmFrameList.type - 100)]);
								tw.Write(anmFrame.value.ToString("F9").PadLeft(16));
								tw.Write(anmFrame.tan1.ToString("F9").PadLeft(16));
								tw.WriteLine(anmFrame.tan2.ToString("F9").PadLeft(16));
							}
						}
					}
				}
			}
			return 0;
		}

		/**/

		public static string Dmp(AnmFile anmFile)
		{
			if (anmFile == null)
			{
				return DmpPmd.error = "ファイルの読見込みに失敗しました.파일을 읽을 수 없습니다.";				
			}

			StringBuilder stringBuilder = new StringBuilder();
			StringWriter tw = new StringWriter(stringBuilder);

			SortedSet<int> timeSet = anmFile.getTimeSet();
			tw.Write("Filename:");
			tw.WriteLine("");
			tw.Write("Format:");
			tw.Write(anmFile.format);
			if (anmFile.format == 1001)
			{
				tw.Write("  MuneL有効:");
				tw.Write((anmFile.muneLR[0] == 0) ? "x" : "o");
				tw.Write("  MuneR有効:");
				tw.Write((anmFile.muneLR[1] == 0) ? "x" : "o");
			}
			tw.WriteLine("");
			foreach (AnmBoneEntry anmBoneEntry in anmFile)
			{
				tw.Write("[");
				tw.Write(anmBoneEntry.boneName);
				tw.WriteLine("]");
				foreach (int num in timeSet)
				{
					bool flag = false;
					foreach (AnmFrameList anmFrameList in anmBoneEntry)
					{
						foreach (AnmFrame anmFrame in anmFrameList)
						{
							if ((int)(anmFrame.time * 1000f) == num)
							{
								if (!flag)
								{
									tw.Write(num.ToString("00000000"));
									flag = true;
								}
								else
								{
									tw.Write("        ");
								}
								tw.Write("    ");
								tw.Write(DmpPmd.types[(int)(anmFrameList.type - 100)]);
								tw.Write(anmFrame.value.ToString("F9").PadLeft(16));
								tw.Write(anmFrame.tan1.ToString("F9").PadLeft(16));
								tw.WriteLine(anmFrame.tan2.ToString("F9").PadLeft(16));
							}
						}
					}
				}
			}
			return stringBuilder.ToString();
		}

		private static int type2int(string type)
		{
			for (int i = 0; i < DmpPmd.types.Length; i++)
			{
				if (type == DmpPmd.types[i])
				{
					return 100 + i;
				}
			}
			return -1;
		}

		/// <summary>
		/// 저장하기
		/// </summary>
		/// <param name="text"></param>
		/// <param name="filename"></param>
		/// <returns></returns>
		public static int Pmd(string text, string filename)
		{
			Match match = DmpPmd.reg1.Match(text);
			if (!match.Success)
			{
				DmpPmd.error = "テキストファイルの書式が不正です. 텍스트 파일의 형식이 잘못되었습니다.";
				return -1;
			}
			AnmFile anmFile = new AnmFile();
			anmFile.format = int.Parse(match.Groups[1].Value);
			anmFile.muneLR[0] = ((byte)((match.Groups[2].Success && match.Groups[2].Value == "o") ? 1 : 0));
			anmFile.muneLR[1] = ((byte)((match.Groups[3].Success && match.Groups[3].Value == "o") ? 1 : 0));
			match = DmpPmd.reg2.Match(text, match.Groups[0].Value.Length);
			while (match.Success)
			{
				AnmBoneEntry anmBoneEntry = new AnmBoneEntry(match.Groups["bone"].Value);
				anmFile.Add(anmBoneEntry);
				AnmFrameList[] array = new AnmFrameList[]
				{
					new AnmFrameList(100),
					new AnmFrameList(101),
					new AnmFrameList(102),
					new AnmFrameList(103),
					new AnmFrameList(104),
					new AnmFrameList(105),
					new AnmFrameList(106)
				};
				int num = 0;
				for (int i = 0; i < match.Groups["time"].Captures.Count; i++)
				{
					AnmFrame anmFrame = new AnmFrame();
					string text2 = match.Groups["time"].Captures[i].Value.Trim();
					if (text2 != "")
					{
						num = int.Parse(text2);
					}
					anmFrame.time = (float)num / 1000f;
					anmFrame.value = float.Parse(match.Groups["val"].Captures[i * 3].Value);
					anmFrame.tan1 = float.Parse(match.Groups["val"].Captures[i * 3 + 1].Value);
					anmFrame.tan2 = float.Parse(match.Groups["val"].Captures[i * 3 + 2].Value);
					int num2 = DmpPmd.type2int(match.Groups["type"].Captures[i].Value);
					array[num2 - 100].Add(anmFrame);
				}
				foreach (AnmFrameList anmFrameList in array)
				{
					if (anmFrameList.Count > 0)
					{
						anmBoneEntry.Add(anmFrameList);
					}
				}
				match = match.NextMatch();
			}
			if (!anmFile.write(filename, null, false))
			{
				DmpPmd.error = "anmファイルの書き出しに失敗しました. anm 파일을 내보내지 못했습니다.";
				return -1;
			}
			return 0;
		}


		public static int Pmd2(string text, string filename)
		{
			// (\d+)(?:\s+MuneL有効:([xo])\s+MuneR有効:([xo]))?\r?\n
			Match match = new Regex(@"(\d+)(?:\s+MuneL有効:([xo])\s+MuneR有効:([xo]))?\r?\n", RegexOptions.Compiled | RegexOptions.Singleline).Match(text);

			//Debug.WriteLine("Pmd2 : " + match.Groups[0].Value);
			//Debug.WriteLine("Pmd2 : " + match.Groups[1].Value);
			//Debug.WriteLine("Pmd2 : " + match.Groups[2].Value);
			//Debug.WriteLine("Pmd2 : " + match.Groups[3].Value);

			if (!match.Success)
			{
				DmpPmd.error = "テキストファイルの書式が不正です. 텍스트 파일의 형식이 잘못되었습니다.";
				return -1;
			}

			AnmFileLilly anmFile = new AnmFileLilly();
			anmFile.format = int.Parse(match.Groups[1].Value);
			anmFile.muneLR[0] = ((byte)((match.Groups[2].Success && match.Groups[2].Value == "o") ? 1 : 0));
			anmFile.muneLR[1] = ((byte)((match.Groups[3].Success && match.Groups[3].Value == "o") ? 1 : 0));

			match = new Regex(@"(?<bone>.+?)\t(?<type>.+?)\t(?<time>[-\d\.]+?)(\s+(?<val>[-\d\.]+?)){3}\r?\n"
				, RegexOptions.Compiled | RegexOptions.Singleline)
				.Match(text, match.Groups[0].Value.Length);

			while (match.Success)
			{
				Debug.WriteLine("item : " + match.Groups.Count);
				//for (int i = 0; i < match.Groups.Count; i++)
				//{
				//	Debug.WriteLine("sub , " + i +" : " + match.Groups[i].Value);
				//}
				// Bip01	qx	0.0000	    -0.560985600	     0.000000000	     0.000000000
				for (int i = 0; i < match.Groups["bone"].Captures.Count; i++)
				{
					Debug.WriteLine("sub1 , " + i + " : " + match.Groups["bone"].Captures[i].Value);
				}
				for (int i = 0; i < match.Groups["type"].Captures.Count; i++)
				{
					Debug.WriteLine("sub2 , " + i + " : " + match.Groups["type"].Captures[i].Value);
				}
				for (int i = 0; i < match.Groups["time"].Captures.Count; i++)
				{
					Debug.WriteLine("sub3 , " + i + " : " + match.Groups["time"].Captures[i].Value);
				}
				for (int i = 0; i < match.Groups["val"].Captures.Count; i++)
				{
					Debug.WriteLine("sub4 , " + i + " : " + match.Groups["val"].Captures[i].Value);
				}
				match = match.NextMatch();
			}

			//match = new Regex(@"\G(?<bone>.+?)\r?\n(?:(?<time>\d{8}|\s{8})\s+(?<type>" 
			//	+ string.Join("|", DmpPmd.types) 
			//	+ @")(?:\s+(?<val>[-\d\.]+)){3}\r?\n)*"
			//	, RegexOptions.Compiled | RegexOptions.Singleline)
			//	.Match(text, match.Groups[0].Value.Length);

			return -1;

			while (match.Success)
			{
				AnmBoneEntryLilly anmBoneEntry = new AnmBoneEntryLilly(match.Groups["bone"].Value);
				anmFile.Add(anmBoneEntry.boneName, anmBoneEntry);
				AnmFrameListLilly[] array = new AnmFrameListLilly[]
				{
					new AnmFrameListLilly(100),
					new AnmFrameListLilly(101),
					new AnmFrameListLilly(102),
					new AnmFrameListLilly(103),
					new AnmFrameListLilly(104),
					new AnmFrameListLilly(105),
					new AnmFrameListLilly(106)
				};
				int num = 0;
				for (int i = 0; i < match.Groups["time"].Captures.Count; i++)
				{
					AnmFrame anmFrame = new AnmFrame();
					string text2 = match.Groups["time"].Captures[i].Value.Trim();
					if (text2 != "")
					{
						num = int.Parse(text2);
					}
					anmFrame.time = (float)num / 1000f;
					anmFrame.value = float.Parse(match.Groups["val"].Captures[i * 3].Value);
					anmFrame.tan1 = float.Parse(match.Groups["val"].Captures[i * 3 + 1].Value);
					anmFrame.tan2 = float.Parse(match.Groups["val"].Captures[i * 3 + 2].Value);
					int num2 = DmpPmd.type2int(match.Groups["type"].Captures[i].Value);
					array[num2 - 100].Add(anmFrame.time, anmFrame);
				}
				foreach (AnmFrameListLilly anmFrameList in array)
				{
					if (anmFrameList.Count > 0)
					{
						anmBoneEntry.Add(anmFrameList.type,anmFrameList);
					}
				}
				match = match.NextMatch();
			}
			if (!anmFile.write(filename, null, false))
			{
				DmpPmd.error = "anmファイルの書き出しに失敗しました. anm 파일을 내보내지 못했습니다.";
				return -1;
			}
			return 0;
		}

		// Note: this type is marked as 'beforefieldinit'.
		static DmpPmd()
		{
		}

		public static string error = "";

		public static readonly string[] types = new string[]
		{
			"qx",
			"qy",
			"qz",
			"qw",
			" x",
			" y",
			" z"
		};

		// 이건 반드시 맨 끝에 있어야함. 대체 왜??
		public static Regex reg1 = new Regex("Filename:.+?\\r?\\nFormat:(\\d+)(?:\\s+MuneL有効:([xo])\\s+MuneR有効:([xo]))?\\r?\\n", RegexOptions.Compiled | RegexOptions.Singleline);

		public static Regex reg2 = new Regex("\\G\\[(?<bone>.+?)\\]\\r?\\n(?:(?<time>\\d{8}|\\s{8})\\s+(?<type>" + string.Join("|", DmpPmd.types) + ")(?:\\s+(?<val>[-\\d\\.]+)){3}\\r?\\n)*", RegexOptions.Compiled | RegexOptions.Singleline);
	}


}
