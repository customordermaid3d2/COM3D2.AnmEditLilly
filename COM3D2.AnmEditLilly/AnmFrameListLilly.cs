using AnmCommon;
using System.IO;
using System.Collections.Generic;

namespace COM3D2.AnmEditLilly
{
	/// <summary>
	/// time
	/// AnmFrame
	/// </summary>
	public class AnmFrameListLilly : Dictionary<float,AnmFrame>
	{
		public AnmFrameListLilly()
		{
		}

		public AnmFrameListLilly(byte type)
		{
			this.type = type;
		}

		public AnmFrameListLilly(AnmFrameListLilly fl)
		{
			this.type = fl.type;
			foreach (AnmFrame f in fl.Values)
			{
				var af = new AnmFrame(f);
				base.Add(af.time, af);
			}
		}

		public AnmFrameListLilly(BinaryReader r)
		{
			this.read(r, true);
		}

		public void read(BinaryReader r, bool recursiveq = true)
		{
			this.type = r.ReadByte();
			int num = r.ReadInt32();
			if (recursiveq)
			{
				for (int i = 0; i < num; i++)
				{
					var af=new AnmFrame(r);
					base.Add(af.time,af);
				}
			}
		}

		public void write(BinaryWriter w, bool recursiveq = true)
		{
			w.Write(this.type);
			w.Write(base.Count);
			if (recursiveq)
			{
				foreach (AnmFrame anmFrame in this.Values)
				{
					anmFrame.write(w);
				}
			}
		}

		/*
		public void inOrder()
		{
			this.OrderBy(x=>x.key).ToDictionary(x => x.Key, x => x.Value);
			//base.Sort((AnmFrame a, AnmFrame b) => Math.Sign(a.time - b.time));
		}
		*/

		public byte type;
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

		internal int <inOrder>b__7_0(AnmFrame a, AnmFrame b)
		{
			return Math.Sign(a.time - b.time);
		}

		public static readonly AnmFrameList.<>c<>9 = new AnmFrameList.<>c();

		public static Comparison<AnmFrame> <>9__7_0;
		}
		*/
}
}