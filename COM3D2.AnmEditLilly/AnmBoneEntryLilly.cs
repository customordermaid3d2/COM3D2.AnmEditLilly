using AnmCommon;
using System.Collections.Generic;
using System.IO;

namespace COM3D2.AnmEditLilly
{
	/// <summary>
	/// type
	/// </summary>
	public class AnmBoneEntryLilly : Dictionary<byte, AnmFrameListLilly>
	{
		public AnmBoneEntryLilly()
		{
		}

		public AnmBoneEntryLilly(string name)
		{
			this.rename(name);
		}

		public AnmBoneEntryLilly(AnmBoneEntryLilly be)
		{
			this.boneName = be.boneName;
			this.boneId = be.boneId;
			foreach (AnmFrameListLilly fl in be.Values)
			{
				AnmFrameListLilly af = new AnmFrameListLilly(fl);
				base.Add(af.type, af);
			}
		}

		public AnmBoneEntryLilly(BinaryReader r)
		{
			this.read(r, true);
		}

		public void rename(string name)
		{
			this.boneName = name;
			this.boneId = AnmBoneName.getBoneId(this.boneName);
		}

		public void read(BinaryReader r, bool recursiveq = true)
		{
			this.rename(r.ReadString());
			if (recursiveq)
			{
				int num;
				while ((num = r.PeekChar()) >= 0 && num != 1 && num >= 100)
				{
					AnmFrameListLilly af= new AnmFrameListLilly(r);
					base.Add(af.type, new AnmFrameListLilly(af));
				}
			}
		}

		public void write(BinaryWriter w, bool recursiveq = true)
		{
			w.Write(1);
			w.Write(this.boneName);
			if (recursiveq)
			{
				foreach (AnmFrameListLilly anmFrameList in this.Values)
				{
					anmFrameList.write(w, true);
				}
			}
		}

		public string getSortkey()
		{
			string[] array = this.boneName.Split(new char[]
			{
				'/'
			});
			string text = array[array.Length - 1];
			return string.Join("", new string[]
			{
				this.boneId.ToString("00"),
				array.Length.ToString("00"),
				text
			});
		}

		/*
		public void inOrder(bool recursiveq = true)
		{
			base.Sort((AnmFrameList a, AnmFrameList b) => (int)(a.type - b.type));
			if (recursiveq)
			{
				foreach (AnmFrameList anmFrameList in this)
				{
					anmFrameList.inOrder();
				}
			}
		}
		*/

		public string boneName = "";

		public int boneId = -1;
		/*
		[CompilerGenerated]
		[Serializable]
		private sealed class <>c
		{
			// Note: this type is marked as 'beforefieldinit'.
			static <>c()
		{
		}

		public <>c()
		{
		}

		internal int <inOrder>b__10_0(AnmFrameList a, AnmFrameList b)
		{
			return (int)(a.type - b.type);
		}

		public static readonly AnmBoneEntry.<>c<>9 = new AnmBoneEntry.<>c();

		public static Comparison<AnmFrameList> <>9__10_0;
		}
	*/
	}
}