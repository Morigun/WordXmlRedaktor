/*
 * Сделано в SharpDevelop.
 * Пользователь: suvoroda
 * Дата: 14.06.2016
 * Время: 12:32
 */
using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.IO.Packaging;
using System.Xml;
using System.Xml.Linq;

namespace WordXmlRedaktor
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		Package wdPackage;
		XDocument xDoc;
		PackagePart documentPart;
		public string sSerchWord = "";
		public int iSelTex = -1;
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		public static string ParagraphText(XElement e)
	    {
	        XNamespace w = e.Name.Namespace;
	        return e
	        	.Elements()
	            /*   .Elements(w + "r")
	               .Elements(w + "t")*/
	               .StringConcatenate(element => (string)element);
	    }
		
		void Button1Click(object sender, EventArgs e)
		{
			CloseWord();
			if(openFileDialog1.ShowDialog() == DialogResult.OK){
				string fileName = openFileDialog1.FileName;
				const string documentRelationshipType =
		          "http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument";
		        const string stylesRelationshipType =
		          "http://schemas.openxmlformats.org/officeDocument/2006/relationships/styles";
		        const string wordmlNamespace =
		          "http://schemas.openxmlformats.org/wordprocessingml/2006/main";
		        XNamespace w = wordmlNamespace;
		        wdPackage = Package.Open(fileName, FileMode.Open,FileAccess.ReadWrite);
		        PackageRelationship docPackageRelationship =
		        	wdPackage.GetRelationshipsByType(documentRelationshipType).FirstOrDefault();
	            if (docPackageRelationship != null)
	            {
	            	Uri documentUri = PackUriHelper.ResolvePartUri(new Uri("/", UriKind.Relative),
	                  docPackageRelationship.TargetUri);
	                documentPart = wdPackage.GetPart(documentUri);
	                
	                //  Load the document XML in the part into an XDocument instance.
	                xDoc = XDocument.Load(XmlReader.Create(documentPart.GetStream()));
	
	                //  Find the styles part. There will only be one.
	                PackageRelationship styleRelation =
	                	documentPart.GetRelationshipsByType(stylesRelationshipType).FirstOrDefault();
	                PackagePart stylePart = null;
	                XDocument styleDoc = null;
	
	                if (styleRelation != null)
	                {
	                    Uri styleUri = PackUriHelper.ResolvePartUri(documentUri, styleRelation.TargetUri);
	                    stylePart = wdPackage.GetPart(styleUri);
	
	                    //  Load the style XML in the part into an XDocument instance.
	                    styleDoc = XDocument.Load(XmlReader.Create(stylePart.GetStream()));
	                }
	                
	                richTextBox1.Text = xDoc.ToString();
	                SaveButton.Enabled = true;
	                GoToErrorTagButton.Enabled = true;
	            }	            
			}
		}
		
		void Button2Click(object sender, EventArgs e)
		{			
            xDoc = XDocument.Parse(richTextBox1.Text);
			using (XmlWriter xw = XmlWriter.Create(documentPart.GetStream(FileMode.Create, FileAccess.Write)))
            {
            	xDoc.Save(xw);
            	xDoc = null;
            }
			wdPackage.Close();
			documentPart = null;
			richTextBox1.Text = "";
			SaveButton.Enabled = false;
	        GoToErrorTagButton.Enabled = false;
		}
		
		void GoToErrorTagButtonClick(object sender, EventArgs e)
		{
			SearchNext("<w:instrText>DOCVARIABLE</w:instrText>");
		}
		
		public void SearchNext(string Findtext)
		{
			string searchWord = Findtext;
			int index = 0;
			if (richTextBox1.Text.Length != 0)
			{
				if (searchWord.Length != 0)
				{
					if (sSerchWord.Length == 0)
					{
						index = richTextBox1.Find(searchWord.ToUpper(), index, RichTextBoxFinds.NoHighlight);
						iSelTex = index;
						if(index >= 0){
							richTextBox1.Select(index,searchWord.Length);
							richTextBox1.Focus();
							sSerchWord = searchWord;
						}
					}
					else if (sSerchWord == searchWord)
					{
						index = richTextBox1.Find(searchWord.ToUpper(), iSelTex+sSerchWord.Length, RichTextBoxFinds.NoHighlight);
						if (index != -1)
						{
							iSelTex = index;
							richTextBox1.Select(index,searchWord.Length);
							richTextBox1.Focus();
						}
						else
						{
							index = richTextBox1.Find(searchWord.ToUpper(), 0, RichTextBoxFinds.NoHighlight);
							iSelTex = index;
							if(index != -1)
								richTextBox1.Select(index,searchWord.Length);
							richTextBox1.Focus();
						}
					}
					else
					{
						sSerchWord = "";
						SearchNext(Findtext);
					}
				}
				else
					MessageBox.Show("Введите слово для поиска!");
			}
		}
		
		void CloseFileButtonClick(object sender, EventArgs e)
		{
			CloseWord();
		}
		
		void CloseWord(){
			if(wdPackage != null)
				wdPackage.Close();
			wdPackage = null;
			documentPart = null;
			richTextBox1.Text = "";
			SaveButton.Enabled = false;
	        GoToErrorTagButton.Enabled = false;
		}
		
		void MainFormFormClosed(object sender, FormClosedEventArgs e)
		{
			CloseWord();
		}
		
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			CloseWord();
		}
		
		void ExitButtonClick(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
