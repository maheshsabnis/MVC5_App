Creating Database and Tables

1. Create Database Company

2. Creating Department Table
USE [Company]
GO

/****** Object:  Table [dbo].[Department]    Script Date: 10/31/2020 4:06:27 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Department](
	[DeptNo] [int] NOT NULL,
	[DeptName] [varchar](100) NOT NULL,
	[Location] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DeptNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

3. Creating Employee Table


USE [Company]
GO

/****** Object:  Table [dbo].[Employee]    Script Date: 10/31/2020 4:07:31 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Employee](
	[EmpNo] [int] NOT NULL,
	[EmpName] [varchar](100) NOT NULL,
	[Designation] [varchar](100) NOT NULL,
	[Salary] [int] NOT NULL,
	[DeptNo] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EmpNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Employee]  WITH CHECK ADD FOREIGN KEY([DeptNo])
REFERENCES [dbo].[Department] ([DeptNo])
GO

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
===========================================================================================================
Model-View-Controller (MVC)
1. Model
	- Domain Implementation of the Application e.g. eCom / FInal / Logic / Office Automation
		- Business Workflows
		- Entity Classes
		- Data Access
	- This contains the state of the application 
		- State, the Data Manupulation
		- State, the Data Persistance
2. Controller
	- This is the Object that accepts HTTP Requests from the End-User
	- Controller is Responsible for
		- Accept request and eveluate the request (GET / POST)
			- The Route Table is Created and Maintained by MVC Application on Web Server for 
				deciding which controller and which action method from the controller is executed
		- Contains  Action Methods (?)
			- Action Methods are those methods which are executed based on HTTP GET / POST  request
		- Invoke an action method based on HTTP REquest (GET /POST)
		- COntroller Validate the Request using Authentication and Authorization
			- BAsed on the Authentication the Action methods will be executed
			- If the User Auth failed the Accces Denied / 401 response will be sent back
		- Validate the Posted data in HTTP Post request
		- Handle Exception if any exception is thrown, then respond the Error View
		- Once the Action method is successfully executed, 
			- COntroller will Update the Model aka perform Domain operations
			- COntriller will respond the View
	- MVC Controller clas is derived from  'Controller' abstract base class.
		- It implements following interfaces
			- IActionFilter
				- Interface that will provided custom action filter mechanism (?)
					- Action Filter means the additional logic that you want to executed along
						with the request e.g. The Logger
			
			- IAuthenticationFilter
				- Used to Authenticate the Request
			- IAuthorizationFilter
				- Used to verify the role of the user before processing the request
			- IDisposable
			- IExceptionFilter
				- USed to handle Exceptions while processing the request
				- Default Error Filter is already present
				- We can write custom Exception Management
			- IResultFilter
				- What result will be responded to tej end-user
			- IAsyncController, IAsyncManagerContainer
				- Asynchronous Exeuction of Action Method	
		- Porperties od Controller abstract class
			- RouteData 
				- Represent the Current Expression
			- ActionInvoker of the type IActionInvoker
				- Invoke the action based on the Route expression and upon the type of HTTP Request (GET/POST)
			- Session
				- represent the current sessiom
			- ModelState
				- Validated the Model object aka entity object passed in HTTP Requedst body while making
					HTTP POST / PUT request
			- User of the type IPrincipal
				- The Current Login user
		- The Controller  abstract base class contains method for
			- Action Execution 
				- Monitor the Action Execution
					- Validate the Model
					- Update the Model
			- Exception Raising
				- If Exception Occites then handle exception
			- Result Generation
				- Used to retirn result in response
			- Authorization
				- Verify the Request for Authentication and Authorization
	- Action Methods
		- Methods Ivoked by COntroller based on Route Expression and Request Type (GET /POST)
		- They returns Type of 'IActionResult' interface
			- This interface represents the type of result generated as response by Action method
			- MVC Action methods have following IActionResult type classes
				- ViewResult
					- Return View
				- EmptyResult
					- No Result aka void response
				- JavaScriptResult
					- Returns JavaScript to CLient
				- JsonResult
					- Respond JSON data to client
				- FilePathResult
					- return the File that wil downloaded to the client 
					- Binary Documents	
				- FileContentResult
					- File is opened on server and its contents are returned to client
					- Text based file
				- FileStreamResult
					- File is opened on server and it will stream to client e.g. Images / Videos
				- RedirectToActionResult
					- Redirect the request to other action method in Same Controller or action method in
						different controller		
				- RedirectToRouteResult
					- Redirect to different Route Expression





3. View
	- The User Interface of the Application
	- The Controller will decide which View will be send to the end-user as a response
	- ASP.NET MVC 3,4,5 has Razor Views (?)
		- Razor Veiws are Lightweight language intergated HTML pages
			- e.g. cshtml, means HTML page with C# language integrated 
	- Two Types of Views
		- Strongly Typed View
			- Accepts the Model class as input parameter to generate View with HTML elements 
			- The View knows what data to be shown
			- Two Types of Strongle Typed Views
				- Page View, executed like page
				- Partial View, executed like User Control
					- Page View can use partiel views in it
			- View Templates
				- List, accepts IENumerable of Model class to show the collection of Model data on View 
				- Create, accpet an Empty model to create new record
				- Edit, accepts a model with data to be edited
				- Delete, accept a model with data to be deleted
				- Details, accept read-only model
				- Empty, accept a model but developer can choose HTML to design view 
			- A Strongly-Typed voiew can accept "only-one model class" at a time  
				- If a Controller wants to pass additional data to view, then the 
					controller must use the ViewBag/ViewData 
				- ViewBag,is a dynamic object that is used to define a Key/Value pair
					of the additional data that controller's action method want to
					pass to view
				- ViewBag, will be typed-to the ViewDataDictionary at runtime
				- ViewBag is scopped to an action method, means once the action method completes
					its execution the 'Key' of the ViewBag will be removed, so make sure that if
					the view accepts ViewBag/ViewData, then all Action methods returning that view
					must be passed with ViewBag/ViewData
		- Empty View
			- Does not accept any data but provides facility to developer to use
				HTML elements and JavaScript
	- Concept behind the Razor View in MVC
		- The Base class for Razor view is 
			- WebViewPage<TModel>
				- TModel is the type of Model class passed to veiw while scaffolding means generating view
				- e.g. If view template is List and Model class is department then 
					TModel will be IEnumerbale<Department>
				- Properties
					- Html
						- Of the type HtmlHelper
							- HtmlHelper are custom MVC elements those are rendered into HTML elements
								by excuting on server 
					- Model of the type TModel
					-ViewData of the type ViewDataDicitonary, used pass data from controller to view 
						like ViewState



Exercise
1. Create Employee Controller with View to Perform CRUD operations (Npw)
2. Show the Department and Employee link on the Home Page (Hint _layout.cshtml page) (Now)


===========================================================================================================
Programming with MVC?
- Understaand and code as per the MVC Request Proceasing(?)
	- Validations
		- Standard Validation
		- Custom Validations
		- Async Validations
	- Filters
		- Standard Filters
		- Security Filters
		- Custom Filters
	- Security Filters
		- User Based Security
		- Role Based Security
- Working with HTTP Services using WEB APIS
	- Validations
	- Filters
	- Security

==========================================================================================================
Validations
- Data Annotations
	- System.ComponentModel.DataAnnotations
		- RequestAttribute, StringLength, KeyAttribute, etc.
	- If the View is scaffolded with the Model class having valdiation rule then the MVC will render
		the jQuery.Validate.js to the browser to execute server-side validations on the client
		This is implemented using
			- UnObstrusiveValidations
				- UnobtrusiveJavaScriptEnabled
					- Add HTML 5 validators for HTML rendered elements
			- ClientSideValaidtions
				- ClientValidationEnabled
			from Web.Config file
	- An Asynchronous Validations
		- Use the  'RemoteAttribute' on the property from entity class taht is to be validated asynchronously
		- The COntroller must have a method that return JSONResult for Async Validation.
		- This action method must acccept the property being validated asynchronously
		- The UnObstrusive JavaScript will add an AJAX call for validations on the View for
		the property being validated
		- One property of ENtity class can have only one remote validator

- Exercise 1: Implement the Async validator for validating the EmpNo as unique key.
=====================================================================================================
Action Filters
1. Global Level
	- All Controllers and all actions from them
2. Controller Level
	- All Actions of the Controle
3. Action Level
	- On;y for the specific Action

Order Of Execution

1. Global
	- OnActionExecuting
2. Controller
	- OnActionExecuting
3. Action 
	- OnActionExecuting
		- OnException
	- OnActionExecuted
	- OnResultExecuting
	- OnResultExecuted
4. Controller
    - OnActionExecuted
5. Global
	- OnActionExecuted

LAB EXERCISE : Create a Action Filter That will log Exceptions in database tabel as below
 ControllerName, ActionName, Exception Type, Exception Message. 
 When exception occures navigate to error page and show error details. This error page must have link
 for 'Go back'. Once this link is clicked, go back to the page where exception has occured
 and show what data caused exception 

===================================================================================================
Data Communication Across Components using
1. TempDataDictionary Object
	- TempData 
		- Key Value pair for sharing data across action methods of Same and different Controllers
		- TempData["Key"] =  value;
		- *** Once the reciving Action Method reads data from the 'key' of TempData
			the Key will be removed
		- If you want to keep the state in TempData, then use
			TempData.keep() method in target n action method so that state will be remained
2. Session State
	- Pure server-side mechanism, of state management















