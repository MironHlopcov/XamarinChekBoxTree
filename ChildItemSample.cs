using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XamarinChekBoxTree
{
    public class ChildItemSample
    {
        private bool _checked;
        private string name;
        public ChildItemSample()
        {
            _checked = false;
            name = "";
        }
        public ChildItemSample(string name)
        {
            _checked = false;
            this.name = name;
        }
        public bool isChecked()
        {
            return _checked;
        }
        public void setChecked(bool Checked)
        {
            _checked = Checked;
        }
        public String getName()
        {
            return name;
        }
        public void setName(String name)
        {
            this.name = name;
        }

    }
}