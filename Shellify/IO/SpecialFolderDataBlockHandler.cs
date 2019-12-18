/* Shellify Copyright (c) 2010-2019 Sebastien Lebreton

Permission is hereby granted, free of charge, to any person obtaining
a copy of this software and associated documentation files (the
"Software"), to deal in the Software without restriction, including
without limitation the rights to use, copy, modify, merge, publish,
distribute, sublicense, and/or sell copies of the Software, and to
permit persons to whom the Software is furnished to do so, subject to
the following conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE. */

using Shellify.ExtraData;
using System.Runtime.InteropServices;
using System;

namespace Shellify.IO
{
	public class SpecialFolderDataBlockHandler : BaseFolderIDDataBlockHandler<SpecialFolderDataBlock>
	{
		private const int ExactBlockSize = 0x10;

		public override int ComputedSize => base.ComputedSize + Marshal.SizeOf(typeof(int));

		public SpecialFolderDataBlockHandler(SpecialFolderDataBlock item, ShellLinkFile context)
			: base(item, context)
		{
		}

		protected override void ReadID(System.IO.BinaryReader reader)
		{
			FormatChecker.CheckExpression(() => BlockSize == ExactBlockSize);
			Item.SpecialFolder = (Environment.SpecialFolder)reader.ReadInt32();
		}

		protected override void WriteID(System.IO.BinaryWriter writer)
		{
			FormatChecker.CheckExpression(() => BlockSize == ExactBlockSize);
			writer.Write((int)Item.SpecialFolder);
		}
	}
}