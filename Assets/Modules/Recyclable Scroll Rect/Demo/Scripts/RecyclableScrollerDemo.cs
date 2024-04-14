using System.Collections.Generic;
using UnityEngine;
using PolyAndCode.UI;
using UnityEngine.Serialization;

namespace PolyAndCode.Examples
{
    /// <summary>
    /// Demo controller class for Recyclable Scroll Rect. 
    /// A controller class is responsible for providing the scroll rect with datasource. Any class can be a controller class. 
    /// The only requirement is to inherit from IRecyclableScrollRectDataSource and implement the interface methods
    /// </summary>

//Dummy Data model for demostraion
    public struct ContactInfo
    {
        public string Name;
        public string Gender;
        public string id;
    }

    public class RecyclableScrollerDemo : MonoBehaviour, IDataAdapter<DemoCell>
    {
        [FormerlySerializedAs("_recyclableScrollRect")]
        [SerializeField]
        RecyclableScrollRect recyclableScrollList;

        DemoCell IDataAdapter<DemoCell>.ViewPrefab
        {
            get { return this.viewPrefab; }
        }
        
        [SerializeField]
        private DemoCell viewPrefab;

        [SerializeField]
        private int _dataLength;

        //Dummy data List
        private List<ContactInfo> _contactList = new List<ContactInfo>();

        //Recyclable scroll rect's data source must be assigned in Awake.
        private void Awake()
        {
            InitData();
            recyclableScrollList.Initialize(this);
        }

        //Initialising _contactList with dummy data 
        private void InitData()
        {
            if (_contactList != null) _contactList.Clear();

            string[] genders = {"Male", "Female"};
            for (int i = 0; i < _dataLength; i++)
            {
                ContactInfo obj = new ContactInfo();
                obj.Name = i + "_Name";
                obj.Gender = genders[Random.Range(0, 2)];
                obj.id = "item : " + i;
                _contactList.Add(obj);
            }
        }

        public int DataCount
        {
            get { return _contactList.Count; }
        }


        void IDataAdapter<DemoCell>.OnAttachItem(DemoCell view, int index)
        {
            view.ConfigureCell(_contactList[index], index);
        }
    }
}