using System;
using System.Collections.Generic;
using Windows.Storage;
using Windows.Foundation;
using System.Xml.Linq;
using System.IO;
using System.Linq;

namespace DailySpendingLib
{
    public class FileManager : DataManager
    {
        private StorageFile file;
        private StorageFolder localFolder;
        private readonly string fileName;

        public FileManager()
        {
            this.localFolder = ApplicationData.Current.LocalFolder;
            this.fileName = "DailySpendingData.xml";
        }

        /// <summary>
        /// Read sample data in the project
        /// </summary>
        public async void ReadSampleData(ItemData dataContains)
        {
            XDocument xmlDoc;

            this.file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///../DailySpendingLib/SampleData/SampleData.xml"));

            using (StreamReader sr = new StreamReader(await this.file.OpenStreamForReadAsync()))
            {
                xmlDoc = XDocument.Load(sr);   
            }

            IEnumerable<DataFormat> datum = from item in xmlDoc.Descendants("Record")
                                            select
                                            new DataFormat(item.Element("SpendingIncomeType").Value,
                                                item.Element("Amount").Value,
                                                item.Element("Business").Value,
                                                item.Element("SpendingCategory").Value,
                                                item.Element("AccountType").Value,
                                                item.Element("SpendingPerson").Value,
                                                item.Element("Year").Value,
                                                item.Element("Month").Value,
                                                item.Element("Day").Value);

            Item eachItem;
            Uri _baseUri = new Uri("ms-appx:///");

            foreach (DataFormat da in datum)
            {
                eachItem = new Item();
                eachItem.Title = da.SpendingCategory;
                eachItem.Subtitle = da.SpendingIncomeType;
                //item.SetImage(_baseUri, "SampleData/Images/60Mail01.png");
                eachItem.Content = da.SpendingPerson;
                dataContains.Collection.Add(eachItem);
            }
        }

        public async void ReadXMLFile()
        {
            XDocument xmlDoc;

            if (this.localFolder == null)
                return;

            this.file = await localFolder.GetFileAsync(this.fileName);
            
            using (StreamReader sr = new StreamReader(await this.file.OpenStreamForReadAsync()))
            {
                xmlDoc = XDocument.Load(sr);
            }
            
            XElement xmlTree = new XElement("Root",
                new XAttribute("Att1", "AttributeContent"),
                new XElement("Child",
                    new XText("Some text"),
                    new XElement("GrandChild", "element content")
                )
            );
            IEnumerable<XElement> de =
                from el in xmlTree.Descendants("Child")
                select el;

            XName tmp;
            foreach (XElement el in de)
            {
                tmp = el.Name;
            }

        }
        public async void CreateNewFile()
        {
            if (this.file == null)
            {
                this.file = await this.localFolder.CreateFileAsync(this.fileName);

                await Windows.Storage.FileIO.WriteTextAsync(this.file, "Hello");
            }
        }


        public class ItemData
        {
            
            private ItemCollection _Collection = new ItemCollection();

            public ItemCollection Collection
            {
                get
                {
                    return this._Collection;
                }
            }
        }
        
    }
}
