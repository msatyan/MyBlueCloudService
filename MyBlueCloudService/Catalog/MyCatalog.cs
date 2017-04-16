using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.IO;

using System.Reflection;
using System.Resources;


namespace MyBlueCloudService
{

    public class MyCatalog
    {
        MyCatalog()
        {

        }

        static bool init = false;
        private static System.Object lockThis = new System.Object();

        private static string CatalogJson = @"{
          'Name': 'This is a faulty Catalog',
          'Reason': 'Catalog may not have loaded from resource, rectify this problem'
        }";


        public static string Catalog
        {
            get
            {
                if ( !init )
                {
                    LoadCatalog();
                }

                return CatalogJson;
            }
        }

        private static void LoadCatalog()
        {
            lock (lockThis)
            {
                if (!init)
                {
                    // We created Embed Resources for MyBlueCatalog.json
                    // Right-click on the MyBlueCatalog.json
                    // In the Properties dialog box, locate the Build Action property. 
                    // By default, this property is set to Content. 
                    // Click the property and change the Build Action property to Embedded Resource.
                    // https://support.microsoft.com/en-us/help/319292/how-to-embed-and-access-resources-by-using-visual-c

                    try
                    {
                        Assembly assem = System.Reflection.Assembly.GetEntryAssembly();
                        var fs = assem.GetManifestResourceStream("MyBlueCloudService.Catalog.MyBlueCatalog.json");

                        StringBuilder sb = new StringBuilder("");
                        using (StreamReader sr = new StreamReader(fs))
                        {
                            string line;
                            while ((line = sr.ReadLine()) != null)
                            {
                                sb.Append(line);
                            }
                        }

                        CatalogJson = sb.ToString();

                        init = true;
                    }
                    catch(Exception)
                    {
                        // TODO
                        // Do some loging here
                    }
                }
            }
        }

        private static bool xLoadCatalog()
        {
            bool rc = false;
            lock (lockThis)
            {
                if (!init)
                {
                    StringBuilder sb = new StringBuilder("");
                    String filename = @"C:\Work0\MyBlueCloudService\MyBlueCloudService\Catalog\MyBlueCatalog.json";

                    FileStream fileStream = new FileStream(filename, FileMode.Open);
                    using (StreamReader sr = new StreamReader(fileStream))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            sb.Append(line);
                        }
                    }

                    CatalogJson = sb.ToString();

                    init = true;
                    rc = true;
                }
            }

            return (rc);
        }
    }
}
