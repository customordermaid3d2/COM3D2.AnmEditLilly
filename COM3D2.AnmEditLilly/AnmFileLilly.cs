using AnmCommon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace COM3D2.AnmEditLilly
{
	/// <summary>
	/// boneName
	/// AnmBoneEntry
	/// </summary>
	public class AnmFileLilly : Dictionary<string,AnmBoneEntryLilly>
	{
		public AnmFileLilly()
		{
		}

		public AnmFileLilly(AnmFileLilly af)
		{
			this.format = af.format;
			this.muneLR[0] = af.muneLR[0];
			this.muneLR[1] = af.muneLR[1];
			foreach (AnmBoneEntryLilly be in af.Values)
			{
				AnmBoneEntryLilly  ab= new AnmBoneEntryLilly(be);
				base.Add(ab.boneName,ab);
			}
		}

		public AnmFileLilly(string filename)
		{
			this.read(filename);
		}

		public static AnmFileLilly fromFile(string filename)
		{
			AnmFileLilly result = null;
			try
			{
				result = new AnmFileLilly(filename);
			}
			catch
			{
			}
			return result;
		}

		private void read(string filename)
		{
			using (BinaryReader binaryReader = new BinaryReader(File.OpenRead(filename)))
			{
				byte[] value = binaryReader.ReadBytes(15);
				this.format = BitConverter.ToInt32(value, 11);
				while (binaryReader.Read() == 1)
				{
					AnmBoneEntryLilly ab=new AnmBoneEntryLilly(binaryReader);
					base.Add(ab.boneName, ab);
				}
				if (this.format == 1001)
				{
					if (binaryReader.PeekChar() >= 0)
					{
						this.muneLR[0] = binaryReader.ReadByte();
					}
					if (binaryReader.PeekChar() >= 0)
					{
						this.muneLR[1] = binaryReader.ReadByte();
					}
				}
			}
		}

		public bool write(string filename, bool[] wblist = null, bool white = false)
		{
			byte[] array = new byte[2];
			try
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(File.Create(filename)))
				{
					binaryWriter.Write(AnmFileLilly.anmHeader);
					binaryWriter.Write(this.format);
					bool[] array2 = wblist;
					if (array2 == null)
					{
						array2 = new bool[AnmBoneName.boneGroup.Length];
					}
					foreach (AnmBoneEntryLilly anmBoneEntry in this.Values)
					{
						if (anmBoneEntry.Count > 0)
						{
							if (anmBoneEntry.boneId == 16)
							{
								array[0] = 1;
							}
							if (anmBoneEntry.boneId == 22)
							{
								array[1] = 1;
							}
						}
						anmBoneEntry.write(binaryWriter, array2[anmBoneEntry.boneId] == white);
					}
					binaryWriter.Write(0);
					if (this.format == 1001)
					{
						byte[] array3 = new byte[]
						{
							this.muneLR[0],
							this.muneLR[1]
						};
						if (wblist != null)
						{
							if (array2[16] != white || array[0] == 0)
							{
								array3[0] = 0;
							}
							if (array2[22] != white || array[1] == 0)
							{
								array3[1] = 0;
							}
						}
						binaryWriter.Write(array3);
					}
				}
			}
			catch
			{
				return false;
			}
			return true;
		}
		/*
		public static bool joinAnm(List<AnmFile> files, string filename)
		{
			bool flag = false;
			Dictionary<string, AnmBoneEntry> dictionary = new Dictionary<string, AnmBoneEntry>();
			foreach (AnmFile anmFile in files)
			{
				foreach (AnmBoneEntry anmBoneEntry in anmFile)
				{
					if (anmFile.format > 1001 && (anmBoneEntry.boneId == 16 || anmBoneEntry.boneId == 22) && anmBoneEntry.boneName.Contains("Bip01") && anmBoneEntry.Count > 0)
					{
						flag = true;
					}
					string sortkey = anmBoneEntry.getSortkey();
					if (dictionary.ContainsKey(sortkey))
					{
						AnmFile.mergeBone(dictionary[sortkey], anmBoneEntry);
					}
					else
					{
						anmBoneEntry.inOrder(true);
						dictionary.Add(sortkey, anmBoneEntry);
					}
				}
			}
			List<string> list = new List<string>(dictionary.Keys);
			list.Sort();
			AnmFile anmFile2 = new AnmFile();
			anmFile2.format = 1001;
			if (flag)
			{
				anmFile2.muneLR[0] = (anmFile2.muneLR[1] = 1);
			}
			else
			{
				foreach (AnmFile anmFile3 in files)
				{
					if (anmFile3.format == 1001)
					{
						byte[] array = anmFile2.muneLR;
						int num = 0;
						array[num] |= anmFile3.muneLR[0];
						byte[] array2 = anmFile2.muneLR;
						int num2 = 1;
						array2[num2] |= anmFile3.muneLR[1];
					}
				}
			}
			foreach (string key in list)
			{
				anmFile2.Add(dictionary[key]);
			}
			return anmFile2.write(filename, null, false);
		}

		public static void mergeBone(AnmBoneEntry to, AnmBoneEntry from)
		{
			foreach (AnmFrameList ml in from)
			{
				AnmFile.mergeFrameList(to, ml);
			}
		}

		public static void mergeFrameList(AnmBoneEntry bone, AnmFrameList ml)
		{
			for (int i = 0; i < bone.Count; i++)
			{
				int num = (int)(bone[i].type - ml.type);
				if (num >= 0)
				{
					if (num == 0)
					{
						foreach (AnmFrame f in ml)
						{
							AnmFile.mergeFrame(bone[i], f);
						}
						return;
					}
					if (num > 0)
					{
						ml.inOrder();
						bone.Insert(i, ml);
						return;
					}
				}
			}
			ml.inOrder();
			bone.Add(ml);
		}

		public static void mergeFrame(AnmFrameList fl, AnmFrame f)
		{
			for (int i = 0; i < fl.Count; i++)
			{
				float num = fl[i].time - f.time;
				if (num >= 0f)
				{
					if (num == 0f)
					{
						fl[i] = f;
						return;
					}
					if (num > 0f)
					{
						fl.Insert(i, f);
						return;
					}
				}
			}
			fl.Add(f);
		}

		public SortedSet<int> getTimeSet()
		{
			SortedSet<int> sortedSet = new SortedSet<int>();
			foreach (AnmBoneEntry anmBoneEntry in this)
			{
				foreach (AnmFrameList anmFrameList in anmBoneEntry)
				{
					foreach (AnmFrame anmFrame in anmFrameList)
					{
						sortedSet.Add((int)(anmFrame.time * 1000f));
					}
				}
			}
			return sortedSet;
		}

		public SortedSet<float> getFloatTimeSet()
		{
			SortedSet<float> sortedSet = new SortedSet<float>();
			foreach (AnmBoneEntry anmBoneEntry in this)
			{
				foreach (AnmFrameList anmFrameList in anmBoneEntry)
				{
					foreach (AnmFrame anmFrame in anmFrameList)
					{
						sortedSet.Add(anmFrame.time);
					}
				}
			}
			return sortedSet;
		}

		public int getGender()
		{
			foreach (AnmBoneEntry anmBoneEntry in this)
			{
				if (anmBoneEntry.boneName.StartsWith("ManBip", StringComparison.Ordinal))
				{
					return 1;
				}
				if (anmBoneEntry.boneName.StartsWith("Bip01", StringComparison.Ordinal))
				{
					return 0;
				}
			}
			return -1;
		}

		// Note: this type is marked as 'beforefieldinit'.
		static AnmFile()
		{
		}
		*/
		public int format = 1001;

		public byte[] muneLR = new byte[2];

		private static readonly byte[] anmHeader = new byte[]
		{
			10,
			67,
			77,
			51,
			68,
			50,
			95,
			65,
			78,
			73,
			77
		};
	}
}
