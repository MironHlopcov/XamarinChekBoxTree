using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.FloatingActionButton;
using Google.Android.Material.Snackbar;
using System.Collections.Generic;
using Android.Widget;
using Toolbar = AndroidX.AppCompat.Widget.Toolbar;
using Java.Interop;

namespace XamarinChekBoxTree
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {


        Button clearChecks;
        ExpandableListView mExpandableListView;
        ExpandableListViewAdapter mExpandableListAdapter;
        int mLastExpandedPosition = -1;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;


            mExpandableListView = (ExpandableListView)FindViewById(Resource.Id.expandedListView);
            clearChecks = (Button)FindViewById(Resource.Id.btnClearChecks);

            List<String> listTitle = genGroupList();
            mExpandableListAdapter = new ExpandableListViewAdapter(this, listTitle, genChildList(listTitle));
            mExpandableListView.Adapter = (IListAdapter)mExpandableListAdapter;

            mExpandableListView.SetOnGroupExpandListener(new ExpandableListView.IOnGroupExpandListener { }
        
    }
        public class MExpandableListAdapter : ExpandableListView.IOnGroupExpandListener
        {
            ba
            public void OnGroupExpand(int groupPosition)
            {
                
            }
        }





        private List<string> genGroupList()
        {
            List<string> listGroup = new List<string>();
            for (int i = 1; i < 10; i++)
            {
                listGroup.Add("Group: " + i);
            }
            return listGroup;
        }
        private Dictionary<String, List<ChildItemSample>> genChildList(List<String> header)
        {
            Dictionary<String, List<ChildItemSample>> listChild = new Dictionary<string, List<ChildItemSample>>();
            Random rnd = new Random();
            for (int i = 0; i < header.Count; i++)
            {
                List<ChildItemSample> testDataList = new List<ChildItemSample>();
                int a = (int)(rnd.Next() * 8);
                for (int j = 0; j < a; j++)
                {
                    ChildItemSample testItem = new ChildItemSample("Child " + (j + 1));
                    testDataList.Add(testItem);
                }
                listChild.Add(header[i], testDataList);
            }
            return listChild;
        }






























        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (View.IOnClickListener)null).Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
	}
}
