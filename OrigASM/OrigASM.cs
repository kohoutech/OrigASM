﻿/* ----------------------------------------------------------------------------
OrigASM - Origami Assembler
Copyright (C) 2007-2020  George E Greaney

This program is free software; you can redistribute it and/or
modify it under the terms of the GNU General Public License
as published by the Free Software Foundation; either version 2
of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
----------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OrigASM.Parse;
using OrigASM.Assemble;
using Origami.Asm32;
using Origami.Win32;

namespace OrigASM
{
    class OrigASM
    {
        static void Main(string[] args)
        {
            Options options = new Options(args);                    //parse the cmd line args

            //temporary debugging shortcut
            String srcname = args[0];
            String outname = args[1];

            Parser parser = new Parser();
            Assembler assembler = new Assembler();
            List<Instruction> insns = parser.parseFile(srcname);
            Win32Obj objfile = assembler.Assemble(insns);
            objfile.WriteOut(outname);
        }
    }
}