# Northwind-MVVM-Survival-Guide
This is the code for the Northwind application that was created during the studying of "MVVM Survival Guide for Enterprise Architecture in Silverlight and WPF", therefore I do not own the rights to this and am using it as a reference.

To Run the code in visual studio you'll need to update the App.Configs in projects "Northwind.Data" and "Northwind.Service", in the connectionstring, to point to the local NORTHWIND.MDF file:

connectionString="metadata=res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl;provider=System.Data.SqlClient;provider connection string=&quot;Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=\[Insert your folder path here\]\NORTHWND.MDF;Integrated Security=True;multipleactiveresultsets=True;App=EntityFramework&quot;" 

