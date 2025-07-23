/*
    Copyright(c) 2017 Neodymium

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in
    all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    THE SOFTWARE.
*/

using RageLib.Resources.Common;
using System;

namespace RageLib.Resources.GTA5.PC.Particles
{
    public class Unknown_P_004 : ResourceSystemBlock
    {
        public override long Length => 0x40;

        // structure data
        public ResourceSimpleList64<Unknown_P_002> Unknown_0h;
        public ResourceSimpleList64<Unknown_P_003> Unknown_10h;
        public uint Unknown_20h; // 0x00000001
        public uint Unknown_24h; // 0x00000000
        public ResourceSimpleList64<Unknown_P_007> Unknown_28h;
        public uint Unknown_38h; // 0x00000000
        public uint Unknown_3Ch; // 0x00000000

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            // read structure data
            this.Unknown_0h = reader.ReadBlock<ResourceSimpleList64<Unknown_P_002>>();
            this.Unknown_10h = reader.ReadBlock<ResourceSimpleList64<Unknown_P_003>>();
            this.Unknown_20h = reader.ReadUInt32();
            this.Unknown_24h = reader.ReadUInt32();
            this.Unknown_28h = reader.ReadBlock<ResourceSimpleList64<Unknown_P_007>>();
            this.Unknown_38h = reader.ReadUInt32();
            this.Unknown_3Ch = reader.ReadUInt32();
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // write structure data
            writer.WriteBlock(this.Unknown_0h);
            writer.WriteBlock(this.Unknown_10h);
            writer.Write(this.Unknown_20h);
            writer.Write(this.Unknown_24h);
            writer.WriteBlock(this.Unknown_28h);
            writer.Write(this.Unknown_38h);
            writer.Write(this.Unknown_3Ch);
        }

        public override Tuple<long, IResourceBlock>[] GetParts()
        {
            return new Tuple<long, IResourceBlock>[] {
                new Tuple<long, IResourceBlock>(0, Unknown_0h),
                new Tuple<long, IResourceBlock>(0x10, Unknown_10h),
                new Tuple<long, IResourceBlock>(0x28, Unknown_28h)
            };
        }
    }
}
