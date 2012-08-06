﻿using System;
using System.IO;

namespace AppHarbor
{
	public class ConsoleProgressBar
	{
		private readonly TextWriter _writer;

		public ConsoleProgressBar(TextWriter writer)
		{
			_writer = writer;
		}

		public void Render(double percentage, char progressBarCharacter, ConsoleColor color, string message)
		{
			ConsoleColor originalColor = Console.ForegroundColor;
			Console.CursorLeft = 0;

			try
			{
				Console.CursorVisible = false;
				Console.ForegroundColor = color;

				int width = Console.WindowWidth - 1;
				int newWidth = (int)((width * percentage) / 100d);
				string progressBar = string.Empty
					.PadRight(newWidth, progressBarCharacter)
					.PadRight(width - newWidth, ' ');

				_writer.Write(progressBar);
				message = message ?? string.Empty;

				try
				{
					Console.CursorTop++;
				}
				catch (ArgumentOutOfRangeException)
				{
				}

				OverwriteConsoleMessage(message);
				Console.CursorTop--;
			}
			finally
			{
				Console.ForegroundColor = originalColor;
				Console.CursorVisible = true;
			}
		}

		private void OverwriteConsoleMessage(string message)
		{
			Console.CursorLeft = 0;
			int maxCharacterWidth = Console.WindowWidth - 1;
			if (message.Length > maxCharacterWidth)
			{
				message = message.Substring(0, maxCharacterWidth - 3) + "...";
			}
			message = message + new string(' ', maxCharacterWidth - message.Length);
			_writer.Write(message);
		}
	}
}
