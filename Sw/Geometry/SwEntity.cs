﻿//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://github.com/xarial/xcad/blob/master/LICENSE
//*********************************************************************

using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Text;
using Xarial.XCad.Geometry;

namespace Xarial.XCad.Sw.Geometry
{
    public abstract class SwEntity : SwSelObject, IXEntity
    {
        public IEntity Entity { get; }

        public abstract IXBody Body { get; }

        internal SwEntity(IEntity entity) : base(null, entity)
        {
            Entity = entity;
        }

        public override void Select(bool append)
        {
            if (!Entity.Select4(append, null)) 
            {
                throw new Exception("Failed to select entity");
            }
        }
    }
}
