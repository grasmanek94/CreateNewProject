using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Resources;

namespace CreateNewProject
{
	class Program
	{
		static void Main(string[] args)
		{
			bool good = false;

			string currentPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

			string projectName = "";			
			string projectPath = "";

			while (!good)
			{
				Console.WriteLine("New Project Name:");
				projectName = Console.ReadLine().Replace(" ", "").Replace("\t", "");			
				try
				{
					projectPath = currentPath + "\\" + projectName + "\\";
					Directory.CreateDirectory(projectPath);
					good = true;
				}
				catch (Exception ex)
				{
					Console.WriteLine("Invalid Project Name: " + ex.Message);
				}
			}


			try
			{
				File.WriteAllText(projectPath + "CompileLinkAndUpload.bat", CreateNewProject.Properties.Resources.CompileLinkAndUpload);
				File.WriteAllText(projectPath + "makefile", CreateNewProject.Properties.Resources.makefile);
				File.WriteAllText(projectPath + projectName + ".c", CreateNewProject.Properties.Resources.Source.Replace("<PROJECTNAME>", projectName));
				File.WriteAllText(projectPath + projectName + ".h", CreateNewProject.Properties.Resources.Header.Replace("<PROJECTNAME>", projectName));
				File.WriteAllText(projectPath + projectName + ".sln", CreateNewProject.Properties.Resources.Solution.Replace("<PROJECTNAME>", projectName));
				File.WriteAllText(projectPath + projectName + ".vcxproj", CreateNewProject.Properties.Resources.Project.Replace("<PROJECTNAME>", projectName));
				File.WriteAllText(projectPath + projectName + ".vcxproj.filters", CreateNewProject.Properties.Resources.Filters.Replace("<PROJECTNAME>", projectName));
			}
			catch (Exception ex)
			{
				Console.WriteLine("Project Creation Failed with message: " + ex.Message);
			}
		}
	}
}
