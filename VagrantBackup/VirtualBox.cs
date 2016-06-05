using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.Tar;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Xml.XPath;

namespace VagrantBackup
{
    class VirtualBox
    {
        protected string _vboxManagePath;
        protected string _tempPath;

        protected string _importedUUID;

        public string ImportedUUID {
            get {
                return _importedUUID;
            }
        }

        public VirtualBox(string vboxManagePath, string tempPath)
        {
            _vboxManagePath = vboxManagePath;
            _tempPath = tempPath;
        }


        public string GetBoxName(string ovfPath)
        {
            XPathDocument doc = new XPathDocument(ovfPath);
            XPathNavigator xpn = doc.CreateNavigator();

            XPathNodeIterator iter = xpn.SelectChildren(XPathNodeType.Element);
            iter.MoveNext();
            iter = iter.Current.SelectChildren(XPathNodeType.Element);

            while (iter.MoveNext()) {
                if (iter.Current.Name == "VirtualSystem") {
                    return iter.Current.GetAttribute("id", iter.Current.GetNamespace("ovf"));
                }

            }

            return null;
        }

        protected string GetBoxUUID(string boxName)
        {
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = _vboxManagePath;
            p.StartInfo.Arguments = "list vms";
            p.StartInfo.CreateNoWindow = true;

            p.Start();
            p.WaitForExit();

            string results = p.StandardOutput.ReadToEnd();
            Regex expression = new Regex(@"""(.+?)\"" \{(.+?)\}");

            MatchCollection matches = expression.Matches(results);

            foreach(Match m in matches) {
                if (m.Groups[1].Value == boxName) {
                    return m.Groups[2].Value;
                }
            }

            return "";
        }

        public void ImportBox()
        {
            string boxName = GetBoxName(Path.Combine(_tempPath, "box.ovf"));

            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = _vboxManagePath;
            p.StartInfo.Arguments = "import \"box.ovf\"";
            p.StartInfo.WorkingDirectory = _tempPath;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            p.WaitForExit();


            _importedUUID = GetBoxUUID(boxName);
        }
    }
}
