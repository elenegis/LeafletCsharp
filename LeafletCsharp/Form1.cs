﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MSHTML;


namespace LeafletCsharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HtmlElement head = webBrowser1.Document.GetElementsByTagName("head")[0];
            HtmlElement scriptEl = webBrowser1.Document.CreateElement("script");
            IHTMLScriptElement element = (IHTMLScriptElement)scriptEl.DomElement;
            element.text = "var mymarker; function addPoints() { mymarker = new L.marker([36.104743, -106.629925]); map.addLayer(mymarker); mymarker.bindPopup('HELLO <br>Added By C#.'); }";
            head.AppendChild(scriptEl);
            webBrowser1.Document.InvokeScript("addPoints");
            button2.Enabled = true;
            button1.Enabled = false;


            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HtmlElement head = webBrowser1.Document.GetElementsByTagName("head")[0];
            HtmlElement scriptEl = webBrowser1.Document.CreateElement("script");
            IHTMLScriptElement element = (IHTMLScriptElement)scriptEl.DomElement;
            element.text = "function removePoints() { map.removeLayer(mymarker); }";
            head.AppendChild(scriptEl);
            webBrowser1.Document.InvokeScript("removePoints");
            button1.Enabled = true;
            button2.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowPrintDialog();
        }
    }
}
