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
using static Android.Views.View;

namespace XamarinChekBoxTree
{
    public class ExpandableListViewAdapter
    {

        private Context context;
        private List<string> listGroup;
        private Dictionary<string, List<ChildItemSample>> listChild;
        private int checkedBoxesCount;
        private bool[] checkedGroup;

        public ExpandableListViewAdapter(Context context, List<string> listGroup, Dictionary<string, List<ChildItemSample>> listChild)
        {
            this.context = context;
            this.listGroup = listGroup;
            this.listChild = listChild;
            checkedBoxesCount = 0;
            checkedGroup = new bool[listGroup.Count];
        }


        public int GroupCount { get { return listGroup.Count; } }

        public bool HasStableIds { get { return false; } }

        public ChildItemSample GetChild(int groupPosition, int childPosition)
        {

            var gr = listChild[listGroup[groupPosition]][childPosition];
            return gr;

        }



        public long GetChildId(int groupPosition, int childPosition)
        {
            return childPosition;
        }

        public int GetChildrenCount(int groupPosition)
        {
            return listChild[listGroup[groupPosition]].Count;
        }

       

        public string GetGroup(int groupPosition)
        {
            //throw new NotImplementedException();
            return listGroup[groupPosition];
        }

        public long GetGroupId(int groupPosition)
        {
            return groupPosition;
        }

        public View GetGroupView(int groupPosition, bool isExpanded, View convertView, ViewGroup parent)
        {
            string itemGroup = GetGroup(groupPosition);
            GroupViewHolder groupViewHolder;
            if (convertView == null)
            {
                LayoutInflater inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
                convertView = inflater.Inflate(Resource.Layout.expanded_list_group, null);

                groupViewHolder = new GroupViewHolder();
                groupViewHolder.tvGroup = (TextView)convertView.FindViewById(Resource.Id.tv_group);
                groupViewHolder.cbGroup = (CheckBox)convertView.FindViewById(Resource.Id.cb_group);

                groupViewHolder.cbGroup.Click += CbGroup_Click;



            }

            return convertView;
        }

        private void CbGroup_Click(object sender, EventArgs e)
        {
            var view = (View)sender;
            int pos = (int)view.Tag;
            checkedGroup[pos] = !checkedGroup[pos];
            //for (ChildItemSample item : listChild.get(listGroup.get(pos)))
            //{
            //    item.setChecked(checkedGroup[pos]);
            //}
            
        }

        public View GetChildView(int groupPosition, int childPosition, bool isLastChild, View convertView, ViewGroup parent)
        {
            ChildItemSample expandedListText = GetChild(groupPosition, childPosition);
            ChildViewHolder childViewHolder;
            if (convertView == null)
            {

            }

            return convertView;
        }

        public bool IsChildSelectable(int groupPosition, int childPosition)
        {
            throw new NotImplementedException();
        }





        private class GroupViewHolder
        {
            public CheckBox cbGroup;
            public TextView tvGroup;
        }

        private class ChildViewHolder
        {
            CheckBox cbChild;
            TextView tvChild;
        }
    }
}