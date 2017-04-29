//
// Based on http://www.codeproject.com/KB/grid/custCheckedListBox.aspx from Ricardo Cuello
// Adapted by stefh to fit into 2005
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Windows.Forms;

namespace MyDbUtils.UserControls
{
    /// <summary>
    /// (eraghi)
    /// Custom CheckedListBox with binding facilities (Value property)
    /// </summary>
    [ToolboxBitmap(typeof(CheckedListBox))]
    public class MyCheckedListBox : CheckedListBox
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public MyCheckedListBox()
        {
            CheckOnClick = true;
        }

        /// <summary>
        ///    Gets or sets the property to display for this CustomControls.CheckedListBox.
        ///
        /// Returns:
        ///     A System.String specifying the name of an object property that is contained
        ///     in the collection specified by the CustomControls.CheckedListBox.DataSource
        ///     property. The default is an empty string ("").
        /// </summary>
        [DefaultValue("")]
        [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [Browsable(true)]
        public new string DisplayMember
        {
            get
            {
                return base.DisplayMember;
            }
            set
            {
                base.DisplayMember = value;

            }
        }

        /// <summary>
        ///    Gets or sets the property to get the values for this CustomControls.CheckedListBox.
        ///
        /// Returns:
        ///     A System.String specifying the name of an object property that is contained
        ///     in the collection specified by the CustomControls.CheckedListBox.DataSource
        ///     property. The default is an empty string ("").
        /// </summary>
        [DefaultValue("")]
        [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [Browsable(true)]
        public new string ValueMember
        {
            get
            {
                return base.ValueMember;
            }
            set
            {
                base.ValueMember = value;

            }
        }


        /// <summary>
        /// Gets or sets the data source for this CustomControls.CheckedListBox.
        /// Returns:
        ///    An object that implements the System.Collections.IList or System.ComponentModel.IListSource
        ///    interfaces, such as a System.Data.DataSet or an System.Array. The default
        ///    is null.
        ///
        ///Exceptions:
        ///  System.ArgumentException:
        ///    The assigned value does not implement the System.Collections.IList or System.ComponentModel.IListSource
        ///    interfaces.
        /// </summary>
        [DefaultValue("")]
        [AttributeProvider(typeof(IListSource))]
        [RefreshProperties(RefreshProperties.All)]
        [Browsable(true)]
        public new object DataSource
        {
            get
            {
                return base.DataSource;
            }
            set
            {
                base.DataSource = value;

            }
        }

        /// <summary>
        /// Gets and sets an integer array of the values based on checked items values ID
        /// </summary>
        [Bindable(true), Browsable(true)]
        public List<int> ValueList
        {
            get
            {
                // Gets checked items id values in a list
                List<int> retArray = new List<int>();
                PropertyDescriptorCollection propList = DataManager.GetItemProperties();
                var prop = propList.Find(ValueMember, false);
                if (prop != null)
                {
                    for (int i = 0; i < Items.Count; i++)
                    {
                        if (GetItemChecked(i))
                        {
                            var checkedItem = DataManager.List[i];
                            retArray.Add(Convert.ToInt32(prop.GetValue(checkedItem).ToString()));
                        }
                    }
                }
                return retArray;
            }

            set
            {
                // Sets checked items base on id values in a list
                List<int> myList = value;
                PropertyDescriptorCollection propList = DataManager.GetItemProperties();
                var prop = propList.Find(ValueMember, false);
                bool found = false;

                if (prop != null)
                {
                    for (int i = 0; i < Items.Count; i++)
                    {
                        var checkedItem = DataManager.List[i];
                        var intValItem = Convert.ToInt32(prop.GetValue(checkedItem).ToString());

                        if (myList.Any(c => c == intValItem))
                        {
                            found = true;
                        }

                        SetItemCheckState(i, found ? CheckState.Checked : CheckState.Unchecked);
                    }
                }
            }
        }
    }
}