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
        public async void ReadSampleData()
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

            foreach (DataFormat item in datum)
            { 
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

            //IEnumerable<DataFormat> datum = from item in xmlDoc.Descendants("Flag")
            //                                  select
            //                                  new DataFormat(item.Element("SpendingIncomeType").Value, 
            //                                      item.Element("SpendingCategory").Value, 
            //                                      item.Element("AccountType").Value,
            //                                      item.Element("SpendingPerson").Value);

            //string tm = "";
            //foreach (DataFormat abc in datum)
            //{
            //    tm = "";
                
 
            //}

            
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

            //IEnumerable<DataFormat> datum = from item in xmlDoc.Descendants("Flag")
            //    select new DataFormat(item.Element("SpendingIncomeType").Value,
            //        item.Element("SpendingCategory").Value,
            //        item.Element("AccountType").Value,
            //        item.Element("SpendingPerson").Value);


            //string result = await Windows.Storage.FileIO.ReadTextAsync(this.file);
            //StorageFile.GetFileFromPathAsync(this.installedLocation.Path    
            //this.file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///DailySpendingData.xml"));

 
//XDocument xmlDoc = XDocument.Load("Flags Of Egypt.xml");
//IEnumerable<Flag> flags = from item in xmlDoc.Descendants("Flag")
// select
// new Flag(item.Element("FlagImage").Value,
// item.Element("FlagTitle").Value,
// item.Element("FlagDescription").Value);


            //XElement xmlTree = new XElement("Root",
            //        new XAttribute("Att1", "AttributeContent"),
            //        new XElement("Child",
            //            new XText("Some text"),
            //            new XElement("GrandChild", "element content"),
            //            new XElement("Child",
            //                new XText("Ltext"),
            //                new XElement("LGrandChild", "Lelement content"))
            //        )                    
            //    );

            //IEnumerable<XElement> de =
            //    from ela in xmlTree.Descendants("Child") select ela;


            //string temp;
            //foreach (XElement el in de)
            //{
            //    temp = el.Name.ToString();

            //}

        }
        public async void CreateNewFile()
        {
            if (this.file == null)
            {
                this.file = await this.localFolder.CreateFileAsync(this.fileName);

                await Windows.Storage.FileIO.WriteTextAsync(this.file, "Hello");
            }
        }
        
    }
}
