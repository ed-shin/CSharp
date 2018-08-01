using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Utility.Parser
{
    /// <summary>
    /// Custom XML Parser 
    /// (Not support tag's attribute)
    /// </summary>
    public class XMLParser
    {
        private string _filename;
        private string _version;
        private string _encoding;
        private TagNode _rootNode;

        public string Version { get { return _version; } }
        public string Encoding { get { return _encoding; } }
        public List<TagNode> Nodes { get { return _rootNode.Nodes; } }

        public bool Load(string file)
        {
            string text = readText(file);
            if(text != null)
            {
                _filename = file;
                _rootNode = new TagNode("root", text);

                text = System.Text.RegularExpressions.Regex.Replace(text, @"\r\n|\n|\t| ", "");
                //text = text.Replace("\n", "").Replace("\r", "").Replace(" ", "").Replace("\t", "");

                int offset = 0;
                readXmlInfo(text, ref offset);
                while (text.Length > offset)
                {
                    attachNodes(text, ref offset, _rootNode);
                }
            }

            return true;
        }

        public TagNode GetNode(string name)
        {
            TagNode node = _rootNode.FindNode(name);

            return node;
        }

        #region private
        private void attachNodes(string text, ref int offset, TagNode parent)
        {
            string s = "<";
            string e = ">";
            
            int sOffset = offset + text.Substring(offset).IndexOf(s);
            int tagLength = text.Substring(sOffset + s.Length).IndexOf(e);
            if (tagLength <= 0)
            {
                offset = sOffset + tagLength;
                return;
            }

            string name = text.Substring(sOffset + s.Length, tagLength);
            string openTag = string.Format("<{0}>", name);
            string closeTag = string.Format("</{0}>", name);
            string value = getValue(text, sOffset, openTag, closeTag);

            TagNode node = new TagNode(name, value);
            if(hasChildNode(value))
            {
                int valueOffset = 0;
                while (value.Length > valueOffset)
                {
                    attachNodes(value, ref valueOffset, node);
                }
            }

            if(parent == null)
            {
                _rootNode.Nodes.Add(node);
            }
            else
            {
                node.Parent = parent;
                parent.Nodes.Add(node);
            }

            offset = sOffset + openTag.Length + value.Length + closeTag.Length;
        }

        private bool hasChildNode(string text)
        {
            int sOffset = text.IndexOf("<");
            int eOffset = text.IndexOf(">");

            return eOffset - sOffset > 0;
        }

        private string getValue(string text, int start, string openTag, string closeTag)
        {
            int sOffset = text.Substring(start).IndexOf(openTag);
            int eOffset = text.Substring(start).IndexOf(closeTag);

            return text.Substring(start + sOffset + openTag.Length, eOffset - (sOffset + openTag.Length));
        }
        
        private void readXmlInfo(string text, ref int offset)
        {
            string s = "<?xml";
            string e = "?>";

            int sOffset = text.Substring(offset).IndexOf(s);
            int eOffset = text.Substring(sOffset).IndexOf(e);
            string xmlInfo = text.Substring(sOffset, eOffset + e.Length);

            _version = readVersion(text);
            _encoding = readEncoding(text);

            offset = eOffset;
        }

        private string readVersion(string text)
        {
            string s = "version=\"";
            string e = "\"";

            int sOffset = text.IndexOf(s);
            int length = text.Substring(sOffset + s.Length).IndexOf(e);

            return text.Substring(sOffset + s.Length, length);
        }

        private string readEncoding(string text)
        {
            string s = "encoding=\"";
            string e = "\"";

            int sOffset = text.IndexOf(s);
            int length = text.Substring(sOffset + s.Length).IndexOf(e);

            return text.Substring(sOffset + s.Length, length);
        }

        private string readText(string file)
        {
            string text = null;

            if (File.Exists(file))
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    text = sr.ReadToEnd();
                }
            }

            return text;
        }
        #endregion
    }
    
    public class TagNode
    {
        private string _name;
        private string _value;
        private List<TagNode> _nodes;

        public TagNode Parent { get; set; }
        public List<TagNode> Nodes { get { return _nodes; } }
        public string Name { get { return _name; } }
        public string Value { get { return _value; } }

        public TagNode(string name, string value)
        {
            this._name = name;
            this._value = value;
            this._nodes = new List<TagNode>();
        }
        
        public TagNode GetNode(string name)
        {
            return this.Nodes.Find(x => x.Name == name);
        }

        public IEnumerable<TagNode> GetNodes(string name)
        {
            return this.Nodes.Where(x => x.Name == name);
        }

        public bool HasNode(string name)
        {
            if (this.GetNode(name) != null)
                return true;

            return false;
        }

        public TagNode FindNode(string name)
        {
            foreach (var node in this.Nodes)
            {
                if (node.Name == name)
                    return node;

                if (node.Nodes.Count > 0)
                    return node.FindNode(name);
            }

            return null;
        }
    }
}
