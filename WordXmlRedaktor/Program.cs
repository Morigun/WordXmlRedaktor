/*
 * Сделано в SharpDevelop.
 * Пользователь: suvoroda
 * Дата: 14.06.2016
 * Время: 12:32
 */
using System;
using System.Windows.Forms;

namespace WordXmlRedaktor
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
		
	}
}
