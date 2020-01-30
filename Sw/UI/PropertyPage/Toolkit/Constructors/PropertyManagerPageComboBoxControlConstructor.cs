﻿//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://github.com/xarial/xcad-solidworks/blob/master/LICENSE
//*********************************************************************

using Xarial.XCad.Sw.UI.PropertyPage.Toolkit.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolidWorks.Interop.swconst;
using SolidWorks.Interop.sldworks;
using System.ComponentModel;
using Xarial.XCad.Utils.PageBuilder.Attributes;
using Xarial.XCad.Utils.PageBuilder.Core;
using Xarial.XCad.Sw.Utils;
using Xarial.XCad.Utils.PageBuilder.Base;
using Xarial.XCad.Utils.Reflection;
using Xarial.XCad.UI.PropertyPage.Attributes;

namespace Xarial.XCad.Sw.UI.PropertyPage.Toolkit.Constructors
{
    [DefaultType(typeof(SpecialTypes.EnumType))]
    internal class PropertyManagerPageComboBoxControlConstructor
        : PropertyManagerPageBaseControlConstructor<PropertyManagerPageComboBoxControl, IPropertyManagerPageCombobox>
    {
        public PropertyManagerPageComboBoxControlConstructor(ISldWorks app, IconsConverter iconsConv) 
            : base(app, swPropertyManagerPageControlType_e.swControlType_Combobox, iconsConv)
        {
        }

        protected override PropertyManagerPageComboBoxControl CreateControl(
            IPropertyManagerPageCombobox swCtrl, IAttributeSet atts, PropertyManagerPageHandlerEx handler, short height)
        {
            var items = EnumExtension.GetEnumFields(atts.BoundType);

            swCtrl.AddItems(items.Values.ToArray());

            if (height != -1)
            {
                swCtrl.Height = height;
            }

            if (atts.Has<ComboBoxOptionsAttribute>())
            {
                var style = atts.Get<ComboBoxOptionsAttribute>();

                if (style.Style != 0)
                {
                    swCtrl.Style = (int)style.Style;
                }
            }

            return new PropertyManagerPageComboBoxControl(atts.Id, atts.Tag, swCtrl, items.Keys.ToList().AsReadOnly(), handler);
        }
    }
}