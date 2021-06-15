
1. Added the nuget package Microsoft.EntityFrameworkCore

2. Added the nuget package Microsoft.EntityFrameworkCore.Tools

3. Added the nuget package Microsoft.EntityFrameworkCore.SqlServer

4. Added the nuget package Microsoft.EntityFrameworkCore.SqlServer.Design

5. Open Package Manager Console 

6. Scaffold-DbContext "Server=(localdb)\mssqllocaldb;Database=DatabaseName;Trusted_Connection=True;"  
     -Provider Microsoft.EntityFrameworkCore.SqlServer 
     -OutputDir Models -Context NorthwndContext