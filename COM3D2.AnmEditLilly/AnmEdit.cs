using AnmCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace COM3D2.AnmEditLilly
{
    public class AnmEdit
    {

        public static void AnmOpen(AnmFile anmFile, StringBuilder stringBuilder)
        {
            foreach (AnmBoneEntry anmBoneEntry in anmFile)
            {
                //stringBuilder.Append("boneId:");
                //stringBuilder.AppendLine(anmBoneEntry.boneId.ToString());
                //stringBuilder.Append("boneName:");
                //stringBuilder.AppendLine(anmBoneEntry.boneName);

                foreach (AnmFrameList anmFrameList in anmBoneEntry)
                {
                    //stringBuilder.Append("type:");
                    //stringBuilder.AppendLine(anmFrameList.type.ToString());

                    foreach (AnmFrame anmFrame in anmFrameList)
                    {
                        stringBuilder.Append(anmBoneEntry.boneId.ToString());
                        stringBuilder.Append("\t");
                        stringBuilder.Append(anmBoneEntry.boneName);
                        stringBuilder.Append("\t");
                        //stringBuilder.Append(anmFrameList.type.ToString());
                        //stringBuilder.Append("\t");
                        stringBuilder.Append(DmpPmd.types[(int)(anmFrameList.type - 100)]);
                        stringBuilder.Append("\t");
                        stringBuilder.Append(anmFrame.time.ToString("F4").PadLeft(4));
                        stringBuilder.Append("\t");
                        stringBuilder.Append(anmFrame.value.ToString("F9").PadLeft(16));
                        stringBuilder.Append("\t");
                        stringBuilder.Append(anmFrame.tan1.ToString("F9").PadLeft(16));
                        stringBuilder.Append("\t");
                        stringBuilder.Append(anmFrame.tan2.ToString("F9").PadLeft(16));
                        stringBuilder.AppendLine();
                    }
                }
            }
        }

        
        public static void AnmOpen(AnmFileLilly anmFile, StringBuilder stringBuilder)
        {
            //foreach (AnmBoneEntryLilly anmBoneEntry in anmFile.Values)
            foreach (var anmBoneEntry in anmFile)
            {
                foreach (var anmFrameList in anmBoneEntry.Value)
                {
                    // 시간별
                    foreach (var anmFrame2 in anmFrameList.Value)
                    {
                        var anmFrame = anmFrame2.Value;

                    stringBuilder.Append(anmBoneEntry.Key);
                    stringBuilder.Append("\t");

                        stringBuilder.Append(DmpPmd.types[(int)(anmFrameList.Key - 100)]);
                        stringBuilder.Append("\t");
                        stringBuilder.Append(anmFrame.time.ToString("F4").PadLeft(4));
                        stringBuilder.Append("\t");
                        stringBuilder.Append(anmFrame.value.ToString("F9").PadLeft(16));
                        stringBuilder.Append("\t");
                        stringBuilder.Append(anmFrame.tan1.ToString("F9").PadLeft(16));
                        stringBuilder.Append("\t");
                        stringBuilder.Append(anmFrame.tan2.ToString("F9").PadLeft(16));
                    
                        stringBuilder.AppendLine();
                    }
                    
                }
            }
        }

        internal static void Tan1Edit(AnmFile anmFile, float value)
        {
            foreach (AnmBoneEntry anmBoneEntry in anmFile)
            {
                foreach (AnmFrameList anmFrameList in anmBoneEntry)
                {
                    foreach (AnmFrame anmFrame in anmFrameList)
                    {
                        anmFrame.tan1 = value;
                    }
                }
            }
        }

        internal static void Tan2Edit(AnmFile anmFile, float value)
        {
            foreach (AnmBoneEntry anmBoneEntry in anmFile)
            {
                foreach (AnmFrameList anmFrameList in anmBoneEntry)
                {
                    foreach (AnmFrame anmFrame in anmFrameList)
                    {
                        anmFrame.tan2 = value;
                    }
                }
            }
        }

        internal static void TimeEdit(AnmFile anmFile, float value)
        {
            foreach (AnmBoneEntry anmBoneEntry in anmFile)
            {
                foreach (AnmFrameList anmFrameList in anmBoneEntry)
                {
                    foreach (AnmFrame anmFrame in anmFrameList)
                    {
                        anmFrame.time = value;
                    }
                }
            }
        }
    }

}
