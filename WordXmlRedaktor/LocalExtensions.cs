/*
 * Сделано в SharpDevelop.
 * Пользователь: suvoroda
 * Дата: 14.06.2016
 * Время: 12:34
 */
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace WordXmlRedaktor
{
	/// <summary>
	/// Description of LocalExtensions.
	/// </summary>
	public static class LocalExtensions
	{
		public static string StringConcatenate(this IEnumerable<string> source)
	    {
	        StringBuilder sb = new StringBuilder();
	        foreach (string s in source)
	            sb.Append(s);
	        return sb.ToString();
	    }
	
	    public static string StringConcatenate<T>(this IEnumerable<T> source,
	        Func<T, string> func)
	    {
	        StringBuilder sb = new StringBuilder();
	        foreach (T item in source)
	            sb.Append(func(item));
	        return sb.ToString();
	    }
	
	    public static string StringConcatenate(this IEnumerable<string> source, string separator)
	    {
	        StringBuilder sb = new StringBuilder();
	        foreach (string s in source)
	            sb.Append(s).Append(separator);
	        return sb.ToString();
	    }
	
	    public static string StringConcatenate<T>(this IEnumerable<T> source,
	        Func<T, string> func, string separator)
	    {
	        StringBuilder sb = new StringBuilder();
	        foreach (T item in source)
	            sb.Append(func(item)).Append(separator);
	        return sb.ToString();
	    }
	}
}
