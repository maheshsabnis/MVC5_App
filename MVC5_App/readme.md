Programming with ASP.NET MVC 5
1. CReating Data Access Layer using EntityFramework 6.1
	- Database First Approach
		- Database is ready with Tables, Procedures, etc.
		- Recommended approach if the Database is Production ready
	- Code First Approach
		- Entity Classes 
			- Classes containing public properties
		- Generate Database and tables based on Entity Classes
		- Recommended when the project is to be defined from scratch
	- Nuget Packages for EF
		- EntityFramework.dll
2. DbContext as Base Class of EntityFramework
	- Manage the CLR class mapping with Database Tables using DbSet<T> class
		- DbSet<T>, the class that contains IQuuryable of T
			- COntains all records from the Table T
		- T is the name of CLR class that is mapped with the db table of name T 
	- Manage the DB Transactions for Create, Update and Delete records using 
		- SaveChanges() method
	- Consider 'ctx' is an instance of DbContext and DbSet<Employee> Employees map with Employee table
	- To Read all records from Employee Table
		- var result = ctx.Employees.ToList();
	- To Read a specific record based on Primary Key
		- var result = ctx.Employee.Find(EmpNo);
	- To CReate a new Record in DbSet<Employee>
		- Create an instance of Employee
		- Set its property values
		- Add the Employee instance in DbSet

			ctx.Employees.Add(Emp);
		- Commit Transations
			ctx.SaveChanges();
	- To update record based on Primary Key
		- Search Record based on Primary Key
		- Update its property values
		- Call SaveChanges()
	- To delete record
		- Search record based on Primary Key
		- Pass the record to the sect Remove metjod of DbSet
			ctx.Employees.Remove(EMp);
		- COmmit Transactions
3. Install Dependency Injection Container for the Application
	- Unity.Mvc5
		- DI COntainer that will be used to create DI Container in application
		- It will register all Depednencies in it.
4. The App_Start folder in the Project
	- COntains classes for
		- Unity COntainers
			- UnityConfig class in UnityConfig.cs
				- RegisterComponents() method
					- Creates an instance of UnityContainer
						- This UnityContainer register all the dependencies
		- Action Filter Registrations
		- Routing COmfiguration
		- Web API Configuration
		- Security or Identity COnfiguration
		- JavaScript and CSS bundling