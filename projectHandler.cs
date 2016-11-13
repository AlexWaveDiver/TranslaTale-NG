using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace TranslaTale_NG
{

    /**
     * TTProject - TranslaTale Project definition
     * 
     * (TTP - TT Project - XML)
     * (TTPX - TT Consolidated Project - ZIP)
     * 
     * @param  filePath  an absolute URI giving the base location of the project file
     * @return TTProject TranslaTale Project object
     */
    public class TTProject
    {
        public string Path { get; set; }
        public string WorkingPath { get; set; }
        public bool ProjConsolidated { get; set; }
        public bool Err { get; set; }
        public XDocument Properties { get; set; }

        public TTProject(string filePath, string prPath, bool prCons, bool Error, XDocument xml)
        {
            Path = filePath;
            WorkingPath = prPath;
            ProjConsolidated = prCons;
            Error = Err;
            Properties = xml;
        }
    }
    public class TTProjectProperties
    {
        public string prjName { get; set; }
        public DateTime lastSaved { get; set; }
        public string utFontsPath { get; set; }
        public string baseText { get; set; }
        public string transText { get; set; }
        public string gfxPath { get; set; }

        public TTProjectProperties(string projectName, DateTime saveDate, string utfPath, string baseTxt, string translationTxt, string graphPath)
        {
            prjName = projectName;
            lastSaved = saveDate;
            utFontsPath = utfPath;
            baseText = baseTxt;
            transText = translationTxt;
            gfxPath = graphPath;
        }
    }
    public class projectHandler
    {
        /**
         * Project loading routine. It checks for the file format and tries to open it
         * according to the file and TTProject object specifications.
         * 
         * (TTP - TT Project - XML)
         * (TTPX - TT Consolidated Project - ZIP)
         * 
         * @param  filePath  an absolute URI giving the base location of the project file
         * @return TTProject TranslaTale Project object
         */

        public static TTProject loadProject(string filePath, bool errorMsgs = true)
        {
            byte[] buffer = new byte[2];
            XDocument xd1 = new XDocument();

            TTProject project = new TTProject("", "", false, false, xd1);

            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    fs.Read(buffer, 0, buffer.Length);
                    fs.Close();

                    if (System.Text.Encoding.UTF8.GetString(buffer) == "<?") // if XML
                    {
                        try
                        {
                            project.Path = filePath;
                            project.WorkingPath = filePath;
                            project.ProjConsolidated = false;
                            project.Err = false;
                            project.Properties = XDocument.Load(filePath); // XML OK
                            return project;
                        }
                        catch (XmlException xex)
                        {
                            if (errorMsgs == true)
                            {
                                MessageBox.Show("The chosen file is not a valid TranslaTale project", "Error loading project", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            project.Path = "";
                            project.WorkingPath = "";
                            project.ProjConsolidated = false;
                            project.Err = true;
                            project.Properties = new XDocument();
                            return project;
                        }
                    }
                    else if (System.Text.Encoding.UTF8.GetString(buffer) == "PK") // if ZIP
                    {
                        try
                        {
                            if (ZipFile.CheckZip(filePath) == true) // ZIP OK
                            {
                                try
                                {
                                string tmpFolder = ExtractFileToDirectory(filePath);
                                    Process.Start(tmpFolder);
                                    project.Path = filePath;
                                    project.WorkingPath = Path.Combine(tmpFolder, @"project.ttp");
                                    project.ProjConsolidated = true;
                                    project.Err = false;
                                    project.Properties = XDocument.Load(Path.Combine(tmpFolder, @"project.ttp")); // XML OK
                                    return project;
                                }
                                catch (XmlException xex)
                                {
                                    if (errorMsgs == true)
                                    {
                                        MessageBox.Show("The chosen file is not a valid TranslaTale project", "Error loading project", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                    project.Path = "";
                                    project.WorkingPath = "";
                                    project.ProjConsolidated = true;
                                    project.Err = true;
                                    project.Properties = new XDocument();
                                    return project;
                                }
                            }
                            else // Malformed ZIP 
                            {
                                if (errorMsgs == true)
                                {
                                    MessageBox.Show("The chosen file is not a valid TranslaTale project", "Error loading project", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                project.Path = "";
                                project.WorkingPath = "";
                                project.ProjConsolidated = true;
                                project.Err = true;
                                project.Properties = new XDocument();
                                return project;
                            }
                        }
                        catch (ZipException zex) // Malformed ZIP 
                        {
                            if (errorMsgs == true)
                            {
                                MessageBox.Show("The chosen file is not a valid TranslaTale project", "Error loading project", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            project.Path = "";
                            project.WorkingPath = "";
                            project.ProjConsolidated = true;
                            project.Err = true;
                            project.Properties = new XDocument();
                            return project;
                        }
                    }
                    else
                    {   // Not recognised
                        if (errorMsgs == true)
                        {
                            MessageBox.Show("The chosen file is not a valid TranslaTale project", "Error loading project", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        project.Path = "";
                        project.WorkingPath = "";
                        project.ProjConsolidated = false;
                        project.Err = true;
                        project.Properties = new XDocument();
                        return project;
                    }
                }
            }
            catch (System.UnauthorizedAccessException fex)
            {   // Not readable
                if (errorMsgs == true)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + fex.Message, "Error loading project", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                project.Path = "";
                project.WorkingPath = "";
                project.ProjConsolidated = false;
                project.Err = true;
                project.Properties = new XDocument();
                return project;
            }
        }

        /**
         * Project unpacking routine, creates a temporal folder and unpacks the TTPX on it
         * 
         * @param  zipFileName  an absolute URI giving the base location of the consolidated project file
         * @return string temporary directory
         */
        public static string ExtractFileToDirectory(string zipFileName)
        {
            string tempDirectory = Path.Combine(Path.GetTempPath(), "TranslaTale", Path.GetRandomFileName());
            Directory.CreateDirectory(tempDirectory);
            ZipFile zip = ZipFile.Read(zipFileName);

            foreach (ZipEntry e in zip)
            {
                e.Extract(tempDirectory, ExtractExistingFileAction.OverwriteSilently);
            }
            return tempDirectory;
        }

        /**
         * Temporary Projects iterator
         * 
         * @return object projects
         */
        public static object getTempProjects()
        {
            string[] projectPaths = Directory.GetDirectories(Path.Combine(Path.GetTempPath(), "TranslaTale"));

            List<TTProject> projects = new List<TTProject>();

            foreach (string project in projectPaths)
            {
                try
                {
                    projects.Add(loadProject(Path.Combine(project, @"project.ttp"), false));
                }
                catch (Exception ttpexc)
                {
                    // 
                }
            }

            return projects;
        }

        /**
         * Get Project Properties
         * 
         * @param  xmlProperties Project XML Document
         * @return TTProjectProperties object
         */
        public static TTProjectProperties getProjectProperties(XDocument xmlProperties)
        {
            TTProjectProperties projectProperties = new TTProjectProperties("", new DateTime(), "", "","","");

            projectProperties.prjName = xmlProperties.Descendants().Where(a => a.Name.LocalName == "prjName").FirstOrDefault().Value;
            projectProperties.lastSaved = DateTime.ParseExact(xmlProperties.Descendants().Where(a => a.Name.LocalName == "lastSaved").FirstOrDefault().Value, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            projectProperties.utFontsPath = xmlProperties.Descendants().Where(a => a.Name.LocalName == "utfonts").FirstOrDefault().Value;
            projectProperties.baseText = xmlProperties.Descendants().Where(a => a.Name.LocalName == "basetxt").FirstOrDefault().Value;
            projectProperties.transText = xmlProperties.Descendants().Where(a => a.Name.LocalName == "translationtxt").FirstOrDefault().Value;
            projectProperties.gfxPath = xmlProperties.Descendants().Where(a => a.Name.LocalName == "gfx").FirstOrDefault().Value;

            return projectProperties;

        }
        /* TODO */



        /**
         * Recent projects
         * 
         * @return object projects
         */
        public static void getRecentProjects()
        {

        }

        /**
         * Project checking routine
         * 
         * @param  filePath  an absolute URI giving the base location of the project file
         * @return bool valid project
         */
        public static void checkProject(string filePath)
        {

        }

        /**
         * Project saving / packing routine
         * 
         * @param  filePath     an absolute URI giving the base location of the project file
         * @param  utFonts      an absolute URI giving the base location of the UTFonts file
         * @param  baseFile     an absolute URI giving the base location of the base strings file
         * @param  transFile    an absolute URI giving the base location of the translation file
         * @param  gfxPath      an absolute URI giving the base location of the GFX folder
         * @param  consolidate  TTP (false) or TTPX -consolidated- project (true)
         * @return bool saving status
         */
        public static void saveProject(string filePath, string utFonts, string baseFile, string transFile, string gfxPath, bool consolidate = false)
        {

        }
    }
}