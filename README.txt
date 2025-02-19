2025-02-19 
https://localhost:7211/
1019- create a page 
add model
add data 
add controller 


Create a Migration Data 
Update-Database
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (2ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
      VALUES (N'20250219151501_AddPerfumeTable', N'8.0.12');

      1026 Adding some seed data in my website 
      Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (2ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
      VALUES (N'20250219152627_SeedPerfumes', N'8.0.12');
Making logo as a page if you click on logo it redirect it to https://localhost:7211/Perfumes

Rebuild the project
Rebuild started at 11:02 AM...
1>------ Rebuild All started: Project: Velour Scents, Configuration: Debug Any CPU ------
Restored C:\Users\urvis\source\repos\Velour Scents\Velour Scents\Velour Scents.csproj (in 555 ms).
1>C:\Users\urvis\source\repos\Velour Scents\Velour Scents\Models\Perfume.cs(6,23,6,27): warning CS8618: Non-nullable property 'Name' must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring the property as nullable.
1>C:\Users\urvis\source\repos\Velour Scents\Velour Scents\Models\Perfume.cs(7,23,7,28): warning CS8618: Non-nullable property 'Brand' must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring the property as nullable.
1>C:\Users\urvis\source\repos\Velour Scents\Velour Scents\Models\Perfume.cs(8,23,8,37): warning CS8618: Non-nullable property 'FragranceNotes' must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring the property as nullable.
1>C:\Users\urvis\source\repos\Velour Scents\Velour Scents\Models\Perfume.cs(10,23,10,31): warning CS8618: Non-nullable property 'ImageUrl' must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring the property as nullable.
1>Velour Scents -> C:\Users\urvis\source\repos\Velour Scents\Velour Scents\bin\Debug\net8.0\Velour Scents.dll
1>Done building project "Velour Scents.csproj".
========== Rebuild All: 1 succeeded, 0 failed, 0 skipped ==========
========== Rebuild completed at 11:02 AM and took 03.163 seconds ==========

 
