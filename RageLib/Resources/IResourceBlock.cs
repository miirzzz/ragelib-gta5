﻿/*
    Copyright(c) 2015 Neodymium

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

using System;

namespace RageLib.Resources
{
    /// <summary>
    /// Represents a data block in a resource file.
    /// </summary>
    public interface IResourceBlock
    {
        /// <summary>
        /// Gets or sets the position of the data block.
        /// </summary>
        long Position { get; set; }

        /// <summary>
        /// Gets the length of the data block.
        /// </summary>
        long Length { get; }

        /// <summary>
        /// Reads the data block.
        /// </summary>
        void Read(ResourceDataReader reader, params object[] parameters);

        /// <summary>
        /// Writes the data block.
        /// </summary>
        void Write(ResourceDataWriter writer, params object[] parameters);
    }

    /// <summary>
    /// Represents a data block of the system segement in a resource file.
    /// </summary>
    public interface IResourceSystemBlock : IResourceBlock
    {
        /// <summary>
        /// Returns a list of data blocks that are part of this block.
        /// </summary>
        Tuple<long, IResourceBlock>[] GetParts();

        /// <summary>
        /// Returns a list of data blocks that are referenced by this block.
        /// </summary>
        IResourceBlock[] GetReferences();
    }

    public interface IResourceXXSystemBlock : IResourceSystemBlock
    {
        IResourceSystemBlock GetType(ResourceDataReader reader, params object[] parameters);
    }

    /// <summary>
    /// Represents a data block of the graphics segmenet in a resource file.
    /// </summary>
    public interface IResourceGraphicsBlock : IResourceBlock
    { }
}